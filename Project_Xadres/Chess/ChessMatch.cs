using System;
using System.Collections.Generic;
using Board;
using Project_Xadres.Chess;

namespace Chess
{
    class ChessMatch
    {
        public board boardd { get; private set; }
        public int turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        public HashSet<Pieces> pieces;
        public HashSet<Pieces> CapPieces;
        public bool check { get; private set; }
        public Pieces vulnerableenpassant { get; private set; }


        public ChessMatch()
        {
            boardd = new board(8, 8);
            turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            check = false;
            vulnerableenpassant = null;
            pieces = new HashSet<Pieces>();
            CapPieces = new HashSet<Pieces>();
            PutPieces();
        }

        public void ValidatingOriginPosition(Position pos)
        {
            if (boardd.piece(pos) == null)
            {
                throw new BoardException("There is no piece for the chosen position!");
            }
            if (CurrentPlayer != boardd.piece(pos).color)
            {
                throw new BoardException("The chosen piece is not yours!");
            }
            if (!boardd.piece(pos).ThereArePosibleMoves())
            {
                throw new BoardException("There are not possible moves for the chosen origin piece!");
            }
        }

        public void ValidatingDestinyPosition(Position origin, Position destiny)
        {
            if (!boardd.piece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Invalid destination position!");
            }
        }

