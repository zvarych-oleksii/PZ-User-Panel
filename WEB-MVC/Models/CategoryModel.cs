using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WEB_MVC.Models;

namespace WEB_MVC.Models
{
    public class CategoryModel
    {
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; }

        [Display(Name = "Products")]
        public ICollection<ProductModel> Products { get; set; }

        [Display(Name = "Insert Time")]
        public DateTime InsertTime { get; set; }

        [Display(Name = "Update Time")]
        public DateTime UpdateTime { get; set; }
    }
}
