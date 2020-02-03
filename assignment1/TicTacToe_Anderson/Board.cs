using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TicTacToe_Anderson
{
    class Board
    {
        int[,] winningCombos = {    {0,1,2},
                                    {3,4,5},
                                    {6,7,8},
                                    {0,3,6},
                                    {1,4,7},
                                    {2,5,8},
                                    {0,4,8},
                                    {2,4,6} };

        ArrayList openPositions = new ArrayList();


        public Board()
        {
            openPositions.Clear();
            openPositions.Add(4);
            openPositions.Add(0);
            openPositions.Add(2);
            openPositions.Add(6);
            openPositions.Add(8);
            openPositions.Add(1);
            openPositions.Add(3);
            openPositions.Add(5);
            openPositions.Add(7);
        }

        public int[,] WinningCombos
        {
            get
            {
                return winningCombos;
            }
        }

        public ArrayList OpenPositions
        {
            get
            {
                return openPositions;
            }

            set
            {
                openPositions = value;
            }
        }

        public bool IsWinner(Player thePlayer)
        {
            bool winner = false;

            for (int rowIndex = 0; rowIndex < winningCombos.GetLength(0); rowIndex++)
            {
                if ((thePlayer.Pieces[winningCombos[rowIndex, 0]]) && (thePlayer.Pieces[winningCombos[rowIndex, 1]]) && (thePlayer.Pieces[winningCombos[rowIndex, 2]]))
                    winner = true;
            }

            return winner;
        }

        public bool IsFull()
        {
            bool tie = false;

            if (openPositions.Count == 0)
                tie = true;

            return tie;
        }
    }
}
