using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyManager
{
    //-Курсу -Домашнього завдання


    class HomeWorkMark
    {
        private int id;
        private DateTime date;
        private string isDone;

        public HomeWorkMark(DateTime date, string isDone)
        {
            Date = date;
            IsDone = isDone ?? "DefaultIsDone";
        }

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string IsDone { get => isDone; set => isDone = value; }
    }
}
