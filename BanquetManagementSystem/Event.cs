using System;
using System.Collections.Generic;
using System.Text;
namespace BanquetEventManagement
{
    internal class Event : Banquet
    {
        public int TotalPax;
        public Event(int id, string name, int cap, int pax) : base(id, name, cap)
        {
            try
            {
                if (pax > cap)
                {
                    throw new Exception("Pax exceeds capacity");
                }

                TotalPax = pax;
            }
            catch (Exception ex)
            {
                throw new CapacityExceededException("Error in Event: Invalid guest count", ex);
            }
        }
        public override int CalculateEarning()
        {
            int basicAmount = base.CalculateEarning();
            return TotalPax * basicAmount;
        }
        public void DisplayDetails()
        {
            Console.WriteLine("\n--- Event Details ---");
            Console.WriteLine("Banquet ID: " + BanquetId);
            Console.WriteLine("Banquet Name: " + BanquetName);
            Console.WriteLine("Capacity: " + Capacity);
            Console.WriteLine("Total Guests: " + TotalPax);
            Console.WriteLine("Total Earnings: " + CalculateEarning());
        }
    }
}
