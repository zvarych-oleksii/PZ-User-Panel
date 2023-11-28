using DTO_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IBL
{
    public interface IUserBL
    {
        void AddUser();
        void UpdateUser();
        void DeleteUser();
        List<User> GetUsers();
        User GetUser(int id);
    }
}
