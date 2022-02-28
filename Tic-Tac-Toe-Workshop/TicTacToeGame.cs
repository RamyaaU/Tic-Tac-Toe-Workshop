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
            board = new char[15];
        }

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
        /// <param name="userChoice">The user choice.</param>
        public void ComputerMovement(char compChoice, char userChoice)
        {
            int compWinMove = WinningMove(compChoice);
            if (compWinMove == 0)
            {
                int userWinMove = WinningMove(userChoice);
                if (userWinMove == 0)
                {
                    if (CornerMove() == 0)
                    {
                        if (PositionCheck(5) == false)
                        {
                            Random random = new Random();
                            int[] middleIndices = { 2, 4, 6, 8 };
                            int index = random.Next(middleIndices.Length);
                            int computerChoice = middleIndices[index];
                            bool emptyPosition = PositionCheck(computerChoice);
                            if (emptyPosition == true)
                            {
                                board[computerChoice] = compChoice;
                                ShowBoard();
                            }
                            else
                            {
                                ComputerMovement(compChoice, userChoice);
                            }
                        }
                        else
                        {
                            board[5] = compChoice;
                            ShowBoard();
                        }
                    }
                    else
                    {
                        board[CornerMove()] = compChoice;
                        ShowBoard();
                    }
                }
                else
                {
                    board[userWinMove] = compChoice;
                    ShowBoard();
                }
            }
            else
            {
                board[compWinMove] = compChoice;
                ShowBoard();
            }
        }

        /// <summary>
        /// Winnings the move.
        /// </summary>
        /// <param name="choice">The choice.</param>
        /// <returns></returns>
        public int WinningMove(char choice)
        {
            int winningIndex = 0;
            for (int i = 1; i < 10; i++)
            {
                if (PositionCheck(i) == true)
                {
                    board[i] = choice;
                    if (CheckWin() == 1)
                    {
                        board[i] = ' ';
                        winningIndex = i;
                        break;
                    }
                    else
                    {
                        board[i] = ' ';
                        winningIndex = 0;
                        continue;
                    }
                }
                else
                    continue;
            }
            return winningIndex;
        }

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
                    ComputerMovement(compChoice, userChoice);
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

        /// <summary>
        /// Corners the move.
        /// </summary>
        /// <returns></returns>
        public int CornerMove()
        {
            int[] corners = { 1, 3, 7, 9 };
            int freeCorner = 0;
            foreach (int i in corners)
            {
                if (PositionCheck(i) == true)
                {
                    freeCorner = i;
                    break;
                }
                else
                    continue;
            }
            return freeCorner;
        }
    }
}