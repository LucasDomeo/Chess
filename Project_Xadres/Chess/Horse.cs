using Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_Xadres.Chess
{
    class Horse : Pieces
    {
        public Horse(board bd, Color color) : base(bd, color)
        {
        }

        public override string ToString()
        {
            return "H";
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
            pos.SetVelues(position.Line - 1, position.Column - 2);
            if (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Ne
            pos.SetVelues(position.Line - 2, position.Column - 1);
            if (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Right
            pos.SetVelues(position.Line - 2, position.Column + 1);
            if (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Se
            pos.SetVelues(position.Line - 1, position.Column + 2);
            if (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Down
            pos.SetVelues(position.Line + 1, position.Column + 2);
            if (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Sw
            pos.SetVelues(position.Line + 2, position.Column + 1);
            if (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Left
            pos.SetVelues(position.Line + 2, position.Column - 1);
            if (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Nw
            pos.SetVelues(position.Line + 1, position.Column - 2);
            if (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }
    }
}