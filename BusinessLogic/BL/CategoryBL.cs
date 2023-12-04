using BusinessLogic.IBL;
using DAL.Data.IModels;
using DAL.Data.Models;
using DTO_Core.Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.BL
{
    public class CategoryBL : ICategoryBL
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBL(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void AddCategory(Category category)
        {
            _categoryRepository.AddCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.UpdateCategory(category);
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
        }

        public List<Category> GetCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Category GetCategory(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }
    }
}

