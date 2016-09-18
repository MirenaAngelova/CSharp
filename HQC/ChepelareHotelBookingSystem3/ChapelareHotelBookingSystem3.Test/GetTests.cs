using System;
using System.Collections.Generic;
using ChepelareHotelBookingSystem3.Data;
using ChepelareHotelBookingSystem3.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChapelareHotelBookingSystem3.Test
{
    [TestClass]
    public class GetTests
    {
        [TestMethod]
        public void Reposirory_GetInvalidItem_ShouldReturnNull()
        {
            var repository = new Repository<User>();
            var user = new User("user name", "password", Roles.User);
            repository.Add(user);

            var result = repository.Get(100);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Reposirory_GetInvalidItem2_ShouldReturnNull()
        {
            var repository = new Repository<User>();
            var user = new User("user name", "password", Roles.User);
            repository.Add(user);

            var result = repository.Get(-100);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Reposirory_GetItemFromListOfItems_ShouldReturnActualItem()
        {
            var repository = new Repository<User>();
            var list = new List<User>();
            for (int i = 0; i < 100; i++)
            {
                var user = new User("user name" + i, "password" + i, Roles.User);
                repository.Add(user);
                list.Add(user);
            }
            
            var result = repository.Get(100);

            Assert.AreEqual(result, list[99]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Repository_GetItemWithInvaildUsername_ShouldReturnAppropriateMessage()
        {
            var repository = new Repository<User>();
            var user = new User("user", "passwort", Roles.User);
            repository.Add(user);

            var result = repository.Get(1);

            Assert.AreEqual("The username must be at least 5 symbols long.", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Repository_GetItemWithInvaildPassword_ShouldReturnAppropriateMessage()
        {
            var repository = new Repository<User>();
            var user = new User("user name", "pass", Roles.User);
            repository.Add(user);

            var result = repository.Get(1);

            Assert.AreEqual("The password must be at least 6 symbols long.", result);
        }
    }
}
