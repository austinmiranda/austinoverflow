using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment3.Models.ViewModels
{
    public class CategoriesViewModel
    {
        public IList<CategoryViewModel> Categories { get; set; }

        public CategoryViewModel AddCat { get; set; }
    }
}