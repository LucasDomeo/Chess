﻿using Board;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}