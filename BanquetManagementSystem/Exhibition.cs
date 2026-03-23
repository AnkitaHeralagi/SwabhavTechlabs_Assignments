using System;
using System.Collections.Generic;
using System.Text;

namespace BanquetEventManagement
{
    internal class Exhibition : Banquet
    {
        public int TotalStalls;
        public int StallRent;
        public Exhibition(int id, string name, int cap, int stalls, int rent): base(id, name, cap)
        {
            try
            {
                if (stalls > cap / 2)
                {
                    throw new Exception("Stalls exceed allowed limit");
                }

                TotalStalls = stalls;
                StallRent = rent;
            }
            catch (Exception ex)
            {
                throw new StallLimitExceededException("Error in Exhibition: Invalid stall count", ex);
            }
        }
        public override int CalculateEarning()
        {
            return base.CalculateEarning() + (TotalStalls * StallRent);
        }
        public void DisplayExhibition()
        {
            Console.WriteLine("\n--- Exhibition Details ---");
            Console.WriteLine("Banquet ID: " + BanquetId);
            Console.WriteLine("Banquet Name: " + BanquetName);
            Console.WriteLine("Capacity: " + Capacity);
            Console.WriteLine("Total Stalls: " + TotalStalls);
            Console.WriteLine("Stall Rent: " + StallRent);
            Console.WriteLine("Total Earnings: " + CalculateEarning());
        }
    }
}
