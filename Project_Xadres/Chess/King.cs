using Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class King : Pieces
    {
        public King(board bd, Color color) : base(bd, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position pos)
        {
            Pieces p = bd.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] PosibleMoviments()
        {
            bool[,] mat = new bool[bd.line, bd.column];

            Position pos = new Position(0, 0);

            //up
            pos.SetVelues(position.Line - 1, position.Column);
            if(bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Ne
            pos.SetVelues(position.Line - 1, position.Column + 1);
            if (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Right
            pos.SetVelues(position.Line, position.Column + 1);
            if (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Se
            pos.SetVelues(position.Line + 1, position.Column + 1);
            if (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Down
            pos.SetVelues(position.Line + 1, position.Column);
            if (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Sw
            pos.SetVelues(position.Line + 1, position.Column - 1);
            if (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Left
            pos.SetVelues(position.Line, position.Column - 1);
            if (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Nw
            pos.SetVelues(position.Line - 1, position.Column - 1);
            if (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }
    }
}