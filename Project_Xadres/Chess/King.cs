using Board;
using Project_Xadres.Chess;
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
        private ChessMatch mt;

        public King(board bd, Color color, ChessMatch mt) : base(bd, color)
        {
            this.mt = mt;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(Position pos)
        {
            Pieces p = bd.piece(pos);
            return p == null || p.color != color;
        }

        private bool rocktest(Position pos)
        {
            Pieces p = bd.piece(pos);
            return p != null && p is Tower && p.color == color && p.NBMoviments == 0;
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

            //Rock
            if (NBMoviments==0 && !mt.check)
            {
                //Little rock
                Position post1 = new Position(position.Line, position.Column + 3);
                if (rocktest(post1))
                {
                    Position p1 = new Position(position.Line, position.Column + 1);
                    Position p2 = new Position(position.Line, position.Column + 2);
                    if (bd.piece(p1)==null && bd.piece(p2) == null)
                    {
                        mat[position.Line, position.Column + 2] = true;
                    }
                }
                //Big rock
                Position post2 = new Position(position.Line, position.Column - 4);
                if (rocktest(post2))
                {
                    Position p1 = new Position(position.Line, position.Column - 1);
                    Position p2 = new Position(position.Line, position.Column - 2);
                    Position p3 = new Position(position.Line, position.Column - 3);
                    if (bd.piece(p1) == null && bd.piece(p2) == null && bd.piece(p3) == null)
                    {
                        mat[position.Line, position.Column - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}