using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Guess : SolverAlgorithms
    {
        public int prevRow = -1;
        public int prevCol = -1;
        public int prevBox = -1;
        public int? prevValue = -1;
        public NumbersOnePlace OnePlaceSolver = new NumbersOnePlace();
        public NumbersOnePossibilitySolver OnePossibilitySolver = new NumbersOnePossibilitySolver();
        Board testBoard;
        public bool Solved = false;
        public bool isFirstGuess = true;
        public Random r = new Random();
        public void SolveCells(Board board)
        {
            int Count = 0;
            while (!Solved && Count < 81)
            {
                if (board.BoardSize == 9)
                {
                    testBoard = board;
                    //ParseSudokuPuzzle.CopyBoard((NineBoard)testBoard, board);
                }
                
                isFirstGuess = true;
                int counter = 0;
                MakeGuess(testBoard);
                while (counter < 81)
                {
                    OnePossibilitySolver.SolveCells(testBoard);

                    if (testBoard.SolvedCells != board.BoardSize * board.BoardSize)
                    {

                        OnePlaceSolver.SolveCells(testBoard);
                    }

                    if (testBoard.SolvedCells != board.BoardSize * board.BoardSize)
                    {

                        MakeGuess(testBoard);
                    }
                    if (testBoard.SolvedCells == board.BoardSize * board.BoardSize)
                    {

                        Solved = true;
                        ParseSudokuPuzzle.CopyBoard(board, testBoard);
                    }
                    counter++;
                }
                Count++;
            }

        }
        public void MakeGuess(Board board)
        {
            foreach(Cell cell in board.Cells)
            {
                if(cell.PossibleNumbers.Count > 0)
                {
                    if (isFirstGuess)
                    {
                        if (cell.Row == prevRow && cell.Col == prevCol && cell.Box == prevBox)
                        {
                            cell.Value = cell.PossibleNumbers[r.Next(0, cell.PossibleNumbers.Count - 1)];
                            while(cell.Value == prevValue)
                            {
                                cell.Value = cell.PossibleNumbers[r.Next(0, cell.PossibleNumbers.Count - 1)];
                            }
                            prevValue = cell.Value;
                            prevRow = cell.Row;
                            prevCol = cell.Col;
                            prevBox = cell.Box;
                        }
                        else
                        {
                            cell.Value = cell.PossibleNumbers[r.Next(0, cell.PossibleNumbers.Count - 1)];
                            prevValue = cell.Value;
                            prevRow = cell.Row;
                            prevCol = cell.Col;
                            prevBox = cell.Box;
                        }
                    }
                    else
                    {
                        cell.Value = cell.PossibleNumbers[r.Next(0, cell.PossibleNumbers.Count - 1)];
                    }
                    cell.PossibleNumbers.Clear();
                    if (cell.Value != null)
                    {
                        foreach (Cell cell2 in board.Cells)
                        {
                            if (cell2.Row == cell.Row)
                            {
                                cell2.PossibleNumbers.Remove((int)cell.Value);
                            }
                            if (cell2.Col == cell.Col)
                            {
                                cell2.PossibleNumbers.Remove((int)cell.Value);
                            }
                            if (cell2.Box == cell.Box)
                            {
                                cell2.PossibleNumbers.Remove((int)cell.Value);
                            }
                        }
                        return;
                    }
                }
            }
        }
    }
}
