using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;

namespace TestBoards
{
    [TestClass]
    public class TestSolverAlgorithms
    {
        [TestMethod]
        public void fourNumbersOnePossibilitySolverTest()
        {
            FourBoard testBoard = new FourBoard();
            string[] lines = File.ReadAllLines(@"E:\School Stuff\Homework\CS 5700\SudokuSolver\SudokuSolver\TestBoards\Input\Puzzle-4x4-0001.txt");
            Assert.IsNotNull(lines);
            List<char> testPuzzle = new List<char>();

            for(int i = 2; i < lines.Length; i++)
            {
                ParseSudokuPuzzle.ParsePuzzleLine(lines[i], testPuzzle);
            }
            Assert.IsNotNull(testPuzzle);
            testBoard.Init(testPuzzle);
            Assert.AreEqual(2, testBoard.Cells[0].Value);
            NumbersOnePossibilitySolver onePSolver = new NumbersOnePossibilitySolver();
            onePSolver.SolveCells(testBoard);
            Assert.AreEqual(16, testBoard.SolvedCells);
            Assert.AreEqual(4, testBoard.Cells[1].Value);

        }
        [TestMethod]
        public void nineNumbersOnePossibilitySolverTest()
        {
            NineBoard testBoard = new NineBoard();
            string[] lines = File.ReadAllLines(@"E:\School Stuff\Homework\CS 5700\SudokuSolver\SudokuSolver\TestBoards\Input\Puzzle-9x9-0001.txt");
            Assert.IsNotNull(lines);
            List<char> testPuzzle = new List<char>();

            for (int i = 2; i < lines.Length; i++)
            {
                ParseSudokuPuzzle.ParsePuzzleLine(lines[i], testPuzzle);
            }
            Assert.IsNotNull(testPuzzle);
            testBoard.Init(testPuzzle);
            Assert.AreEqual(4, testBoard.Cells[0].Value);
            NumbersOnePossibilitySolver onePSolver = new NumbersOnePossibilitySolver();
            onePSolver.SolveCells(testBoard);
            Assert.AreEqual(81, testBoard.SolvedCells);
            Assert.AreEqual(9, testBoard.Cells[1].Value);
        }
        [TestMethod]
        public void NumbersOnePlaceTest()
        {
            NineBoard testBoard = new NineBoard();
            string[] lines = File.ReadAllLines(@"E:\School Stuff\Homework\CS 5700\SudokuSolver\SudokuSolver\TestBoards\Input\Puzzle-9x9-0001.txt");
            Assert.IsNotNull(lines);
            List<char> testPuzzle = new List<char>();

            for (int i = 2; i < lines.Length; i++)
            {
                ParseSudokuPuzzle.ParsePuzzleLine(lines[i], testPuzzle);
            }
            Assert.IsNotNull(testPuzzle);
            testBoard.Init(testPuzzle);
            Assert.AreEqual(4, testBoard.Cells[0].Value);
            NumbersOnePlace solver = new NumbersOnePlace();
            NumbersOnePossibilitySolver onePSolver = new NumbersOnePossibilitySolver();
            solver.SolveCells(testBoard);
            NineBoard testBBB = new NineBoard();
            testBBB.Init(testPuzzle);
            ParseSudokuPuzzle.CopyBoard(testBBB, testBoard);
            onePSolver.SolveCells(testBoard);
            Assert.AreEqual(46, testBoard.SolvedCells);
            Assert.AreEqual(9, testBoard.Cells[1].Value);
        }
    }
}
