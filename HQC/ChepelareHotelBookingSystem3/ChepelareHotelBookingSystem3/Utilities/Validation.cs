namespace ChepelareHotelBookingSystem3.Utilities
{
    public static class Validation
    {
        public const string ExceptionMessageInvalidDateRange = "The date range is invalid.";

        public const string ExceptionMessagePasswordsDoNotMatch = "The provided passwords do not match.";
        public const string ExceptionMessagePasswordWrong = "The provided password is wrong.";
        
        public const string ExceptionMessageRouteInvalid = "The provided route is invalid.";

        public const string ExceptionMessageAlreadyLoggedInUser = "There is already a logged in user.";
        public const string ExceptionMessageNoLoggedInUser = "There is no currently logged in user.";
        public const string ExceptionMessageUsernameCannotChanged = "A user's username cannot be changed.";
        public const string ExceptionMessageUserNotAuthorized =
            "The currently logged in user doesn't have sufficient rights to perform this operation.";

        public const string MessageNoBookingsForRoom = "There are no bookings for this room.";
        public const string MessageNotMadeBookings = "You have not made any bookings yet.";

        public const string MessageNoVenuesToShow = "There are currently no venues to show.";

        public const string MessageNoRoomsAvailable = "No rooms are currently available.";
        public const string MessageRoomNotAvailable = "This room is not currently available.";

        public const string ExceptionMessageSomethingHappend = "Something happened!!1";

        public const int MinLengthVenueName = 3;
        public const int MinLengthVenueAddress = 3;
        public const int MinLengthUsername = 5;
        public const int MinLengthRassword = 6;
    }
}
