using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Box
    {
        public int size;
        public List<Cell> cells;

        public Box(int size)
        {
            cells = new List<Cell>();
            this.size = size;
        }
    } 
}
