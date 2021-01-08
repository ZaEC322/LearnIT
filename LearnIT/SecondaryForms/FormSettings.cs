using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace LearnIT.SecondaryForms
{
    public partial class FormSettings : Form
    {
        #region Переменные

        private DataSet set; //датасет для работы с данными
        private int LastCID = 0; //нужен для добавления ответов к последнему ответу.
        private int LastQID = 0; //нужен для добавления ответов к последнему вопросу.
        private int rowindx = 0; //для перемещения фокуса в гриде с вопросами.
        private int SelectedID = 1; //Выбраный ID
        private OpenFileDialog OFD = new OpenFileDialog(); //окно выбора файла
        private SqlCommand cmd;//для комманд
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString); //подключение

        #endregion Переменные

        public FormSettings()
        {
            InitializeComponent();
            CreateToolTip(a, "Новый пустой вопрос в конец списка");
            CreateToolTip(button_ChooseXML, "Открыть окно для выбора файла базы");
            CreateToolTip(button_LoadChosenXML, "Загрузить выбранный файл в программу");
            CreateToolTip(button_Remove, "Удаляет выделенный вопрос");
            CreateToolTip(button_SaveThisDBToXML, "Сохранить открытую базу из программы в файл");
            CreateToolTip(textBox_dbname, "Название файла базы");
        }

        #region Рабочие методы

        private string PackName
        {
            get
            {
                string temp = "";
                using (XmlReader reader = XmlReader.Create("UserPacks\\" + textBox_dbname.Text + ".LearnITPack"))
                {
                    while (reader.Read())
                    {
                        // first element is the root element
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            temp = reader.Name;
                            break;
                        }
                    }
                }
                return temp;
            }
        }

        /// <summary>
        /// всплывающие подсказки
        /// </summary>
        /// <param name="controlForToolTip"></param>
        /// <param name="toolTipText"></param>
        private void CreateToolTip(Control controlForToolTip, string toolTipText)
        {
            ToolTip toolTip = new ToolTip
            {
                Active = true,
                IsBalloon = true
            };
            toolTip.SetToolTip(controlForToolTip, toolTipText);
        }

        /// <summary>
        /// Устанавливает свойства внешний вид гридов.
        /// </summary>
        private void SetGridsAppearence()
        {
            dataGridView_Questions.Columns[0].ReadOnly = true; //чтобы нельзя было менять id
            dataGridView_Choices.Columns[0].Visible = false;
            dataGridView_Choices.Columns[1].Visible = false;

            dataGridView_Questions.Columns[0].Width = 60;
            dataGridView_Choices.Columns[3].Width = 100;

            dataGridView_Questions.Columns[0].HeaderText = "ID";
            dataGridView_Questions.Columns[1].HeaderText = "Вопрос";

            dataGridView_Choices.Columns[2].HeaderText = "Ответ";
            dataGridView_Choices.Columns[3].HeaderText = "Верный";

            dataGridView_Questions.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dataGridView_Choices.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
        }

        /// <summary>
        /// Получает все данные из таблицы
        /// </summary>
        /// <param name="table">Название таблицы</param>
        /// <returns></returns>
        public DataTable FillDataTable(string table)
        {
            string query = "SELECT * FROM " + table;
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }

        /// <summary>
        /// Выводит данные из таблицы Questions и по внешнему ключу выводит ответы к вопросу из
        /// таблицы Choices.
        /// </summary>
        private void DisplayData()
        {
            set = new DataSet();
            DataTable QuestionsTable = FillDataTable("Questions");
            DataTable ChoicesTable = FillDataTable("Choices");
            //DataTable CurrentName = fillDataTable("CurrentName");

            QuestionsTable.TableName = "Questions";
            ChoicesTable.TableName = "Choices";
            set.Tables.Add(QuestionsTable);
            set.Tables.Add(ChoicesTable);
            // set.Tables.Add(CurrentName);

            set.Relations.Add("QCRealations", QuestionsTable.Columns["Question_ID"], ChoicesTable.Columns["FK_Question_ID"]);

            BindingSource masterBinding = new BindingSource
            {
                DataSource = set,
                DataMember = "Questions"
            };

            dataGridView_Questions.DataSource = masterBinding;
            dataGridView_Choices.DataSource = masterBinding;

            dataGridView_Choices.DataMember = "QCRealations";

            SetGridsAppearence();
        }

        /// <summary>
        /// выбирает самое большое id, оно же и последнее. Нужно для корректного перемещения выделения
        /// </summary>
        /// <param name="i">0 - присвоит lastQID И CID как 0. 1 - сделать запрос MAX в базу</param>
        private void GetLastIDFromQC(int i)
        {
            if (i == 0)
            {
                LastQID = 0;
                LastCID = 0;
                return;
            }
            con.Open();
            try
            {
                cmd = new SqlCommand("select MAX(Question_ID) FROM Questions", con);
                LastQID = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("select MAX(Choice_ID) FROM Choices", con);
                LastCID = (int)cmd.ExecuteScalar();
            }
            catch (Exception) { }
            con.Close();
        }

        /// <summary>
        /// Обновляет все записи всех таблиц - загружает в память базы проги.
        /// </summary>
        private void UpdateThis()
        {
            //обновляем вопросы
            cmd = new SqlCommand("UPDATE Questions SET Question_Text = @Question_Text WHERE Question_ID = @Question_ID", con);
            cmd.Parameters.Add("@Question_ID", SqlDbType.Int);
            cmd.Parameters.Add("@Question_Text", SqlDbType.NVarChar);

            con.Open();
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                cmd.Parameters["@Question_ID"].Value = (int)set.Tables[0].Rows[i]["Question_ID"];
                cmd.Parameters["@Question_Text"].Value = set.Tables[0].Rows[i]["Question_Text"].ToString();

                cmd.ExecuteNonQuery();
            }
            con.Close();

            //обновляем варианты ответов
            cmd = new SqlCommand("UPDATE Choices SET Choice_Text = @Choice_Text, is_Correct = @is_Correct WHERE Choice_ID = @Choice_ID", con);
            cmd.Parameters.Add("@Choice_ID", SqlDbType.Int);
            cmd.Parameters.Add("@Choice_Text", SqlDbType.NVarChar);
            cmd.Parameters.Add("@is_Correct", SqlDbType.Bit);

            con.Open();
            for (int i = 0; i < set.Tables[1].Rows.Count; i++)
            {
                cmd.Parameters["@Choice_ID"].Value = (int)set.Tables[1].Rows[i]["Choice_ID"];
                cmd.Parameters["@Choice_Text"].Value = set.Tables[1].Rows[i]["Choice_Text"].ToString();
                cmd.Parameters["@is_Correct"].Value = (bool)set.Tables[1].Rows[i]["is_Correct"];

                cmd.ExecuteNonQuery();
            }
            con.Close();
            DisplayData();

            try
            {
                dataGridView_Questions.Rows[rowindx].Cells[1].Selected = true; //выбераем запись которую меняли чтобы выделение не скакало в начало после каждого изменения
            }
            catch (Exception)
            {
                //иногда выскакивают ошибки тут, не влияет на работу программы
            }
        }

        #endregion Рабочие методы

        #region Кнопки

        #region CRUD для работы с базой в проге

        /// <summary>
        /// Вставляет пустую запись с айди последннее+1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Insert_Click(object sender, EventArgs e)
        {
            UpdateThis();
            GetLastIDFromQC(1);
            cmd = new SqlCommand("insert into Questions(Question_ID,Question_Text) values(@Qid,@text)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@Qid", LastQID + 1);
            cmd.Parameters.AddWithValue("@text", "");
            cmd.ExecuteNonQuery();
            con.Close();

            GetLastIDFromQC(1);

            cmd = new SqlCommand("insert into Choices(Choice_ID,FK_Question_ID,Choice_Text,is_Correct) values(@Cid,@Qid,@Ctext,@IsCor)", con);
            con.Open();

            cmd.Parameters.Add("@Cid", SqlDbType.Int);
            cmd.Parameters.Add("@Qid", SqlDbType.Int);
            cmd.Parameters.Add("@Ctext", SqlDbType.NVarChar);
            cmd.Parameters.Add("@IsCor", SqlDbType.Bit);

            for (int i = 1; i < 5; i++)
            {
                cmd.Parameters["@Cid"].Value = LastCID + i;
                cmd.Parameters["@Qid"].Value = LastQID;
                cmd.Parameters["@Ctext"].Value = "";
                cmd.Parameters["@IsCor"].Value = false;

                cmd.ExecuteNonQuery();
            }

            con.Close();

            DisplayData();

            rowindx = dataGridView_Questions.Rows.Count - 1; //количество строк минус 1 потому-что индексы строк нач. с 0. а кол-во с 1.
            dataGridView_Questions.Rows[rowindx].Cells[1].Selected = true; // выбераем её
            SelectedID = (int)dataGridView_Questions.Rows[rowindx].Cells[0].Value; //селектедайди присваиваем значение из последней добавленной
        }

        /// <summary>
        /// Удаляет вопрос и каскадом удаляет ответы к нему
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Remove_Click(object sender, EventArgs e)
        {
            //если удалять нечего то ретурн
            if (dataGridView_Questions.Rows.Count == 0)
                return;
            // если запись одна - значит удаляем последнюю запись. Значит присваиваем ластайди 0.
            else if (dataGridView_Questions.Rows.Count == 1)
            {
                cmd = new SqlCommand("DELETE FROM Questions WHERE Question_ID = @Question_ID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Question_ID", SelectedID);
                cmd.ExecuteNonQuery();
                con.Close();
                UpdateThis();
                DisplayData();
                LastQID = 0;
                LastCID = 0;
            }
            //если записей больше 1
            else if (dataGridView_Questions.Rows.Count > 1)
            {
                cmd = new SqlCommand("DELETE FROM Questions WHERE Question_ID = @Question_ID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Question_ID", SelectedID);
                cmd.ExecuteNonQuery();
                con.Close();
                UpdateThis();
                DisplayData();

                if (rowindx != 0)
                    rowindx -= 1;

                dataGridView_Questions.Rows[rowindx].Cells[1].Selected = true;//выделяем пред. запись
                SelectedID = (int)dataGridView_Questions.Rows[rowindx].Cells[0].Value;//селектедайди присваиваем значение из пред. записи

                GetLastIDFromQC(1);
            }
            else
                MessageBox.Show("Выберите запись для удаления");
        }

        #endregion CRUD для работы с базой в проге

        #region Сохранение и загрузка xml

        /// <summary>
        /// Сохранить текущую базу в xml файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_SaveThisDBToXML_Click(object sender, EventArgs e)
        {
            if (textBox_dbname.Text == "")
            {
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Желаете сохранить эту базу с именем \"" + textBox_dbname.Text +
                "\"?", "Внимание!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (!Directory.Exists(Application.StartupPath + "\\UserPacks"))//если нету папки userpacks - создаём её.
                    Directory.CreateDirectory(Application.StartupPath + "\\UserPacks");

                //Если файл с таким названием уже есть то спрашиваем хочет ли пользователь перезаписать базу.
                if (File.Exists("UserPacks\\" + textBox_dbname.Text + ".LearnITPack"))
                {
                    DialogResult dialogResult2 = MessageBox.Show("Указано существующее название базы - она будет перезаписана.\nЖелаете продолжить?", "Внимание!", MessageBoxButtons.YesNo);
                    if (dialogResult2 == DialogResult.Yes)
                    {
                        set.DataSetName = textBox_dbname.Text;
                        // setPackName();
                        set.WriteXml("UserPacks\\" + textBox_dbname.Text + ".LearnITPack");
                        MessageBox.Show("UserPacks\\" + textBox_dbname.Text + " Обновлён");
                        return;
                    }
                    else return;
                }
                //Если такого фалйа не то просто создаём его.
                else
                {
                    set.DataSetName = textBox_dbname.Text;
                    // setPackName();
                    set.WriteXml("UserPacks\\" + textBox_dbname.Text + ".LearnITPack");
                    MessageBox.Show("UserPacks\\" + textBox_dbname.Text + " Создан");
                    return;
                }
            }
            else return;
        }

        /// <summary>
        /// прогружает в базу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_LoadChosenXML_Click(object sender, EventArgs e)
        {
            #region проверки

            if (textBox_dbname.Text == "")
            {
                return;
            }

            string errorText = "";
            DialogResult dialogResult = MessageBox.Show("Данное действие удалит текущую базу из памяти программы и загрузит выбранную базу из папки UserPacks." +
                " \nЕсли вы не сохранили текущую базу то она пропадёт.\nЖелаете продолжить?", "ВНИМАНИЕ!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //продолжаем если выбор да
            }
            else if (dialogResult == DialogResult.No) return; //прекращаем если выбор нет

            //Создайм локальный дс дт на случай если будет ошибка чтобы не перебить существующий сет
            DataSet ds = new DataSet();

            try
            {
                ds.ReadXml("UserPacks\\" + textBox_dbname.Text + ".LearnITPack");//читаем файл xml
                //проверяем на некоторые ошибки xml. В целом можно не проверять, так как в инструкции к программе будет написано не трогать xml файлы.
                //а ошибки могут возникнуть только в случае если пользователь сам будет пытаться изменить эти файлы. На всякий случай оставлю.
                if (ds.Tables.Count < 2) errorText += "Не хватает таблиц. Должно быть две";

                if (ds.Tables.Count == 2)
                {
                    if (ds.Tables[0].TableName != "Questions")
                        errorText += "\nНету таблицы Questions либо она не на первом месте либо название таблицы не верно ";
                    if (ds.Tables[1].TableName != "Choices")
                        errorText += "\nНету таблицы Choices либо она не на втором месте либо название таблицы не верно ";
                    if (ds.Tables[0].HasErrors)
                        errorText += "\nТаблица Questions имеет ошибки ";
                    if (ds.Tables[1].HasErrors)
                        errorText += "\nТаблица Choices имеет ошибки ";
                    if (ds.Tables[1].Rows.Count != ds.Tables[0].Rows.Count * 4)
                        errorText += "\nОшибка в структуре xml. Либо не хватает ответов на вопросы либо их больше чем допустимо";
                }
            }
            catch (DirectoryNotFoundException)
            {
                errorText += " Не удалось найти часть пути. Скорее всего отсутсвует каталог UserPacks. Загружать свои базы можно только в этот каталог";
            }
            catch (FileNotFoundException)
            {
                errorText += textBox_dbname.Text + " Не найден";
            }
            catch (XmlException)
            {
                errorText += textBox_dbname.Text + " Файл повреждён либо не являеться xml";
            }
            catch (Exception)
            {
                errorText += "Неизвестная ошибка.";
            }
            if (errorText != "")
            {
                MessageBox.Show(errorText + "\nЗагрузка базы отменена. Проверьте выбраный файл, выберите другой или создайте новый.", "Ошибка!");
                return;
            }

            #endregion проверки

            #region очищаем бд перед загрузкой новых данных

            con.Open();
            cmd = new SqlCommand("ALTER TABLE Choices DROP CONSTRAINT FK_QuestionChoices", con);//Убираем внешний ключ для TRUNCATE
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("TRUNCATE TABLE Questions", con);//очищает данные из таблицы Questions
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("TRUNCATE TABLE Choices", con);//очищает данные из таблицы Choices
            cmd.ExecuteNonQuery();
            ////////////////
            // cmd = new SqlCommand("TRUNCATE TABLE CurrentName", con);//очищает данные из таблицы CurrentName
            //cmd.ExecuteNonQuery();
            ////////////////
            cmd = new SqlCommand("ALTER TABLE Choices ADD CONSTRAINT FK_QuestionChoices FOREIGN KEY (FK_Question_ID)" +
                " REFERENCES Questions (Question_ID) ON DELETE CASCADE ON UPDATE CASCADE", con); //Возвращаем внешний ключ на место.
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayData(); //показываем пустую бд
            GetLastIDFromQC(0);//устанавливаем ластID как 0 для избежания ошибок

            #endregion очищаем бд перед загрузкой новых данных

            #region заполнение и вывод базы

            con.Open();
            //dt = ds.Tables[0]; //записываем таблицу Questions в дататейбл. Она всегда первая.
            // инсерт всех строк таблицы Questions в бд
            foreach (DataRow row in /*dt.Rows*/ ds.Tables[0].Rows)
            {
                cmd = new SqlCommand("insert into Questions(Question_ID,Question_Text) values(@Qid,@text)", con);
                cmd.Parameters.AddWithValue("@Qid", row.Field<string>("Question_ID"));
                cmd.Parameters.AddWithValue("@text", row.Field<string>("Question_Text"));
                cmd.ExecuteNonQuery();
            }
            con.Close();

            // dt = ds.Tables[1];//записываем таблицу Choices в дататейбл. Она всегда вторая.

            con.Open();
            // инсерт всех строк таблицы Choices
            foreach (DataRow row in /*dt.Rows*/ds.Tables[1].Rows)
            {
                cmd = new SqlCommand("insert into Choices(Choice_ID,FK_Question_ID,Choice_Text,is_Correct) values(@Cid,@Qid,@Ctext,@IsCor)", con);
                cmd.Parameters.AddWithValue("@Cid", row.Field<string>("Choice_ID"));
                cmd.Parameters.AddWithValue("@Qid", row.Field<string>("FK_Question_ID"));
                cmd.Parameters.AddWithValue("@Ctext", row.Field<string>("Choice_Text"));
                cmd.Parameters.AddWithValue("@IsCor", row.Field<string>("is_Correct"));
                cmd.ExecuteNonQuery();
            }
            con.Close();
            DisplayData();
            GetLastIDFromQC(1);
            dataGridView_Questions.Rows[0].Cells[1].Selected = true; //выделяем первую запись на гриде

            ///////////////

            ///////////////

            #endregion заполнение и вывод базы
        }

        /// <summary>
        /// Выбираем xml файл с данными для загрузки в бд.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ChooseXML_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Application.ExecutablePath) + "\\UserPacks"); //создаёт каталог если его нет
            OFD.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\UserPacks"; //открывает каталог юзерпакс
            OFD.Multiselect = false;
            OFD.Filter = "Файлы пака xml(*.LearnITPack)|*.LearnITPack|Все файлы (*.*)|*.*";
            if (OFD.ShowDialog() == DialogResult.OK)
                textBox_dbname.Text = Path.GetFileNameWithoutExtension(OFD.SafeFileName); //записывает название файла в каталоге
        }

        #endregion Сохранение и загрузка xml

        #endregion Кнопки

        #region События

        /// <summary>
        /// в лоаде вызываем метод дисплей чтобы отобразить данные с базы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSettings_Load(object sender, EventArgs e) => DisplayData();

        /// <summary>
        /// при закрытии формы всегда сейвим изменения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e) => UpdateThis();

        /// <summary>
        /// Записывает id выбраной записи в SelectedID для удаления. Записывает индекс выбраной
        /// строки для перемещения фокуса.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_Questions.Rows.Count != 0)
            {
                if (e.RowIndex >= 0)
                {
                    SelectedID = (int)dataGridView_Questions.Rows[e.RowIndex].Cells[0].Value;
                    rowindx = e.RowIndex;
                }
            }
            else
                return;
        }

        /// <summary>
        /// Не допускает ввод некректных символов для имени файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_dbname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\\') e.Handled = true;
            if (e.KeyChar == '/') e.Handled = true;
            if (e.KeyChar == ':') e.Handled = true;
            if (e.KeyChar == '*') e.Handled = true;
            if (e.KeyChar == '?') e.Handled = true;
            if (e.KeyChar == '"') e.Handled = true;
            if (e.KeyChar == '<') e.Handled = true;
            if (e.KeyChar == '>') e.Handled = true;
            if (e.KeyChar == '|') e.Handled = true;
            if (e.KeyChar == '.') e.Handled = true;
            if (e.KeyChar == '@') e.Handled = true;
            if (e.KeyChar == '%') e.Handled = true;
            if (e.KeyChar == '#') e.Handled = true;
            if (e.KeyChar == (Char)Keys.Space) e.Handled = true;
        }

        /// <summary>
        /// Если пользователь решит схитрить и попытаться вставить запрещённый символ с помощью
        /// ctrl+v то стираем строку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_dbname_TextChanged(object sender, EventArgs e)
        {
            if (textBox_dbname.Text.IndexOfAny(new char[] { '\\', '/', ':', '*', '?', '"', '<', '>', '|', '.', '@', '%', '#', (Char)Keys.Space }) != -1)
            {
                if (textBox_dbname.Text.Length > 1)
                {
                    textBox_dbname.Text = textBox_dbname.Text.Substring(0, textBox_dbname.Text.Length - 1);
                }
                else
                {
                    MessageBox.Show("Строка которую вы пытались вставить содежит недопустимый символ.");
                    textBox_dbname.Text = "";
                }
            }
        }

        #endregion События
    }
}