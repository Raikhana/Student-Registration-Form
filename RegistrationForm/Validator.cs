using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm
{
    public class Validator
    {
        private static string title = "Entry Error";

        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public static bool IsPresent(TextBox textBox, string v)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(textBox.Tag + v + " is a required field.", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        public static bool IsPresentComboBox(ComboBox comboBox, string v)
        {
            if (comboBox.SelectedIndex == 0)
            {
                MessageBox.Show(comboBox.Tag + v + " is a required field.", Title);
                comboBox.Focus();
                return false;
            }
            return true;
        }

        public static bool IsPresentDateTimePicker(DateTimePicker dateTimePicker, string v)
        {
            DateTime currentDate = DateTime.Today;
            DateTime birthDate = DateTime.Parse(dateTimePicker.Text);
            if (currentDate <= birthDate)
            {
                MessageBox.Show(dateTimePicker.Tag + v + " is a required field.", Title);
                dateTimePicker.Focus();
                return false;
            }
            return true;
        }

        public static bool IsInt64(TextBox textBox, string v)
        {
            string phoneNumber = textBox.Text.Trim(); //txtPhoneNumber.Text
            string digitsOnly = "";
            foreach (char c in phoneNumber)
            {
                if (!(
                    c == '(' || c == ')' ||
                    c == ' ' || c == '-' || c == '.'
                    ))
                {
                    digitsOnly += c;
                }
            }
            textBox.Text = digitsOnly;

            if (digitsOnly.Length == 10)
            {
                long number = 0;
                if (Int64.TryParse(textBox.Text, out number))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(textBox.Tag + v + " must be an integer.", Title);
                    textBox.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("The phone number must be 10 digits. .", Title);
                return false;
            }

        }

        public static bool IsValidEmail(TextBox textBox, string v)
        {
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (Regex.IsMatch(textBox.Text, pattern))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + v + " must be a valid email address.", Title);
                textBox.Focus();
                return false;
            }
        }
    }
}
