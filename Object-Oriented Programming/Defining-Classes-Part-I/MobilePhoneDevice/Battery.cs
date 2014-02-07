using System;
namespace MobilePhoneDevice
{
    public class Battery
    {
        private string model;

        public BatteryType? Type { get; set; }
        public TimeSpan? IdleHours { get; set; }
        public TimeSpan? TalkHours { get; set; }

        public Battery(string model = null, TimeSpan? idleHours = null, TimeSpan? talkHours = null, BatteryType? type = null)
        {
            this.Model = model;
            this.IdleHours = idleHours;
            this.TalkHours = talkHours;
            this.Type = type;
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
    }
}