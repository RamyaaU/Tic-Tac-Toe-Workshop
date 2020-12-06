using System;

namespace Tic_Tac_Toe_Workshop
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to Tic-Tac-Toe!");
            TicTacToeGame game = new TicTacToeGame();
            int playAnotherGame = 1;
            while (playAnotherGame == 1)
            {
                game.CreateBoard();
                char userChoice = game.Choice();
                char compChoice;
                if (userChoice == 'X')
                    compChoice = 'O';
                else
                    compChoice = 'X';
                game.ShowBoard();
                game.Play(userChoice, compChoice);
                Console.WriteLine("Do you want to play another game? \n1. Yes\n2. No");
                playAnotherGame = int.Parse(Console.ReadLine());
            }
    }
}
