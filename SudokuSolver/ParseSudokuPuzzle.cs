using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public static class ParseSudokuPuzzle
    {
        public static void ParsePuzzleLine(string line, List<char> list)
        {
            foreach(char num in line)
            {
                if(num != ' ')
                {
                    list.Add(num);
                }
            }
        }
        public static void CopyBoard(Board board1, Board board2)
        {
            board1.SolvedCells = board2.SolvedCells;
            for(int i = 0; i < board1.BoardSize*board1.BoardSize; i++)
            {
                board1.Cells[i].Value = board2.Cells[i].Value;
                board1.Cells[i].PossibleNumbers.Clear();
                foreach (int pi in board2.Cells[i].PossibleNumbers)
                {
                    board1.Cells[i].PossibleNumbers.Add(pi);
                }
            }
        }
    }
}
