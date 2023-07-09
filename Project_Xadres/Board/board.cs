using System.Net.NetworkInformation;

namespace Board
{
    class boardd
    {
        public int line { get; set; }
        public int column { get; set; }
        private Pieces[,] pieces;

        public boardd(int line, int column)
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

        public void SetPiece(Pieces p, Position pos)
        {
            if (HasPiece(pos))
            {
                throw new BoardException("There is a piece");
            }
            pieces[pos.Line, pos.Column] = p;
            p.position = pos;
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
