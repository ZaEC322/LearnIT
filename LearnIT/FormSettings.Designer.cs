namespace LearnIT
{
    partial class FormSettings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_Questions = new System.Windows.Forms.DataGridView();
            this.dataGridView_Choices = new System.Windows.Forms.DataGridView();
            this.button_Remove = new System.Windows.Forms.Button();
            this.a = new System.Windows.Forms.Button();
            this.button_SaveThisDBToXML = new System.Windows.Forms.Button();
            this.button_LoadChosenXML = new System.Windows.Forms.Button();
            this.textBox_dbname = new System.Windows.Forms.TextBox();
            this.button_ChooseXML = new System.Windows.Forms.Button();
            this.tablePanel_GRIDS = new System.Windows.Forms.TableLayoutPanel();
            this.tablePanel_Controls = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Questions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Choices)).BeginInit();
            this.tablePanel_GRIDS.SuspendLayout();
            this.tablePanel_Controls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Questions
            // 
            this.dataGridView_Questions.AllowUserToAddRows = false;
            this.dataGridView_Questions.AllowUserToDeleteRows = false;
            this.dataGridView_Questions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Questions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Questions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_Questions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridView_Questions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Questions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_Questions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Questions.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_Questions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_Questions.EnableHeadersVisualStyles = false;
            this.dataGridView_Questions.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_Questions.MultiSelect = false;
            this.dataGridView_Questions.Name = "dataGridView_Questions";
            this.dataGridView_Questions.RowHeadersVisible = false;
            this.dataGridView_Questions.RowHeadersWidth = 51;
            this.dataGridView_Questions.RowTemplate.Height = 24;
            this.dataGridView_Questions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_Questions.Size = new System.Drawing.Size(1275, 382);
            this.dataGridView_Questions.TabIndex = 31;
            this.dataGridView_Questions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // dataGridView_Choices
            // 
            this.dataGridView_Choices.AllowUserToAddRows = false;
            this.dataGridView_Choices.AllowUserToDeleteRows = false;
            this.dataGridView_Choices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Choices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Choices.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_Choices.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView_Choices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Choices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_Choices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Choices.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView_Choices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_Choices.EnableHeadersVisualStyles = false;
            this.dataGridView_Choices.Location = new System.Drawing.Point(3, 391);
            this.dataGridView_Choices.MultiSelect = false;
            this.dataGridView_Choices.Name = "dataGridView_Choices";
            this.dataGridView_Choices.RowHeadersVisible = false;
            this.dataGridView_Choices.RowHeadersWidth = 51;
            this.dataGridView_Choices.RowTemplate.Height = 24;
            this.dataGridView_Choices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_Choices.Size = new System.Drawing.Size(1275, 188);
            this.dataGridView_Choices.TabIndex = 32;
            // 
            // button_Remove
            // 
            this.button_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Remove.AutoSize = true;
            this.button_Remove.BackColor = System.Drawing.Color.Gainsboro;
            this.button_Remove.FlatAppearance.BorderSize = 0;
            this.button_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Remove.Location = new System.Drawing.Point(1166, 4);
            this.button_Remove.Margin = new System.Windows.Forms.Padding(4);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(114, 36);
            this.button_Remove.TabIndex = 30;
            this.button_Remove.Text = "Видалити";
            this.button_Remove.UseVisualStyleBackColor = false;
            this.button_Remove.Click += new System.EventHandler(this.Button_Remove_Click);
            // 
            // a
            // 
            this.a.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.a.AutoSize = true;
            this.a.BackColor = System.Drawing.Color.Gainsboro;
            this.a.FlatAppearance.BorderSize = 0;
            this.a.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.a.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.a.Location = new System.Drawing.Point(1046, 4);
            this.a.Margin = new System.Windows.Forms.Padding(4);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(112, 36);
            this.a.TabIndex = 27;
            this.a.Text = "Додати";
            this.a.UseVisualStyleBackColor = false;
            this.a.Click += new System.EventHandler(this.Button_Insert_Click);
            // 
            // button_SaveThisDBToXML
            // 
            this.button_SaveThisDBToXML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SaveThisDBToXML.AutoSize = true;
            this.button_SaveThisDBToXML.BackColor = System.Drawing.Color.Gainsboro;
            this.button_SaveThisDBToXML.FlatAppearance.BorderSize = 0;
            this.button_SaveThisDBToXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SaveThisDBToXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_SaveThisDBToXML.Location = new System.Drawing.Point(193, 47);
            this.button_SaveThisDBToXML.Name = "button_SaveThisDBToXML";
            this.button_SaveThisDBToXML.Size = new System.Drawing.Size(184, 40);
            this.button_SaveThisDBToXML.TabIndex = 36;
            this.button_SaveThisDBToXML.Text = "Зберегти";
            this.button_SaveThisDBToXML.UseVisualStyleBackColor = false;
            this.button_SaveThisDBToXML.Click += new System.EventHandler(this.Button_SaveThisDBToXML_Click);
            // 
            // button_LoadChosenXML
            // 
            this.button_LoadChosenXML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_LoadChosenXML.AutoSize = true;
            this.button_LoadChosenXML.BackColor = System.Drawing.Color.Gainsboro;
            this.button_LoadChosenXML.FlatAppearance.BorderSize = 0;
            this.button_LoadChosenXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_LoadChosenXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_LoadChosenXML.Location = new System.Drawing.Point(3, 47);
            this.button_LoadChosenXML.Name = "button_LoadChosenXML";
            this.button_LoadChosenXML.Size = new System.Drawing.Size(184, 40);
            this.button_LoadChosenXML.TabIndex = 0;
            this.button_LoadChosenXML.Text = "Відкрити";
            this.button_LoadChosenXML.UseVisualStyleBackColor = false;
            this.button_LoadChosenXML.Click += new System.EventHandler(this.Button_LoadChosenXML_Click);
            // 
            // textBox_dbname
            // 
            this.tablePanel_Controls.SetColumnSpan(this.textBox_dbname, 3);
            this.textBox_dbname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_dbname.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_dbname.Location = new System.Drawing.Point(3, 3);
            this.textBox_dbname.Name = "textBox_dbname";
            this.textBox_dbname.Size = new System.Drawing.Size(564, 38);
            this.textBox_dbname.TabIndex = 37;
            this.textBox_dbname.TextChanged += new System.EventHandler(this.TextBox_dbname_TextChanged);
            this.textBox_dbname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_dbname_KeyPress);
            // 
            // button_ChooseXML
            // 
            this.button_ChooseXML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ChooseXML.AutoSize = true;
            this.button_ChooseXML.BackColor = System.Drawing.Color.Gainsboro;
            this.button_ChooseXML.FlatAppearance.BorderSize = 0;
            this.button_ChooseXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ChooseXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ChooseXML.Location = new System.Drawing.Point(383, 47);
            this.button_ChooseXML.Name = "button_ChooseXML";
            this.button_ChooseXML.Size = new System.Drawing.Size(184, 40);
            this.button_ChooseXML.TabIndex = 38;
            this.button_ChooseXML.Text = "Вибрати";
            this.button_ChooseXML.UseVisualStyleBackColor = false;
            this.button_ChooseXML.Click += new System.EventHandler(this.Button_ChooseXML_Click);
            // 
            // tablePanel_GRIDS
            // 
            this.tablePanel_GRIDS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablePanel_GRIDS.BackColor = System.Drawing.Color.Transparent;
            this.tablePanel_GRIDS.ColumnCount = 1;
            this.tablePanel_GRIDS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel_GRIDS.Controls.Add(this.dataGridView_Questions, 0, 0);
            this.tablePanel_GRIDS.Controls.Add(this.dataGridView_Choices, 0, 1);
            this.tablePanel_GRIDS.Location = new System.Drawing.Point(3, 44);
            this.tablePanel_GRIDS.Name = "tablePanel_GRIDS";
            this.tablePanel_GRIDS.RowCount = 2;
            this.tablePanel_GRIDS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tablePanel_GRIDS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tablePanel_GRIDS.Size = new System.Drawing.Size(1281, 582);
            this.tablePanel_GRIDS.TabIndex = 40;
            // 
            // tablePanel_Controls
            // 
            this.tablePanel_Controls.BackColor = System.Drawing.Color.Transparent;
            this.tablePanel_Controls.ColumnCount = 6;
            this.tablePanel_Controls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.47417F));
            this.tablePanel_Controls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.47418F));
            this.tablePanel_Controls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.47418F));
            this.tablePanel_Controls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 472F));
            this.tablePanel_Controls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.78873F));
            this.tablePanel_Controls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.78874F));
            this.tablePanel_Controls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanel_Controls.Controls.Add(this.button_ChooseXML, 2, 1);
            this.tablePanel_Controls.Controls.Add(this.button_SaveThisDBToXML, 1, 1);
            this.tablePanel_Controls.Controls.Add(this.button_LoadChosenXML, 0, 1);
            this.tablePanel_Controls.Controls.Add(this.a, 4, 0);
            this.tablePanel_Controls.Controls.Add(this.button_Remove, 5, 0);
            this.tablePanel_Controls.Controls.Add(this.textBox_dbname, 0, 0);
            this.tablePanel_Controls.Controls.Add(this.tableLayoutPanel1, 3, 0);
            this.tablePanel_Controls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tablePanel_Controls.Location = new System.Drawing.Point(0, 632);
            this.tablePanel_Controls.Name = "tablePanel_Controls";
            this.tablePanel_Controls.RowCount = 2;
            this.tablePanel_Controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.65035F));
            this.tablePanel_Controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.34965F));
            this.tablePanel_Controls.Size = new System.Drawing.Size(1284, 90);
            this.tablePanel_Controls.TabIndex = 41;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(573, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tablePanel_Controls.SetRowSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(466, 84);
            this.tableLayoutPanel1.TabIndex = 39;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown1.Location = new System.Drawing.Point(115, 3);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            36000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Час на гру:";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(1284, 722);
            this.Controls.Add(this.tablePanel_Controls);
            this.Controls.Add(this.tablePanel_GRIDS);
            this.Name = "FormSettings";
            this.Text = "Налаштування";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.SizeChanged += new System.EventHandler(this.FormSettings_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Questions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Choices)).EndInit();
            this.tablePanel_GRIDS.ResumeLayout(false);
            this.tablePanel_Controls.ResumeLayout(false);
            this.tablePanel_Controls.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_Questions;
        private System.Windows.Forms.DataGridView dataGridView_Choices;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button a;
        private System.Windows.Forms.Button button_SaveThisDBToXML;
        private System.Windows.Forms.Button button_LoadChosenXML;
        private System.Windows.Forms.TextBox textBox_dbname;
        private System.Windows.Forms.Button button_ChooseXML;
        private System.Windows.Forms.TableLayoutPanel tablePanel_GRIDS;
        private System.Windows.Forms.TableLayoutPanel tablePanel_Controls;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}