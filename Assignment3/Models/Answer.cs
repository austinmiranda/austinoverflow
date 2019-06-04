using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment3.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [StringLength(4000), Required]
        public String AnswerText { get; set; }

        [Required]
        public virtual Question Question { get; set; }

        public DateTime AnswerDate { get; set; }

        [Required, Column("User_Id")]
        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }

    }
} 