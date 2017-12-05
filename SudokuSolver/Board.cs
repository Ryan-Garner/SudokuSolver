using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public abstract class Board
    {
        protected readonly List<int> _possibleNumbers = new List<int>();
        protected readonly List<string> _possibleStrings = new List<string>();
        public List<Cell> Cells;
        public List<Box> Boxes;
        public int SolvedCells = 0;
        public int BoardSize;

        public abstract void Init(List<char> puzzle);
        public abstract int SetBox(int row, int col);
        public abstract bool IsSolved();


        
    }
}
