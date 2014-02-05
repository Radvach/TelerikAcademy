using System;
namespace MobilePhoneDevice
{
    public class Battery
    {
        private string model;
        private TimeSpan? idleHours;
        private TimeSpan? talkHours;
        private BatteryType? type;

        public Battery()
            : this(null)
        { }

        public Battery(string model)
            : this(model, null)
        {

        }

        public Battery(string model, TimeSpan? idleHours)
            : this(model, idleHours, null)
        {

        }

        public Battery(string model, TimeSpan? idleHours, TimeSpan? talkHours)
            : this(model, idleHours, talkHours, null)
        {
        }

        public Battery(string model, TimeSpan? idleHours, TimeSpan? talkHours, BatteryType? type)
        {
            this.model = model;
            this.idleHours = idleHours;
            this.talkHours = talkHours;
            this.type = type;
        }


        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                { throw new ArgumentException("Invalid Model: " + value); }
                this.model = value;
            }
        }

        public TimeSpan? IdleHours
        {
            get { return this.idleHours; }
            set { this.idleHours = value; }
        }

        public TimeSpan? TalkHours
        {
            get { return this.talkHours; }
            set { this.talkHours = value; }
        }

        public BatteryType? Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}