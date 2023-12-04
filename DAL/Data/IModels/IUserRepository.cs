using DTO_Core.Models;

namespace DAL.Data.IModels
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        List<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        User GetUserByUsername(string usernama);
    }
}