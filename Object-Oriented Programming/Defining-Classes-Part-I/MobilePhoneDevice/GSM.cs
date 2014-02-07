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

        public string Owner { get; set; }

        public GSM(string model, string manufacturer, decimal? price = 0.0m,
            string owner = null, Battery battery = null, Display display = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
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

        public string ViewCalls()
        {
            var historyList = new StringBuilder();

            if (calls.Count > 0)
            {
                historyList.Append(new string('-', 25));
                historyList.Append("Call List");
                historyList.Append(new string('-', 25));
                historyList.Append(Environment.NewLine);
                historyList.AppendFormat("{0,-13}{1,-18}{2}", "Duration", "Dialed number", "Date and Time");
                historyList.Append(Environment.NewLine);
                for (int i = 0; i < this.calls.Count; i++)
                {
                    historyList.AppendFormat("{0,-13}", calls[i].Duration);
                    historyList.AppendFormat("{0,-18}", calls[i].DialedNumber);
                    historyList.AppendFormat("{0}", calls[i].DateTime);
                    historyList.Append(Environment.NewLine);
                }
                historyList.Append(new string('-', 59));
            }
            else
            {
                historyList.Append(Environment.NewLine);
                historyList.Append("Call History is empty!\n");
            }

            return historyList.ToString();
        }

        public void AddCall(string phoneNumber, uint duration)
        {
            Call newCall = new Call(phoneNumber, duration);
            this.calls.Add(newCall);
        }

        public string RemoveCall(string numberToRemove)
        {
            if (this.calls.Count == 0)
            {
                throw new ArgumentException("Call History is already empty!");
            }

            int removedCount = 0;
            removedCount = this.calls.RemoveAll(
                delegate(Call call)
                {
                    return call.DialedNumber == numberToRemove;
                });

            string message = string.Empty;
            if (removedCount > 0)
            {
                message = String.Format("Removed {0} records.", removedCount);
            }
            else
            {
                message = String.Format("Record {0} not found.", numberToRemove);
            }

            return message;
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
            const string unknown = "Unknown";
            info.AppendLine("GSM:");
            info.AppendFormat("Model: {0}\n", this.model);
            info.AppendFormat("Manufacturer: {0}\n", this.manufacturer);

            if (this.price != null) { info.AppendFormat("Price: {0}\n", this.price); }
            else { info.AppendFormat("Price: {0}\n", unknown); }

            if (this.Owner != null) { info.AppendFormat("Owner: {0}\n", this.Owner); }
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

