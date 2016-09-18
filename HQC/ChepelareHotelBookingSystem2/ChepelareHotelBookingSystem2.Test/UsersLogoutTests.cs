namespace ChepelareHotelBookingSystem2.Test
{
    using System;

    using Controllers;
    using Data;
    using Interfaces;
    using Models;
    using Views.Users;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class UsersLogoutTests
    {
        [TestMethod]
        public void UsersLogoutValidUser_ShouldReturnCorrectResult()
        {
            Mock<IHotelBookingSystemData> mockData = new Mock<IHotelBookingSystemData>();
            User user = new User("test user", "password", Roles.User);
            UsersController controller = 
                new UsersController(mockData as IHotelBookingSystemData, user);

            IView view = controller.Logout();
            string result = view.Display();
            string expected = "The user test user has logged out.";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void UsersLogoutNoUserLogged_ShouldThrowExceptionWithAppropriateMessage()
        {
            IHotelBookingSystemData data = new HotelBookingSystemData();
            User user = new User("test user", "password", Roles.User);
            UsersController controller = new UsersController(data, user);

            controller.CurrentUser = null;
            string result = String.Empty;
            try
            {
                IView view = new Logout(user);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            string expected = "";

            Assert.AreEqual(expected, result);
        }
    }
}
