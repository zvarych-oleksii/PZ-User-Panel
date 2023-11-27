using DTO_Core.Models;
using PZ_User_Panel_console.Context;
using PZ_User_Panel_console.Data.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_User_Panel_console.Data.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDBContext _dbContext;

        public CategoryRepository(StoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddCategory(Category category)
        {
            _dbContext.Category.Add(category);
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var categoryToDelete = _dbContext.Category.Find(categoryId);

            if (categoryToDelete != null)
            {
                _dbContext.Category.Remove(categoryToDelete);
                _dbContext.SaveChanges();
            }
        }

        public List<Category> GetAllCategories()
        {
            return _dbContext.Category.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _dbContext.Category.Find(categoryId);   
        }

        public void UpdateCategory(Category category)
        {
            var existingCategory = _dbContext.Category.Find(category.CategoryId);

            if (existingCategory != null)
            {
                existingCategory.CategoryId = category.CategoryId;
                existingCategory.CategoryName = category.CategoryName;
                _dbContext.SaveChanges();
            }
        }

        public Category GetCategoryByName(string categoryName)
        {
            return _dbContext.Category
                .Where(category => category.CategoryName == categoryName)
                .FirstOrDefault();
        }

    }
}
