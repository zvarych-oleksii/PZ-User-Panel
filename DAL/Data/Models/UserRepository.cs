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
    public class UserRepository : IUserRepository
    {
        private readonly StoreDBContext _dbContext;

        public UserRepository(StoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(User user)
        {
            _dbContext.User_.Add(user);
            _dbContext.SaveChanges();
        }
        public User GetUserByUsername(string username) 
        {
            return _dbContext.User_.FirstOrDefault(u => u.UserName == username);
        }
        public User GetUserById(int userId)
        {
            return _dbContext.User_.FirstOrDefault(u => u.UserId == userId);
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.User_.ToList();
        }

        public void UpdateUser(User user)
        {
            var existingUser = _dbContext.User_.Find(user.UserId);

            if (existingUser != null)
            {
                existingUser.UserId = user.UserId;
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                _dbContext.SaveChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            var userToDelete = _dbContext.User_.FirstOrDefault(u => u.UserId == userId);

            if (userToDelete != null)
            {
                _dbContext.User_.Remove(userToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}