using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PZ_User_Panel_DTO.Models;

namespace PZ_User_Panel_BL.BusinessLogic.ILogic
{
    public interface IProductService
    {
        void SaveProduct(Product product);
    }
}
