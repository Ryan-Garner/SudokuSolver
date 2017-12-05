using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;

namespace TestBoards
{
    [TestClass]
    public class TestBoards
    {
        [TestMethod]
        public void TestFourBoard()
        {
            FourBoard testFour = new FourBoard();
            Cell testCell1 = new Cell(1,1,1);
            Cell testCell2 = new Cell(4, 4, 4);
            Cell testCell3 = new Cell(2, 3, 2);
            Assert.IsNotNull(testFour);
            foreach(Cell cell in testFour.Cells)
            {
                Assert.IsNotNull(cell);
                Assert.AreNotEqual(-1, cell.Box);
            }

            Assert.AreEqual(16, testFour.Cells.Count);
            Assert.AreEqual(testCell1.Row, testFour.Cells[0].Row);
            Assert.AreEqual(testCell2.Row, testFour.Cells[15].Row);
            Assert.AreEqual(testCell1.Box, testFour.Cells[0].Box);
            Assert.AreEqual(testCell2.Box, testFour.Cells[15].Box);
            Assert.AreEqual(testCell3.Row, testFour.Cells[7].Row);
            Assert.AreEqual(testCell3.Box, testFour.Cells[7].Box);
        }
        [TestMethod]
        public void TestNineBoard()
        {
            NineBoard testNine = new NineBoard();
            Cell testCell1 = new Cell(1, 1, 1);
            Cell testCell2 = new Cell(9, 9, 9);
            Cell testCell3 = new Cell(2, 3, 1);

            Assert.IsNotNull(testNine);
            foreach (Cell cell in testNine.Cells)
            {
                Assert.IsNotNull(cell);
                Assert.AreNotEqual(-1, cell.Box);
            }

            Assert.AreEqual(81, testNine.Cells.Count);
            Assert.AreEqual(testCell1.Row, testNine.Cells[0].Row);
            Assert.AreEqual(testCell2.Row, testNine.Cells[80].Row);
            Assert.AreEqual(testCell1.Box, testNine.Cells[0].Box);
            Assert.AreEqual(testCell2.Box, testNine.Cells[80].Box);
            Assert.AreEqual(testCell3.Row, testNine.Cells[11].Row);
            Assert.AreEqual(testCell3.Box, testNine.Cells[11].Box);
        }
    }
}
