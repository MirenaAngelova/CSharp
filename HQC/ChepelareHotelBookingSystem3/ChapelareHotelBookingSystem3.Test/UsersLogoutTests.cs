using System;
using ChepelareHotelBookingSystem3.Controllers;
using ChepelareHotelBookingSystem3.Data;
using ChepelareHotelBookingSystem3.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChapelareHotelBookingSystem3.Test
{
    [TestClass]
    public class UsersLogoutTests
    {
        [TestMethod]
        public void Logout_WithValidUser_ShouldReturnLogoutView()
        {
            var data = new HotelBookingSystemData();
            var user = new User("user name", "password", Roles.User);
            var controller = new UsersController(data, user);

            var view = controller.Logout();
            var result = view.Display();

            var expected = "The user user name has logged out.";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Logout_WithValidVenueAdmin_ShouldReturnLogoutView()
        {
            var data = new HotelBookingSystemData();
            var user = new User("user name", "password", Roles.VenueAdmin);
            var controller = new UsersController(data, user);

            var view = controller.Logout();
            var result = view.Display();

            var expected = "The user user name has logged out.";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Logout_WithNoValidUser_ShouldReturnAppropriateExceptionMessage()
        {
            var data = new HotelBookingSystemData();
            var controller = new UsersController(data, null);

            controller.Logout();
        }

        [TestMethod]
        public void Logout_WithNoInitializedDataAndValidUser_ShouldReturnLogoutView()
        {
            var controller = new UsersController(null, new User("user name", "password", Roles.User));
            var view = controller.Logout();

            var result = view.Display();

            var expected = "The user user name has logged out.";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Logout_WithNoInitializedDataAndValidVenueAdmin_ShouldReturnLogoutView()
        {
            var controller = new UsersController(null, new User("user name", "password", Roles.VenueAdmin));
            var view = controller.Logout();

            var result = view.Display();

            var expected = "The user user name has logged out.";

            Assert.AreEqual(expected, result);
        }
    }
}
