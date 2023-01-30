using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Board
    {

        public Array squares = Array.CreateInstance(typeof(Square), 8, 8);
        

        public Board()
        {
            InitBoard();
        }

        public void InitBoard()
        {
            //Make chess squares
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Square square = new Square(j, i);
                    squares.SetValue(new Square(j, i), j, i);
                }
            }
            Debug.WriteLine(squares);
        }

        public Square GetSquare(int x, int y)
        {
            return (Square)squares.GetValue(x, y);
        }

       
    }
}


//if (i == 1 || i == 6)
//{
//    ChessPiece chessPiece = new ChessPiece("Pawn", "♟︎", i < 3 ? "Black" : "White", square);

//}
//if (i == 0 || i == 7)
//{
//    ChessPiece chessPiece = new ChessPiece(j, i < 3 ? "Black" : "White", square);
//}