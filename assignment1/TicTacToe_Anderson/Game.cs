using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Anderson
{
    class Game
    {
        HumanPlayer playerX;
        ComputerPlayer playerO;
        Board gameBoard;
        string[] gameArray = new string[9];
        string gamePlayer;

        public void PlayAgain()
        {
            string response;

            DisplayWelcome();

            do
            {
                Console.Clear();
                Play();
                Console.Write("\n\nWould you like to play again? ");
                response = Console.ReadLine().ToUpper();
                response = response.Substring(0, 1);
            }
            while (response == "Y");
        }

        public void DisplayWelcome()
        {
            Console.WriteLine("\nReady to play Tic Tac toe?");
            Console.WriteLine("\nHit any key when you are ready to begin");
            Console.ReadKey();
            Console.Clear();
        }

        public void Play()
        {
            bool result = false;
            bool tieGame = false;
            int selection;

            playerX = new HumanPlayer();
            playerO = new ComputerPlayer();
            gameBoard = new Board();

            for (int index = 0; index < gameArray.Length; index++)
                gameArray[index] = " ";
            gamePlayer = "X";

            DisplayBoardGrid();

            do
            {
                selection = IsPlaying(gamePlayer);
                DisplayBoardGrid();
                DisplayGrid(selection);

                if (gamePlayer == "X")
                    result = gameBoard.IsWinner(playerX);
                else
                    result = gameBoard.IsWinner(playerO);

                if (result)
                    AnnounceWinner();
                else
                    tieGame = gameBoard.IsFull();

                if (tieGame)
                    IsTie();

                if (gamePlayer == "X")
                    gamePlayer = "O";
                else
                    gamePlayer = "X";
            }
            while (!(tieGame || result));
        }

        public void DisplayBoardGrid()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t 0 | 1 | 2 ");
            Console.WriteLine("\t------------");
            Console.WriteLine("\t 3 | 4 | 5 ");
            Console.WriteLine("\t------------");
            Console.WriteLine("\t 6 | 7 | 8 ");
            Console.WriteLine("\n\n");
        }

        public int IsPlaying(string thePlayer)
        {
            int userselection = -1;
            if (thePlayer == "X")
            {
                Console.Write("Player {0}, choose your location: ", thePlayer);
                while ((int.TryParse(Console.ReadLine(), out userselection) == false) || (userselection > 8) || (userselection < 0) || (gameArray[userselection] != " "))
                {
                    Console.WriteLine("\nPlease enter a free number between 0 and 8 that appears on the grid");
                    Console.Write("\nPlayer {0}, choose your location: ", thePlayer);
                }

                userselection = playerX.MakeMove(gameBoard, userselection, playerX);
            }
            else
            {
                userselection = playerO.MakeMove(gameBoard, -1, playerX);
            }

            Console.Clear();

            return userselection;
        }

        public void DisplayGrid(int theSelection)
        {
            
            gameArray[theSelection] = gamePlayer;

            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t {0} | {1} | {2} ", gameArray[0], gameArray[1], gameArray[2]);
            Console.WriteLine("\t------------");
            Console.WriteLine("\t {0} | {1} | {2} ", gameArray[3], gameArray[4], gameArray[5]);
            Console.WriteLine("\t------------");
            Console.WriteLine("\t {0} | {1} | {2} ", gameArray[6], gameArray[7], gameArray[8]);
            Console.WriteLine("\n\n\n");

        }

        public void AnnounceWinner()
        {

            Console.WriteLine("\n\n\n");
            Console.WriteLine("Player {0} has won the game!\n\n\n", gamePlayer);
        }

        public void IsTie()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("The game is a draw. No one won!\n\n\n");
        }

    }
}
