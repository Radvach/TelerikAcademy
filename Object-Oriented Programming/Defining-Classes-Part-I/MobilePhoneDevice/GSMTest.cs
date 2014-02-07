using System;
using System.Threading;
using System.Globalization;

namespace MobilePhoneDevice
{
    public class GSMTest
    {
        private static GSM[] smartGSMs = new GSM[2];

        static void Main()
        {
            PrintGSMInfo();
        }

        static public void PrintGSMInfo()
        {
            // GSM 1
            smartGSMs[0] = new GSM("Galaxy S4", "Samsung", 1200m, "Pesho",
                new Battery("GS240", new TimeSpan(25, 20, 0), new TimeSpan(14, 15, 0),
                BatteryType.LiIon), new Display(4.99m, "16M"));

            // GSM 2 variant 2
            Battery smartBattery = new Battery("BA700", new TimeSpan(68, 0, 0), new TimeSpan(36, 0, 0));
            Display smartDisplay = new Display(3.7m, "16M");
            smartGSMs[1] = new GSM("MT15i", "Sony", null, null, smartBattery, smartDisplay);
            // Set Price and Owner by properties
            smartGSMs[1].Price = 370m;
            smartGSMs[1].Owner = "Grigor Iliev";

            // Print Gsm's info
            foreach (GSM gsm in smartGSMs)
            {
                Console.WriteLine(gsm);
            }

            // Print static
            Console.WriteLine(GSM.IPhone4S);

            // Add calls
            smartGSMs[0].AddCall("0897777777", 61); // 2 min
            smartGSMs[0].AddCall("0897777788", 24); // 1 min
            smartGSMs[0].AddCall("0897777777", 44); // 1 min
            smartGSMs[0].AddCall("0897777331", 5);  // 1 min

            decimal totalPrice = 0.0m;
            // View calls, Calc price of calls, Print total price.
            // Initial
            Console.WriteLine(smartGSMs[0].ViewCalls());
            totalPrice = smartGSMs[0].CalcPriceOfCalls(0.37m);
            Console.WriteLine("Total Price: " + totalPrice.ToString("C", new CultureInfo("bg-BG")));

            // Remove longest call from history.
            Console.WriteLine(smartGSMs[0].RemoveCall("0897777777"));
            Console.WriteLine(smartGSMs[0].ViewCalls());
            totalPrice = smartGSMs[0].CalcPriceOfCalls(0.37m);
            Console.WriteLine("Total Price: " + totalPrice.ToString("C", new CultureInfo("bg-BG")));

            // Clear call history.
            smartGSMs[0].ClearCallHistory();
            Console.WriteLine(smartGSMs[0].ViewCalls());
            totalPrice = smartGSMs[0].CalcPriceOfCalls(0.37m);
            Console.WriteLine("Total Price: " + totalPrice.ToString("C", new CultureInfo("bg-BG")));
        }
    }
}
