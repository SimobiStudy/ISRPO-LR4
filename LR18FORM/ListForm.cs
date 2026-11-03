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
    public partial class ListForm : Form
    {
        public OITStudentRepository studentRepository;

        public const string FILE_PATH = "students.json";
        public ListForm()
        {
            InitializeComponent();
            dataGVSource = new BindingSource();
            studentRepository = new OITStudentRepository(FILE_PATH);

            dataGVSource.DataSource = studentRepository;
            dataGV.DataSource = dataGVSource;
            ElementChange(this, EventArgs.Empty);
        }

        private void ElementChange(object sender, EventArgs e)
        {
            labelCount.Text = studentRepository.Count().ToString();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;

            var students = studentRepository.SearchByGroupNumber(textBox1.Text, 50, 0);

            if (students.Any())
            {
                dataGVSource.DataSource = students;
            }
            else
                MessageBox.Show("Студенты не найдены.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGVSource.Clear();
            studentRepository.Clear();
            labelCount.Text = "0";
        }

        private void dataGV_DoubleClick(object sender, EventArgs e)
        {
            ElementForm elementForm;
            var element = (OITStudent)dataGV.CurrentRow?.DataBoundItem!;
            dataGVSource.DataSource = studentRepository;

            elementForm = new ElementForm(dataGVSource, studentRepository, element);

            elementForm.ShowDialog();

            if (elementForm.HasChanges)
            {
                labelCount.Text = studentRepository.Count().ToString();
                studentRepository.SerializeAsync();
            }

        }

        private void dataGVSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            ElementChange(sender, e);
        }

        private void dataGVSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            ElementChange(sender, e);
        }

        private void dataGVSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            ElementChange(sender, e);
        }

        private void SortRadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (!rb.Checked) return;

            List<OITStudent> sorted = new List<OITStudent>(studentRepository);

            if (rb == rButtonGroupSort)
                sorted.Sort((a, b) => string.Compare(a.GroupNumber, b.GroupNumber, StringComparison.Ordinal));
            else if (rb == rButtonNameSort)
                sorted.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));
            else if (rb == rButtonBirthDaySort)
                sorted.Sort((a, b) => a.BirthDay.CompareTo(b.BirthDay));
            else if (rb == rButtonPhoneSort)
                sorted.Sort((a, b) => string.Compare(a.Phone, b.Phone, StringComparison.Ordinal));

            dataGVSource.DataSource = sorted;
        }
    }
}
