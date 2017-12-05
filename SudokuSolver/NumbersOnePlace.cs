using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class NumbersOnePlace : SolverAlgorithms
    {
        public void SolveCells(Board board)
        {
            bool canContinue = true;
            int theCell = -1;
            int possibilities = 0;
            bool onlyOne = false;
            int onePlaces = 0;
            int boxes = 0;
            while (canContinue)
            {
                onePlaces = 0;
                foreach (Box box in board.Boxes)
                {
                    boxes++;
                        for (int i = 1; i < box.size + 1; i++)
                        {
                            for (int j = 0; j < box.size; j++)
                            {
                                if (box.cells[j].PossibleNumbers.Contains(i))
                                {
                                    possibilities++;
                                    if (possibilities <= 1)
                                    {
                                        onlyOne = true;
                                        theCell = j;
                                    }
                                    else
                                    {
                                        onlyOne = false;
                                        theCell = -1;
                                    }
                                }
                            }
                            if (onlyOne)
                            {
                                box.cells[theCell].Value = i;
                                possibilities = 0;
                                onlyOne = false;
                                onePlaces++;
                                board.SolvedCells++;
                                box.cells[theCell].PossibleNumbers.Clear();
                                foreach (Cell cell in board.Cells)
                                {
                                    if (cell.Row == box.cells[theCell].Row)
                                    {
                                        cell.PossibleNumbers.Remove((int)box.cells[theCell].Value);
                                    }
                                    if (cell.Col == box.cells[theCell].Col)
                                    {
                                        cell.PossibleNumbers.Remove((int)box.cells[theCell].Value);
                                    }
                                    if (cell.Box == box.cells[theCell].Box)
                                    {
                                        cell.PossibleNumbers.Remove((int)box.cells[theCell].Value);
                                    }
                                }
                            }
                        }
                    }
                
                
                if(onePlaces > 0)
                {
                    canContinue = true;
                    onePlaces = 0;
                }
                else
                {
                    canContinue = false;
                }
            }
        }
    }
}
