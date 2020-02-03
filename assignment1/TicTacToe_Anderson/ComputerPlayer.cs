using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TicTacToe_Anderson
{
    class ComputerPlayer : Player
    {
        ArrayList defaultMoves = new ArrayList();
        public ComputerPlayer()
        {
            defaultMoves.Clear();
            defaultMoves.Add(4);
            defaultMoves.Add(0);
            defaultMoves.Add(2);
            defaultMoves.Add(6);
            defaultMoves.Add(8);
            defaultMoves.Add(1);
            defaultMoves.Add(3);
            defaultMoves.Add(5);
            defaultMoves.Add(7);
        }
        
        public override int MakeMove(Board gameBoard, int position, HumanPlayer aPlayer)
        {
            int move;
           
            //check for computer win (8 possible wins)
            for (int rowIndex = 0; rowIndex < gameBoard.WinningCombos.GetLength(0); rowIndex++)
            {
                if ((Pieces[gameBoard.WinningCombos[rowIndex, 0]]) && (Pieces[gameBoard.WinningCombos[rowIndex, 1]]))
                {
                    move = gameBoard.WinningCombos[rowIndex, 2]; rowIndex = 100; return move;
                }
                else if ((Pieces[gameBoard.WinningCombos[rowIndex, 0]]) && (Pieces[gameBoard.WinningCombos[rowIndex, 2]]))
                {
                    move = gameBoard.WinningCombos[rowIndex, 1]; rowIndex = 100; return move;
                }
                else if ((Pieces[gameBoard.WinningCombos[rowIndex, 1]]) && (Pieces[gameBoard.WinningCombos[rowIndex, 2]]))
                {
                    move = gameBoard.WinningCombos[rowIndex, 0]; rowIndex = 100; return move;
                }
            }
            //check for player block
            for (int rowIndex2 = 0; rowIndex2 < gameBoard.WinningCombos.GetLength(0); rowIndex2++)
            {
                if ((aPlayer.Pieces[gameBoard.WinningCombos[rowIndex2, 0]]) && (aPlayer.Pieces[gameBoard.WinningCombos[rowIndex2, 1]]))
                {
                    move = gameBoard.WinningCombos[rowIndex2, 2]; rowIndex2 = 100; return move;
                }
                else if ((aPlayer.Pieces[gameBoard.WinningCombos[rowIndex2, 0]]) && (aPlayer.Pieces[gameBoard.WinningCombos[rowIndex2, 2]]))
                {
                    move = gameBoard.WinningCombos[rowIndex2, 1]; rowIndex2 = 100; return move;
                }
                else if ((aPlayer.Pieces[gameBoard.WinningCombos[rowIndex2, 1]]) && (aPlayer.Pieces[gameBoard.WinningCombos[rowIndex2, 2]]))
                {
                    move = gameBoard.WinningCombos[rowIndex2, 0]; rowIndex2 = 100; return move;
                }
            }
            //go to default (alter default first)
            int go = 1;
            while (go == 1)
            { 
                if(gameBoard.OpenPositions.Contains(defaultMoves[0]) == false)
                {
                    defaultMoves.RemoveAt(0);
                }
                else
                {
                    move = int.Parse(defaultMoves[0].ToString());
                    go = 0;
                    return move;
                }
            }
            return -9999999;
        }
    }
}
