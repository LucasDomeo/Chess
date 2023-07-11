using Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_Xadres.Chess
{
    class Tower : Pieces
    {
        public Tower(board bd, Color color) : base(bd, color) 
        { 
        }

        public override string ToString()
        {
            return "T";
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
            while(bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(bd.piece(pos) != null && bd.piece(pos).color != color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }

            //Down
            pos.SetVelues(position.Line + 1, position.Column);
            while (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (bd.piece(pos) != null && bd.piece(pos).color != color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }

            //Right
            pos.SetVelues(position.Line, position.Column + 1);
            while (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (bd.piece(pos) != null && bd.piece(pos).color != color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            //Left
            pos.SetVelues(position.Line, position.Column - 1);
            while (bd.validposition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (bd.piece(pos) != null && bd.piece(pos).color != color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            return mat;
        }
    }
}