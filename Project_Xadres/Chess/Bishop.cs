using Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_Xadres.Chess
{
    class Bishop : Pieces
    {
        public Bishop(board bd, Color color) : base(bd, color)
        {
        }

        public override string ToString()
        {
            return "B";
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

            //Ne
            pos.SetVelues(position.Line - 1, position.Column + 1);
            while (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (bd.piece(pos) != null && bd.piece(pos).color != color)
                {
                    break;
                }
                pos.SetVelues(pos.Line - 1, pos.Column + 1);
            }

            //Se
            pos.SetVelues(position.Line + 1, position.Column + 1);
            while (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (bd.piece(pos) != null && bd.piece(pos).color != color)
                {
                    break;
                }
                pos.SetVelues(pos.Line + 1, pos.Column + 1);
            }

            //Sw
            pos.SetVelues(position.Line + 1, position.Column - 1);
            while (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (bd.piece(pos) != null && bd.piece(pos).color != color)
                {
                    break;
                }
                pos.SetVelues(pos.Line + 1, pos.Column - 1);
            }

            //Nw
            pos.SetVelues(position.Line - 1, position.Column - 1);
            while (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (bd.piece(pos) != null && bd.piece(pos).color != color)
                {
                    break;
                }
                pos.SetVelues(pos.Line - 1, pos.Column - 1);
            }
            return mat;
        }
    }
}