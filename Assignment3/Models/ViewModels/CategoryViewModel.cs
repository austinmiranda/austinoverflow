using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment3.Models.ViewModels
{
    public class CategoryViewModel
    {
        
        public int Id { get; set; }

        [StringLength(100), Required(ErrorMessage = "Category is required"), DisplayName("Category Name")]
        public String Name { get; set; }
    }
}