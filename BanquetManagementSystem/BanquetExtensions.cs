using System;
using BanquetEventManagement;

namespace BanquetEventManagement
{
    internal static class BanquetExtensions
    {
        // Utilization
        internal static string CalculateUtilization(this Event e)
        {
            double utilization = ((double)e.Capacity / e.TotalPax) * 100;
            return utilization.ToString("0.00") + "% utilized";
        }
        // Discount
        internal static double CalculateDiscount(this Event e)
        {
            if (e.TotalPax > 500)
                return 0.20;
            else if (e.TotalPax > 300)
                return 0.10;
            else
                return 0;
        }
    }
}