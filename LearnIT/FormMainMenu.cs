using FontAwesome.Sharp; //Библ. с иконками.
using LearnIT.SecondaryForms;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LearnIT
{
    //Мейнформа предаставляет собой меню. Слева на панели будут кнопки для открытия дочерних форм.
    public partial class FormMainMenu : Form
    {
        #region Переменные, структуры, дллимпорты

        private IconButton currentBtn; //Для храниение текущей активной кнопки.
        private Panel leftBorderBtn; //полоска слева от кнопки для красоты. Появляеться после активации кнопки.
        private Form currentChildForm; //для дочерней формы
        public bool isMax;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        /// <summary>
        /// Цвета для кнопок
        /// </summary>
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);

            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        #endregion Переменные, структуры, дллимпорты

        //конструктор
        public FormMainMenu()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 1000;
            leftBorderBtn = new Panel();
            panelMenu.Controls.Add(leftBorderBtn);
            //Настраиваем вид формы
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            FormBorderStyle = FormBorderStyle.None;
        }

        #region Рабочие методы

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
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Size = new Size(7, currentBtn.Height);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon

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
            //Закрывает открытую форму если такая есть
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
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

        #endregion Рабочие методы

        #region События нажатия кнопок

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

        private void IconButton_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IconButton_Maximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                isMax = true;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                isMax = false;
            }
        }

        private void IconButton_Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion Управление формой справа сверху

        #region Двигать форму за верхнюю панель

        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void LblTitleChildForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void IconCurrentChildForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        #endregion Двигать форму за верхнюю панель

        #endregion События нажатия кнопок

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_TIME.Text = DateTime.Now.ToString();
        }
    }
}