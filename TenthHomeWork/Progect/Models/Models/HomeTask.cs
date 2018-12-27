﻿namespace Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class HomeTask
    {
        
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Number { get; set; }

        public virtual Course Course { get; set; }//+

        public virtual List<HomeTaskAssessment> HomeTaskAssessments { get; set; }//+
    }
}