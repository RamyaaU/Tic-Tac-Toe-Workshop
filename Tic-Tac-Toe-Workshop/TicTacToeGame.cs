using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_Workshop
{
    class TicTacToeGame
    {
        public char[] board;
        
        public enum Player { USER, COMPUTER };

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
            for (int position = 1; position < 10; position++)
            {
                board[position] = ' ';
            }
        }

        /// UC2
        /// <summary>
        /// Choices this instance.
        /// </summary>
        /// <returns></returns>
        public char Choice()
        {
            Console.WriteLine("Enter your choice. \nX \nO");
            char userSign = Convert.ToChar(Console.ReadLine());
            string choice;
            switch (userSign)
            {
                case 'X':
                    choice = "You Chose: X";
                    break;
                case 'O':
                    choice = "You Chose: O";
                    break;
                default:
                    choice = "Invalid Choice";
                    break;
            }
            Console.WriteLine(choice);
            if (choice == "Invalid Choice")
                Choice();
            return userSign;
        }

        /// UC3
        /// <summary>
        /// Shows the board.
        /// </summary>
        public void ShowBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1], board[2], board[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[4], board[5], board[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[7], board[8], board[9]);
            Console.WriteLine("     |     |      ");
        }

        /// <summary>
        /// Positions the check.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        public bool PositionCheck(int position)
        {
            if (board[position] == ' ')
                return true;
            else
            {
                return false;
            }
        }

        /// UC5
        /// <summary>
        /// Players the movement.
        /// </summary>
        /// <param name="choice">The choice.</param>
        public void PlayerMovement(char choice)
        {
            Console.WriteLine("Select the position you want to play on");
            int userChoice = int.Parse(Console.ReadLine());
            bool emptyPosition = PositionCheck(userChoice);
            if (emptyPosition == true)
            {
                board[userChoice] = choice;
                ShowBoard();
            }
            else
            {
                Console.WriteLine("Position already occupied");
                Console.WriteLine("Try Again");
                PlayerMovement(choice);
            }
        }

        /// UC6
        /// <summary>
        /// Tosses this instance.
        /// </summary>
        /// <returns></returns>
        public Player Toss()
        {
            Random random = new Random();
            int toss = random.Next(1, 3);
            if (toss == 1)
            {
                Console.WriteLine("User will begin");
                return Player.USER;
            }
            else
            {
                Console.WriteLine("Computer will begin");
                return Player.COMPUTER;
            }
        }
    }
}
