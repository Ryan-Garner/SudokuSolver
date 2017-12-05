using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class FourBoard : Board
    {

        public FourBoard()
        {
            Cells = new List<Cell>();
            Boxes = new List<Box>();
            
            for(int i = 1; i < 5; i++)
            {
                _possibleNumbers.Add(i);
            }

            for(int r = 1; r<5; r++)
            {
                for(int c = 1; c < 5; c++)
                {
                    var tempCell = new Cell(r, c, SetBox(r, c));
                    Cells.Add(tempCell);
                }
            }
            foreach (Cell cell in Cells)
            {
                for (int i = 1; i < 5; i++)
                {
                    cell.PossibleNumbers.Add(i);
                }
            }
        }
        
        public override void Init(List<char> puzzle)
        {
            for (int i = 0; i < puzzle.Count; i++)
            {
                if (puzzle[i] != '-')
                {
                    Cells[i].Value = (int)Char.GetNumericValue(puzzle[i]);
                    Cells[i].PossibleNumbers.Clear();
                    SolvedCells++;
                    foreach(Cell cell in Cells)
                    {
                        if(cell.Row == Cells[i].Row)
                        {
                            cell.PossibleNumbers.Remove((int)Char.GetNumericValue(puzzle[i]));
                        }
                        if(cell.Col == Cells[i].Col)
                        {
                            cell.PossibleNumbers.Remove((int)Char.GetNumericValue(puzzle[i]));
                        }
                        if(cell.Box == Cells[i].Box)
                        {
                            cell.PossibleNumbers.Remove((int)Char.GetNumericValue(puzzle[i]));
                        }
                    }
                }
            }
        }

        public override bool IsSolved()
        {
            if(SolvedCells == 16)
            {
                return true;
            }
            return false;
        }

        public override int SetBox(int row, int col)
        {
            if(row < 3)
            {
                if(col < 3)
                {
                    return 1;
                }
                if(col > 2)
                {
                    return 2;
                }
            }
            if(row > 2)
            {
                if(col < 3)
                {
                    return 3;
                }
                if(col > 2)
                {
                    return 4;
                }
            }
            return -1;
        }
    }
}
