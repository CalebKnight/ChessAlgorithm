using System;
using System.Collections;
using System.Diagnostics;

namespace Chess
{
    internal class Algorithm
    {
        ChessPieceDict chessPieceDict = new ChessPieceDict();

        public Move GenerateMove(Array allyPieces, Array enemyPieces)
        {

            Tuple<int, Move> move = GenerateRecursiveMoves(allyPieces, enemyPieces, null, 4, 0, 0, 0);
            //Trace.WriteLine(move.Item1);
            return (null);

            



        }


        Tuple<int, Move> GenerateRecursiveMoves(Array allyPieces, Array enemyPieces, Move? firstMove, int depth, int count, int allyScore, int enemyScore)
        {
           if(count == depth)
            {
                if(allyScore - enemyScore != 0)
                {
                    Trace.WriteLine(firstMove.start.x + " " + firstMove.start.y + " " + firstMove.end.x + " " + firstMove.end.y);
                }
                
               
                return (new Tuple<int, Move>(allyScore - enemyScore, firstMove));
            }
         

            ArrayList potentialMoves = new ArrayList();
            ArrayList potentialCaptures = new ArrayList();

            foreach (ChessPiece ally in allyPieces)
            {
              

                ArrayList moves = GenerateMoves(ally);
                ArrayList vision = GenerateVision(ally);
                foreach(ChessPiece enemy in enemyPieces)
                {
                    if (vision != null && vision.)
                    {
                        Trace.WriteLine("here");
                        potentialCaptures.Add(GenerateCapture(ally, enemy));
                    }
                    if (moves != null && moves.Contains(enemy.square))
                    {
                        moves.Remove(enemy.square);
                    }
                }
                if(moves != null)
                {
                    foreach (Square move in moves)
                    {
                        potentialMoves.Add(new Move(ally.square, move, ally));
                    }
                }

            }

            int bestScore = 0;
            Move bestMove = null;
            foreach (Move move in potentialMoves)
            {
                if (count == 0)
                {
                    firstMove = move;
                }
                MakeMove(move, allyPieces);
                Tuple<int, Move> evaluatedLine = GenerateRecursiveMoves(allyPieces, enemyPieces, firstMove, depth, count + 1, allyScore, enemyScore);
                UndoMove(move, allyPieces);
                if (evaluatedLine.Item1 > bestScore)
                {
                    
                    bestScore = evaluatedLine.Item1;
                    bestMove = move;
                }
            }

            foreach (Tuple<Move, ChessPiece> capture in potentialCaptures)
            {
                Trace.WriteLine("here");
                if (count == 0)
                {
                    firstMove = capture.Item1;
                }
                Trace.WriteLine("HERE!");
                MakeMove(capture.Item1, allyPieces);
                capture.Item2.alive = false;
                Tuple<int, Move> evaluatedLine = GenerateRecursiveMoves(allyPieces, enemyPieces, firstMove, depth, count + 1, allyScore + chessPieceDict.GetPieceValue(capture.Item2.name), enemyScore);
                capture.Item2.alive = true;
                UndoMove(capture.Item1, allyPieces);
                if (evaluatedLine.Item1 > bestScore)
                {
                    Trace.WriteLine("Here");
                    bestScore = evaluatedLine.Item1;
                    bestMove = capture.Item1;
                }
            }



            // write move to console
            if (count == 0)
            {
                if(bestMove == null)
                {
                    Trace.WriteLine("wtf");
                }
                else
                {
                Trace.WriteLine(bestMove.start.x + " " + bestMove.start.y + " " + bestMove.end.x + " " + bestMove.end.y);
                }
            }
            

            return (bestMove == null ? new Tuple<int, Move>(0, null) : new Tuple<int, Move>(bestScore, bestMove));

        }


        private void MakeMove(Move move, Array allyPieces)
        {
            move.piece.SetSquare(move.end);
            allyPieces.SetValue(move.piece, move.piece.id);
        }

        private void UndoMove(Move move, Array allyPieces)
        {
            move.piece.SetSquare(move.start);
            allyPieces.SetValue(move.piece, move.piece.id);
        }

        

        private Tuple<Move, ChessPiece> GenerateCapture(ChessPiece ally, ChessPiece enemy)
        {
            Move move = new Move(ally.square, enemy.square, ally);
            return (new Tuple<Move, ChessPiece>(move, enemy));
        }

        private ArrayList GenerateMoves(ChessPiece ally)
        {
            switch (ally)
            {
                case Pawn pawn:
                    return pawn.GetMoves();
                default:
                    return null;
            }
        }

        private ArrayList GenerateVision(ChessPiece ally)
        {
            switch (ally)
            {
                case Pawn pawn:
                    return pawn.GetVision();
                default:
                    return null;
            }
        }







    }

    //Chess pieces have both vision and a distance they can move


}
