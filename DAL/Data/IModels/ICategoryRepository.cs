using DTO_Core.Models;

namespace PZ_User_Panel_console.Data.IModels
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(int categoryId);
        Category GetCategoryByName(string categoryName);
        List<Category> GetAllCategories();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryId);
    }
}
