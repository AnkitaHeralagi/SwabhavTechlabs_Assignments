using System;
using Order_Processing_System;

namespace Order_Processing_System
{
    class Program
    {
        static void Main()
        {
            OrderProcessor processor = new OrderProcessor();

            Console.WriteLine("====== Order Processing System ======");

            while (true)
            {
                Console.Write("\nEnter product price: ");

                // Input validation using TryParse
                if (!double.TryParse(Console.ReadLine(), out double price) || price <= 0)
                {
                    Console.WriteLine("Invalid input! Please enter a valid positive number:");
                    continue;
                }

                // Process order
                ProcessOrder(processor, price);

                // Retry option
                Console.Write("\nDo you want to process another order? (y/n): ");
                string choice = Console.ReadLine().ToLower();

                if (choice != "y")
                {
                    Console.WriteLine("\nThank you for using the system!");
                    break;
                }
            }
        }

        // Separate method for clean logic
        static void ProcessOrder(OrderProcessor processor, double price)
        {
            double discount = processor.CalculateDiscount(price);
            double finalPrice = processor.CalculateFinalPrice(price, discount);

            string discountType = price > 1000 ? "15%" : "5%";

            Console.WriteLine("\n----- Order Summary -----");
            Console.WriteLine($"Original Price   : {price:F2}");
            Console.WriteLine($"Discount ({discountType})   : {discount:F2}");
            Console.WriteLine($"Final Price      : {finalPrice:F2}");
        }
    }
}