namespace LearnIT.SecondaryForms
{
    partial class FormGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox_Question = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelQuestion = new System.Windows.Forms.Panel();
            this.button_Next = new System.Windows.Forms.Button();
            this.label_Timer = new System.Windows.Forms.Label();
            this.PlayButton = new FontAwesome.Sharp.IconButton();
            this.tablePanel_Choices = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Answer4 = new System.Windows.Forms.TextBox();
            this.btn_Answer3 = new System.Windows.Forms.TextBox();
            this.btn_Answer2 = new System.Windows.Forms.TextBox();
            this.btn_Answer1 = new System.Windows.Forms.TextBox();
            this.panelQuestion.SuspendLayout();
            this.tablePanel_Choices.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Question
            // 
            this.textBox_Question.BackColor = System.Drawing.Color.Linen;
            this.textBox_Question.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Question.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Question.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox_Question.Location = new System.Drawing.Point(0, 0);
            this.textBox_Question.Multiline = true;
            this.textBox_Question.Name = "textBox_Question";
            this.textBox_Question.ReadOnly = true;
            this.textBox_Question.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Question.Size = new System.Drawing.Size(1284, 722);
            this.textBox_Question.TabIndex = 10;
            this.textBox_Question.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // panelQuestion
            // 
            this.panelQuestion.Controls.Add(this.textBox_Question);
            this.panelQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQuestion.Location = new System.Drawing.Point(0, 0);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Size = new System.Drawing.Size(1284, 722);
            this.panelQuestion.TabIndex = 9;
            this.panelQuestion.Visible = false;
            // 
            // button_Next
            // 
            this.button_Next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Next.Location = new System.Drawing.Point(1025, 3);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(256, 178);
            this.button_Next.TabIndex = 4;
            this.button_Next.Text = "Наступне питання";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.Button_Next_Click);
            // 
            // label_Timer
            // 
            this.label_Timer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Timer.ForeColor = System.Drawing.Color.Gainsboro;
            this.label_Timer.Location = new System.Drawing.Point(1025, 184);
            this.label_Timer.Name = "label_Timer";
            this.label_Timer.Size = new System.Drawing.Size(256, 185);
            this.label_Timer.TabIndex = 7;
            this.label_Timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayButton
            // 
            this.PlayButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayButton.FlatAppearance.BorderSize = 0;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.PlayButton.Font = new System.Drawing.Font("Onyx", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Inch, ((byte)(204)));
            this.PlayButton.ForeColor = System.Drawing.Color.Black;
            this.PlayButton.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.PlayButton.IconColor = System.Drawing.Color.Gainsboro;
            this.PlayButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.PlayButton.IconSize = 120;
            this.PlayButton.Location = new System.Drawing.Point(0, 0);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Rotation = 0D;
            this.PlayButton.Size = new System.Drawing.Size(1284, 722);
            this.PlayButton.TabIndex = 11;
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // tablePanel_Choices
            // 
            this.tablePanel_Choices.ColumnCount = 3;
            this.tablePanel_Choices.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanel_Choices.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanel_Choices.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 262F));
            this.tablePanel_Choices.Controls.Add(this.btn_Answer4, 1, 1);
            this.tablePanel_Choices.Controls.Add(this.btn_Answer3, 0, 1);
            this.tablePanel_Choices.Controls.Add(this.btn_Answer2, 1, 0);
            this.tablePanel_Choices.Controls.Add(this.btn_Answer1, 0, 0);
            this.tablePanel_Choices.Controls.Add(this.label_Timer, 2, 1);
            this.tablePanel_Choices.Controls.Add(this.button_Next, 2, 0);
            this.tablePanel_Choices.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tablePanel_Choices.Location = new System.Drawing.Point(0, 353);
            this.tablePanel_Choices.Name = "tablePanel_Choices";
            this.tablePanel_Choices.RowCount = 2;
            this.tablePanel_Choices.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanel_Choices.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanel_Choices.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanel_Choices.Size = new System.Drawing.Size(1284, 369);
            this.tablePanel_Choices.TabIndex = 12;
            this.tablePanel_Choices.Visible = false;
            // 
            // btn_Answer4
            // 
            this.btn_Answer4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(84)))));
            this.btn_Answer4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.btn_Answer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Answer4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Answer4.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_Answer4.Location = new System.Drawing.Point(514, 187);
            this.btn_Answer4.Multiline = true;
            this.btn_Answer4.Name = "btn_Answer4";
            this.btn_Answer4.ReadOnly = true;
            this.btn_Answer4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.btn_Answer4.Size = new System.Drawing.Size(505, 179);
            this.btn_Answer4.TabIndex = 14;
            this.btn_Answer4.Click += new System.EventHandler(this.Btn_Answer4_Click);
            this.btn_Answer4.MouseEnter += new System.EventHandler(this.Btn_Answer4_MouseEnter);
            this.btn_Answer4.MouseLeave += new System.EventHandler(this.Btn_Answer4_MouseLeave);
            this.btn_Answer4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Btn_Answer4_MouseMove);
            // 
            // btn_Answer3
            // 
            this.btn_Answer3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(84)))));
            this.btn_Answer3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.btn_Answer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Answer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Answer3.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_Answer3.Location = new System.Drawing.Point(3, 187);
            this.btn_Answer3.Multiline = true;
            this.btn_Answer3.Name = "btn_Answer3";
            this.btn_Answer3.ReadOnly = true;
            this.btn_Answer3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.btn_Answer3.Size = new System.Drawing.Size(505, 179);
            this.btn_Answer3.TabIndex = 13;
            this.btn_Answer3.Click += new System.EventHandler(this.Btn_Answer3_Click);
            this.btn_Answer3.MouseEnter += new System.EventHandler(this.Btn_Answer3_MouseEnter);
            this.btn_Answer3.MouseLeave += new System.EventHandler(this.Btn_Answer3_MouseLeave);
            this.btn_Answer3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Btn_Answer3_MouseMove);
            // 
            // btn_Answer2
            // 
            this.btn_Answer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(84)))));
            this.btn_Answer2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.btn_Answer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Answer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Answer2.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_Answer2.Location = new System.Drawing.Point(514, 3);
            this.btn_Answer2.Multiline = true;
            this.btn_Answer2.Name = "btn_Answer2";
            this.btn_Answer2.ReadOnly = true;
            this.btn_Answer2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.btn_Answer2.Size = new System.Drawing.Size(505, 178);
            this.btn_Answer2.TabIndex = 12;
            this.btn_Answer2.Click += new System.EventHandler(this.Btn_Answer2_Click);
            this.btn_Answer2.MouseEnter += new System.EventHandler(this.Btn_Answer2_MouseEnter);
            this.btn_Answer2.MouseLeave += new System.EventHandler(this.Btn_Answer2_MouseLeave);
            this.btn_Answer2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Btn_Answer2_MouseMove);
            // 
            // btn_Answer1
            // 
            this.btn_Answer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(84)))));
            this.btn_Answer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.btn_Answer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Answer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Answer1.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_Answer1.Location = new System.Drawing.Point(3, 3);
            this.btn_Answer1.Multiline = true;
            this.btn_Answer1.Name = "btn_Answer1";
            this.btn_Answer1.ReadOnly = true;
            this.btn_Answer1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.btn_Answer1.Size = new System.Drawing.Size(505, 178);
            this.btn_Answer1.TabIndex = 11;
            this.btn_Answer1.Click += new System.EventHandler(this.Btn_Answer1_Click);
            this.btn_Answer1.MouseEnter += new System.EventHandler(this.Btn_Answer1_MouseEnter);
            this.btn_Answer1.MouseLeave += new System.EventHandler(this.Btn_Answer1_MouseLeave);
            this.btn_Answer1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Btn_Answer1_MouseMove);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1284, 722);
            this.Controls.Add(this.tablePanel_Choices);
            this.Controls.Add(this.panelQuestion);
            this.Controls.Add(this.PlayButton);
            this.Name = "FormGame";
            this.Text = "Гра";
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.panelQuestion.ResumeLayout(false);
            this.panelQuestion.PerformLayout();
            this.tablePanel_Choices.ResumeLayout(false);
            this.tablePanel_Choices.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_Question;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelQuestion;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.Label label_Timer;
        private FontAwesome.Sharp.IconButton PlayButton;
        private System.Windows.Forms.TableLayoutPanel tablePanel_Choices;
        private System.Windows.Forms.TextBox btn_Answer1;
        private System.Windows.Forms.TextBox btn_Answer2;
        private System.Windows.Forms.TextBox btn_Answer4;
        private System.Windows.Forms.TextBox btn_Answer3;
    }
}