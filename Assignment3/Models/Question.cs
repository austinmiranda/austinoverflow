using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment3.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [StringLength(4000), Required]
        public String Name { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        public DateTime QuestionDate { get; set; }

        public int ViewCount { get; set; }

        public int AnswerCount { get; set; }

        public int VoteCount { get; set; }

        [Required, Column("User_Id")]
        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }

    }
}