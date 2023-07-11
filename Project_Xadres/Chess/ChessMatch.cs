using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ChessMatch()
        {
            boardd = new board(8, 8);
            turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            pieces = new HashSet<Pieces>();
            CapPieces = new HashSet<Pieces>();
            PutPieces();
        }

        public void PerformMove(Position origin,  Position destination)
        {
            ExecuteMov(origin, destination);
            turn++;
            ChangePlayer();
        }

        public void ValidatingOriginPosition(Position pos)
        {
            if (boardd.piece(pos) == null)
            {
                throw new BoardException("There is no piece for the chosen position!");
            }
            if(CurrentPlayer != boardd.piece(pos).color)
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
            if(CurrentPlayer == Color.White)
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
            foreach(Pieces x  in CapPieces)
            {
                if(x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Pieces> piecesingame(Color color)
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

        public void ExecuteMov(Position origin,  Position destination) 
        {
            Pieces p = boardd.RemovePiece(origin);
            p.NBMovimentsMethod();
            Pieces CAPPiece = boardd.RemovePiece(destination);
            boardd.AddPiece(p, destination);
            if(CAPPiece != null)
            {
                CapPieces.Add(CAPPiece);
            }
        }

        public void PutNewPiece(char column, int line, Pieces piece)
        {
            boardd.AddPiece(piece, new chessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('c', 1, new Tower(boardd, Color.White));
            PutNewPiece('c', 2, new Tower(boardd, Color.White));
            PutNewPiece('d', 2, new Tower(boardd, Color.White));
            PutNewPiece('e', 2, new Tower(boardd, Color.White));
            PutNewPiece('e', 1, new Tower(boardd, Color.White));
            PutNewPiece('d', 1, new King(boardd, Color.White));

            PutNewPiece('c', 7, new Tower(boardd, Color.Black));
            PutNewPiece('c', 8, new Tower(boardd, Color.Black));
            PutNewPiece('d', 7, new Tower(boardd, Color.Black));
            PutNewPiece('e', 7, new Tower(boardd, Color.Black));
            PutNewPiece('e', 8, new Tower(boardd, Color.Black));
            PutNewPiece('d', 8, new King(boardd, Color.Black));
        }
    }
}
