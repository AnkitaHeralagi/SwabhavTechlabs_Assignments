using System;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using BanquetEventManagement;

class Program
{
    static void Main(string[] args)
    {
        // Array for base class objects
        Banquet[] banquets = new Banquet[3];
        GenerateBanquets(banquets);

        Console.WriteLine("\nEvent and Exhibition Details\n");

        // Array for Event and Exhibition objects
        Banquet[] eventexhibition = new Banquet[2];
        GenerateEventExhibition(eventexhibition);
    }

    // Method for base class Banquet
    static void GenerateBanquets(Banquet[] banquets)
    {
        banquets[0] = new Banquet(1, "Chandani Hall", 200);
        banquets[1] = new Banquet(2, "Town Palace", 300);
        banquets[2] = new Banquet(3, "Sai Grand", 250);

        Console.WriteLine("Banquet Details\n");

        for (int i = 0; i < banquets.Length; i++)
        {
            banquets[i].Display();
            Console.WriteLine("Basic Earnings: " + banquets[i].CalculateEarning());
            Console.WriteLine();
        }
    }

    // Method for Event and Exhibition 
    static void GenerateEventExhibition(Banquet[] eventexhibition)
    {
        for (int i = 0; i < eventexhibition.Length; i++)
        {
            try
            {
                Console.WriteLine("Enter 1 for Event or 2 for Exhibition:");

                int choice = Convert.ToInt32(Console.ReadLine());

                string idInput;
                int id;

                while (true)
                {
                    Console.WriteLine("Enter Banquet Id (Format: BQ-101):");
                    idInput = Console.ReadLine();

                    if (Regex.IsMatch(idInput, @"^BQ-\d{3}$"))
                    {
                        id = int.Parse(idInput.Split('-')[1]);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Banquet ID");
                    }
                }

                string name;
                while (true)
                {
                    Console.WriteLine("Enter Banquet Name:");
                    name = Console.ReadLine();

                    if (Regex.IsMatch(name, @"^[A-Za-z\s]{3,}$"))
                        break;
                    else
                        Console.WriteLine("Invalid Banquet Name");
                }

                Console.WriteLine("Enter Capacity:");
                int cap = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Enter Total Guests:");
                    int pax = Convert.ToInt32(Console.ReadLine());

                    eventexhibition[i] = new Event(id, name, cap, pax);
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter Total Stalls:");
                    int stalls = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Stall Rent:");
                    int rent = Convert.ToInt32(Console.ReadLine());

                    eventexhibition[i] = new Exhibition(id, name, cap, stalls, rent);
                }
            }
            catch (CapacityExceededException ex)
            {
                Console.WriteLine("Event Error: " + ex.Message);
                i--; 
            }
            catch (StallLimitExceededException ex)
            {
                Console.WriteLine("Exhibition Error: " + ex.Message);
                i--; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                i--;
            }

            Console.WriteLine();
        }
        Console.WriteLine("\n Event / Exhibition Details\n");

        for (int i = 0; i < eventexhibition.Length; i++)
        {
            eventexhibition[i].Display();
            Console.WriteLine("Total Earnings: " + eventexhibition[i].CalculateEarning());
            if (eventexhibition[i] is Event ev)
            {
                Console.WriteLine("Utilization: " + ev.CalculateUtilization());
                Console.WriteLine("Discount: " + (ev.CalculateDiscount() * 100) + "%");
            }
            Console.WriteLine();
        }
    }
}