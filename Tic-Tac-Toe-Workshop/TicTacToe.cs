using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_Workshop
{
    public class TicTacToeGame
    {
        public char[] board;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicTacToeGame"/> class.
        /// </summary>
        public TicTacToeGame()
        {
            board = new char[10];
        }

        /// UC1
        /// <summary>
        /// Creates the board.
        /// </summary>
        public void CreateBoard()
        {
            TicTacToeGame game = new TicTacToeGame();
            for (int position = 1; position < 10; position++)
            {
                game.board[position] = ' ';
            }
        }
    }
}
