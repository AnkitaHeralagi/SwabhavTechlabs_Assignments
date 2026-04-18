using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    internal class GameEvaluator
    {
        public bool CheckWinner(char[,] grid, char player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (grid[i, 0] == player && grid[i, 1] == player && grid[i, 2] == player)
                    return true;

                if (grid[0, i] == player && grid[1, i] == player && grid[2, i] == player)
                    return true;
            }
            if (grid[0, 0] == player && grid[1, 1] == player && grid[2, 2] == player)
                return true;

            if (grid[0, 2] == player && grid[1, 1] == player && grid[2, 0] == player)
                return true;

            return false;
        }
        public bool IsDraw(char[,] grid)
        {
            foreach (char cell in grid)
            {
                if (cell == '-')
                    return false;
            }
            return true;
        }
    }
}
