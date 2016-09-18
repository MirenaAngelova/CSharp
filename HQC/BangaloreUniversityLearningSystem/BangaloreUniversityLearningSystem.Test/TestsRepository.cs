using System;
using System.Collections.Generic;
using BangaloreUniversityLearningSystem.Data;
using BangaloreUniversityLearningSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BangaloreUniversityLearningSystem.Test
{
    [TestClass]
    public class TestsRepository
    {
        [TestMethod]
        public void Get_WithANonExistingID_ShouldReturnDefaultValue()
        {
            var repository = new Repository<User>();
            var result = repository.Get(1);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void Get_WithExistingID_ShouldReturnExistingvalue()
        {
            var repository = new Repository<User>();
            var user = new User("user name", "password", Role.Lecturer);
            repository.Add(user);

            var result = repository.Get(1);

            Assert.AreEqual(user, result);
        }

        [TestMethod]
        public void Get_WithManyEntries_ShouldReturnCorrectEntry()
        {
            var repository = new Repository<User>();
            var list = new List<User>();
            for (int i = 0; i < 100; i++)
            {
                var user = new User("user name" + i, "password" + i, Role.Student);
                repository.Add(user);
                list.Add(user);
            }

            var result = repository.Get(5);

            Assert.AreEqual(list[4], result);
        }
    }
}
