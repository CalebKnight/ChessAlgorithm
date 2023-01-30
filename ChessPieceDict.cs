using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class ChessPieceDict
    {
        public Dictionary<int, Tuple<string, string>> ChessPieces = new Dictionary<int, Tuple<string, string>>();

        public Dictionary<int, string> PieceCords = new Dictionary<int, string>();

        public Dictionary<string, int> PieceValues = new Dictionary<string, int>();

        public ChessPieceDict()
        {
            AddPieces();
            AddCords();
            AddPieceValues();
        }

        public string GetPieceName(int id)
        {
            return ChessPieces[id].Item1;
        }

        public string GetPieceIcon(int id)
        {
            return ChessPieces[id].Item2;
        }

        public string GetPieceCords(int id)
        {
            return PieceCords[id];
        }

        public int GetPieceValue(string name)
        {
            return PieceValues[name];
        }

        private void AddPieces()
        {
            ChessPieces.Add(0, new Tuple<string, string>("Rook", "♜"));
            ChessPieces.Add(1, new Tuple<string, string>("Knight", "♞"));
            ChessPieces.Add(2, new Tuple<string, string>("Bishop", "♝"));
            ChessPieces.Add(3, new Tuple<string, string>("Queen", "♛"));
            ChessPieces.Add(4, new Tuple<string, string>("King", "♚"));
            ChessPieces.Add(5, new Tuple<string, string>("Bishop", "♝"));
            ChessPieces.Add(6, new Tuple<string, string>("Knight", "♞"));
            ChessPieces.Add(7, new Tuple<string, string>("Rook", "♜"));
        }

        private void AddCords()
        {
            PieceCords.Add(0, "A");
            PieceCords.Add(1, "B");
            PieceCords.Add(2, "C");
            PieceCords.Add(3, "D");
            PieceCords.Add(4, "E");
            PieceCords.Add(5, "F");
            PieceCords.Add(6, "G");
            PieceCords.Add(7, "H");
        }

        private void AddPieceValues()
        {
            PieceValues.Add("Pawn", 1);
            PieceValues.Add("Rook", 5);
            PieceValues.Add("Knight", 3);
            PieceValues.Add("Bishop", 3);
            PieceValues.Add("Queen", 9);
            PieceValues.Add("King", 100);
        }



    }
}
