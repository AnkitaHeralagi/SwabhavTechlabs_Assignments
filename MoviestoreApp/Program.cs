using System;
using System.Linq;
using MoviestoreApp;

namespace MoviestoreApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieService service = new MovieService();
            int choice;
            Console.WriteLine("Welcome to Movie Store developed by Ankita");
            do
            {
                Console.WriteLine("\n============ MOVIE STORE ===========");
                Console.WriteLine("1. Add new Movie");
                Console.WriteLine("2. Display All Movies");
                Console.WriteLine("3. Find Movie by ID");
                Console.WriteLine("4. Remove Movie by ID");
                Console.WriteLine("5. Clear All Movies");
                Console.WriteLine("6. Exit");
                Console.WriteLine("====================================");

                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        service.AddMovie();
                        break;
                    case 2:
                        service.DisplayMovies();
                        break;
                    case 3:
                        service.FindMovieById();
                        break;
                    case 4:
                        service.RemoveMovie();
                        break;
                    case 5:
                        service.ClearAllMovies();
                        break;
                    case 6:
                        Console.WriteLine("Exiting... Thank you!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Choose between 1-6.");
                        break;
                }
            } while (choice != 6);
        }
    }
}