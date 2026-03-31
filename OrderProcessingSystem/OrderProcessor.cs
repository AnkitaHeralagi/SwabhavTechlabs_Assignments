using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Processing_System
{
    internal class OrderProcessor
    {
        // Func delegates
        public Func<double, double> CalculateDiscount;
        public Func<double, double, double> CalculateFinalPrice;

        public OrderProcessor()
        {
            // Discount
            CalculateDiscount = price =>
            {
                return price > 1000 ? price * 0.15 : price * 0.05;
            };

            // Final price 
            CalculateFinalPrice = (price, discount) =>
            {
                return price - discount;
            };
        }
    }
}
