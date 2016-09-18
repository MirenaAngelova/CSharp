﻿namespace ChepelareHotelBookingSystem2.Identity
{
    using System;

    public class AuthorizationFailedException : ArgumentException
    {
        // BUG: User class should not be involved here.
        public AuthorizationFailedException(string message) : base(message)
        {
        }
    }
}
