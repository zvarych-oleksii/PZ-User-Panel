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
        void AddCategory();
        void DeleteCategory();
        void UpdateCategory();
        List<Category> GetCategories();
        Category GetCategory(int id);
    }
}
