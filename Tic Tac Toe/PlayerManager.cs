using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    internal class PlayerManager
    {
        private char currentPlayer = 'X';
        public char GetCurrentPlayer()
        {
            return currentPlayer;
        }
        public void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }
        public void Reset()
        {
            currentPlayer = 'X';
        }
    }
}
