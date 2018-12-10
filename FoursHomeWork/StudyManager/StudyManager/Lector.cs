using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyManager
{
    //-Курсів

    class Lector
    {
        private int id;
        private string name;
        private DateTime birthdayDate;

        public Lector(string name, DateTime birthdayDate)
        {
            Name = name ?? "DefaultNate";
            BirthdayDate = birthdayDate;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime BirthdayDate { get => birthdayDate; set => birthdayDate = value; }
    }
}
