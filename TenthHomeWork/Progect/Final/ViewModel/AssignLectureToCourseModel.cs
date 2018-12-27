using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ViewModel
{
    public class AssignLectureToCourseModel
    {
        public string CourseName { get; set; }
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }

        public List<LectureViewModel> Lectures { get; set; }


        public class LectureViewModel
        {
            public bool IsChecked { get; set; }
            public string Name { get; set; }
            public int Id { get; set; }
        }
    }
}
