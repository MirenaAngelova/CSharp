﻿namespace ChepelareHotelBookingSystem.Identity
{
    using Enum;
    using Models;

    public static class UserExtensions
    {
        public static bool IsInRole(this User user, Role role)
        {
            return user.Role == role;
        }
    }
}
