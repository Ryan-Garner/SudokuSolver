using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class NineBoard : Board
    {

        public NineBoard()
        {
            Cells = new List<Cell>();
            Cell tempCell;
            Boxes = new List<Box>();
            for(int i = 1; i < 10; i++)
            {
                _possibleNumbers.Add(i);
                Boxes.Add(new Box(9));
            }
            for(int r = 1; r < 10; r++)
            {
                for(int c = 1; c < 10; c++)
                {
                    tempCell = new Cell(r, c, SetBox(r, c));
                    
                    Boxes[SetBox(r, c) - 1].cells.Add(tempCell);
                    Cells.Add(tempCell);
                }
            }
            foreach (Cell cell in Cells)
            {
                for (int i = 1; i < 10; i++)
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
                    foreach (Cell cell in Cells)
                    {
                        if (cell.Row == Cells[i].Row)
                        {
                            cell.PossibleNumbers.Remove((int)Char.GetNumericValue(puzzle[i]));
                        }
                        if (cell.Col == Cells[i].Col)
                        {
                            cell.PossibleNumbers.Remove((int)Char.GetNumericValue(puzzle[i]));
                        }
                        if (cell.Box == Cells[i].Box)
                        {
                            cell.PossibleNumbers.Remove((int)Char.GetNumericValue(puzzle[i]));
                        }
                    }
                }
            }
        }

        public override bool IsSolved()
        {
            if (SolvedCells == 81)
            {
                return true;
            }
            return false;
        }

        public override int SetBox(int row, int col)
        {
            if (row < 4)
            {
                if (col < 4)
                {
                    return 1;
                }
                else if (col < 7)
                {
                    return 2;
                }
                else if (col < 10)
                {
                    return 3;
                }
            }
            else if (row < 7)
            {
                if (col < 4)
                {
                    return 4;
                }
                else if (col < 7)
                {
                    return 5;
                }
                else if (col < 10)
                {
                    return 6;
                }
            }
            else if (row < 10)
            {
                if (col < 4)
                {
                    return 7;
                }
                else if (col < 7)
                {
                    return 8;
                }
                else if (col < 10)
                {
                    return 9;
                }
            }
            return -1;
        }
    }
}
