using DTO_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IBL
{
    public interface ICategoryBL
    {
        void AddCategory(Category category);
        void DeleteCategory(int categoryId);
        void UpdateCategory(Category category);
        List<Category> GetCategories();
        Category GetCategory(int id);
    }
}
