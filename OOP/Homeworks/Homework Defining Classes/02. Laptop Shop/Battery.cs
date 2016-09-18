using System;
using System.Runtime.CompilerServices;

class Battery
{
    private string batteryName;
    private double? batteryLife;

    public string BatteryName
    {
        get { return this.batteryName; }
        private set
        {
            if (value != null && value.Trim() == "" )
            {
                throw new ArgumentNullException("Battery shoul be has a name!");
            }
            this.batteryName = value;
        }
    }

    public double? BatteryLife
    {
        get { return this.batteryLife; }
        private set
        {
            if (value != null && value < 0)
            {
                throw new ArgumentOutOfRangeException("Battery life shouldn't be negative!");
            }
            this.batteryLife = value;
        }
    }

    public Battery() : this(null,null)
    {
    }

    public Battery(string batteryName, double? batteryLife)
    {
        this.BatteryName = batteryName;
        this.BatteryLife = batteryLife;
    }

    public override string ToString()
    {
        return String.Format("Battery name: {0}\nBattery life: {1}", this.BatteryName ?? "N/A", this.BatteryLife);
    }
}

