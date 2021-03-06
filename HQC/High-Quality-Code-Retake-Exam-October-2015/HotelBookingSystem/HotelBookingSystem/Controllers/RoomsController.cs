﻿namespace HotelBookingSystem.Controllers
{
    using System;
    using System.Linq;
    using Contracts;
    using Infrastructure;
    using Models;
    using Utilities;

    public class RoomsController : Controller
    {
        public RoomsController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        public IView Add(int venueId, int places, decimal pricePerDay)
        {
            this.Authorize(Role.VenueAdmin);
            var venue = this.Data.Venues.Get(venueId);
            if (venue == null)
            {
                return this.NotFound(string.Format("The venue with ID {0} does not exist.", venueId));
            }

            var newRoom = new Room(places, pricePerDay);
            venue.Rooms.Add(newRoom);
            this.Data.Rooms.Add(newRoom);
            return this.View(newRoom);
        }

        public IView AddPeriod(int roomId, DateTime startDate, DateTime endDate)
        {
            this.Authorize(Role.VenueAdmin);
            var room = this.Data.Rooms.Get(roomId);
            if (room == null)
            {
                return this.NotFound(string.Format("The room with ID {0} does not exist.", roomId));
            }

            Validator.ValidateDateRange(startDate, endDate);
            room.AvailableDates.Add(new AvailableDate(startDate, endDate));
            return this.View(room);
        }

        public IView ViewBookings(int id)
        {
            this.Authorize(Role.VenueAdmin);
            var room = this.Data.Rooms.Get(id);
            if (room == null)
            {
                return this.NotFound(string.Format("The room with ID {0} does not exist.", id));
            }

            return this.View(room.Bookings);
        }

        public IView Book(int roomId, DateTime startDate, DateTime endDate, string comments)
        {
            this.Authorize(Role.User, Role.VenueAdmin);
            var room = this.Data.Rooms.Get(roomId);
            if (room == null)
            {
                return this.NotFound(string.Format("The room with ID {0} does not exist.", roomId));
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
            var booking = new Booking(this.CurrentUser, startDate, endDate, totalPrice, comments);
            room.Bookings.Add(booking);
            this.CurrentUser.Bookings.Add(booking);

            this.UpdateRoomAvailability(startDate, endDate, room, availablePeriod);

            return this.View(booking);
        }

        private void UpdateRoomAvailability(
            DateTime startDate, DateTime endDate, Room room, AvailableDate availablePeriod)
        {
            room.AvailableDates.Remove(availablePeriod);
            var periodBeforeBooking = startDate - availablePeriod.StartDate;
            if (periodBeforeBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(new AvailableDate(availablePeriod.StartDate,
                    availablePeriod.StartDate.Add(periodBeforeBooking)));
            }

            var periodAfterBooking = availablePeriod.EndDate - endDate;
            if (periodAfterBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(new AvailableDate(availablePeriod.EndDate.Subtract(periodAfterBooking), 
                    availablePeriod.EndDate));
            }
        }
    }
}
