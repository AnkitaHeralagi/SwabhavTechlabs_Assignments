using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    internal class Board
    {
        private char[,] grid = new char[3, 3];
        public Board()
        {
            Reset();
        }
        public void Reset()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    grid[i, j] = '-';
        }
        public bool IsValidPosition(int row, int col)
        {
            return row >= 0 && row < 3 && col >= 0 && col < 3;
        }
        public bool PlaceMark(int row, int col, char mark)
        {
            if (!IsValidPosition(row, col))
                return false;
            if (grid[row, col] == '-')
            {
                grid[row, col] = mark;
                return true;
            }
            return false;
        }
        public char[,] GetGrid()
        {
            return (char[,])grid.Clone();
        }
        public void Display()
        {
            Console.WriteLine("\nCurrent Board:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{grid[i, 0]} | {grid[i, 1]} | {grid[i, 2]}");
                if (i < 2) Console.WriteLine("--+---+--");
            }
        }
    }
}
