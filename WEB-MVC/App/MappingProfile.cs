using DTO_Core.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WEB_MVC.Models;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace WEB_MVC.App
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Cart, CartModel>().ReverseMap();
            CreateMap<User,  UserModel>().ReverseMap();
        }
    }
}
