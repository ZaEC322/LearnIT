using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LearnIT
{
    public partial class FormGame : Form
    {
        #region оптимизация отображения контролов

        /// <summary>
        /// Хз как работает но контролы отображаються корректно
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #endregion оптимизация отображения контролов

        #region поля

        /// <summary>
        /// лимит времени. Если не успел ответить на все вопросы то конец игры
        /// </summary>
        private int timeLimit;

        /// <summary>
        /// лист для хранения объектов класса question которые заполняем из бд
        /// </summary>
        private readonly List<Question> list_Questions = new List<Question>();

        /// <summary>
        /// лист для хранения объектов класса Choice которые заполняем из бд
        /// </summary>
        private readonly List<Choice> list_Choices = new List<Choice>();

        /// <summary>
        /// объект класса рандом.
        /// </summary>
        private readonly Random rand = new Random();

        /// <summary>
        /// id вопроса для выполнения процедуры по поиску ответов в базе.
        /// </summary>
        private int current_id;

        /// <summary>
        /// количество правильно отвеченых вопросов
        /// </summary>
        private int CorrectCounter;

        /// <summary>
        /// для хранинения рандомно выбраного индекса текущего вопроса.
        /// </summary>
        private int temp;

        /// <summary>
        /// изначальное общее кол-во вопросов.
        /// </summary>
        private int questCount;

        /// <summary>
        /// для счёта времени
        /// </summary>
        private int _ticks;

        /// <summary>
        /// Для проверки заполнился ли лист из бд. Если нет то false.
        /// </summary>
        private bool result1;

        /// <summary>
        /// Для проверки заполнился ли лист из бд. Если нет то false.
        /// </summary>
        private bool result2;

        /// <summary>
        /// переменные для проверки правильности ответа
        /// </summary>
        private readonly bool[] Is_Correct = new bool[4];

        /// <summary>
        /// если на текущий вопрос дан ответ == true, если не дан то false
        /// </summary>
        private bool Is_Answered;

        /// <summary>
        /// для комманд
        /// </summary>
        private SqlCommand cmd;

        /// <summary>
        /// подключение
        /// </summary>
        private readonly SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            Directory.EnumerateFiles(Environment.CurrentDirectory, "*.mdf", SearchOption.AllDirectories).First() + ";Integrated Security=True;Connect Timeout=30;");

        #endregion поля

        public FormGame()
        {
            InitializeComponent();
            KeyPreview = true; //для шорткатов
            DoubleBuffered = true; //чтобы окно было плавным
        }

        #region события

        #region изменения цвета текстбоксов как у кнопок

        private void Btn_Answer1_MouseEnter(object sender, EventArgs e)
        {
            btn_Answer1.Cursor = Cursors.Arrow;
            if (!Is_Answered)
            {
                btn_Answer1.BackColor = Color.FromArgb(34, 33, 94);
            }
        }

        private void Btn_Answer2_MouseEnter(object sender, EventArgs e)
        {
            btn_Answer2.Cursor = Cursors.Arrow;
            if (!Is_Answered)
            {
                btn_Answer2.BackColor = Color.FromArgb(34, 33, 94);
            }
        }

        private void Btn_Answer3_MouseEnter(object sender, EventArgs e)
        {
            btn_Answer3.Cursor = Cursors.Arrow;
            if (!Is_Answered)
            {
                btn_Answer3.BackColor = Color.FromArgb(34, 33, 94);
            }
        }

        private void Btn_Answer4_MouseEnter(object sender, EventArgs e)
        {
            btn_Answer4.Cursor = Cursors.Arrow;
            if (!Is_Answered)
            {
                btn_Answer4.BackColor = Color.FromArgb(34, 33, 94);
            }
        }

        private void Btn_Answer1_MouseLeave(object sender, EventArgs e)
        {
            if (!Is_Answered)
            {
                btn_Answer1.BackColor = Color.FromArgb(34, 33, 74);
            }
        }

        private void Btn_Answer2_MouseLeave(object sender, EventArgs e)
        {
            if (!Is_Answered)
            {
                btn_Answer2.BackColor = Color.FromArgb(34, 33, 74);
            }
        }

        private void Btn_Answer3_MouseLeave(object sender, EventArgs e)
        {
            if (!Is_Answered)
            {
                btn_Answer3.BackColor = Color.FromArgb(34, 33, 74);
            }
        }

        private void Btn_Answer4_MouseLeave(object sender, EventArgs e)
        {
            if (!Is_Answered)
            {
                btn_Answer4.BackColor = Color.FromArgb(34, 33, 74);
            }
        }

        #endregion изменения цвета текстбоксов как у кнопок

        #region снятие выделений у текстбоксов

        private void Btn_Answer1_MouseMove(object sender, MouseEventArgs e) => btn_Answer1.SelectionLength = 0;

        private void Btn_Answer2_MouseMove(object sender, MouseEventArgs e) => btn_Answer2.SelectionLength = 0;

        private void Btn_Answer3_MouseMove(object sender, MouseEventArgs e) => btn_Answer3.SelectionLength = 0;

        private void Btn_Answer4_MouseMove(object sender, MouseEventArgs e) => btn_Answer4.SelectionLength = 0;

        #endregion снятие выделений у текстбоксов

        #region клики кнопки на форме

        /// <summary>
        /// Запускает игру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayButton_Click(object sender, EventArgs e)
        {
            PlayButton.SendToBack();
            PlayButton.Enabled = false;
            PlayButton.Visible = false;
            panelQuestion.Show();
            tablePanel_Choices.Show();
            NextQuestion();
            timer1.Start();
            Focus();
        }

        /// <summary>
        /// Кнопка ответа1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Answer1_Click(object sender, EventArgs e)
        {
            if (!Is_Answered)//если ответ ещё не дан то засчитываем балл(или нет если был дан неверный ответ)
            {
                btn_Answer1.BackColor = WinOrLose(0) ? Color.Green : Color.Red;
            }
            else//а если уже выбрали один из ответов то только меняем цвета у кнопок но балл не засчитываем
            {
                btn_Answer1.BackColor = Is_Correct[0] ? Color.Green : Color.Red;
            }
        }

        /// <summary>
        /// Кнопка ответа2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Answer2_Click(object sender, EventArgs e)
        {
            if (!Is_Answered)//если ответ ещё не дан то засчитываем балл(или нет если был дан неверный ответ)
            {
                btn_Answer2.BackColor = WinOrLose(1) ? Color.Green : Color.Red;
            }
            else//а если уже выбрали один из ответов то только меняем цвета у кнопок но балл не засчитываем
            {
                btn_Answer2.BackColor = Is_Correct[1] ? Color.Green : Color.Red;
            }
        }

        /// <summary>
        /// Кнопка ответа3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Answer3_Click(object sender, EventArgs e)
        {
            if (!Is_Answered)//если ответ ещё не дан то засчитываем балл(или нет если был дан неверный ответ)
            {
                btn_Answer3.BackColor = WinOrLose(2) ? Color.Green : Color.Red;
            }
            else//а если уже выбрали один из ответов то только меняем цвета у кнопок но балл не засчитываем
            {
                btn_Answer3.BackColor = Is_Correct[2] ? Color.Green : Color.Red;
            }
        }

        /// <summary>
        /// Кнопка ответа4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Answer4_Click(object sender, EventArgs e)
        {
            if (!Is_Answered)//если ответ ещё не дан то засчитываем балл(или нет если был дан неверный ответ)
            {
                btn_Answer4.BackColor = WinOrLose(3) ? Color.Green : Color.Red;
            }
            else//а если уже выбрали один из ответов то только меняем цвета у кнопок но балл не засчитываем
            {
                btn_Answer4.BackColor = Is_Correct[3] ? Color.Green : Color.Red;
            }
        }

        /// <summary>
        /// Следующий вопрос
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Next_Click(object sender, EventArgs e)
        {
            NextQuestion();
        }

        #endregion клики кнопки на форме

        #region разное

        /// <summary>
        /// Чистит листы и заполняет их заново. Обнуляет таймеры, счётчики и тд.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGame_Load(object sender, EventArgs e)//при загрузке окна будет высвечен рандомный вопрос
        {
            PlayButton.BringToFront();
            list_Questions.Clear();//сбрасываем при каждом открытии окна.
            list_Choices.Clear();//сбрасываем при каждом открытии окна.
            timer1.Stop();//останавливаем таймер чтобы он стартанул с запуском игры
            _ticks = 0;//обнуляем таймер
            CorrectCounter = 0; //сбрасываем при каждой загрузке окна.
            result1 = Init_ListQuestions(list_Questions);//заполняем лист вопросов

            if (list_Questions.Count == 0)
                GameEnd();
            questCount = list_Questions.Count; //Присваеваем в лоаде потому-что записи из листа по мере выполнения
                                               //программы будут удаляться и надо записыть кол-во вопросов заранее.

            panelQuestion.Hide();
            tablePanel_Choices.Hide();

            GetPackTime();
            Focus();
        }

        /// <summary>
        /// для шорткатов на форме игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            Shortcuts(Keys.D1, 0, 0, tablePanel_Choices, e, sender);
            Shortcuts(Keys.D2, 1, 0, tablePanel_Choices, e, sender);
            Shortcuts(Keys.Q, 0, 1, tablePanel_Choices, e, sender);
            Shortcuts(Keys.W, 1, 1, tablePanel_Choices, e, sender);
            Shortcuts(Keys.Space, 2, 0, tablePanel_Choices, e, sender);

            if (e.KeyCode == Keys.Enter)
            {
                PlayButton.PerformClick();
            }
        }

        /// <summary>
        /// Событие таймера. Считает время
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (_ticks == timeLimit)
            {
                GameEnd();
            }
            _ticks++;
            label_Timer.Text = _ticks.ToString() + "\\" + timeLimit + " сек.";
        }

        #endregion разное

        #endregion события

        #region рабочие методы

        /// <summary>
        /// Заполнение листа ответов
        /// </summary>
        /// <param name="list_Choices">лист который заполняем</param>
        /// <param name="_qID">id вопроса для процедуры</param>
        /// <returns>Если ошибка то false сли всё сработало то тру</returns>
        private bool Init_ListChoices(List<Choice> list_Choices, int _qID)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "[Procedure1]",
                Connection = con
            };

            // параметр для id вопроса
            SqlParameter IDParam = new SqlParameter
            {
                ParameterName = "@Q_ID",
                Value = _qID
            };
            cmd.Parameters.Add(IDParam);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ID = (reader.GetInt32(0));
                        int Q_ID = (reader.GetInt32(1));
                        string Choice_Text = (reader.GetString(2));
                        bool is_Correct = (reader.GetBoolean(3));

                        list_Choices.Add(new Choice(ID, Q_ID, Choice_Text, is_Correct));  //додаємо в колекцію
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("Дані в таблиці Choices відсутні.\n", "DBQnA.mdf",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Помилка читання даних з бази даних.\n" + exc.ToString(), "DBQnA.mdf",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Заполнение списка вопросов
        /// </summary>
        /// <param name="list_Questions">лист который заполняем</param>
        /// <returns>Если ошибка то false сли всё сработало то тру</returns>
        private bool Init_ListQuestions(List<Question> list_Questions)
        {
            cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "[Procedure2]",
                Connection = con
            };
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ID = (reader.GetInt32(0));
                        string Text = (reader.GetString(1));

                        list_Questions.Add(new Question(ID, Text));  //додаємо в колекцію
                    }
                }
                else
                {
                    MessageBox.Show("Дані в таблиці Questions відсутні.\n", "DBQnA.mdf",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Помилка читання даних з бази даних.\n" + exc.ToString(), "DBQnA.mdf",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Записывает в timeLimit время для игры с базы
        /// </summary>
        private void GetPackTime()
        {
            cmd = new SqlCommand("Select TimeForGame from CurrentPackInfo", con);
            con.Open();

            timeLimit = (int)cmd.ExecuteScalar();
            con.Close();
        }

        /// <summary>
        /// В зависимости от правильсности выбраного ответа возвращаем тру если верный или фолс если неверный
        /// </summary>
        /// <param name="b">какой ответ проверяем</param>
        /// <returns></returns>
        private bool WinOrLose(int b)
        {
            Is_Answered = true; //ответ был дан
            if (Is_Correct[b])
            {
                CorrectCounter++;//если правильно ответил то засчитываем балл
                list_Questions.RemoveAt(temp); //удаляем текущий вопрос из листа чтобы он больше не показывался.
                return true;
            }
            else
            {
                list_Questions.RemoveAt(temp); //удаляем текущий вопрос из листа чтобы он больше не показывался.
                return false;
            }
        }

        /// <summary>
        /// Перемещение по вопросам
        /// </summary>
        private void NextQuestion()
        {
            Is_Answered = false;//пока игрок не выбрал ответ должно быть false

            //выставляем цвеnа кнопок(текстбоксов) по умолчанию
            btn_Answer1.BackColor = Color.FromArgb(34, 33, 74);
            btn_Answer2.BackColor = Color.FromArgb(34, 33, 74);
            btn_Answer3.BackColor = Color.FromArgb(34, 33, 74);
            btn_Answer4.BackColor = Color.FromArgb(34, 33, 74);

            if (result1)//если листу удалось заполниться то...
            {
                if (list_Questions.Count == 0) //если вопросы закончились то останавливаем игру
                {
                    timer1.Stop();
                    GameEnd();
                    return;
                }
                else
                {
                    temp = rand.Next(list_Questions.Count);//записываем индекс рандомно выбраный из листа. от 0 до числа записей в листе
                                                           //потом нам этот темп нужен будет для удаления. По этому сначала присваиваем в темп.
                    Question Q = list_Questions[temp];//записываем в объект класса question вопрос по рандомному temp
                    textBox_Question.Text = Q.QuestionText.Value;//вывод вопроса в текстбокс
                    current_id = Q.ID.Value; //!записываем id вопроса для поиска по внешнему ключу в базе ответов!
                }
            }
            else
            {
                MessageBox.Show("Error");
                Close();
            }
            //заполняем лист ответов в соответствии с вопросом. Делаем это после вопросов потому-что вопросы меняються и нужно подгружать из базы ответы
            //динамически в соответсвии с вопросом.
            result2 = Init_ListChoices(list_Choices, current_id);
            //если листу удалось заполниться то...
            if (result2)
            {
                string[] AnswerTexts = new string[4];//для хранения текстового значения ответов на вопос
                for (int i = 0; i < list_Choices.Count; i++) //заполняем массив ответами.
                {
                    Choice C = list_Choices[i];
                    AnswerTexts[i] = C.ChoiceText.Value;//собсна сам текст ответа
                    Is_Correct[i] = C.is_Correct.Value;//правильный ли ответ
                }
                if (AnswerTexts.Any(x => x == null))//проверочка если какой-то вопрос оказался null (такое может случиться если юзер сам пытался изменить xml файл
                {
                    MessageBox.Show("Проверьте базу данных ответов. Проблема с ответами для вопроса с id " + current_id);
                    Close();
                    return;
                }
                //показываем текст ответов на кнопках(текстбоксах)
                btn_Answer1.Text = AnswerTexts[0];
                btn_Answer2.Text = AnswerTexts[1];
                btn_Answer3.Text = AnswerTexts[2];
                btn_Answer4.Text = AnswerTexts[3];

                #region рандомно меняем расположение кнопок

                TableLayoutPanelCellPosition[] p =
                {
                    new TableLayoutPanelCellPosition(0,0),
                    new TableLayoutPanelCellPosition(1,0),
                    new TableLayoutPanelCellPosition(0,1),
                    new TableLayoutPanelCellPosition(1,1)
                };
                TableLayoutPanelCellPosition[] RandomizedP = p.OrderBy(_ => rand.Next()).ToArray();

                Control[] c =
                {
                    tablePanel_Choices.GetControlFromPosition(0, 0),
                    tablePanel_Choices.GetControlFromPosition(1, 0),
                    tablePanel_Choices.GetControlFromPosition(0, 1),
                    tablePanel_Choices.GetControlFromPosition(1, 1)
                };

                for (int i = 0; i < c.Length; i++)
                {
                    tablePanel_Choices.SetCellPosition(c[i], RandomizedP[i]);
                }

                #endregion рандомно меняем расположение кнопок

                list_Choices.Clear();//очищаем лист ответов. (Для загрузки ответов на следующий вопрос)
            }
            else
            {
                MessageBox.Show("Error");
                Close();
            }
        }

        /// <summary>
        /// скрывает все елементы на форме и выводит результат в конце игры
        /// </summary>
        private void GameEnd()
        {
            //скрываем контролы с формы
            foreach (Control ct in Controls)
            {
                ct.Hide();
            }
            //выводим результат
            //переделать по красивей что-то придумать мб график или таблицу результатов.
            TextBox txt = new TextBox()
            {
                Text = "Вопросы закончились. Правильных ответов " + CorrectCounter + " из " + questCount + "\r\nВремя: " + _ticks + "\\" + timeLimit + " сек.",
                Dock = DockStyle.Fill,
                Parent = this,
                BackColor = Color.FromArgb(34, 33, 74),
                Font = new Font("Arial", 24, FontStyle.Bold),
                ForeColor = Color.Gainsboro,
                BorderStyle = BorderStyle.None,
                Multiline = true
            };

            Controls.Add(txt);
            SetGameResult();
        }

        /// <summary>
        /// Записываем результат игры в бд
        /// </summary>
        private void SetGameResult()
        {
            int? UserID;//для id игрока

            //для генерирования след. id
            con.Open();
            cmd = new SqlCommand("select MAX(Id) FROM ResultLog", con);
            int LastRID = (int)cmd.ExecuteScalar() + 1;
            con.Close();

            //дата и время игры
            DateTime myDateTime = DateTime.Now;

            //записываем id игрока
            cmd = new SqlCommand("Select CurrentPlayerName_FK from CurrentPackInfo", con);
            con.Open();
            try
            {
                UserID = (int?)cmd.ExecuteScalar();
            }
            catch (InvalidCastException)
            {
                UserID = null;
            }

            con.Close();

            //название пака
            cmd = new SqlCommand("Select PackName from CurrentPackInfo", con);
            con.Open();

            string packname = (string)cmd.ExecuteScalar();
            con.Close();

            //и вставляем всё это в бд
            cmd = new SqlCommand("insert into ResultLog(Id,GameResult,GameDate,PlayerName_FK,PackName,Time) values(@Id,@GameResult,@GameDate,@PlayerName_FK,@PackName,@Time)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@Id", LastRID);
            cmd.Parameters.AddWithValue("@GameResult", CorrectCounter * 100 / questCount);
            cmd.Parameters.AddWithValue("@GameDate", myDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            if (UserID == null)
            {
                cmd.Parameters.AddWithValue("@PlayerName_FK", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@PlayerName_FK", UserID);
            }

            cmd.Parameters.AddWithValue("@PackName", packname);
            cmd.Parameters.AddWithValue("@Time", _ticks);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /// <summary>
        /// горячие клавишы
        /// </summary>
        /// <param name="k">Кнопка шортката</param>
        /// <param name="col">Колонка в TableLayoutPanel</param>
        /// <param name="row">Столбец в TableLayoutPanel</param>
        /// <param name="tlp">Собственно сам TableLayoutPanel</param>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void Shortcuts(Keys k, int col, int row, TableLayoutPanel tlp, KeyEventArgs e, object sender)
        {
            Control c = tlp.GetControlFromPosition(col, row);
            if (e.KeyCode == k && tlp.Visible)
            {
                if (c == btn_Answer1)
                {
                    Btn_Answer1_Click(sender, e);
                }
                else if (c == btn_Answer2)
                {
                    Btn_Answer2_Click(sender, e);
                }
                else if (c == btn_Answer3)
                {
                    Btn_Answer3_Click(sender, e);
                }
                else if (c == btn_Answer4)
                {
                    Btn_Answer4_Click(sender, e);
                }
                else if (c == button_Next)
                {
                    button_Next.PerformClick();
                }
            }
        }

        #endregion рабочие методы
    }
}