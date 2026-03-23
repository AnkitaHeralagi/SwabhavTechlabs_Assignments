using System;
using System.Collections.Generic;
using System.Text;
namespace BanquetEventManagement
{
    // For Event
    class CapacityExceededException : Exception
    {
        public CapacityExceededException(string message, Exception inner) : base(message,inner)
        {
        }
        public CapacityExceededException(string message) : base(message) 
        {
        }
    }

    // For Exhibition
    class StallLimitExceededException : Exception
    {
        public StallLimitExceededException(string message,Exception inner) : base(message,inner)
        {
        }
        public StallLimitExceededException(string message) : base(message) 
        {
        }
    }

internal class Banquet
    {
        public int BanquetId { get; set; }
        public string BanquetName { get; set; }
        public int Capacity { get; set; }
        public Banquet(int id, string name, int cap)
        {
            BanquetId = id;
            BanquetName = name;
            Capacity = cap;
        }
        public virtual int CalculateEarning()
        {
            return 2000;
        }
        public void Display()
        {
            Console.WriteLine("\n--- Banquet Details ---");
            Console.WriteLine("Banquet ID: " + BanquetId);
            Console.WriteLine("Banquet Name: " + BanquetName);
            Console.WriteLine("Capacity: " + Capacity);

        }
    }
}
