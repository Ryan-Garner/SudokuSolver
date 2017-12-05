using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Cell
    {
        public List<int> PossibleNumbers = new List<int>();
        public List<string> PossibleStrings = new List<string>();
        public int? Value = null;
        public bool IsSolved = false;
        public int Row;
        public int Col;
        public int Box;
        
        public Cell(int row, int col, int box)
        {
            Value = null;
            IsSolved = false;
            this.Row = row;
            this.Col = col;
            this.Box = box;
        }
    }
}
