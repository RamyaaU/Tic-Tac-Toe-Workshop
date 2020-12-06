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
            Console.WriteLine("Enter your choice. \nX \n0");
            char userSign = Convert.ToChar(Console.ReadLine());
            string choice;
            switch (userSign)
            {
                case 'X':
                    choice = "You Chose: X";
                    break;
                case '0':
                    choice = "You Chose: 0";
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

        /// UC4
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

        /// <summary>
        /// Computers the movement.
        /// </summary>
        /// <param name="compChoice">The comp choice.</param>
        /// <returns></returns>
        public void ComputerMovement(char compChoice)
        {
            Random random = new Random();
            int computerChoice = random.Next(1, 10);
            bool emptyPosition = PositionCheck(computerChoice);
            if (emptyPosition == true)
            {
                board[computerChoice] = compChoice;
                ShowBoard();
            }
            else
            {
                ComputerMovement(compChoice);
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

        /// <summary>
        /// Plays the specified user choice.
        /// </summary>
        /// <param name="userChoice">The user choice.</param>
        /// <param name="compChoice">The comp choice.</param>
        /// <returns></returns>
        public void Play(char userChoice, char compChoice)
        {
            Player player = Toss();
            int win = 0;
            while (win == 0)
            {
                if (player.Equals(Player.USER))
                {
                    PlayerMovement(userChoice);
                    player = Player.COMPUTER;
                }
                else
                {
                    ComputerMovement(compChoice);
                    player = Player.USER;
                }
                win = CheckWin();
                if (win == 1)
                {
                    if (player == Player.USER)
                    {
                        Console.WriteLine("Computer won");
                        break;
                    }
                    if (player == Player.COMPUTER)
                    {
                        Console.WriteLine("User won");
                        break;
                    }
                }
                else if (win == -1)
                {
                    Console.WriteLine("Game draw");
                    break;
                }
                else
                    continue;
            }
        }

        /// UC7
        /// <summary>
        /// Checks the win.
        /// </summary>
        /// <returns></returns>
        public int CheckWin()
        {
            if (board[1] == board[2] && board[2] == board[3] && board[3] != ' ')
            {
                return 1;
            }
            else if (board[4] == board[5] && board[5] == board[6] && board[6] != ' ')
            {
                return 1;
            }
            else if (board[6] == board[7] && board[7] == board[8] && board[8] != ' ')
            {
                return 1;
            }
            else if (board[1] == board[4] && board[4] == board[7] && board[7] != ' ')
            {
                return 1;
            }
            else if (board[2] == board[5] && board[5] == board[8] && board[8] != ' ')
            {
                return 1;
            }
            else if (board[3] == board[6] && board[6] == board[9] && board[9] != ' ')
            {
                return 1;
            }
            else if (board[1] == board[5] && board[5] == board[9] && board[9] != ' ')
            {
                return 1;
            }
            else if (board[3] == board[5] && board[5] == board[7] && board[7] != ' ')
            {
                return 1;
            }
            else if (board[1] != ' ' && board[2] != ' ' && board[3] != ' ' && board[4] != ' ' && board[5] != ' ' && board[6] != ' ' && board[7] != ' ' && board[8] != ' ' && board[9] != ' ')
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}