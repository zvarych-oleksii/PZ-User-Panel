using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WEB_MVC.Models;

namespace WEB_MVC.Models
{
    public class UserModel
    {
        [Display(Name = "User ID")]
        public int UserId { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Salt")]
        public string Salt { get; set; }

        [Display(Name = "Insert Time")]
        public DateTime InsertTime { get; set; }

        [Display(Name = "Update Time")]
        public DateTime UpdateTime { get; set; }

        [Display(Name = "Carts")]
        public ICollection<CartModel> Carts { get; set; }
    }
}