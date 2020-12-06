using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_Workshop
{
    class TicTacToeGame
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

        /// UC2
        /// <summary>
        /// Choices this instance.
        /// </summary>
        public void Choice()
        {
            Console.WriteLine("Enter your choice. \nX \n0");
            string userChoice = Console.ReadLine();
            string choice;
            switch (userChoice)
            {
                case "X":
                    choice = "You Chose: X";
                    break;
                case "O":
                    choice = "You Chose: O";
                    break;
                default:
                    choice = "Invalid Choice";
                    break;
            }
            Console.WriteLine(choice);
            if (choice == "Invalid Choice")
                Choice();
        }

        /// UC3
        /// <summary>
        /// Shows the board.
        /// </summary>
        public void ShowBoard()
        {
            TicTacToeGame game = new TicTacToeGame();
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", game.board[1], game.board[2], game.board[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", game.board[4], game.board[5], game.board[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", game.board[7], game.board[8], game.board[9]);
            Console.WriteLine("     |     |      ");
        }
    }
}
