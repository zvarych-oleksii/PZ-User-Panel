using BusinessLogic.IBL;
using DAL.Data.IModels;
using DAL.Data.Models;
using DTO_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BL
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepository _userRepository;

        public UserBL(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            string salt = GenerateSalt(user.UserName, user.Password);
            user.Salt = salt;
            string passToHash = user.Password + salt;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(passToHash);
            user.Password = passwordHash;
            _userRepository.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUser(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public bool AuthUser(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);

            if (user != null)
            {
                string salt = user.Salt;
                string passToCheck = password + salt;
                var check = BCrypt.Net.BCrypt.Verify(passToCheck, user.Password);

                return check;
            }

            return false;
        }

        public string GenerateSalt(string username, string password)
        {
            return username + ":" + password;
        }

        public string GetSalt(int userId)
        {
            User user = _userRepository.GetUserById(userId);
            return user.Salt;
        }
    }
}
