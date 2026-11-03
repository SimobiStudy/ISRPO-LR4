using LR18LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR18FORM
{
    public partial class ElementForm : Form
    {
        private IBindingList binding;

        private OITStudentRepository StudentRepository;

        public bool HasChanges { get; private set; } = false;
        public ElementForm(BindingSource binding, OITStudentRepository studentRepository)
        {
            InitializeComponent();
            this.binding = binding;
            this.StudentRepository = studentRepository;
        }

        public ElementForm(BindingSource binding, OITStudentRepository studentRepository, OITStudent student) : this(binding, studentRepository)
        {
            LoadStudent(student);
        }

        private void LoadStudent(OITStudent student)
        {
            if (student == null)
                return;
            textBoxName.Text = student.Name;
            comboBox1.Text = student.GroupNumber;
            monthCalendar1.SetDate(student.BirthDay);
            textBoxPhone.Text = student.Phone;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            var stud = StudentRepository.FindFirst(textBoxName.Text);
            if (stud != null)
            {
                var dia = MessageBox.Show("Студент с таким именем уже существует. Вы хотите изменить его данные?", "Подтверждение",
                    MessageBoxButtons.YesNo);
                if (dia == DialogResult.Yes)
                    UpdateItem();

            }
            else
                AddItem();
        }

        private async Task AddItem()
        {
            HasChanges = true;

            binding.Add(new OITStudent
            {
                Name = textBoxName.Text,
                GroupNumber = comboBox1.Text,
                BirthDay = monthCalendar1.SelectionStart,
                Phone = textBoxPhone.Text
            });

            this.Close();
        }

        private async Task DeleteItem()
        {
            HasChanges = true;

            var stud = StudentRepository.FindFirst(textBoxName.Text);
            binding.Remove(stud);

            this.Close();
        }

        private async Task UpdateItem()
        {
            HasChanges = true;

            var stud = StudentRepository.FindFirst(textBoxName.Text);
            if (stud != null)
            {
                stud.Name = textBoxName.Text;
                stud.GroupNumber = comboBox1.Text;
                stud.BirthDay = monthCalendar1.SelectionStart;
                stud.Phone = textBoxPhone.Text;
            }
            ((BindingSource)binding).ResetBindings(false);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var found = StudentRepository.SearchByFullName(textBoxName.Text);

            if (!found.Any())
            {
                MessageBox.Show("Студент с таким именем не найден.");
            }

            LoadStudent(found.ElementAt(0));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var stud = StudentRepository.FindFirst(textBoxName.Text);
            if (stud != null)
            {
                var dia = MessageBox.Show("Вы уверены?", "Подтверждение",
                    MessageBoxButtons.YesNo);
                if (dia == DialogResult.Yes)
                    DeleteItem();

            }
            else
            {
                MessageBox.Show("Студент не найден");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
