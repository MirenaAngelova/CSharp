﻿namespace ChepelareHotelBookingSystem
{
    using System.Globalization;
    using System.Threading;

    using Core;

    public class HotelBookingSystemMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var engine = new Engine();
            engine.Run();
        }
    }
}
