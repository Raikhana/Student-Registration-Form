using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm
{
    public partial class RegistrationTemplate : Form
    {
        public RegistrationTemplate()
        {
            InitializeComponent();
        }
        private Student student = null;
        public Student GetNewStudent()
        {
            this.ShowDialog();
            return student;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                string fullName = txtStudentName.Text; // txtStudentName
                string[] names = fullName.Trim().Split(' ');

                string first = "";
                string middle = "";
                string last = "";

                if (names.Length == 1)
                    first = names[0];
                else if (names.Length == 2)
                {
                    first = names[0];
                    last = names[1];
                }
                else if (names.Length > 2)
                {
                    first = names[0];
                    middle = names[1];
                    last = names[2];
                    if (!Regex.Match(this.ToInitialCap(middle), "^[A-Z][a-zA-Z]*$").Success)
                    { 
                        MessageBox.Show("Invalid middle name", "Message");
                        txtStudentName.Focus();
                        return;
                    }
                }
                if (!Regex.Match(this.ToInitialCap(first), "^[A-Z][a-zA-Z]*$").Success)
                {
                    MessageBox.Show("Invalid first name", "Message");
                    txtStudentName.Focus();
                    return;
                }
               
                if (!Regex.Match(this.ToInitialCap(last), "^[A-Z][a-zA-Z]*$").Success)
                { 
                    MessageBox.Show("Invalid last name", "Message");
                    txtStudentName.Focus();
                    return;
                }

                txtStudentName.Text = this.ToInitialCap(first) + " " +
                                    this.ToInitialCap(middle) + " " +
                                    this.ToInitialCap(last);
                string studentName = this.ToInitialCap(first) + " " +
                                    this.ToInitialCap(middle) + " " +
                                    this.ToInitialCap(last);

                student = new Student(txtStudentName.Text, Convert.ToDateTime(dtpBirthdate.Text), cmbGender.Text,
                                     txtStudentEmail.Text, Convert.ToInt64(txtPhoneNumber.Text), cmbCourses.Text);
                this.Close();
            }

        }
        private string ToInitialCap(string s)
        {
            if (s.Length > 0)
            {
                string initialCap = s.Substring(0, 1).ToUpper();
                string lowerCaseLetters = s.Substring(1).ToLower();
                s = initialCap + lowerCaseLetters;
            }
            return s;
        }

        private bool IsValidData()
        {
            return Validator.IsPresent(txtStudentName, "Student Name") &&
                   Validator.IsPresent(txtStudentEmail, "Student Email") &&
                   Validator.IsPresentComboBox(cmbGender, "Gender") &&
                   Validator.IsPresentComboBox(cmbCourses, "Courses") &&
                   Validator.IsPresentDateTimePicker(dtpBirthdate, "Birthdate") &&
                   Validator.IsPresent(txtPhoneNumber, "Phone Number") &&
                   Validator.IsValidEmail(txtStudentEmail, "Student E-mail") &&
                   Validator.IsInt64(txtPhoneNumber, "Phone Number");
        }

        private void RegistrationTemplate_Load(object sender, EventArgs e)
        {
            string[] gender = { "Select: ", "Male", "Female" };
            foreach (string g in gender)
            {
                cmbGender.Items.Add(g);
            }
            cmbGender.SelectedIndex = 0;

            string[] courses = { "Select: ", "Baker", "Baking and Pastry Arts", "Cook", "Professional Cooking" };
            foreach (string course in courses)
            {
                cmbCourses.Items.Add(course);
            }
            cmbCourses.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
