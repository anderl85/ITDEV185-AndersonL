using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Anderson
{
    class HumanPlayer : Player
    {
        public HumanPlayer()
            : base()        
        {

        }

        public override int MakeMove(Board gameBoard, int position, HumanPlayer PlayerX)  
        {                                                                                   
            int index;
            base.Pieces[position] = true;

            index = (int)gameBoard.OpenPositions.IndexOf(position);
            gameBoard.OpenPositions.RemoveAt(index);

            return position;
        }
    }
}
