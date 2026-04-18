using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    internal class TicTacToeFacade
    {
        private Board board;
        private PlayerManager playerManager;
        private GameEvaluator evaluator;
        public TicTacToeFacade()
        {
            board = new Board();
            playerManager = new PlayerManager();
            evaluator = new GameEvaluator();
        }
        public void PlayGame()
        {
            bool gameOver = false;
            ShowGuide();           //position guide 
            while (!gameOver)
            {
                try
                {
                    board.Display();
                    char player = playerManager.GetCurrentPlayer();

                    Console.WriteLine($"\nPlayer {player}'s Turn");

                    int row = GetValidInput("Enter row (0-2): ");
                    int col = GetValidInput("Enter col (0-2): ");

                    if (!board.PlaceMark(row, col, player))
                    {
                        Console.WriteLine("Invalid move! Cell already occupied.");
                        continue;
                    }
                    if (evaluator.CheckWinner(board.GetGrid(), player))
                    {
                        board.Display();
                        Console.WriteLine($"\nPlayer {player} Wins!");
                        gameOver = true;
                    }
                    else if (evaluator.IsDraw(board.GetGrid()))
                    {
                        board.Display();
                        Console.WriteLine("\nGame Draw!");
                        gameOver = true;
                    }
                    else
                    {
                        playerManager.SwitchPlayer();
                    }
                }
                catch
                {
                    Console.WriteLine("Something went wrong. Try again.");
                }
            }
        }
        private int GetValidInput(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                    continue;
                }
                input = input.Trim();

                if (input.Length == 1 && input[0] >= '0' && input[0] <= '2')
                {
                    return input[0] - '0';
                }

                Console.WriteLine("Invalid input! Enter only 0, 1, or 2.");
            }
        }
        // POSITION GUIDE
        private void ShowGuide()
        {
            Console.WriteLine("TIC TAC TOE GAME\n");
            Console.WriteLine("Position Guide:");
            Console.WriteLine("0 0 | 0 1 | 0 2");
            Console.WriteLine("1 0 | 1 1 | 1 2");
            Console.WriteLine("2 0 | 2 1 | 2 2\n");
        }
        public void ResetGame()
        {
            board.Reset();
            playerManager.Reset();
            Console.WriteLine("\nGame Reset! Starting new game...\n");
        }
    }
}
