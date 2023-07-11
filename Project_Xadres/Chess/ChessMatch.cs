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
        private int turn;
        private Color CurrentPlayer;
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            boardd = new board(8, 8);
            turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            PutPieces();
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
