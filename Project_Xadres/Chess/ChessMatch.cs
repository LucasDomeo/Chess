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

        public ChessMatch()
        {
            boardd = new board(8, 8);
            turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
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

        public void ExecuteMov(Position origin,  Position destination) 
        {
            Pieces p = boardd.RemovePiece(origin);
            p.NBMovimentsMethod();
            Pieces CAPPiece = boardd.RemovePiece(destination);
            boardd.AddPiece(p, destination);
        }

        private void PutPieces()
        {
            boardd.AddPiece(new Tower(boardd, Color.White), new chessPosition('c', 1).toPosition());
            boardd.AddPiece(new Tower(boardd, Color.White), new chessPosition('c', 2).toPosition());
            boardd.AddPiece(new Tower(boardd, Color.White), new chessPosition('d', 2).toPosition());
            boardd.AddPiece(new Tower(boardd, Color.White), new chessPosition('e', 2).toPosition());
            boardd.AddPiece(new Tower(boardd, Color.White), new chessPosition('e', 1).toPosition());
            boardd.AddPiece(new King(boardd, Color.White), new chessPosition('d', 1).toPosition());

            boardd.AddPiece(new Tower(boardd, Color.Black), new chessPosition('c', 7).toPosition());
            boardd.AddPiece(new Tower(boardd, Color.Black), new chessPosition('c', 8).toPosition());
            boardd.AddPiece(new Tower(boardd, Color.Black), new chessPosition('d', 7).toPosition());
            boardd.AddPiece(new Tower(boardd, Color.Black), new chessPosition('e', 7).toPosition());
            boardd.AddPiece(new Tower(boardd, Color.Black), new chessPosition('e', 8).toPosition());
            boardd.AddPiece(new King(boardd, Color.Black), new chessPosition('d', 8).toPosition());
        }
    }
}
