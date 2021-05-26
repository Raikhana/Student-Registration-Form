using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm
{
    public static class StudentDB
    {
        private const string dir = @"C:\Users\Raikhana\Documents\StudentNew\";
        private const string path = dir + "Customers.txt";

        public static void SaveStudents(List<Student> students)
        {
            // create the output stream for a text file that exists
            StreamWriter textOut =
                new StreamWriter(
                new FileStream(path, FileMode.Create, FileAccess.Write));

            // write each student
            foreach (Student student in students)
            {
                textOut.Write(student.StudentName + "|");
                textOut.Write(student.Birthdate.ToShortDateString() + "|");
                textOut.Write(student.Gender + "|");
                textOut.Write(student.StudentEmail + "|");
                textOut.Write(student.PhoneNumber + "|");
                textOut.WriteLine(student.Courses);
            }
            // write the end of the document
            textOut.Close();
        }

        public static List<Student> GetStudents()
        {
            // if the directory doesn't exist, create it
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            // create the object for the input stream for a text file
            StreamReader textIn =
                new StreamReader(
                    new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read));

            // create the array list for students
            List<Student> students = new List<Student>();

            // read the data from the file and store it in the ArrayList
            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine();
                string[] columns = row.Split('|');
                Student student = new Student();
                student.StudentName = columns[0];
                student.Birthdate = Convert.ToDateTime(columns[1]);
                student.Gender = columns[2];
                student.StudentEmail = columns[3];
                student.PhoneNumber = Convert.ToInt64(columns[4]);
                student.Courses = columns[5];
                students.Add(student);
            }
            textIn.Close();

            return students;
        }
    }
}
