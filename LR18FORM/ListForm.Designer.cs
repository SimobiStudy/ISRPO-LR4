namespace LR18FORM
{
    partial class ListForm
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
            components = new System.ComponentModel.Container();
            dataGV = new DataGridView();
            label1 = new Label();
            labelCount = new Label();
            Сортировка = new GroupBox();
            rButtonPhoneSort = new RadioButton();
            rButtonBirthDaySort = new RadioButton();
            rButtonNameSort = new RadioButton();
            rButtonGroupSort = new RadioButton();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            buttonSearch = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            dataGVSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGV).BeginInit();
            Сортировка.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGVSource).BeginInit();
            SuspendLayout();
            // 
            // dataGV
            // 
            dataGV.AllowUserToAddRows = false;
            dataGV.AllowUserToDeleteRows = false;
            dataGV.AllowUserToOrderColumns = true;
            dataGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGV.Location = new Point(57, 204);
            dataGV.Name = "dataGV";
            dataGV.ReadOnly = true;
            dataGV.RowHeadersVisible = false;
            dataGV.RowHeadersWidth = 51;
            dataGV.Size = new Size(494, 210);
            dataGV.TabIndex = 0;
            dataGV.DoubleClick += dataGV_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 455);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 1;
            label1.Text = "Всего записей:";
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Location = new Point(130, 455);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(17, 20);
            labelCount.TabIndex = 2;
            labelCount.Text = "0";
            // 
            // Сортировка
            // 
            Сортировка.Controls.Add(rButtonPhoneSort);
            Сортировка.Controls.Add(rButtonBirthDaySort);
            Сортировка.Controls.Add(rButtonNameSort);
            Сортировка.Controls.Add(rButtonGroupSort);
            Сортировка.Location = new Point(428, 23);
            Сортировка.Name = "Сортировка";
            Сортировка.Size = new Size(235, 154);
            Сортировка.TabIndex = 3;
            Сортировка.TabStop = false;
            Сортировка.Text = "Сортировка";
            // 
            // rButtonPhoneSort
            // 
            rButtonPhoneSort.AutoSize = true;
            rButtonPhoneSort.Location = new Point(6, 116);
            rButtonPhoneSort.Name = "rButtonPhoneSort";
            rButtonPhoneSort.Size = new Size(175, 24);
            rButtonPhoneSort.TabIndex = 3;
            rButtonPhoneSort.TabStop = true;
            rButtonPhoneSort.Text = "по номеру телефона";
            rButtonPhoneSort.UseVisualStyleBackColor = true;
            rButtonPhoneSort.CheckedChanged += SortRadioButtons_CheckedChanged;
            // 
            // rButtonBirthDaySort
            // 
            rButtonBirthDaySort.AutoSize = true;
            rButtonBirthDaySort.Location = new Point(6, 86);
            rButtonBirthDaySort.Name = "rButtonBirthDaySort";
            rButtonBirthDaySort.Size = new Size(157, 24);
            rButtonBirthDaySort.TabIndex = 2;
            rButtonBirthDaySort.TabStop = true;
            rButtonBirthDaySort.Text = "по дате рождения";
            rButtonBirthDaySort.UseVisualStyleBackColor = true;
            rButtonBirthDaySort.CheckedChanged += SortRadioButtons_CheckedChanged;
            // 
            // rButtonNameSort
            // 
            rButtonNameSort.AutoSize = true;
            rButtonNameSort.Location = new Point(6, 56);
            rButtonNameSort.Name = "rButtonNameSort";
            rButtonNameSort.Size = new Size(85, 24);
            rButtonNameSort.TabIndex = 1;
            rButtonNameSort.TabStop = true;
            rButtonNameSort.Text = "по ФИО";
            rButtonNameSort.UseVisualStyleBackColor = true;
            rButtonNameSort.CheckedChanged += SortRadioButtons_CheckedChanged;
            // 
            // rButtonGroupSort
            // 
            rButtonGroupSort.AutoSize = true;
            rButtonGroupSort.Location = new Point(6, 26);
            rButtonGroupSort.Name = "rButtonGroupSort";
            rButtonGroupSort.Size = new Size(111, 24);
            rButtonGroupSort.TabIndex = 0;
            rButtonGroupSort.TabStop = true;
            rButtonGroupSort.Text = "по группам";
            rButtonGroupSort.UseVisualStyleBackColor = true;
            rButtonGroupSort.CheckedChanged += SortRadioButtons_CheckedChanged;
            // 
            // buttonSearch
            // 
            buttonSearch.Font = new Font("Roboto SemiBold", 12F);
            buttonSearch.ForeColor = Color.Blue;
            buttonSearch.Location = new Point(57, 23);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(115, 51);
            buttonSearch.TabIndex = 4;
            buttonSearch.Text = "Поиск";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Roboto SemiBold", 12F);
            button1.ForeColor = Color.FromArgb(192, 0, 0);
            button1.Location = new Point(214, 23);
            button1.Name = "button1";
            button1.Size = new Size(115, 51);
            button1.TabIndex = 5;
            button1.Text = "Сброс";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(170, 109);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(194, 27);
            textBox1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 109);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 7;
            label2.Text = "ГРУППА";
            // 
            // dataGVSource
            // 
            dataGVSource.AddingNew += dataGVSource_AddingNew;
            dataGVSource.BindingComplete += dataGVSource_BindingComplete;
            dataGVSource.DataMemberChanged += ElementChange;
            // 
            // ListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(719, 502);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(buttonSearch);
            Controls.Add(Сортировка);
            Controls.Add(labelCount);
            Controls.Add(label1);
            Controls.Add(dataGV);
            Name = "ListForm";
            Text = "Список студентов ОИТ";
            ((System.ComponentModel.ISupportInitialize)dataGV).EndInit();
            Сортировка.ResumeLayout(false);
            Сортировка.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGVSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGV;
        private Label label1;
        private Label labelCount;
        private GroupBox Сортировка;
        private RadioButton rButtonPhoneSort;
        private RadioButton rButtonBirthDaySort;
        private RadioButton rButtonNameSort;
        private RadioButton rButtonGroupSort;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button buttonSearch;
        private Button button1;
        private TextBox textBox1;
        private Label label2;
        private BindingSource dataGVSource;
    }
}