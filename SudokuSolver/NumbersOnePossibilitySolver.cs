using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class NumbersOnePossibilitySolver : SolverAlgorithms
    {
        public void SolveCells(Board board)
        {
            bool canContinue = true;
            int onePossibilities = 0;
            while(canContinue)
            {
                foreach(Cell cell in board.Cells)
                {
                    if(cell.PossibleNumbers.Count == 1)
                    {
                        cell.Value = cell.PossibleNumbers[0];
                        cell.PossibleNumbers.Clear();
                        board.SolvedCells++;
                        onePossibilities++;
                        foreach(Cell cell2 in board.Cells)
                        {
                            if(cell2.Row == cell.Row)
                            {
                                cell2.PossibleNumbers.Remove((int)cell.Value);
                            }
                            if(cell2.Col == cell.Col)
                            {
                                cell2.PossibleNumbers.Remove((int)cell.Value);
                            }
                            if (cell2.Box == cell.Box)
                            {
                                cell2.PossibleNumbers.Remove((int)cell.Value);
                            }
                        }
                    }
                }
                if(onePossibilities != 0)
                {
                    onePossibilities = 0;
                }
                else
                {
                    canContinue = false;
                }
            }
        }
    }
}
