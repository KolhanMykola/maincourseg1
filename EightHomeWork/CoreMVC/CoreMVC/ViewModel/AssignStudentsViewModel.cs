using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.ViewModel
{
    public class AssignStudentsViewModel
    {
        public string CourseName { get; set; }
        public int Id { get; set; }
        public DateTime StartDate { get; set; }

        public List<StudentViewModel> Students { get; set; }
    }


    public class StudentViewModel
    {
        public bool IsChecked { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
