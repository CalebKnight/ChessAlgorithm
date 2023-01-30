using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Move
    {
        public Square start { get; set; }
        public Square end { get; set; }
        public ChessPiece piece { get; set; }
        public Move(Square start, Square end, ChessPiece piece)
        {
            this.start = start;
            this.end = end;
            this.piece = piece;
        }



        bool IsLegal()
        {
            return true;
        }


    }
}