        public void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public HashSet<Pieces> capturedpieces(Color color)
        {
            HashSet<Pieces> aux = new HashSet<Pieces>();
            foreach (Pieces x in CapPieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Pieces>piecesingame(Color color)
        {
            HashSet<Pieces> aux = new HashSet<Pieces>();
            foreach (Pieces x in CapPieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedpieces(color));
            return aux;
        }

        private Color AdversaryPiece(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Pieces KING(Color color)
        {
            foreach (Pieces x in piecesingame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public Pieces ExecuteMov(Position origin,  Position destination) 
        {
            Pieces p = boardd.RemovePiece(origin);
            p.NBMovimentsMethod();
            Pieces CAPPiece = boardd.RemovePiece(destination);
            boardd.AddPiece(p, destination);
            if(CAPPiece != null)
            {
                CapPieces.Add(CAPPiece);
            }

            //Little rock
            if(p is King && destination.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinationT = new Position(origin.Line, origin.Column + 1);
                Pieces T = boardd.RemovePiece(originT);
                T.NBMovimentsMethod();
                boardd.AddPiece(T, destinationT);
            }
            //Big rock
            if (p is King && destination.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinationT = new Position(origin.Line, origin.Column - 1);
                Pieces T = boardd.RemovePiece(originT);
                T.NBMovimentsMethod();
                boardd.AddPiece(T, destinationT);
            }

            //EnPassant
            if(p is Pawn)
            {
                if(origin.Column != destination.Column && CAPPiece == null)
                {
                    Position posP;
                    if(p.color == Color.White)
                    {
                        posP = new Position(destination.Line + 1, destination.Column);
                    }
                    else
                    {
                        posP = new Position(destination.Line - 1, destination.Column);
                    }
                    CAPPiece = boardd.RemovePiece(posP);
                    CapPieces.Add(CAPPiece);
                }
            }

            return CAPPiece;
        }

        public void UndoMove(Position origin, Position destination, Pieces CAPPieces)
        {
            Pieces p = boardd.RemovePiece(destination);
            p.DNBMovimentsMethod();
            if(CapPieces != null)
            {
                boardd.AddPiece(CAPPieces, destination);
                CapPieces.Remove(CAPPieces);
            }
            boardd.AddPiece(p, origin);

            //Little rock
            if (p is King && destination.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinationT = new Position(origin.Line, origin.Column + 1);
                Pieces T = boardd.RemovePiece(destinationT);
                T.DNBMovimentsMethod();
                boardd.AddPiece(T, destinationT);
            }
            //Big rock
            if (p is King && destination.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinationT = new Position(origin.Line, origin.Column - 1);
                Pieces T = boardd.RemovePiece(destinationT);
                T.NBMovimentsMethod();
                boardd.AddPiece(T, originT);
            }

            //EnPassant
            if(p is Pawn)
            {
                if(origin.Column != destination.Column && CAPPieces == vulnerableenpassant)
                {
                    Pieces pawn = boardd.RemovePiece(destination);
                    Position posP;
                    if(p.color == Color.White)
                    {
                        posP = new Position(3, destination.Column);
                    }
                    else
                    {
                        posP = new Position(4, destination.Column);
                    }
                    boardd.AddPiece(pawn, posP);
                }
            }
        }

        public void PerformMove(Position origin, Position destination)
        {
            Pieces CAPPieces = ExecuteMov(origin, destination);
            if (InCheck(CurrentPlayer))
            {
                UndoMove(origin, destination, CAPPieces);
                throw new BoardException("You can't put yourself in check");
            }

            Pieces p = boardd.piece(destination);

            //Promotion
            if(p is Pawn)
            {
                if((p.color == Color.White && destination.Line == 0) || (p.color == Color.Black && destination.Line == 7))
                {
                    p = boardd.RemovePiece(destination);
                    pieces.Remove(p);
                    Pieces queen = new Queen(boardd, p.color);
                    boardd.AddPiece(queen, destination);
                    pieces.Add(queen);
                }
            }

            if (InCheck(AdversaryPiece(CurrentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (testcheckmat(AdversaryPiece(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                turn++;
                ChangePlayer();
            }
            
            //enpassant
            if(p is Pawn && (destination.Line == origin.Line - 2 || destination.Line == origin.Line + 2))
            {
                vulnerableenpassant = p;
            }
            else
            {
                vulnerableenpassant = null;
            }
        }

        public bool InCheck(Color color)
        {
            Pieces K = KING(color);
            foreach(Pieces x in piecesingame(AdversaryPiece(color)))
            {
                bool[,] mat = x.PosibleMoviments();
                if (mat[K.position.Line, K.position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testcheckmat(Color color)
        {
            if (!InCheck(color))
            {
                return false;
            }
            foreach(Pieces x in piecesingame(color))
            {
                bool[,] mat = x.PosibleMoviments();
                for(int i = 0; i<boardd.line; i++)
                {
                    for(int j = 0; i<boardd.column; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position destination = new Position(i, j);
                            Pieces cp = ExecuteMov(origin, destination);
                            bool tc = InCheck(color);
                            UndoMove(origin, destination, cp);
                            if (!tc)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PutNewPiece(char column, int line, Pieces piece)
        {
            boardd.AddPiece(piece, new chessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('a', 1, new Tower(boardd, Color.White));
            PutNewPiece('b', 1, new Horse(boardd, Color.White));
            PutNewPiece('c', 1, new Bishop(boardd, Color.White));
            PutNewPiece('d', 1, new Queen(boardd, Color.White));
            PutNewPiece('e', 1, new King(boardd, Color.White, this));
            PutNewPiece('f', 1, new Bishop(boardd, Color.White));
            PutNewPiece('g', 1, new Horse(boardd, Color.White));
            PutNewPiece('h', 1, new Tower(boardd, Color.White));
            PutNewPiece('a', 2, new Pawn(boardd, Color.White, this));
            PutNewPiece('b', 2, new Pawn(boardd, Color.White, this));
            PutNewPiece('c', 2, new Pawn(boardd, Color.White, this));
            PutNewPiece('d', 2, new Pawn(boardd, Color.White, this));
            PutNewPiece('e', 2, new Pawn(boardd, Color.White, this));
            PutNewPiece('f', 2, new Pawn(boardd, Color.White, this));
            PutNewPiece('g', 2, new Pawn(boardd, Color.White, this));
            PutNewPiece('h', 2, new Pawn(boardd, Color.White, this));

            PutNewPiece('a', 8, new Tower(boardd, Color.Black));
            PutNewPiece('b', 8, new Horse(boardd, Color.Black));
            PutNewPiece('c', 8, new Bishop(boardd, Color.Black));
            PutNewPiece('d', 8, new Queen(boardd, Color.Black));
            PutNewPiece('e', 8, new King(boardd, Color.Black, this));
            PutNewPiece('f', 8, new Bishop(boardd, Color.Black));
            PutNewPiece('g', 8, new Horse(boardd, Color.Black));
            PutNewPiece('h', 8, new Tower(boardd, Color.Black));
            PutNewPiece('a', 7, new Pawn(boardd, Color.Black, this));
            PutNewPiece('b', 7, new Pawn(boardd, Color.Black, this));
            PutNewPiece('c', 7, new Pawn(boardd, Color.Black, this));
            PutNewPiece('d', 7, new Pawn(boardd, Color.Black, this));
            PutNewPiece('e', 7, new Pawn(boardd, Color.Black, this));
            PutNewPiece('f', 7, new Pawn(boardd, Color.Black, this));
            PutNewPiece('g', 7, new Pawn(boardd, Color.Black, this));
            PutNewPiece('h', 7, new Pawn(boardd, Color.Black, this));
        }
    }
}
