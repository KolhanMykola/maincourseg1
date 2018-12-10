using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;

namespace StudyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.GetStudentList();
            Student.AddStudent(new Student("Kate", "Ivanova", 0965834555, "KateIvanova@gmail.com", "KateIvanova"));
            student.GetStudentList();

            Course course = new Course();
            course.GetCourseList();

            Console.ReadKey();
        }
    }
}
