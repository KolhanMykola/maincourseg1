﻿namespace Models.Models
{
    using System;
    using System.Collections.Generic;

    public class StudentCourse
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}