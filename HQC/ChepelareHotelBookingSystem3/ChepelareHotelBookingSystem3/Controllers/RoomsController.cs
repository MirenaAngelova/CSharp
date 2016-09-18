namespace ChepelareHotelBookingSystem3.Controllers
{
    using System;
    using System.Linq;

    using Infrastructure;
    using Interfaces;
    using Models;
    using Utilities;

    public class RoomsController : Controller
    {
        public RoomsController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        /// <summary>
        /// Adds new room to venue and room repository
        /// </summary>
        /// <param name="venueId">Venue ID</param>
        /// <param name="places">Number of available places.</param>
        /// <param name="pricePerDay">Price for stay per day</param>
        /// <returns>View of new room.</returns>
        public IView Add(int venueId, int places, decimal pricePerDay)
        {
            this.Authorize(Roles.VenueAdmin);
            var venue = Data.RepositoryWithVenues.Get(venueId);

            // BUG: Refactor venue != null to venue == null
            if (venue == null)
            {
                return this.NotFound($"The venue with ID {venueId} does not exist.");
            }

            var newRoom = new Room(places, pricePerDay);
            venue.Rooms.Add(newRoom);
            this.Data.RepositoryWithRooms.Add(newRoom);
            return this.View(newRoom);
        }

        public IView AddPeriod(int roomId, DateTime startDate, DateTime endDate)
        {
            this.Authorize(Roles.VenueAdmin);
            var room = this.Data.RepositoryWithRooms.Get(roomId);
            if (room == null)
            {
                return this.NotFound($"The room with ID {roomId} does not exist.");
            }

            // BUG: Refactor startDate < endDate to startDate > endDate
            Validator.ValidateDateRange(startDate, endDate);
            room.AvailableDates.Add(new AvailableDate(startDate, endDate));
            return this.View(room);
        }

        public IView ViewBookings(int id)
        {
            this.Authorize(Roles.VenueAdmin);
            var room = this.Data.RepositoryWithRooms.Get(id);
            if (room == null)
            {
                return this.NotFound($"The room with ID {id} does not exist.");
            }

            return this.View(room.Bookings);
        }

        public IView Book(int roomId, DateTime startDate, DateTime endDate, string comments)
        {
            this.Authorize(Roles.User, Roles.VenueAdmin);
            var room = this.Data.RepositoryWithRooms.Get(roomId);
            if (room == null)
            {
                return this.NotFound($"The room with ID {roomId} does not exist.");
            }

            Validator.ValidateDateRange(startDate, endDate);
            var availablePeriod = room.AvailableDates
                .FirstOrDefault(d => d.StartDate <= startDate || d.EndDate >= endDate);
            if (availablePeriod == null)
            {
                throw new ArgumentException(
                    $"The room is not available to book in the period {startDate:dd.MM.yyyy} - {endDate:dd.MM.yyyy}.");
            }

            decimal totalPrice = (endDate - startDate).Days * room.PricePerDay;
            var booking = new Booking(CurrentUser, startDate, endDate, totalPrice, comments);
            room.Bookings.Add(booking);
            this.CurrentUser.Bookings.Add(booking);
            this.UpdateRoomAvailability(startDate, endDate, room, availablePeriod);
            return this.View(booking);
        }

        private void UpdateRoomAvailability(DateTime startDate, DateTime endDate, Room room, AvailableDate availablePeriod)
        {
            room.AvailableDates.Remove(availablePeriod);
            var periodBeforeBooking = startDate - availablePeriod.StartDate;
            if (periodBeforeBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(new AvailableDate(availablePeriod.StartDate, availablePeriod.StartDate.Add(periodBeforeBooking)));
            }

            var periodAfterBooking = availablePeriod.EndDate - endDate;
            if (periodAfterBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(new AvailableDate(availablePeriod.EndDate.Subtract(periodAfterBooking), availablePeriod.EndDate));
            }
        }
    }
}
