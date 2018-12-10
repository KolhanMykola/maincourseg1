using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudyManager
{
     //Курсів  -Оцінки домашніх завдань.

    public class Student
    {
        private static readonly string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resource\\", "Student.xml");
        private int id;
        private string firstName;
        private string lastName;
        private int phoneNumber;
        private string email;
        private string git;

        public Student()
        {
        }
        
        public Student(string firstName, string lastName, int phoneNumber, string email, string git)
        {
            FirstName = firstName ?? "DefaultFirstName";
            LastName = lastName ?? "DefaultLastName";
            PhoneNumber = phoneNumber;
            Email = email ?? "DefaultEmail";
            Git = git ?? "DefaultGit";
        }

       
        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public string Git { get => git; set => git = value; }

        public void GetStudentList()
        {
            XDocument xdoc = XDocument.Load(path);            
            var list = xdoc.Element("students").Elements("student").Select
                        (p => new {
                            firstName = p.Element("firstName").Value,
                            lastName = p.Element("lastName").Value
                        });

            foreach (var item in list)
                Console.WriteLine(item.firstName + " " + item.lastName);
        }

        public static void AddStudent(Student student)
        {
            student.Id = StudyManager.Id.GetStudent();

            XDocument xdoc = XDocument.Load(path);
            XElement root = xdoc.Element("students");
            root.Add(new XElement("student",
                        new XAttribute("id", student.id),
                        new XElement("firstName", student.FirstName),
                        new XElement("lastName", student.LastName),
                        new XElement("phoneNumber", student.PhoneNumber),
                        new XElement("email", student.Email),
                        new XElement("git", student.Git)));
            
            xdoc.Save(path, SaveOptions.OmitDuplicateNamespaces);

            StudyManager.Id.AddStudent(student.Id);
        }

    }
}
