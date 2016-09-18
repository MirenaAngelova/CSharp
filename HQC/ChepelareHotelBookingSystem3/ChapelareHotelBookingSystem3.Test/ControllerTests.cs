using System;
using ChepelareHotelBookingSystem3.Controllers;
using ChepelareHotelBookingSystem3.Data;
using ChepelareHotelBookingSystem3.Identity;
using ChepelareHotelBookingSystem3.Infrastructure;
using ChepelareHotelBookingSystem3.Interfaces;
using ChepelareHotelBookingSystem3.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ChapelareHotelBookingSystem3.Test
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Controller_WithNoLoggedInUser_ShouldReturnAppropriateExceptionMessage()
        {
            var data = new Mock<IHotelBookingSystemData>();
            var controller = new Controller(data.Object, null);
             
            controller.Authorize(Roles.User);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void Controller_WithNoData_ShouldReturnAppropriateExceptionMessage()
        {
            var controller = new Controller(null, new User("user name", "password", Roles.User));

            controller.Authorize(Roles.VenueAdmin);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void Controller_WithNoAuthorizedUser_ShouldReturnAppropriateExceptionMessage()
        {
            var data = new Mock<IHotelBookingSystemData>();
            var controller = new Controller(data.Object, new User("user name", "password", Roles.User));

            controller.Authorize(Roles.VenueAdmin);
        }

        [TestMethod]
        public void Controller_WithNoData_ShouldNotReturnExceptionMessage()
        {
            var controller = new Controller(null, new User("user name", "password", Roles.User));

            controller.Authorize(Roles.User);
        }
    }
}
