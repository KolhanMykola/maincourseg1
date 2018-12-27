namespace Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        public int Id { get; set; }

        [Display(Name = "Name Course:")]
        public string Name { get; set; }        

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int? PassCredits { get; set; }

        public virtual List<HomeTask> HomeTasks { get; set; }//+

        public virtual List<LecturerCourse> Lecturers { get; set; }//+

        public virtual List<StudentCourse> Students { get; set; }//+
    }
}