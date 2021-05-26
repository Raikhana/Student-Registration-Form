using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm
{
    public partial class frmCourseRegistrationForm : Form
    {
        public frmCourseRegistrationForm()
        {
            InitializeComponent();
        }

        private List<Student> students = null;

        private void FrmStudents_Load(object sender, EventArgs e)
        {
            students = StudentDB.GetStudents();
            FillStudentListBox();
        }

        private void FillStudentListBox()
        {
            lstRegistration.Items.Clear();
            foreach (Student c in students)
            {
                lstRegistration.Items.Add(c.GetDisplayText());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lstRegistration.SelectionMode = SelectionMode.None;
            RegistrationTemplate addStudentForm = new RegistrationTemplate();
            Student student = addStudentForm.GetNewStudent();
            if (student != null)
            {
                students.Add(student);
                StudentDB.SaveStudents(students);
                FillStudentListBox();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstRegistration.SelectedItem == null)
            {
                MessageBox.Show("You must select a line to delete .", "Entry Error");
                lstRegistration.SelectionMode = SelectionMode.One;
                lstRegistration.Focus();
            }
            else
            {
                int i = lstRegistration.SelectedIndex;
                if (i != -1)
                {
                    Student customer = students[i];
                    string message = "Are you sure you want to delete "
                        + customer.StudentName + " from " + customer.Courses + "  course ?";
                    DialogResult button = MessageBox.Show(message, "Confirm Delete",
                        MessageBoxButtons.YesNo);
                    if (button == DialogResult.Yes)
                    {
                        students.Remove(customer);
                        StudentDB.SaveStudents(students);
                        FillStudentListBox();
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_MouseMove(object sender, MouseEventArgs e)
        {
            lstRegistration.SelectionMode = SelectionMode.None;
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            lstRegistration.SelectionMode = SelectionMode.One;
        }
    }
}
