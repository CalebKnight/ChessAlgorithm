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
            return (move.Item2);

            



        }


        Tuple<int, Move> GenerateRecursiveMoves(Array allyPieces, Array enemyPieces, Move? firstMove, int depth, int count, int allyScore, int enemyScore)
        {
            if (count == depth)
            {
                ////Trace.WriteLine(allyScore - enemyScore);
                return new Tuple<int, Move>(allyScore - enemyScore, firstMove);

            }
            ArrayList possibleLines = new ArrayList();
            foreach (ChessPiece ally in allyPieces)
            {
                if (ally.name != "Pawn")
                {
                    continue;
                }

                ArrayList moves = GetPawnMoves(ally, enemyPieces);
                foreach (Square square in moves)
                {
                    if (count == 0)
                    {
                        firstMove = new Move(ally.square, square, ally);
                    }
                    foreach (ChessPiece enemy in enemyPieces)
                    {
                        if (enemy.square.x == square.x && enemy.square.y == square.y)
                        {
                            allyScore += chessPieceDict.GetPieceValue(enemy.name);
                            ally.SetSquare(square);
                            //enemy.alive = false;
                            possibleLines.Add(GenerateRecursiveMoves(enemyPieces, allyPieces, firstMove, depth, count + 1, allyScore, enemyScore));
                        }
                        else
                        {
                            ally.SetSquare(square);
                            possibleLines.Add(GenerateRecursiveMoves(enemyPieces, allyPieces, firstMove, depth, count + 1, allyScore, enemyScore));
                        }
                    }
                   
                }

                



                



            }
            int bestScore = 0;
            Move bestMove = null;
         
            foreach (Tuple<int, Move> possibleMove in possibleLines)
            {
                if (possibleMove.Item1 > bestScore)
                {
                    bestScore = possibleMove.Item1;
                    
                    bestMove = possibleMove.Item2;

                }
            }
            if(possibleLines.Count == 0)
            {
                //Trace.WriteLine("Woah");
            }
            if(bestMove != null)
            {
             
            }
            
            return (new Tuple<int, Move>(bestScore, bestMove));


        }





        public ArrayList GetPawnMoves(ChessPiece piece, Array enemyPieces)
        {
            ArrayList moves = new ArrayList();
            int x = piece.square.x;
            int y = piece.square.y;
            ChessPiece enemyPiece = (ChessPiece)enemyPieces.GetValue(piece.square.x);
            if(enemyPiece.name != "Pawn")
            {
                Trace.WriteLine("Something else");
            }
            if (piece.color == "White")
            {
                if (x < 7)
                {
                    ChessPiece adjacentRight = (ChessPiece)enemyPieces.GetValue(piece.square.x + 1);
                    if (adjacentRight != null && adjacentRight.square.y == y + 1)
                    {
                        moves.Add(new Square(x + 1, y + 1));
                    }

                }
                if (x > 0)
                {
                    ChessPiece adjacentLeft = (ChessPiece)enemyPieces.GetValue(piece.square.x - 1);
                    if (adjacentLeft != null && adjacentLeft.square.y == y + 1)
                    {
                        moves.Add(new Square(x - 1, y + 1));
                    }
                }
                if (y == 7 || (enemyPiece.square.y == y + 1 && enemyPiece.square.x == x))
                {
                    return moves;
                }
                else
                {
                    moves.Add(new Square(x, y + 1));
                    if (y == 1)
                    {
                        moves.Add(new Square(x, y + 2));
                    }
                    
                }

            }
            else
            {
                if (x < 7)
                {
                    ChessPiece adjacentRight = (ChessPiece)enemyPieces.GetValue(piece.square.x + 1);
                    if (adjacentRight != null && adjacentRight.square.y == y - 1)
                    {
                        moves.Add(new Square(x + 1, y - 1));
                    }
                }
                if (x > 0)
                {
                    ChessPiece adjacentLeft = (ChessPiece)enemyPieces.GetValue(piece.square.x - 1);
                    if (adjacentLeft != null && adjacentLeft.square.y == y - 1)
                    {
                        moves.Add(new Square(x - 1, y - 1));
                    }
                }
                if (y == 0 || (enemyPiece.square.y == y - 1 && enemyPiece.square.x == x))
                {
                    return moves;
                }
                else
                {
                    moves.Add(new Square(x, y - 1));
                    if (y == 6)
                    {
                        moves.Add(new Square(x, y - 2));
                    }
                   
                }
            }
            return moves;
        }

    }

    //Chess pieces have both vision and a distance they can move


}
