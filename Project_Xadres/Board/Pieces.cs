using Board;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;

namespace Board
{
    abstract class Pieces
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int NBMoviments { get; protected set; }
        public board bd { get; protected set; }

        public Pieces(board bd , Color color)
        {
            this.position = null;
            this.color = color;
            this.bd = bd;
            NBMoviments = 0;
        }

        public void NBMovimentsMethod()
        {
            NBMoviments++;
        }

        public bool ThereArePosibleMoves()
        {
            bool[,] mat = PosibleMoviments();
            for(int i = 0; i < bd.line; i++)
            {
                for(int j = 0; j < bd.column; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos) 
        {
            return PosibleMoviments()[pos.Line, pos.Column];
        }

        public abstract bool[,] PosibleMoviments();

    }
}
