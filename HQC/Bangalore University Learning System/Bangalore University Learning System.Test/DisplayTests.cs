namespace Bangalore_University_Learning_System.Test
{
    using System;

    using Models;
    using Views.Courses;
    using Views.Users;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DisplayTests
    {
        [TestMethod]
        public void TestDetailsViewDisplay()
        {
            string expectedResult = "testCourse" + Environment.NewLine + "No lectures";
            var course = new Course("testCourse");
            var view = new Details(course);
            string actualResult = view.Display();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestEnrollViewDisplay()
        {
            string expectedResult = "Student successfully enrolled in course testCourse.";
            var course = new Course("testCourse");
            var view = new Enroll(course);
            string actualResult = view.Display();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestCreateViewDisplay()
        {
            string expectedResult = "Course testCourse created successfully.";
            var course = new Course("testCourse");
            var view = new Create(course);
            string actualResult = view.Display();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestAddLecturesViewDisplay()
        {
            string expectedResult = "Lecture successfully added to course testCourse.";
            var course = new Course("testCourse");
            var view = new AddLecture(course);
            string actualResult = view.Display();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestLoginUserViewDisplay()
        {
            string expectedResult = "User username logged in successfully.";
            string username = "username";
            string password = "password";
            var user = new User(username, password, Role.Lecturer);
            var view = new Login(user);
            string actualResult = view.Display();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestLogoutUserViewDisplay()
        {
            string expectedResult = "User username logged out successfully.";
            string username = "username";
            string password = "password";
            var user = new User(username, password, Role.Lecturer);
            var view = new Logout(user);
            string actualResult = view.Display();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRegisterUserViewDisplay()
        {
            string expectedResult = "User username registered successfully.";
            string username = "username";
            string password = "password";
            var user = new User(username, password, Role.Lecturer);
            var view = new Register(user);
            string actualResult = view.Display();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}