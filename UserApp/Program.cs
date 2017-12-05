using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver;

namespace UserApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string file;
            Console.WriteLine("Please Enter a FileName: ");
            file = Console.ReadLine();
            NineBoard testBoard = new NineBoard();
           // NumbersOnePlace solver = new NumbersOnePlace();
            Solver solver = new Solver();
            string[] lines = File.ReadAllLines(@file);
            solver.Init(lines);
            solver.Solve();
            /*List<char> testPuzzle = new List<char>();

            for (int i = 2; i < lines.Length; i++)
            {
                ParseSudokuPuzzle.ParsePuzzleLine(lines[i], testPuzzle);
            }
            
            testBoard.Init(testPuzzle);
            solver.SolveCells(testBoard);*/
            Console.WriteLine("Done");
            Console.WriteLine("Press a key to Exit");
            Console.ReadLine();

        }
    }
}
