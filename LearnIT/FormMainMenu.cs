using FontAwesome.Sharp; //Библ. с иконками.
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LearnIT
{
    //Мейнформа предаставляет собой меню. Слева на панели будут кнопки для открытия дочерних форм.
    public partial class FormMainMenu : Form
    {
        #region Переменные, структуры, дллимпорты

        /// <summary>
        /// Для храниение текущей активной кнопки.
        /// </summary>
        private IconButton currentBtn;

        /// <summary>
        /// полоска слева от кнопки для красоты. Появляеться после активации кнопки.
        /// </summary>
        private readonly Panel leftBorderBtn;

        /// <summary>
        /// для дочерней формы
        /// </summary>
        private Form currentChildForm;

        /// <summary>
        /// Цвета для кнопок
        /// </summary>
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
        }

        /// <summary>
        /// подключение
        /// </summary>
        public SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            Directory.EnumerateFiles(Environment.CurrentDirectory, "*.mdf", SearchOption.AllDirectories).First() + ";Integrated Security=True;Connect Timeout=30;");

        /// <summary>
        /// для комманд
        /// </summary>
        private SqlCommand cmd;

        #endregion Переменные, структуры, дллимпорты

        //конструктор
        public FormMainMenu()
        {
            InitializeComponent();
            timer1.Enabled = true; //подрубаем часики
            timer1.Interval = 1000;
            leftBorderBtn = new Panel();//полоска для красоты
            panelMenu.Controls.Add(leftBorderBtn);
            //Настраиваем вид формы
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            GetUserName();//выводим ник юзера сверху
        }

        #region Рабочие методы

        /// <summary>
        /// показываем таблицу результат
        /// </summary>
        private void LoadResults()
        {
            const string select = "select RT.GameResult,RT.GameDate,RT.PackName,RT.Time,PT.PlayerName from ResultLog RT join Players PT on RT.PlayerName_FK=PT.Id";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, con);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        #region управление дочерними формами

        /// <summary>
        /// Изменение вида кнопки после нажатия на неё придавая ей цвет и смещая содержимое чтобы
        /// было понятно что она нажата.
        /// </summary>
        /// <param name="senderBtn"></param>
        /// <param name="color"></param>
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton(); //Деактивация предыдущей нажатой кнопки
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Полоска справа от кнопкии
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Size = new Size(7, currentBtn.Height);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Иконка текущей дочерней формы

                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        /// <summary>
        /// Изменение вида текущей активной кнопки в исходный неактивный вид
        /// </summary>
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        /// <summary>
        /// Открывает дочернюю форму внутри мейнформы.
        /// </summary>
        /// <param name="childForm">Конструктор формы которую нужно открыть</param>
        private void OpenChildForm(Form childForm)
        {
            //Закрываем открытую форму если такая есть
            currentChildForm?.Close();
            //записываем новую
            currentChildForm = childForm;

            //устанавливаем вид для формы
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.Size = panelDesktop.Size;
            //добавляем её в контролы
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;

            childForm.BringToFront();//ставим форму на передний план

            childForm.Show();//и показываем её
            lblTitleChildForm.Text = childForm.Text;//выводим название дочерней формы сверху.
        }

        /// <summary>
        /// Переход на домашнюю страницу мейнформы(закрытие дочерних).
        /// </summary>
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Домашня сторінка";
        }

        #endregion управление дочерними формами

        #region get/set

        /// <summary>
        /// Установить id текущего игрока для которого ведутся записи результатов
        /// </summary>
        /// <param name="userId"></param>
        private void SetUserName(int? userId)
        {
            cmd = new SqlCommand("UPDATE CurrentPackInfo SET CurrentPlayerName_FK = @CurrentPlayerName_FK WHERE Id = @id", con);
            con.Close();
            con.Open();
            if (userId == null)
            {
                cmd.Parameters.AddWithValue("@CurrentPlayerName_FK", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CurrentPlayerName_FK", userId);
            }
            cmd.Parameters.AddWithValue("@id", 1);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /// <summary>
        /// Показать ник игрока сверху
        /// </summary>
        private void GetUserName()
        {
            int? temp;
            cmd = new SqlCommand("Select CurrentPlayerName_FK from CurrentPackInfo", con);
            con.Open();
            try
            {
                temp = (int)cmd.ExecuteScalar();
                con.Close();
            }
            catch (NullReferenceException)
            {
                label_LogText.Text = "Привет, пожалуйста войдите в аккаунт.";
                return;
            }
            catch (InvalidCastException)
            {
                label_LogText.Text = "Привет, пожалуйста войдите в аккаунт.";
                return;
            }
            catch (Exception)
            {
                label_LogText.Text = "Привет, пожалуйста войдите в аккаунт.";
                return;
            }
            con.Open();
            cmd = new SqlCommand("Select PlayerName from Players Where Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", temp);
            label_LogText.Text = "Привет, " + (string)cmd.ExecuteScalar();
            con.Close();
        }

        /// <summary>
        /// Получить ID ТЕКУЩЕГО пользователя(игрока)
        /// </summary>
        /// <returns></returns>
        private int? GetCurrentUserID()
        {
            int? temp;
            cmd = new SqlCommand("Select CurrentPlayerName_FK from CurrentPackInfo", con);
            con.Close();
            con.Open();
            try
            {
                temp = (int)cmd.ExecuteScalar();
                con.Close();
            }
            catch (NullReferenceException)
            {
                return null;
            }
            catch (InvalidCastException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            return temp;
        }

        #endregion get/set

        #endregion Рабочие методы

        #region События

        #region разное

        /// <summary>
        /// часы на дом. форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e) => label_TIME.Text = DateTime.Now.ToString();

        /// <summary>
        /// Шорткаты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMainMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                iconButton_Game.PerformClick();
            }
            if (e.KeyCode == Keys.F2)
            {
                iconButton_About.PerformClick();
            }
            if (e.KeyCode == Keys.F3)
            {
                iconButton_Settings.PerformClick();
            }
            if (e.KeyCode == Keys.F4)
            {
                BtnHome_Click(sender, e);
            }
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            LoadResults();
        }

        #endregion разное

        #region результаты

        /// <summary>
        /// Обновить таблицу результаты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Update_Click(object sender, EventArgs e)
        {
            LoadResults();
        }

        /// <summary>
        /// Сбросить резульаты текущего пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDropCurrentUserResults_Click(object sender, EventArgs e)
        {
            int? temp = GetCurrentUserID();
            if (temp == null)
            {
                MessageBox.Show("Войдите в аккаунт");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Данное действие удалит все результаты текщего пользователя" +
                    ".\nЖелаете продолжить?", "ВНИМАНИЕ!", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.No)
                {
                    cmd = new SqlCommand("DELETE FROM ResultLog WHERE PlayerName_FK = @PlayerName_FK", con);
                    con.Close();
                    con.Open();
                    cmd.Parameters.AddWithValue("@PlayerName_FK", temp);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadResults();
                }
            }
        }

        #endregion результаты

        #region Кнопки на левой панели

        /// <summary>
        /// Переключает состояние кнопки game в активное положение. Открывает форму игры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IconButton_Game_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FormGame());
        }

        /// <summary>
        /// Переключает состояние кнопки Settings в активное положение. Открывает форму настроек.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IconButton_Settings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FormSettings());
        }

        /// <summary>
        /// Переключает состояние кнопки About в активное положение. Открывает форму про программу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IconButton_About_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FormAbout());
        }

        /// <summary>
        /// Кнопка домой. При нажатии на название программы в левом верхнем углу текущая дочерняя
        /// форма будет закрыта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                Reset();
            }
        }

        #endregion Кнопки на левой панели

        #region Управление формой справа сверху

        /// <summary>
        /// Кнопка выхода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IconButton_Exit_Click(object sender, EventArgs e) => Application.Exit();

        /// <summary>
        /// максимизировать окно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IconButton_Maximize_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        /// <summary>
        /// минимизировать окно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IconButton_Minimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        #endregion Управление формой справа сверху

        #region Двигать форму за верхнюю панель

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        /// <summary>
        /// двигать за верхнюю панель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        /// <summary>
        /// двигать за лейбл на в. панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblTitleChildForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        /// <summary>
        /// двигать за иконку на в. панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IconCurrentChildForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        #endregion Двигать форму за верхнюю панель

        #region аккаунт

        #region подсказка для юзера

        /// <summary>
        /// Подсказка для юзера, когда текстбох для логина выбирается пользователем то стираем
        /// введите логин
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Введите логин")
            {
                txtUsername.ForeColor = Color.Black;
                txtUsername.Text = "";
            }
        }

        /// <summary>
        /// Подсказка для юзера, когда снимается выбор текстбокса для логина то записываем в
        /// текстбокс Введите логин
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length == 0)
            {
                txtUsername.ForeColor = Color.BlueViolet;
                txtUsername.Text = "Введите логин";
            }
        }

        /// <summary>
        /// Подсказка для юзера, когда текстбох для пароля выбирается пользователем то стираем
        /// введите пароль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Введите пароль")
            {
                txtPassword.ForeColor = Color.Black;
                txtPassword.Text = "";
            }
        }

        /// <summary>
        /// Подсказка для юзера, когда снимается выбор текстбокса для пароля то записываем в
        /// текстбокс Введите пароль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length == 0)
            {
                txtPassword.ForeColor = Color.BlueViolet;
                txtPassword.Text = "Введите пароль";
            }
        }

        #endregion подсказка для юзера

        #region кнопки

        /// <summary>
        /// Логин
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            //проверки
            if (txtUsername.Text.Length < 1)
            {
                MessageBox.Show("Логин должен быть не короче одного символа");
                return;
            }
            if (txtPassword.Text.Length < 1)
            {
                MessageBox.Show("Пароль должен быть не короче одного символа");
                return;
            }

            DataTable dtbl = new DataTable();

            string query = "Select * from Players Where PlayerName = '" + txtUsername.Text.Trim() + "' and Password = '" + txtPassword.Text.Trim() + "'";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            sda.Fill(dtbl);

            if (dtbl.Rows.Count == 1)//если такой аккаунт есть то
            {
                SetUserName(dtbl.Rows[0].Field<int>("Id")); //записываем его id как fk в таблице CurrentPackInfo
                MessageBox.Show("Вы успешно зашли в аккаунт");
                GetUserName();
            }
            else
            {
                MessageBox.Show("Логин или пароль неправильный");
            }
        }

        /// <summary>
        /// Новый юзер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewAcc_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length < 1 || txtUsername.Text == "Введите логин")
            {
                MessageBox.Show("Логин должен быть не короче одного символа");
                return;
            }
            if (txtPassword.Text.Length < 1 || txtPassword.Text == "Введите пароль")
            {
                MessageBox.Show("Пароль должен быть не короче одного символа");
                return;
            }
            DataTable dtbl = new DataTable();

            string query = "Select * from Players Where PlayerName = '" + txtUsername.Text.Trim() + "' and Password = '" + txtPassword.Text.Trim() + "'";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            sda.Fill(dtbl);

            if (dtbl.Rows.Count == 1)
            {
                MessageBox.Show("Такой юзер уже есть");
            }
            else//создаём новую запись в players
            {
                con.Close();
                con.Open();
                cmd = new SqlCommand("select MAX(Id) FROM Players", con);
                int LastPID = (int)cmd.ExecuteScalar();
                con.Close();

                cmd = new SqlCommand("insert into Players(Id,PlayerName,Password) values(@Id,@PlayerName,@Password)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Id", LastPID + 1);
                cmd.Parameters.AddWithValue("@PlayerName", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Аккаунт создан успешно");
            }
        }

        /// <summary>
        /// выйти из аккаунта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            SetUserName(null);
            MessageBox.Show("Вы успешно вышли из аккаунта");
            GetUserName();
        }

        #endregion кнопки

        #endregion аккаунт

        #endregion События
    }
}