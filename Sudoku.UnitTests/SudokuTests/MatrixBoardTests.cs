using Microsoft.VisualStudio.TestTools.UnitTesting;
using sudoku.Exceptions;
using sudoku.SudokuBoardParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.UnitTests.SudokuTests
{
    [TestClass]
    public class MatrixBoardTests
    {
        [TestMethod]
        public void Constructor_WithValidInput_InitializesBoardCorrectly()
        {
            string input = "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
            MatrixBoard board = new MatrixBoard(input);

            Assert.AreEqual(9, board.boardSize);
        }

        [TestMethod]
        public void Constructor_WithInvalidInput_ThrowsInvalidBoardException1()
        {
            string input = "53007000060019500009800006080006000340080300170002000606000028000041900500008007"; //input lenght is 80

            Assert.ThrowsException<InvalidBoardException>(() => new MatrixBoard(input));
        }


        [TestMethod]
        public void Constructor_WithInvalidInput_ThrowsInvalidBoardException2()
        {
            string input = "lghljkafdhvladj";

            Assert.ThrowsException<InvalidBoardException>(() => new MatrixBoard(input));
        }

        [TestMethod]
        public void Constructor_WithInvalidInput_ThrowsInvalidBoardException3()
        {
            string input = "0000000000000009";

            Assert.ThrowsException<InvalidBoardException>(() => new MatrixBoard(input));
        }

        [TestMethod]
        public void Constructor_WithInvalidInput_ThrowsInvalidBoardException4()
        {
            string input = "";

            Assert.ThrowsException<InvalidBoardException>(() => new MatrixBoard(input));
        }

        [TestMethod]
        public void RemoveOptions_RemovesOptionsCorrectly()
        {
            string input = "000000000000000000000000000000000000000000000000000000000000000000000000000000008";
            MatrixBoard board = new MatrixBoard(input);
            int row = 0;
            int col = 0;
            board.SetNumber(row, col, 2);
            int affectedCount = 0;

            foreach (Cell cell in board.GetCell(row, col).connected)
                if (cell.number == 0)
                    affectedCount++;

            HashSet<Cell> affectedCells = board.RemoveOptions(row, col);

            Assert.AreEqual(affectedCount, affectedCells.Count);
        }

        [TestMethod]
        public void InitConnectionCells_InitializesConnectionsCorrectly()
        {
            string input = "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
            MatrixBoard board = new MatrixBoard(input);
            int row = 0;
            int col = 0;
            Cell cell = board.GetCell(row, col);
            int boxSize = (int)Math.Sqrt(board.boardSize);
            int boxStartRow = (row / boxSize) * boxSize;
            int boxStartCol = (col / boxSize) * boxSize;

            board.InitConnectionCells(cell, row, col);

            foreach (Cell connectedCell in cell.connected)
            {
                Assert.AreNotEqual(cell, connectedCell);
                bool isRealConnected = (connectedCell.row >= boxStartRow && connectedCell.row < boxStartRow + boxSize &&
                                connectedCell.col >= boxStartCol && connectedCell.col < boxStartCol + boxSize) ||
                                ((connectedCell.col == col && connectedCell.row != row) || (row == connectedCell.row && col != connectedCell.col));
                Assert.IsTrue(isRealConnected);
            }
        }

        [TestMethod]
        public void InitConnectionCells_ThrowsInvalidBoardException()
        {
            string input = "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
            MatrixBoard board = new MatrixBoard(input);
            int row = 0;
            int col = 0;
            Cell cell = board.GetCell(row, col);

            board.SetNumber(0, 1, 5);

            Assert.ThrowsException<InvalidBoardException>(() => board.InitConnectionCells(cell, row, col));
        }
    }
}
