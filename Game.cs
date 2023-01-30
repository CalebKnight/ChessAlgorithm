using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace Chess
{
    internal class Game
    {
        public ArrayList moves = new ArrayList();
        public Array whitePieces = Array.CreateInstance(typeof(ChessPiece), 16);
        public Array blackPieces = Array.CreateInstance(typeof(ChessPiece), 16);
        public Board board = new Board();
        public Algorithm whiteBot = new Algorithm();
        public Algorithm blackBot = new Algorithm();

        public Game()
        {
            InitGame();
        }

        public void PlayMove(string color)
        {
            Move move;
            if (color == "White")
            {
                
                Array whitePiecesCopy = Array.CreateInstance(typeof(ChessPiece), 16);
                Array blackPiecesCopy = Array.CreateInstance(typeof(ChessPiece), 16);
                whitePiecesCopy = CopyArray(whitePieces);
                blackPiecesCopy = CopyArray(blackPieces);
                move = whiteBot.GenerateMove(whitePiecesCopy, blackPiecesCopy);
                // Set square to new square
                if(move == null)
                {
                    return;
                }
                move.piece.SetSquare(move.end);
                whitePieces.SetValue(move.piece, move.piece.id);
                // Remove enemy piece
                foreach (ChessPiece piece in blackPieces)
                {
                    if (piece.square.x == move.end.x && piece.square.y == move.end.y)
                    {
                        piece.alive = false;
                    }
                }
            }
            else
            {
                Array whitePiecesCopy = Array.CreateInstance(typeof(ChessPiece), 16);
                Array blackPiecesCopy = Array.CreateInstance(typeof(ChessPiece), 16);
                whitePiecesCopy = CopyArray(whitePieces);
                blackPiecesCopy = CopyArray(blackPieces);

                move = blackBot.GenerateMove(blackPiecesCopy, whitePiecesCopy);

                // Set square to new square
                if (move == null)
                {
                    return;
                }
                move.piece.SetSquare(move.end);
                blackPieces.SetValue(move.piece, move.piece.id);
                foreach (ChessPiece piece in whitePieces)
                {
                    if (piece.square.x == move.end.x && piece.square.y == move.end.y)
                    {
                        piece.alive = false;
                    }
                }
            }
            if (move != null)
            {
                moves.Add(move);
            }

        }

        

        private void InitGame()
        {
            AddPieces();
        }

        private void AddPieces()
        {
            GenWhite();
            GenBlack();
        }

        private void GenWhite()
        {
            for (int j = 0; j < 8; j++)
            {
                ChessPiece pawn = new ChessPiece(j, "Pawn", "♟︎", "White", board.GetSquare(j,1));
                // This overload uses a dict to find the relevant piece
                ChessPiece piece = new ChessPiece(j, "White", board.GetSquare(j,0));
                whitePieces.SetValue(pawn, j);
                whitePieces.SetValue(piece, j + 8);
            }
        }

        private void GenBlack()
        {
            for (int j = 0; j < 8; j++)
            {
                ChessPiece pawn = new ChessPiece(j, "Pawn", "♟︎", "Black", board.GetSquare(j, 6));
                // This overload uses a dict to find the relevant piece
                ChessPiece piece = new ChessPiece(j, "Black", board.GetSquare(j, 7));
                blackPieces.SetValue(pawn, j);
                blackPieces.SetValue(piece, j + 8);
            }
        }

        private Array CopyArray(Array array)
        {
            Array copy = Array.CreateInstance(typeof(ChessPiece), 16);
            for (int i = 0; i < array.Length; i++)
            {
                ChessPiece piece = (ChessPiece)array.GetValue(i);
                ChessPiece pieceCopy = new ChessPiece(piece.id, piece.name, piece.icon, piece.color, piece.square, piece.alive);
                copy.SetValue(pieceCopy, i);
            }
            return copy;
        }



    }
}



