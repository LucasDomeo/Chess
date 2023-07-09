using Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Horse : Pieces
    {
        public Horse(boardd bd, Color color) : base(bd, color) 
        { 
        }

        public override string ToString()
        {
            return "H";
        }
    }
}
