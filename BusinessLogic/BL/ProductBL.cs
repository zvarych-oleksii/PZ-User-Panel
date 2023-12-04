using BusinessLogic.IBL;
using DAL.Data.IModels;
using DAL.Data.Models;
using DTO_Core.Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.BL
{
    public class ProductBL : IProductBL
    {
        private readonly IProductRepository _productRepository;

        public ProductBL(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProduct(int productId)
        {
            return _productRepository.GetProductById(productId);
        }
    }
}
