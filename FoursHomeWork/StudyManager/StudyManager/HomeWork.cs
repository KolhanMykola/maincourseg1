using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyManager
{
    //-Курсу  -Оцінки домашніх завдань


    class HomeWork
    {
        private int id;
        private string name;
        private string description;
        private DateTime date;
        private int number;

        public HomeWork(string name, string description, DateTime date, int number)
        {
            Name = name ?? "DefaultName";
            Description = description ?? "DefaultDescription";
            Date = date;
            Number = number;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Number { get => number; set => number = value; }
    }
}
