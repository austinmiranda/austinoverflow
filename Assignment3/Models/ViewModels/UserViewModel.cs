using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment3.Models.ViewModels
{
    public class UserViewModel
    {
        public string UserId { get; set; }

        public String UserName { get; set; }

        public DateTime? LockoutEndDate { get; set; } 
    }
}