namespace MobilePhoneDevice
{
    using System.Text;
    using System;
    using System.Collections.Generic;

    public class GSM
    {
        private Battery battery;
        private Display display;
        private List<Call> calls = new List<Call>();

        static private GSM iPhone4S;

        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;

        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price)
            : this(model, manufacturer, price, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner)
            : this(model, manufacturer, price, owner, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery)
            : this(model, manufacturer, price, owner, battery, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price,
            string owner, Battery battery, Display display)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = battery;
            this.display = display;
        }

        static GSM()
        {
            iPhone4S = new GSM("iPhone4S", "Apple", 700m, null,
                new Battery("AppleBattery", new TimeSpan(30, 27, 0), new TimeSpan(16, 22, 0),
                BatteryType.LiIon), new Display(4.1m, "16M"));
        }

        static public GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                { throw new ArgumentException("Invalid Model: " + value); }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                { throw new ArgumentException("Invalid Manufacturer: " + value); }
                this.manufacturer = value;
            }
        }

        public decimal? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid price: " + value);
                }
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                { throw new ArgumentException("Invalid Owner: " + value); }
                this.owner = value;
            }
        }

        public void ViewCalls()
        {
            if (calls.Count > 0)
            {
                Console.Write(new string('-', 25));
                Console.Write("Call List");
                Console.WriteLine(new string('-', 25));
                Console.WriteLine("{0,-13}{1,-18}{2}", "Duration", "Dialed number", "Date and Time");
                for (int i = 0; i < this.calls.Count; i++)
                {
                    Console.Write("{0,-13}", calls[i].Duration);
                    Console.Write("{0,-18}", calls[i].DialedNumber);
                    Console.Write("{0}", calls[i].DateTime);
                    Console.WriteLine();
                }
                Console.WriteLine(new string('-', 59));
            }
            else
            {
                Console.WriteLine("Call history is empty!");
            }
        }

        public void ViewCalls1()
        {
            if (calls.Count > 0)
            {
                Console.WriteLine("---------------- Calls List ------------------");
                Console.WriteLine("{0,-10}{1,-13} | {2,-8} | {3}", "Date", "Time", "Number", "Duration");
                foreach (var call in this.calls)
                {
                    Console.WriteLine("{0,-23} | {1,-8} | {2}", call.DateTime, call.DialedNumber, call.Duration);
                }
                Console.WriteLine("----------------------------------------------");
            }
            else
            {
                Console.WriteLine("\nNo calls\n");
            }
        }


        public void AddCall(string phoneNumber, uint duration)
        {
            Call newCall = new Call(phoneNumber, duration);
            this.calls.Add(newCall);
        }

        public void RemoveCall(string numberToRemove)
        {
            if (this.calls.Count == 0)
            {
                Console.WriteLine("Call history is empty!");
                return;
            }

            int removedCount = 0;
            removedCount = this.calls.RemoveAll(
                delegate(Call call)
                {
                    return call.DialedNumber == numberToRemove;
                });

            if (removedCount > 0)
            {
                Console.WriteLine("Removed {0} records.", removedCount);
            }
            else
            {
                Console.WriteLine("Record {0} not found.", numberToRemove);
            }
        }

        public void ClearCallHistory()
        {
            this.calls.Clear();
            Console.WriteLine("Call History - Cleared!");
        }

        public decimal CalcPriceOfCalls(decimal pricePerMin = 0.13m)
        {
            uint totalMinutes = 0u;
            for (int i = 0; i < this.calls.Count; i++)
            {
                uint secDuration = (uint)this.calls[i].Duration;

                uint minDuration = secDuration / 60;
                if (secDuration % 60 > 0)
                {
                    minDuration += 1;
                }

                totalMinutes += minDuration;
            }

            // 131 секунди = 2min и 11 сек
            // 131 / 60 = 2 <- uint
            // за 11 сек ти зимам още 1 мин
            // Аз съм като Globul, sorry
            return totalMinutes * pricePerMin;            
        }

        public override string ToString()
        {
            var info = new StringBuilder();
            info.AppendLine(new string('-', 20));
            string unknown = "Unknown";
            info.AppendLine("GSM:");
            info.AppendFormat("Model: {0}\n", this.model);
            info.AppendFormat("Manufacturer: {0}\n", this.manufacturer);

            if (this.price != null) { info.AppendFormat("Price: {0}\n", this.price); }
            else { info.AppendFormat("Price: {0}\n", unknown); }

            if (this.owner != null) { info.AppendFormat("Owner: {0}\n", this.owner); }
            else { info.AppendFormat("Owner: {0}\n", unknown); }

            if (this.battery != null)
            {
                info.AppendFormat("\nBattery\n");
                info.AppendFormat("Model: {0}\n", this.battery.Model);

                var idleHours = this.battery.IdleHours != null ? this.battery.IdleHours.ToString() : unknown;
                info.AppendFormat("Hours Idle: {0}\n", idleHours);
                
                var talkHours = this.battery.TalkHours != null ? this.battery.TalkHours.ToString() : unknown;
                info.AppendFormat("Hours Talk: {0}\n", talkHours);

                var type = this.battery.Type != null ? this.battery.Type.ToString() : unknown;
                info.AppendFormat("Battery Type: {0}\n", type);              
            }
            else
            {
                info.AppendFormat("\nBattery Type: {0}\n", unknown);
            }

            if (this.display != null)
            {
                info.AppendFormat("\nDisplay\n");
                info.AppendFormat("Size: {0}\n", this.display.Size);

                string colors = this.display.Colors != null ? this.display.Colors : unknown;
                info.AppendFormat("Colors: {0}\n", colors);
            }
            else
            {
                info.AppendFormat("\nDisplay: {0}\n", unknown);
            }

            return info.ToString();
        }
    }
}
/*
 Define a class that holds information about a mobile phone device: model,
 * manufacturer, price, owner, battery characteristics
 * (model, hours idle and hours talk) and display characteristics
 * (size and number of colors). Define 3 separate classes
 * (class GSM holding instances of the classes Battery and Display).
*/

