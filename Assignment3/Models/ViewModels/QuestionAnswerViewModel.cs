using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment3.Models.ViewModels
{
    public class QuestionAnswerViewModel
    {
       public QuestionViewModel Question { get; set; }

       public IList<AnswerViewModel> Answers { get; set; }

        public AnswerViewModel AddAns { get; set; }

    }
}