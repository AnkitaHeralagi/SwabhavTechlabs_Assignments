using System;
using TicTacToe;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeFacade game = new TicTacToeFacade();
            while (true)
            {
                game.PlayGame();
                Console.Write("\nPlay again? (y/n): ");
                string choice = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("Invalid choice. Exiting...");
                    break;
                }
                choice = choice.Trim().ToLower();
                if (choice == "y")
                {
                    game.ResetGame();
                }
                else if (choice == "n")
                {
                    Console.WriteLine("Thanks for playing!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Exiting...");
                    break;
                }
            }
        }
    }
}