using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm
{
    public class Student
    {
        private string studentName;
        private DateTime birthdate;
        private string gender;
        private string studentEmail;
        private long phoneNumber;
        private string courses;

        public Student() { }
        
        public Student(string studentName,DateTime birthdate,string gender,
                       string studentEmail,long phoneNumber,string courses)
        {
            this.StudentName = studentName;
            this.Birthdate = birthdate;
            this.Gender = gender;
            this.StudentEmail = studentEmail;
            this.PhoneNumber = phoneNumber;
            this.Courses = courses;
        }
        public string StudentName
        {
            get
            {
                return studentName;
            }
            set
            {
                studentName = value;
            } 
        }
        public DateTime Birthdate
        {
            get
            {
                return birthdate;
            }
            set
            {
                birthdate = value;
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        public string StudentEmail
        {
            get
            {
                return studentEmail;
            }
            set
            {
                studentEmail = value;
            }
        }
        public long PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }
        public string Courses
        {
            get
            {
                return courses;
            }
            set
            {
                courses = value;
            }
        }

        public string GetDisplayText()
        {
            return studentName + "  |   " + birthdate.ToShortDateString() + "  |   " + gender + "  |   " +
                        studentEmail + "  |   " + phoneNumber + "  |   " + courses;
        }

        public string GetDisplayText(string sep)
        {
            return studentName + "  |   " + birthdate.ToShortDateString() + "  |   " + gender + "  |   " +
                       studentEmail + "  |   " + phoneNumber + "  |   " + courses;
        }
    }
}
