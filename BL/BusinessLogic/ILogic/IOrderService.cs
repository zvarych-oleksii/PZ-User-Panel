using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_User_Panel_BL.BusinessLogic.ILogic
{
    public interface IOrderService
    {
        void CreateOrder(int userId, int productId);
        
        void CancelOrder(int orderId);

        void ChangeOrder(int orderId, int quantity);
    }
}
