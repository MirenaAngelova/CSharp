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
    public class VenuesAllTests
    {
        [TestMethod]
        public void All_WithNoVenues_ShouldReturnAppropriateExceptionMessage()
        {
            var data = new HotelBookingSystemData();
            var controller = new VenuesController(data, new User("user name", "password", Roles.User));
            var view = controller.All();

            var result = view.Display();

            var expected = "There are currently no venues to show.";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void Add_WithNoAuthorizedUser_ShouldReturnAppropriateExceptionMessage()
        {
            var data = new HotelBookingSystemData();
            var controller = new VenuesController(data, new User("user name", "password", Roles.User));
         
            var view = controller.Add("venue name", "address", "description");

            view.Display();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void All_WithInvalidUser_ShouldReturnVenuesAllView()
        {
            var data = new HotelBookingSystemData();
            var controller = new VenuesController(data, null);

            controller.Add("venue name", "address", "description");
            var view = controller.All();
            view.Display();
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void All_WithNoAuthorizedUser_ShouldReturnIViewVenuesAll()
        {
            var data = new Mock<IHotelBookingSystemData>();
            var user = new User("Username", "123456", Roles.User);
            var controller = new VenuesController(data.Object, user);
            controller.Add("Venue", "Address", "Description");
            controller.All();
        }

        [TestMethod]
        public void All_WithValidVenue_ShouldReturnIViewVenuesAll()
        {
            var data = new HotelBookingSystemData();
            var user = new User("Username", "123456", Roles.VenueAdmin);
            var controller = new VenuesController(data, user);
         
            controller.Add("Venue", "Address", "Description");
            var view = controller.All();
            var actual = view.Display();

            var expected = "*[1] Venue, located at Address\r\nFree rooms: 0";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void All_WithListOfValidVenues_ShouldReturnIViewVenuesAll()
        {
            var data = new HotelBookingSystemData();
            var user = new User("Username", "123456", Roles.VenueAdmin);
            var controller = new VenuesController(data, user);

            for (int i = 0; i < 10; i++)
            {
                controller.Add("Venue" + i, "Address" + i, "Description" + i);
            }
            
            var view = controller.All();
            var actual = view.Display();

            var expected = "*[1] Venue0, located at Address0\r\nFree rooms: 0" +
                           "\r\n*[2] Venue1, located at Address1\r\nFree rooms: 0" +
                           "\r\n*[3] Venue2, located at Address2\r\nFree rooms: 0" +
                           "\r\n*[4] Venue3, located at Address3\r\nFree rooms: 0" +
                           "\r\n*[5] Venue4, located at Address4\r\nFree rooms: 0" +
                           "\r\n*[6] Venue5, located at Address5\r\nFree rooms: 0" +
                           "\r\n*[7] Venue6, located at Address6\r\nFree rooms: 0" +
                           "\r\n*[8] Venue7, located at Address7\r\nFree rooms: 0" +
                           "\r\n*[9] Venue8, located at Address8\r\nFree rooms: 0" +
                           "\r\n*[10] Venue9, located at Address9\r\nFree rooms: 0";

             Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void All_WithListOfValidVenuesAndAddRoom_ShouldReturnIViewVenuesAll()
        {
            var data = new HotelBookingSystemData();
            var user = new User("Username", "123456", Roles.VenueAdmin);
            var controller = new VenuesController(data, user);
            var roomsController = new RoomsController(data, user);
            
            for (int i = 0; i < 10; i++)
            {
                controller.Add("Venue" + i, "Address" + i, "Description" + i);
                roomsController.Add(1 + i, 2, 30);
            }
            var view = controller.All();
            var actual = view.Display();

            var expected = "*[1] Venue0, located at Address0\r\nFree rooms: 1" +
                           "\r\n*[2] Venue1, located at Address1\r\nFree rooms: 1" +
                           "\r\n*[3] Venue2, located at Address2\r\nFree rooms: 1" +
                           "\r\n*[4] Venue3, located at Address3\r\nFree rooms: 1" +
                           "\r\n*[5] Venue4, located at Address4\r\nFree rooms: 1" +
                           "\r\n*[6] Venue5, located at Address5\r\nFree rooms: 1" +
                           "\r\n*[7] Venue6, located at Address6\r\nFree rooms: 1" +
                           "\r\n*[8] Venue7, located at Address7\r\nFree rooms: 1" +
                           "\r\n*[9] Venue8, located at Address8\r\nFree rooms: 1" +
                           "\r\n*[10] Venue9, located at Address9\r\nFree rooms: 1";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void All_WithListOfValidVenuesAndAddRooms_ShouldReturnIViewVenuesAll()
        {
            var data = new HotelBookingSystemData();
            var user = new User("Username", "123456", Roles.VenueAdmin);
            var controller = new VenuesController(data, user);
            var roomsController = new RoomsController(data, user);

            for (int i = 0; i < 10; i++)
            {
                controller.Add("Venue" + i, "Address" + i, "Description" + i);
                for (int j = 0; j < 10; j++)
                {
                    roomsController.Add(1 + i, 2, 30);
                }
                
            }
            var view = controller.All();
            var actual = view.Display();

            var expected = "*[1] Venue0, located at Address0\r\nFree rooms: 10" +
                           "\r\n*[2] Venue1, located at Address1\r\nFree rooms: 10" +
                           "\r\n*[3] Venue2, located at Address2\r\nFree rooms: 10" +
                           "\r\n*[4] Venue3, located at Address3\r\nFree rooms: 10" +
                           "\r\n*[5] Venue4, located at Address4\r\nFree rooms: 10" +
                           "\r\n*[6] Venue5, located at Address5\r\nFree rooms: 10" +
                           "\r\n*[7] Venue6, located at Address6\r\nFree rooms: 10" +
                           "\r\n*[8] Venue7, located at Address7\r\nFree rooms: 10" +
                           "\r\n*[9] Venue8, located at Address8\r\nFree rooms: 10" +
                           "\r\n*[10] Venue9, located at Address9\r\nFree rooms: 10";

            Assert.AreEqual(expected, actual);
        }
    }
}
