namespace LR18FORM
{
    partial class ElementForm
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
            monthCalendar1 = new MonthCalendar();
            labelBirthDay = new Label();
            label1 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            textBoxName = new TextBox();
            textBoxPhone = new TextBox();
            label3 = new Label();
            buttonSubmit = new Button();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(228, 148);
            monthCalendar1.Margin = new Padding(11, 9, 11, 9);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 0;
            // 
            // labelBirthDay
            // 
            labelBirthDay.AutoSize = true;
            labelBirthDay.Location = new Point(31, 148);
            labelBirthDay.Margin = new Padding(4, 0, 4, 0);
            labelBirthDay.Name = "labelBirthDay";
            labelBirthDay.Size = new Size(133, 20);
            labelBirthDay.TabIndex = 1;
            labelBirthDay.Text = "Дата рождения";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 27);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 2;
            label1.Text = "Группа:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "23290907/1094", "23290907/1093", "23290907/1092", "23290907/1096", "23290907/1095", "24290907/3094" });
            comboBox1.Location = new Point(228, 27);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(192, 28);
            comboBox1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 85);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 4;
            label2.Text = "ФИО";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(182, 85);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(238, 28);
            textBoxName.TabIndex = 5;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(204, 367);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(216, 28);
            textBoxPhone.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 367);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(143, 20);
            label3.TabIndex = 6;
            label3.Text = "Номер телефона";
            label3.Click += label3_Click;
            // 
            // buttonSubmit
            // 
            buttonSubmit.Location = new Point(41, 447);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(104, 53);
            buttonSubmit.TabIndex = 8;
            buttonSubmit.Text = "Добавить";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // button1
            // 
            button1.Location = new Point(326, 447);
            button1.Name = "button1";
            button1.Size = new Size(70, 53);
            button1.TabIndex = 9;
            button1.Text = "Поиск";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(182, 447);
            button2.Name = "button2";
            button2.Size = new Size(92, 53);
            button2.TabIndex = 10;
            button2.Text = "Удалить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(204, 413);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(216, 28);
            textBox1.TabIndex = 12;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 413);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(143, 20);
            label4.TabIndex = 11;
            label4.Text = "Email";
            // 
            // ElementForm
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 546);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(buttonSubmit);
            Controls.Add(textBoxPhone);
            Controls.Add(label3);
            Controls.Add(textBoxName);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(labelBirthDay);
            Controls.Add(monthCalendar1);
            Font = new Font("Roboto", 10F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ElementForm";
            Text = "Форма элемента студент";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar monthCalendar1;
        private Label labelBirthDay;
        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private TextBox textBoxName;
        private TextBox textBoxPhone;
        private Label label3;
        private Button buttonSubmit;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label4;
    }
}