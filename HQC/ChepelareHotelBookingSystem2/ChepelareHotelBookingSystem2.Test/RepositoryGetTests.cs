namespace ChepelareHotelBookingSystem2.Test
{
    using System;

    using Data;
    using Interfaces;
    using Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RepositoryGetTests
    {
        [TestMethod]
        public void RepositoryGetFromOneItem_ShouldReturnCorrectResult()
        {
            //Arrange
            IRepository<User> repository = new Repository<User>();
            User user = new User("test user", "userPassword", Roles.User);
            repository.Add(user);

            //Act
            User foundUser = repository.Get(1);

            //Assert
            Assert.AreEqual(user, foundUser);
        }

        [TestMethod]
        public void RepositoryGetFromMultipleItems_ShouldReturnCorrectResult()
        {
            IRepository<User> repository = new Repository<User>();
            User user1 = new User("user1", "password1", Roles.User);
            User user2 = new User("user2", "password2", Roles.User);
            User user3 = new User("user3", "password3", Roles.User);
            User user4 = new User("user4", "password4", Roles.User);
            User user5 = new User("user5", "password5", Roles.User);
            repository.Add(user1);
            repository.Add(user2);
            repository.Add(user3);
            repository.Add(user4);
            repository.Add(user5);

            User foundUser = repository.Get(5);

            Assert.AreEqual(user5, foundUser);
        }

        [TestMethod]
        public void RepositoryGetFromEmpty_ShouldReturnNull()
        {
            IRepository<User> repository = new Repository<User>();
          
            User foundUser = repository.Get(1);

            Assert.AreSame(null, foundUser);
        }

        [TestMethod]
        public void RepositoryGetInvalidIndex_ShouldReturnNull()
        {
            IRepository<User> repository = new Repository<User>();
            User user = new User("test user", "test password", Roles.User);
            repository.Add(user);

            User foundUser = repository.Get(2);

            Assert.AreEqual(null, foundUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RepositoryGetNegativeIndex_ShouldReturnAppropriateMessage()
        {
            IRepository<User> repository = new Repository<User>();
            User user = new User("user", "pass", Roles.User);
            repository.Add(user);

            User foundUser = repository.Get(-1);

            Assert.AreEqual("The username must be at least 5 symbols long.", foundUser);
        }
    }
}
