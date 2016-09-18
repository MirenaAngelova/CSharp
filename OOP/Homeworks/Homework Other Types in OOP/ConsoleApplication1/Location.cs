using System;
using System.Text;

namespace ConsoleApplication1
{
    public struct Location
    {
        private double longitude;
        private double latitude;
        private const double MinLatitude = -90; 
        private const double MaxLatitude = 90; 
        private const double MinLongitude = -180; 
        private const double MaxLongitude = 180; 
        public Location(double latitude, double longitude, Planet planet) : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public Planet Planet { get; set; }

        public double Longitude {
            get { return this.longitude; }
            set
            {
                if (value < MinLongitude || value > MaxLongitude)
                {
                    throw new ArgumentOutOfRangeException("Invalid degrees.");
                }
                this.longitude = value;
            }
        }

        public double Latitude
        {
            get { return this.latitude; }
            set
            {
                if (value < MinLatitude || value > MaxLatitude)
                {
                    throw new ArgumentOutOfRangeException("Invalid degrees.");
                }
                this.latitude = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}, {1} - {2}", this.Latitude, this.Longitude, this.Planet);
            return sb.ToString();
        }
    }
}