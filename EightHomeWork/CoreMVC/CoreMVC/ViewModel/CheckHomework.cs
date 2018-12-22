using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.ViewModel
{
    public class CheckHomework
    {
        public string courseName { get; set; }
        public List<CourseCheck> courseChecks {get; set;}
    }

    public class CourseCheck
    {
        public string hometaskName { get; set; }
        public bool  mark { get; set; }
        public int HomeTaskAssessmentId { get; set; }
    }

    
}
