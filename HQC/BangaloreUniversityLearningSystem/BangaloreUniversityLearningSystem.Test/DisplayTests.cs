using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BangaloreUniversityLearningSystem.Infrastructure;
using BangaloreUniversityLearningSystem.Models;
using BangaloreUniversityLearningSystem.Views.Courses;
using BangaloreUniversityLearningSystem.Views.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BangaloreUniversityLearningSystem.Test
{
    [TestClass]
    public class DisplayTests
    {
        [TestMethod]
        public void TestDisplayLoginUser_ShouldReturnMessage()
        {
            var test = new Login(new User("username", "passowrd", Role.Lecturer));

            var result = test.Display();

            Assert.AreEqual(result, "User username logged in successfully.");
        }

        [TestMethod]
        public void TestDisplayLogoutUser_ShouldReturnMessage()
        {
            var test = new Views.Users.Logout(new User("username", "passowrd", Role.Lecturer));

            var result = test.Display();

            Assert.AreEqual(result, "User username logged out successfully.");
        }

        [TestMethod]
        public void TestDisplayRegisterUser_ShouldReturnMessage()
        {
            var test = new Register(new User("username", "passowrd", Role.Lecturer));

            var result = test.Display();

            Assert.AreEqual(result, "User username registered successfully.");
        }

        [TestMethod]
        public void TestDisplayCoursesAddLecture()
        {
            var course = new Course("course name");
            var test = new AddLecture(course);

            var expected = test.Display();

            Assert.AreEqual(expected, "Lecture successfully added to course course name.");
        }

        [TestMethod]
        public void TestDisplayNullCoursesAll()
        {
            IList<Course> courses = new List<Course>();
            var test = new All(courses);

            var expected = test.Display();

            Assert.AreEqual(expected, "No courses.");
        }

        [TestMethod]
        public void TestDisplayCoursesCreate()
        {
            var course = new Course("course name");
            var test = new Create(course);

            var expected = test.Display();

            Assert.AreEqual(expected, "Course course name created successfully.");
        }

        //[TestMethod]
        //public void TestDisplayCoursesDetails()
        //{
        //    var course = new Course("course name");
        //    IList<Lecture> lectures = new List<Lecture>();
        //    var details = new Details(course);

        //    var expected = details.Display();

        //    Assert.AreEqual(expected, "No lectures");
        //}


        [TestMethod]
        public void TestDisplayCoursesEnroll()
        {
            var course = new Course("course name");
            var enroll = new Enroll(course);

           var expected = enroll.Display();
            Assert.AreEqual(expected, "Student successfully enrolled in course course name.");
        }
        [TestMethod]
        public void TestDisplayNullMethod_ShouldReturnBoolean()
        {
            var test = new TestViewNull();

            var expected = test.Display();

            Assert.IsTrue(expected.Length > 0);
        }

        [TestMethod]
        public void TestDisplayUserLogin_ShouldReturnMessage()
        {
            var test = new TestViewUserLogin();

            var result = test.Display();

            Assert.AreEqual(result, "User user name logged in successfully.");
        }

        public class TestViewNull : All
        {
            public TestViewNull()
                : base(new List<Course>())
            {
            }

        }
        public class TestViewUserLogin : Login
        {
            public TestViewUserLogin()
                : base(new User("user name", "1234567", Role.Student))
            {

            }
        }

    }
}
