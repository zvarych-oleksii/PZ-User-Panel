using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_MVC.Models
{
    public class CartModel
    {
        [Display(Name = "Cart ID")]
        [ValidateNever]
        public int CartId { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Insert Time")]
        [ValidateNever]
        public DateTime InsertTime { get; set; }

        [Display(Name = "Update Time")]
        [ValidateNever]
        public DateTime UpdateTime { get; set; }

        [Display(Name = "User ID")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [ValidateNever]
        public UserModel User { get; set; }

        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        [ValidateNever]
        public ProductModel Product { get; set; }
    }
}