using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment3.Models.ViewModels
{
    public class EditAnswerViewModel
    {
        public int? Id { get; set; }

        [StringLength(500), Required(ErrorMessage = "Answer is required"), DisplayName("Edit Answer")]
        [DataType(DataType.MultilineText)]
        public String Answer { get; set; }

        public int? QuestionId { get; set; }

    }
}