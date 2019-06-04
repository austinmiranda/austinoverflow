using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment3.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual Question Question { get; set; }

        [Required, Column("User_Id")]
        public string UserId { get; set; }

        public bool VoteUp { get; set; }

        public bool VoteDown { get; set; }


    }
}