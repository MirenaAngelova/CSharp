﻿namespace ChepelareHotelBookingSystem3.Identity
{
    using System;

    public class AuthorizationFailedException : ArgumentException
    {
        public AuthorizationFailedException(string message) : base(message)
        {
        }
    }
}
