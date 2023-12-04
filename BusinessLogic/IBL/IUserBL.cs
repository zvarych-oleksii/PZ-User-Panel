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
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        List<User> GetUsers();
        User GetUser(int id);
        bool AuthUser(string username, string password);
        string GenerateSalt(string username, string password);
        string GetSalt(int userId);
    }
}
