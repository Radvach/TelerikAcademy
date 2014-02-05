using System;
namespace MobilePhoneDevice
{
    public class Call
    {
        private DateTime dateTime;
        private string dialedNumber;
        private ulong duration; // seconds

        public Call(string dialedNumber, ulong duration)
        {
            this.dateTime = DateTime.Now;
            this.dialedNumber = dialedNumber;
            this.duration = duration;
        }

        public DateTime DateTime
        {
            get { return this.dateTime; }
        }

        public string DialedNumber
        {
            get { return this.dialedNumber; }
        }

        public ulong Duration
        {
            get { return this.duration; }
        }
        
    }
}
