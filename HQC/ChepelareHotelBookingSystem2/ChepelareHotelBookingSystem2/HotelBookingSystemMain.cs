namespace ChepelareHotelBookingSystem2
{
    using System;
    using System.Globalization;
    using System.Threading;

    using Core;

    public class HotelBookingSystemMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var engine = Activator.CreateInstance(typeof(Engine)) as Engine;
            engine.Run();
        }
    }
}
