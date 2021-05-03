namespace LearnIT
{
    partial class FormMainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.iconButton_About = new FontAwesome.Sharp.IconButton();
            this.iconButton_Settings = new FontAwesome.Sharp.IconButton();
            this.iconButton_Game = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.iconButton_Minimize = new FontAwesome.Sharp.IconButton();
            this.iconButton_Maximize = new FontAwesome.Sharp.IconButton();
            this.iconButton_Exit = new FontAwesome.Sharp.IconButton();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.label_LogText = new System.Windows.Forms.Label();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonNewAcc = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Update = new System.Windows.Forms.Button();
            this.label_TIME = new System.Windows.Forms.Label();
            this.buttonDropCurrentUserResults = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.panelDesktop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.iconButton_About);
            this.panelMenu.Controls.Add(this.iconButton_Settings);
            this.panelMenu.Controls.Add(this.iconButton_Game);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(280, 853);
            this.panelMenu.TabIndex = 0;
            // 
            // iconButton_About
            // 
            this.iconButton_About.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton_About.FlatAppearance.BorderSize = 0;
            this.iconButton_About.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_About.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_About.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iconButton_About.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton_About.IconChar = FontAwesome.Sharp.IconChar.Question;
            this.iconButton_About.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton_About.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton_About.IconSize = 32;
            this.iconButton_About.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_About.Location = new System.Drawing.Point(0, 260);
            this.iconButton_About.Name = "iconButton_About";
            this.iconButton_About.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton_About.Rotation = 0D;
            this.iconButton_About.Size = new System.Drawing.Size(280, 60);
            this.iconButton_About.TabIndex = 3;
            this.iconButton_About.TabStop = false;
            this.iconButton_About.Text = "Про програму";
            this.iconButton_About.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_About.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton_About.UseVisualStyleBackColor = true;
            this.iconButton_About.Click += new System.EventHandler(this.IconButton_About_Click);
            // 
            // iconButton_Settings
            // 
            this.iconButton_Settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton_Settings.FlatAppearance.BorderSize = 0;
            this.iconButton_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_Settings.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iconButton_Settings.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton_Settings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.iconButton_Settings.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton_Settings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton_Settings.IconSize = 32;
            this.iconButton_Settings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_Settings.Location = new System.Drawing.Point(0, 200);
            this.iconButton_Settings.Name = "iconButton_Settings";
            this.iconButton_Settings.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton_Settings.Rotation = 0D;
            this.iconButton_Settings.Size = new System.Drawing.Size(280, 60);
            this.iconButton_Settings.TabIndex = 2;
            this.iconButton_Settings.TabStop = false;
            this.iconButton_Settings.Text = "Налаштування";
            this.iconButton_Settings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_Settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton_Settings.UseVisualStyleBackColor = true;
            this.iconButton_Settings.Click += new System.EventHandler(this.IconButton_Settings_Click);
            // 
            // iconButton_Game
            // 
            this.iconButton_Game.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton_Game.FlatAppearance.BorderSize = 0;
            this.iconButton_Game.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_Game.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_Game.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iconButton_Game.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton_Game.IconChar = FontAwesome.Sharp.IconChar.Gamepad;
            this.iconButton_Game.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton_Game.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton_Game.IconSize = 32;
            this.iconButton_Game.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_Game.Location = new System.Drawing.Point(0, 140);
            this.iconButton_Game.Name = "iconButton_Game";
            this.iconButton_Game.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton_Game.Rotation = 0D;
            this.iconButton_Game.Size = new System.Drawing.Size(280, 60);
            this.iconButton_Game.TabIndex = 1;
            this.iconButton_Game.TabStop = false;
            this.iconButton_Game.Text = "Гра";
            this.iconButton_Game.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_Game.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton_Game.UseVisualStyleBackColor = true;
            this.iconButton_Game.Click += new System.EventHandler(this.IconButton_Game_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.btnHome);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(280, 140);
            this.panelLogo.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHome.Image = global::LearnIT.Properties.Resources.LogoWhite;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(280, 140);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panelTitleBar.Controls.Add(this.iconButton_Minimize);
            this.panelTitleBar.Controls.Add(this.iconButton_Maximize);
            this.panelTitleBar.Controls.Add(this.iconButton_Exit);
            this.panelTitleBar.Controls.Add(this.lblTitleChildForm);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Controls.Add(this.label_LogText);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(280, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1302, 75);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitleBar_MouseDown);
            // 
            // iconButton_Minimize
            // 
            this.iconButton_Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton_Minimize.FlatAppearance.BorderSize = 0;
            this.iconButton_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_Minimize.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_Minimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.iconButton_Minimize.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton_Minimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton_Minimize.IconSize = 30;
            this.iconButton_Minimize.Location = new System.Drawing.Point(1169, 12);
            this.iconButton_Minimize.Name = "iconButton_Minimize";
            this.iconButton_Minimize.Rotation = 0D;
            this.iconButton_Minimize.Size = new System.Drawing.Size(30, 30);
            this.iconButton_Minimize.TabIndex = 3;
            this.iconButton_Minimize.UseVisualStyleBackColor = true;
            this.iconButton_Minimize.Click += new System.EventHandler(this.IconButton_Minimize_Click);
            // 
            // iconButton_Maximize
            // 
            this.iconButton_Maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton_Maximize.FlatAppearance.BorderSize = 0;
            this.iconButton_Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_Maximize.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_Maximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.iconButton_Maximize.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton_Maximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton_Maximize.IconSize = 30;
            this.iconButton_Maximize.Location = new System.Drawing.Point(1216, 12);
            this.iconButton_Maximize.Name = "iconButton_Maximize";
            this.iconButton_Maximize.Rotation = 0D;
            this.iconButton_Maximize.Size = new System.Drawing.Size(30, 30);
            this.iconButton_Maximize.TabIndex = 2;
            this.iconButton_Maximize.UseVisualStyleBackColor = true;
            this.iconButton_Maximize.Click += new System.EventHandler(this.IconButton_Maximize_Click);
            // 
            // iconButton_Exit
            // 
            this.iconButton_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton_Exit.FlatAppearance.BorderSize = 0;
            this.iconButton_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_Exit.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_Exit.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.iconButton_Exit.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton_Exit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton_Exit.IconSize = 30;
            this.iconButton_Exit.Location = new System.Drawing.Point(1260, 12);
            this.iconButton_Exit.Name = "iconButton_Exit";
            this.iconButton_Exit.Rotation = 0D;
            this.iconButton_Exit.Size = new System.Drawing.Size(30, 30);
            this.iconButton_Exit.TabIndex = 1;
            this.iconButton_Exit.UseVisualStyleBackColor = true;
            this.iconButton_Exit.Click += new System.EventHandler(this.IconButton_Exit_Click);
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitleChildForm.Location = new System.Drawing.Point(78, 24);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(205, 25);
            this.lblTitleChildForm.TabIndex = 1;
            this.lblTitleChildForm.Text = "Домашня сторінка";
            this.lblTitleChildForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitleChildForm_MouseDown);
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.IconSize = 50;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(22, 19);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(50, 50);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            this.iconCurrentChildForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.IconCurrentChildForm_MouseDown);
            // 
            // label_LogText
            // 
            this.label_LogText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_LogText.AutoEllipsis = true;
            this.label_LogText.AutoSize = true;
            this.label_LogText.ForeColor = System.Drawing.Color.White;
            this.label_LogText.Location = new System.Drawing.Point(767, 25);
            this.label_LogText.Name = "label_LogText";
            this.label_LogText.Size = new System.Drawing.Size(273, 17);
            this.label_LogText.TabIndex = 7;
            this.label_LogText.Text = "Привіт, будь ласка увійдіть до аккаунта.";
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(280, 75);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(1302, 9);
            this.panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelDesktop.Controls.Add(this.tableLayoutPanel1);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(280, 84);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1302, 769);
            this.panelDesktop.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(84)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.35791F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.29186F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.42703F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Update, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_TIME, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonDropCurrentUserResults, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.95839F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.25748F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.91417F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1302, 769);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.buttonLogout, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtUsername, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPassword, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonLogin, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonNewAcc, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(219, 208);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLogout.Location = new System.Drawing.Point(3, 123);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(213, 38);
            this.buttonLogout.TabIndex = 7;
            this.buttonLogout.Text = "Вийти";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.ButtonLogout_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtUsername.Location = new System.Drawing.Point(3, 3);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(213, 27);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.Text = "Введіть логін";
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPassword.Location = new System.Drawing.Point(3, 41);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(213, 27);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Text = "Введіть пароль";
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLogin.Location = new System.Drawing.Point(3, 79);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(213, 38);
            this.buttonLogin.TabIndex = 6;
            this.buttonLogin.Text = "Увійти";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // buttonNewAcc
            // 
            this.buttonNewAcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNewAcc.Location = new System.Drawing.Point(3, 167);
            this.buttonNewAcc.Name = "buttonNewAcc";
            this.buttonNewAcc.Size = new System.Drawing.Size(213, 38);
            this.buttonNewAcc.TabIndex = 8;
            this.buttonNewAcc.Text = "Створити новий";
            this.buttonNewAcc.UseVisualStyleBackColor = true;
            this.buttonNewAcc.Click += new System.EventHandler(this.ButtonNewAcc_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(84)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 3);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 217);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1296, 441);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 10;
            // 
            // button_Update
            // 
            this.button_Update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Update.Location = new System.Drawing.Point(3, 664);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(219, 102);
            this.button_Update.TabIndex = 5;
            this.button_Update.Text = "Оновити результати";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // label_TIME
            // 
            this.label_TIME.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_TIME.AutoSize = true;
            this.label_TIME.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_TIME.ForeColor = System.Drawing.Color.White;
            this.label_TIME.Location = new System.Drawing.Point(1155, 79);
            this.label_TIME.Name = "label_TIME";
            this.label_TIME.Size = new System.Drawing.Size(0, 55);
            this.label_TIME.TabIndex = 0;
            this.label_TIME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDropCurrentUserResults
            // 
            this.buttonDropCurrentUserResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDropCurrentUserResults.Location = new System.Drawing.Point(1012, 664);
            this.buttonDropCurrentUserResults.Name = "buttonDropCurrentUserResults";
            this.buttonDropCurrentUserResults.Size = new System.Drawing.Size(287, 102);
            this.buttonDropCurrentUserResults.TabIndex = 6;
            this.buttonDropCurrentUserResults.Text = "Видалити свої результати";
            this.buttonDropCurrentUserResults.UseVisualStyleBackColor = true;
            this.buttonDropCurrentUserResults.Click += new System.EventHandler(this.buttonDropCurrentUserResults_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(84)))));
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(228, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(778, 208);
            this.dataGridView2.StandardTab = true;
            this.dataGridView2.TabIndex = 9;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMainMenu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMainMenu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMainMenu_KeyDown);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.panelDesktop.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton iconButton_Game;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton iconButton_About;
        private FontAwesome.Sharp.IconButton iconButton_Settings;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label lblTitleChildForm;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelDesktop;
        private FontAwesome.Sharp.IconButton iconButton_Exit;
        private FontAwesome.Sharp.IconButton iconButton_Minimize;
        private FontAwesome.Sharp.IconButton iconButton_Maximize;
        private System.Windows.Forms.Label label_TIME;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button buttonNewAcc;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Label label_LogText;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.Button buttonDropCurrentUserResults;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}

