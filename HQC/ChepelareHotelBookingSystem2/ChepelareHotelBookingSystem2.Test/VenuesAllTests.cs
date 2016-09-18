namespace ChepelareHotelBookingSystem2.Test
{
    using Controllers;
    using Data;
    using Interfaces;
    using Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class VenuesAllTests
    {
        [TestMethod]
        public void VenuesAllFourVenues_ShouldReturnCorrectResult()
        {
            IHotelBookingSystemData data = new HotelBookingSystemData();
            User user = new User("test user", "password", Roles.VenueAdmin);
            VenuesController controller = 
                new VenuesController(data, user);

            controller.Add("Vitosha", "Sofia", "test1");
            controller.Add("Prista", "Ruse", "test2");
            controller.Add("Tepetata", "Plovdiv", "test3");
            controller.Add("Abritus", "Razgrad", "test4");
            IView view = controller.All();
            string result = view.Display();
            string expected = "*[1] Vitosha, located at Sofia\r\nFree rooms: 0" +
                              "\r\n*[2] Prista, located at Ruse\r\nFree rooms: 0" +
                              "\r\n*[3] Tepetata, located at Plovdiv\r\nFree rooms: 0" +
                              "\r\n*[4] Abritus, located at Razgrad\r\nFree rooms: 0";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void VenuesAllNoVenues_ShouldReturnCorrectResult()
        {
            IHotelBookingSystemData data = new HotelBookingSystemData();
            User user = new User("test user", "password", Roles.User);
            VenuesController controller = new VenuesController(data, user);

            IView view = controller.All();
            string result = view.Display();
            string expected = "There are currently no venues to show.";

            Assert.AreEqual(expected, result);
        }
    }
}
