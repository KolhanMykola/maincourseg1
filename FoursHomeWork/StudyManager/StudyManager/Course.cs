using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudyManager
{
    //-Студентів -Домашніх завдань -Лекторів
    
    class Course
    {
        private static readonly string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resource\\", "Course.xml");
        private int id;
        private string name;
        private DateTime beginDate;
        private DateTime endDate;
        private int pasMark;

        public Course()
        {
        }

        public Course(string name, DateTime beginDate, DateTime endDate, int pasMark)
        {
            Name = name ?? "DefaultName";
            BeginDate = beginDate;
            EndDate = endDate;
            PasMark = pasMark;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime BeginDate { get => beginDate; set => beginDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public int PasMark { get => pasMark; set => pasMark = value; }

        public void GetCourseList()
        {
            XDocument xdoc = XDocument.Load(path);
            var list = xdoc.Element("courses").Elements("course").Select
                        (p => p.Element("name").Value);

            foreach (var item in list)
                Console.WriteLine(item);
        }
    }
}
