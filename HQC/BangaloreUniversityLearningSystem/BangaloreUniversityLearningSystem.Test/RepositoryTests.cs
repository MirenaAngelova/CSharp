using System;
using System.Collections.Generic;
using BangaloreUniversityLearningSystem.Data;
using BangaloreUniversityLearningSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BangaloreUniversityLearningSystem.Test
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void EmptyGetNonExistingItem_ShouldReturnNull()
        {
            var repository = new Repository<User>();

            var result = repository.Get(-4);

           // Assert.AreEqual(null, result);
           Assert.IsNull(result);
        }

        [TestMethod]
        public void EmptyGetNonExistingItem2_ShouldReturnNull()
        {
            var repository = new Repository<User>();

            var result = repository.Get(30000);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void EmptyGetNonExistingItem3_ShouldReturnNull()
        {
            var repository = new Repository<User>();

            for (int i = 0; i < 200; i++)
            {
                repository.Add(new User("username" + i, "123456" + i, Role.Student));
            }

            var result = repository.Get(201);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void EmptyGetNonExistingItem4_ShouldReturnNull()
        {
            var repository = new Repository<User>();

            for (int i = 0; i < 100; i++)
            {
                repository.Add(new User("username" + i, "123456" + i, Role.Lecturer));
            }

            var result = repository.Get(-200);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetExistingItem()
        {
            var repository = new Repository<User>();
            User user = new User("username", "password", Role.Student);

            repository.Add(user);
            var result = repository.Get(1);

            Assert.AreEqual(user, result);
        }

        [TestMethod]
        public void GetExistingItem2()
        {
            var repository = new Repository<User>();
            var list = new List<User>();
            for (int i = 0; i < 100; i++)
            {
                var user = new User("username" + i, "password" + i, Role.Student);
                repository.Add(user);
                list.Add(user);
            }

            var expected = repository.Get(3);

            Assert.AreEqual(expected, list[2]);
        }

        [TestMethod]
        public void EmptyGetNonExistingCourse_ShouldReturnNull()
        {
            var repository = new Repository<Course>();

            var result = repository.Get(-1);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void EmptyGetNonExistingCourse_ShouldReturnNull2()
        {
            var repository = new Repository<Course>();

            var result = repository.Get(2000000);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void EmptyGetNonExistingCourse_ShouldRetutnNull3()
        {
            var repository = new Repository<Course>();

            for (int i = 0; i < 1000; i++)
            {
                Course course = new Course("course name" + i);
                repository.Add(course);
            }

            var result = repository.Get(1001);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void EmptyGetNonExistingCourse_ShouldReturnNull4()
        {
            var repository = new Repository<Course>();

            for (int i = 0; i < 10; i++)
            {
                var course = new Course("course name" + i);
                repository.Add(course);
            }

            var result = repository.Get(-10); 

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetExistingCourse()
        {
            var repository = new Repository<Course>();
            Course course = new Course("course name");

            repository.Add(course);
            var result = repository.Get(1);

            Assert.AreEqual(course, result);
        }

        [TestMethod]
        public void GetExistingCourse2()
        {
            var repository = new Repository<Course>();
            var list = new List<Course>();
            for (int i = 0; i < 200; i++)
            {
                Course course = new Course("course name" + i);
                repository.Add(course);
                list.Add(course);
            }

            var result = repository.Get(200);

            Assert.AreEqual(result, list[199]);
        }
    }
}
