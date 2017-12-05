using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Solver
    {
        Board board;
        Stopwatch numbersOPS;
        Stopwatch numbersOP;
        NumbersOnePossibilitySolver SolverOPS;
        NumbersOnePlace SolverOP;
        Guess SolverGuess = new Guess();
        int _maxCounts = 50;
        string[] Lines;
        public void Init(string[] lines)
        {
            Lines = lines;
            numbersOPS = new Stopwatch();
            numbersOP = new Stopwatch();
            SolverOPS = new NumbersOnePossibilitySolver();
            SolverOP = new NumbersOnePlace();

            List<char> Puzzle = new List<Char>();
            if (lines[0] == "4")
            {
                board = new FourBoard();
                board.BoardSize = 4;
            }
            if (lines[0] == "9")
            {
                board = new NineBoard();
                board.BoardSize = 9;
            }
            for (int i = 2; i < lines.Length; i++)
            {
                ParseSudokuPuzzle.ParsePuzzleLine(lines[i], Puzzle);
            }
            board.Init(Puzzle);
        }
        public void Solve()
        {
            int counter = 0;
            while (counter < _maxCounts)
            {
                numbersOPS.Start();
                SolverOPS.SolveCells(board);
                numbersOPS.Start();
                if (board.SolvedCells != board.BoardSize * board.BoardSize)
                {
                    numbersOP.Start();
                    SolverOP.SolveCells(board);
                    numbersOP.Stop();
                    if (board.SolvedCells != board.BoardSize * board.BoardSize)
                    {
                        SolverGuess.SolveCells(board);
                    }
                }
                counter++;
            }

            PrintPuzzle(numbersOPS, numbersOP, board);

        }
        public void PrintPuzzle(Stopwatch sw, Stopwatch sw2, Board board)
        {
            if (board.BoardSize == 4)
            {
                PrintFour(sw, sw2, board);
            }
            if (board.BoardSize == 9)
            {
                PrintNine(sw, sw2, board);
            }
        }
        public void PrintNine(Stopwatch sw1, Stopwatch sw2, Board board)
        {
            using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"E:\School Stuff\Homework\CS 5700\SudokuSolver\SudokuSolver\SolvedPuzzleResult.txt"))
            {
                foreach (string line in Lines)
                {
                    file.WriteLine(line);
                    Console.WriteLine(line);
                }
                file.WriteLine("\n\n\n");
                Console.WriteLine("\n\n\n\n\n");
                if (board.SolvedCells == 81)
                {
                    file.WriteLine("Solved");
                    Console.WriteLine("Solved");
                    for (int j = 0; j < 9; j++)
                    {

                        file.WriteLine();
                        file.WriteLine(board.Cells[0 + (9 * j)].Value + " " + board.Cells[1 + (9 * j)].Value + " " + board.Cells[2 + (9 * j)].Value + " " + board.Cells[3 + (9 * j)].Value + " " + board.Cells[4 + (9 * j)].Value + " " + board.Cells[5 + (9 * j)].Value + " " + board.Cells[6 + (9 * j)].Value + " " + board.Cells[7 + (9 * j)].Value + " " + board.Cells[8 + (9 * j)].Value);


                        Console.WriteLine();
                        Console.Write(board.Cells[0 + (9 * j)].Value + " " + board.Cells[1 + (9 * j)].Value + " " + board.Cells[2 + (9 * j)].Value + " " + board.Cells[3 + (9 * j)].Value + " " + board.Cells[4 + (9 * j)].Value + " " + board.Cells[5 + (9 * j)].Value + " " + board.Cells[6 + (9 * j)].Value + " " + board.Cells[7 + (9 * j)].Value + " " + board.Cells[8 + (9 * j)].Value);
                    }


                }
                else
                {
                    file.WriteLine("Unsolved");
                    Console.WriteLine("Unsolved");
                    
                        for (int j = 0; j < 9; j++)
                        {
                            file.WriteLine(board.Cells[0 + (9 * j)].Value + " " + board.Cells[1 + (9 * j)].Value + " " + board.Cells[2 + (9 * j)].Value + " " + board.Cells[3 + (9 * j)].Value + " " + board.Cells[4 + (9 * j)].Value + " " + board.Cells[5 + (9 * j)].Value + " " + board.Cells[6 + (9 * j)].Value + " " + board.Cells[7 + (9 * j)].Value + " " + board.Cells[8 + (9 * j)].Value);


                            Console.WriteLine();
                            Console.Write(board.Cells[0 + (9 * j)].Value + " " + board.Cells[1 + (9 * j)].Value + " " + board.Cells[2 + (9 * j)].Value + " " + board.Cells[3 + (9 * j)].Value + " " + board.Cells[4 + (9 * j)].Value + " " + board.Cells[5 + (9 * j)].Value + " " + board.Cells[6 + (9 * j)].Value + " " + board.Cells[7 + (9 * j)].Value + " " + board.Cells[8 + (9 * j)].Value);
                        }
                    
                }

                file.WriteLine("\n\n\n");
                Console.WriteLine("\n\n\n\n\n");

                file.WriteLine("Total Time: " + (sw1.Elapsed.Add(sw2.Elapsed)));
                file.WriteLine("Only One Possibility: " + sw1.Elapsed);
                file.WriteLine("Only One Place: " + sw2.Elapsed);
                Console.WriteLine("Total Time: " + sw1.Elapsed);
                Console.WriteLine("Only One Possibility: " + sw1.Elapsed);
                Console.WriteLine("Only One Place: " + sw2.Elapsed);
                file.Close();
            }
            

        }
        public void PrintFour(Stopwatch sw1, Stopwatch sw2, Board board)
        {
            using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"E:\School Stuff\Homework\CS 5700\SudokuSolver\SudokuSolver\SolvedPuzzleResult.txt"))
            {
                foreach (string line in Lines)
                {
                    file.WriteLine(line);
                    Console.WriteLine(line);
                }
                file.WriteLine("\n\n\n");
                Console.WriteLine("\n\n\n\n\n");
                if (board.SolvedCells == 16)
                {
                    Console.WriteLine("Solved");
                    for (int j = 0; j < 4; j++)
                    {


                        file.WriteLine(board.Cells[0 + (4 * j)].Value + " " + board.Cells[1 + (4 * j)].Value + " " + board.Cells[2 + (4 * j)].Value + " " + board.Cells[3 + (4 * j)].Value);


                        Console.WriteLine();
                        Console.Write(board.Cells[0 + (4 * j)].Value + " " + board.Cells[1 + (4 * j)].Value + " " + board.Cells[2 + (4 * j)].Value + " " + board.Cells[3 + (4 * j)].Value);
                    }


                }
                else
                {
                    Console.WriteLine("Unsolved");
                    for (int j = 0; j < 4; j++)
                    {


                        file.WriteLine(board.Cells[0 + (4 * j)].Value + " " + board.Cells[1 + (4 * j)].Value + " " + board.Cells[2 + (4 * j)].Value + " " + board.Cells[3 + (4 * j)].Value);


                        Console.WriteLine();
                        Console.Write(board.Cells[0 + (4 * j)].Value + " " + board.Cells[1 + (4 * j)].Value + " " + board.Cells[2 + (4 * j)].Value + " " + board.Cells[3 + (4 * j)].Value);
                    }
                }

                file.WriteLine("\n\n\n");
                Console.WriteLine("\n\n\n\n\n");

                file.WriteLine("Total Time: " + (sw1.Elapsed.Add(sw2.Elapsed)));
                file.WriteLine("Only One Possibility: " + sw1.Elapsed);
                file.WriteLine("Only One Place: " + sw2.Elapsed);
                Console.WriteLine("Total Time: " + sw1.Elapsed);
                Console.WriteLine("Only One Possibility: " + sw1.Elapsed);
                Console.WriteLine("Only One Place: " + sw2.Elapsed);
                file.Close();
            }
        }
    }
}
