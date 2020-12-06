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
            game.CreateBoard();
            char choice = game.Choice();
            game.ShowBoard();
            game.PlayerMovement(choice);
        }
    }
}
