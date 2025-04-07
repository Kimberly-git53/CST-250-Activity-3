using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodFillVisual
{
    internal class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public String Contents { get; set; } // "E" for empty, "W" for wall, "F" for filled
        public Cell(int row, int column, String contents)
        {
            Row = row;
            Column = column;
            Contents = contents;
        }
    }
}
