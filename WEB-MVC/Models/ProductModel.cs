using System;
using System.ComponentModel.DataAnnotations;

namespace WEB_MVC.Models
{
    public class ProductModel
    {
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }

        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Price")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative number")]
        public decimal Price { get; set; }

        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public CategoryModel Category { get; set; }

        [Display(Name = "Insert Time")]
        public DateTime InsertTime { get; set; }

        [Display(Name = "Update Time")]
        public DateTime UpdateTime { get; set; }
    }
}
