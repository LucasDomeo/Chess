using System.Net.NetworkInformation;

namespace Board
{
    class board
    {
        public int line { get; set; }
        public int column { get; set; }
        private Pieces[,] pieces;

        public board(int line, int column)
        {
            this.line = line;
            this.column = column;
            pieces = new Pieces[line, column];
        }

        public Pieces piece (int line, int column)
        {
            return pieces[line, column];
        }

        public Pieces piece (Position pos)
        {
            return pieces[pos.Line, pos.Column];
        }

        public void AddPiece(Pieces p, Position pos)
        {
            if (HasPiece(pos))
            {
                throw new BoardException("There is a piece");
            }
            pieces[pos.Line, pos.Column] = p;
            p.position = pos;
        }

        public Pieces RemovePiece(Position pos)
        {
            if(piece(pos) == null)
            {
                return null;
            }
            Pieces aux = piece(pos);
            aux.position = null;
            pieces[pos.Line, pos.Column] = null;
            return aux;
        }

        public bool HasPiece(Position pos) 
        {
            return piece(pos) != null;
        }

        public bool validposition(Position pos)
        {
            if(pos.Line < 0 || pos.Line >= line || pos.Column < 0 || pos.Column >= column)
            {
                return false;
            }
            return true;
        }

        public void AvaliatePosition(Position pos) 
        {
            if(!validposition(pos)) 
            {
                throw new BoardException("Invalid Position");
            }
        }
    }
}
