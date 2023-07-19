using Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_Xadres.Chess
{
    class Pawn : Pieces
    {
        public Pawn(board bd, Color color) : base(bd, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ThereisEnemie(Position pos)
        {
            Pieces p = bd.piece(pos);
            return p != null && p.color != color;
        }

        private bool free(Position pos)
        {
            return bd.piece(pos) == null;
        }

        public override bool[,] PosibleMoviments()
        {
            bool[,] mat = new bool[bd.line, bd.column];

            Position pos = new Position(0, 0);
            
            if(color == Color.White)
            {
                pos.SetVelues(position.Line - 1, position.Column);
                if(bd.validposition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetVelues(position.Line - 2, position.Column);
                if (bd.validposition(pos) && free(pos) && NBMoviments == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetVelues(position.Line - 1, position.Column - 1);
                if (bd.validposition(pos) && ThereisEnemie(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetVelues(position.Line - 1, position.Column + 1);
                if (bd.validposition(pos) && ThereisEnemie(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                pos.SetVelues(position.Line + 1, position.Column);
                if (bd.validposition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetVelues(position.Line + 2, position.Column);
                if (bd.validposition(pos) && free(pos) && NBMoviments == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetVelues(position.Line + 1, position.Column - 1);
                if (bd.validposition(pos) && ThereisEnemie(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetVelues(position.Line + 1, position.Column + 1);
                if (bd.validposition(pos) && ThereisEnemie(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }

            return mat;
        }
    }
}