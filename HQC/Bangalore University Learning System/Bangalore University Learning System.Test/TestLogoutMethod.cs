namespace Bangalore_University_Learning_System.Test
{
    using System;

    using Controllers;
    using Core;
    using Core.Interfaces;
    using Data;
    using Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestLogoutMethod
    {
        [TestMethod]
        public void TestsSuccessfullLogoutReturnAppropriateMessage()
        {
            IBangaloreUniversityData data = new BangaloreUniversityData();
            User user = new User("firstLecturer", "firstPass", Role.Lecturer);
            UsersController controller = new UsersController(data, user);

            string message = controller.Logout().Display();

            Assert.AreEqual("User firstLecturer logged out successfully.", message);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void TestLogoutIfNoUserIsLoggedInShouldReturnAppropriateMessage()
        {
            IBangaloreUniversityData data = new BangaloreUniversityData();
            User user = new User("firstLecturer", "firstPass", Role.Lecturer);
            UsersController controller = new UsersController(data, null);

            controller.Logout().Display();
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void TestLogoutWithWrongUserRoleShouldReturnAppropriateMessage()
        {
            IBangaloreUniversityData data = new BangaloreUniversityData();
            User user = new User("firstLecturer", "firstPass", Role.Guest);
            UsersController controller = new UsersController(data, user);

            controller.Logout().Display();
        }
    }
}
