namespace BangaloreUniversityLearningSystem.Test
{
    using System;

    using Controllers;
    using Interfaces;
    using Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class UsersControllerTests
    {
        [TestMethod]
        public void Logout_WithValidInput_ShouldLogoutUser()
        {
            var user = new Mock<User>("user name", "passowrd", Role.Student);
            var database = new Mock<IBangaloreUniversityData>();

            var userController = new UsersController(database.Object, user.Object);
            Assert.AreEqual(user.Object, userController.User);

            userController.Logout();

            Assert.AreEqual(null, userController.User);
        }

        [TestMethod]
        public void Logout_WithNoLoggedInUser_ShouldReturnAppropriateExceptionMessage()
        {
            Mock<IBangaloreUniversityData> mockData = new Mock<IBangaloreUniversityData>();
            //var userController = new UsersController(mockData as IBangaloreUniversityData, null);
            var userController = new UsersController(mockData.Object, null);

            string result = string.Empty;
            try
            {
                userController.Logout();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            string expected = "There is no currently logged in user.";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Logout_WithNoAuthorizedUserToPerformAction_ShouldReturnAppropriateExceptionMessage()
        {
            Mock<IBangaloreUniversityData> mockData = new Mock<IBangaloreUniversityData>();
            var user = new User("user name", "password", Role.Guest);
            var userController = new UsersController(mockData as IBangaloreUniversityData, user);

            string result = string.Empty;
            try
            {
                userController.Logout();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            string expected = "The current user is not authorized to perform this operation.";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Logout_WithValidInput_ShouldReturnAppropiateMessage()
        {
            Mock<IBangaloreUniversityData> mockData = new Mock<IBangaloreUniversityData>();
            var user = new User("user name", "password", Role.Student);
            var userController = new UsersController(mockData as IBangaloreUniversityData, user);

            var result = userController.Logout();

            string expected = "User user name logged out successfully.";

            Assert.AreEqual(expected, result.Display());
            Assert.IsInstanceOfType(result, typeof(IView));
        }
    }
}
