using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3.Models.ViewModels
{
    public class QuestionAddViewModel
    {

        public SelectList Categories { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Category is required"), DisplayName("Category")]
        public int? CategoryId { get; set; }

        [StringLength(100), Required(ErrorMessage = "Question is required"), DisplayName("Question")]
        [DataType(DataType.MultilineText)]
        public String Name { get; set; }

    }
}