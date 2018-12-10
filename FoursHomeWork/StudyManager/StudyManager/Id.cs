using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudyManager
{
    class Id
    {
        private static readonly string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resource\\", "Id.xml");

        public static int GetStudent()
        {
            XDocument xdoc = XDocument.Load(path);
            var list = xdoc.Element("id").Elements("student").First();
            return int.Parse(list.Value) + 1;
        }

        internal static void AddStudent(int id)
        {
            XDocument xdoc = XDocument.Load(path);
            XElement xe = xdoc.Element("id");
            xe.Element("student").Value = id.ToString();
            xdoc.Save(path, SaveOptions.OmitDuplicateNamespaces);
        }

        public static int GetCourse()
        {
            XDocument xdoc = XDocument.Load(path);
            var list = xdoc.Element("id").Elements("course").First();
            return int.Parse(list.Value) + 1;
        }

        public static int GetLector()
        {
            XDocument xdoc = XDocument.Load(path);
            var list = xdoc.Element("id").Elements("lector").First();
            return int.Parse(list.Value) + 1;
        }

        public static int GetHomeWork()
        {
            XDocument xdoc = XDocument.Load(path);
            var list = xdoc.Element("id").Elements("homeWork").First();
            return int.Parse(list.Value) + 1;
        }

       
    }
}
