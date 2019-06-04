using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment3.Models.ViewModels
{
    public class QuestionViewModel
    {
       
        public int Id { get; set; }

        [Display(Name = "Question")]
        public String Name { get; set; }

        public String Category { get; set; }

        [Display(Name = "Date Created")]
        public DateTime QuestionDate { get; set; }

        [Display(Name = "View Count")]
        public int ViewCount { get; set; }

        [Display(Name = "Answer Count")]
        public int AnswerCount { get; set; }

        [Display(Name = "Vote Count")]
        public int VoteCount { get; set; }

        [Display(Name = "User")]
        public string UserName { get; set; }

    }
}