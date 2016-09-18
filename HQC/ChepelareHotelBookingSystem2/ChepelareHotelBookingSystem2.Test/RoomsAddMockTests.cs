using System;
using ChepelareHotelBookingSystem2.Controllers;
using ChepelareHotelBookingSystem2.Interfaces;
using ChepelareHotelBookingSystem2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ChepelareHotelBookingSystem2.Test
{
    [TestClass]
    public class RoomsAddMockTests
    {
        [TestMethod]
        public void RoomsAddInvalidVenue_ShouldThrowExceptionWithCorrectMessage()
        {
            Mock<IHotelBookingSystemData> mockData = new Mock<IHotelBookingSystemData>();
            User user = new User("mock user", "password", Roles.User);
            RoomsController controller = new RoomsController(
                mockData as IHotelBookingSystemData, user);

            string result = string.Empty;
            try
            {
                IView view = controller.Add(1, 1, 30.00m);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            string expected = "The currently logged in user doesn't have sufficient rights" +
                              " to perform this operation.";

            Assert.AreEqual(expected, result);
        }
    }
}
