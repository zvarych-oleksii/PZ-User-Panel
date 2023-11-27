using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PZ_User_Panel_console.Data.Models;
using PZ_User_Panel_console.Context;
using System.Collections.Generic;
using System.Linq;
using PZ_User_Panel_console.Context;

namespace PZ_DAL_Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PZ_User_Panel_console.Data.Models;
    using PZ_User_Panel_console.Context;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class UserRepositoryTests
    {
        private UserRepository _userRepository;
        private StoreDBContext _dbContext;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<StoreDBContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            _dbContext = new StoreDBContext(options);
            _userRepository = new UserRepository(_dbContext);
        }

        [TestMethod]
        public void AddUser_Should_Add_User()
        {
            var user = new User
            {
                UserId = 1,
                UserName = "TestUser1",
                Password = "Password1"
            };

            _userRepository.AddUser(user);

            var addedUser = _dbContext.User_.FirstOrDefault(u => u.UserId == user.UserId);

            Assert.IsNotNull(addedUser);
            Assert.AreEqual(user.UserName, addedUser.UserName);
            Assert.AreEqual(user.Password, addedUser.Password);
           
        }

        [TestMethod]
        public void GetUserByUsername_Should_Return_User()
        {
            var usernameToFind = "TestUser2";
            var passwordToFind = "Password2";

            var user = new User
            {
                UserId = 2,
                UserName = usernameToFind,
                Password = passwordToFind
               
            };

            _userRepository.AddUser(user);

            var retrievedUser = _userRepository.GetUserByUsername(usernameToFind);

            Assert.IsNotNull(retrievedUser);
            Assert.AreEqual(usernameToFind, retrievedUser.UserName);
            Assert.AreEqual(passwordToFind, retrievedUser.Password);
           
        }

        [TestMethod]
        public void GetUserById_Should_Return_This_User()
        {
            var expectedUser = new User
            {
                UserId = 3,
                UserName = "TestUser3",
                Password = "Password3"
           
            };

            _userRepository.AddUser(expectedUser);

            var retrievedUser = _userRepository.GetUserById(3);

            Assert.IsNotNull(retrievedUser);
            Assert.AreEqual(expectedUser.UserId, retrievedUser.UserId);
            Assert.AreEqual(expectedUser.UserName, retrievedUser.UserName);
      
        }

        [TestMethod]
        public void UpdateUser_Should_Update_User()
        {
            var originalUser = new User
            {
                UserId = 4,
                UserName = "TestUser4",
                Password = "Password4"
              
            };

            _userRepository.AddUser(originalUser);

            var updatedUser = new User
            {
                UserId = 4,
                UserName = "UpdatedUser",
                Password = "UpdatedPassword"
          
            };

            _userRepository.UpdateUser(updatedUser);

            var retrievedUser = _userRepository.GetUserById(4);

            Assert.IsNotNull(retrievedUser);
            Assert.AreEqual(updatedUser.UserName, retrievedUser.UserName);
            Assert.AreEqual(updatedUser.Password, retrievedUser.Password);
     
        }

        [TestMethod]
        public void DeleteUser_Should_Delete_User()
        {
            var user = new User
            {
                UserId = 5,
                UserName = "TestUser5",
                Password = "Password5"
              
            };

            _userRepository.AddUser(user);
            _userRepository.DeleteUser(5);

            var deletedUser = _userRepository.GetUserById(5);

            Assert.IsNull(deletedUser);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _dbContext = null;
            _userRepository = null;
        }
    }
}
