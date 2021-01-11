using LearnIT.ClassesAndDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LearnIT.SecondaryForms
{
    public partial class FormGame : Form
    {
        #region оптимизация отображения всего

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #endregion оптимизация отображения всего

        #region поля

        private int timeLimit;

        private List<Question> list_Questions = new List<Question>();//создаём листы для хранения объектов класса question которые заполняем из бд
        private List<Choice> list_Choices = new List<Choice>();//после заполняем ответы
        private Random rand = new Random();//объект класса рандом.
        private int current_id;// id вопроса для выполнения процедуры по поиску ответов в базе.
        private int counter;//количество правильно отвеченых вопросов
        private int temp; // для хранинения рандомно выбраного индекса текущего вопроса.
        private int questCount;//изначальное общее кол-во вопросов.
        private int _ticks;//для счёта времени
        private bool result1; //Для проверки заполнился ли лист из бд. Если нет то false.
        private bool[] Is_Correct = new bool[4]; //переменные для проверки правильности ответа
        private bool Is_Answered;//если на текущий вопрос дан ответ == true, если не дан то false
        private SqlCommand cmd;
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString); //подключение

        internal ConnectDB Dbb { get; set; } = new ConnectDB();

        #endregion поля

        public FormGame()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
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
        }

        private void Btn_Answer1_Click(object sender, EventArgs e)
        {
            if (!Is_Answered)
            {
                if (WinOrLose(0))
                {
                    btn_Answer1.BackColor = Color.Green;
                }
                else
                    btn_Answer1.BackColor = Color.Red;
            }
            else
            {
                if (Is_Correct[0] == true)
                {
                    btn_Answer1.BackColor = Color.Green;
                }
                else
                {
                    btn_Answer1.BackColor = Color.Red;
                }
            }
        }

        private void Btn_Answer2_Click(object sender, EventArgs e)
        {
            if (!Is_Answered)
            {
                if (WinOrLose(1))
                {
                    btn_Answer2.BackColor = Color.Green;
                }
                else
                    btn_Answer2.BackColor = Color.Red;
            }
            else
            {
                if (Is_Correct[1] == true)
                {
                    btn_Answer2.BackColor = Color.Green;
                }
                else
                {
                    btn_Answer2.BackColor = Color.Red;
                }
            }
        }

        private void Btn_Answer3_Click(object sender, EventArgs e)
        {
            if (!Is_Answered)
            {
                if (WinOrLose(2))
                {
                    btn_Answer3.BackColor = Color.Green;
                }
                else
                    btn_Answer3.BackColor = Color.Red;
            }
            else
            {
                if (Is_Correct[2] == true)
                {
                    btn_Answer3.BackColor = Color.Green;
                }
                else
                {
                    btn_Answer3.BackColor = Color.Red;
                }
            }
        }

        private void Btn_Answer4_Click(object sender, EventArgs e)
        {
            if (!Is_Answered)
            {
                if (WinOrLose(3))
                {
                    btn_Answer4.BackColor = Color.Green;
                }
                else
                    btn_Answer4.BackColor = Color.Red;
            }
            else
            {
                if (Is_Correct[3] == true)
                {
                    btn_Answer4.BackColor = Color.Green;
                }
                else
                {
                    btn_Answer4.BackColor = Color.Red;
                }
            }
        }

        private void Button_Next_Click(object sender, EventArgs e)
        {
            NextQuestion();
        }

        #endregion клики кнопки на форме

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
            counter = 0; //сбрасываем при каждой загрузке окна.
            result1 = Dbb.Init_ListQuestions(list_Questions);//заполняем лист вопросов

            if (list_Questions.Count == 0)
                GameEnd();
            questCount = list_Questions.Count; //Присваеваем в лоаде потому-что записи из листа по мере выполнения
                                               //программы будут удаляться и надо записыть кол-во вопросов заранее.

            panelQuestion.Hide();
            tablePanel_Choices.Hide();

            GetPackTime();
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

        #endregion события

        #region рабочие методы

        private void GetPackTime()
        {
            cmd = new SqlCommand("Select TimeForGame from CurrentPackInfo", con);
            con.Open();

            timeLimit = (int)cmd.ExecuteScalar();
            con.Close();
        }

        /// <summary>
        /// В зависимости от правильсности выбраного ответа возвращаем тру или фолс
        /// </summary>
        /// <param name="b">хуйло</param>
        /// <returns></returns>
        private bool WinOrLose(int b)
        {
            Is_Answered = true;
            if (Is_Correct[b] == true)
            {
                counter++;
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

            //выставляем цвеа по умолчанию
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
            bool result2 = Dbb.Init_ListChoices(list_Choices, current_id);

            if (result2)
            {
                string[] AnswerTexts = new string[4];//для хранения текстового значения ответов на вопос
                for (int i = 0; i < list_Choices.Count; i++) //заполняем массив ответами.
                {
                    Choice C = list_Choices[i];
                    AnswerTexts[i] = C.ChoiceText.Value;
                    Is_Correct[i] = C.is_Correct.Value;
                }
                if (AnswerTexts.Any(x => x == null))
                {
                    MessageBox.Show("Проверьте базу данных ответов. Проблема с ответами для вопроса с id " + current_id);
                    Close();
                    return;
                }

                btn_Answer1.Text = AnswerTexts[0].ToString();
                btn_Answer2.Text = AnswerTexts[1].ToString();
                btn_Answer3.Text = AnswerTexts[2].ToString();
                btn_Answer4.Text = AnswerTexts[3].ToString();

                #region меняем расположение кнопок

                TableLayoutPanelCellPosition[] p =
                {
                    new TableLayoutPanelCellPosition(0,0),
                    new TableLayoutPanelCellPosition(1,0),
                    new TableLayoutPanelCellPosition(0,1),
                    new TableLayoutPanelCellPosition(1,1)
                };
                TableLayoutPanelCellPosition[] RandomizedP = p.OrderBy(x => rand.Next()).ToArray();

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

                #endregion меняем расположение кнопок

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
            foreach (Control ct in Controls)
            {
                ct.Hide();
            }

            TextBox txt = new TextBox()
            {
                Text = "Вопросы закончились. Правильных ответов " + counter + " из " + questCount + "\r\nВремя: " + _ticks + "\\" + timeLimit + " сек.",
                Dock = DockStyle.Fill,
                Parent = this,
                BackColor = Color.FromArgb(34, 33, 74),
                Font = new Font("Arial", 24, FontStyle.Bold),
                ForeColor = Color.Gainsboro,
                BorderStyle = BorderStyle.None,
                Multiline = true
            };

            Controls.Add(txt);

            /*
             * Записывать в бд результат который потом выводить на мейнформе.
             *
            */
        }

        #endregion рабочие методы
    }
}