using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment3.Models.ViewModels
{
    public class AnswerViewModel
    {
        public int? Id { get; set; }

        [StringLength(500), Required(ErrorMessage = "Answer is required"), DisplayName("Answer")]
        [DataType(DataType.MultilineText)]
        public String Answer{ get; set; }

        public int? QuestionId { get; set; }


        public DateTime AnswerDate { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string UserId { get; set; }

    }
}