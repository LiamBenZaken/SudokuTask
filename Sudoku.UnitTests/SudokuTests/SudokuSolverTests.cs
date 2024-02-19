using Microsoft.VisualStudio.TestTools.UnitTesting;
using sudoku.Algorithm;
using sudoku.Exceptions;
using sudoku.InputAndOutput;
using sudoku.SudokuBoardParts;
using System;
using System.Collections.Generic;

namespace Sudoku.UnitTests.SudokuTests
{
    [TestClass]
    public class SudokuSolverTests
    {
        private ISudokuBoard board;

        [TestMethod]
        public void SolveSudoku_WithValidBoard_ShouldSolveBoard1()
        {
            string input = "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
            board = new MatrixBoard(input);
            ISudokuBoard solvedBoard = SudokuSolver.SolveSudoku(board);

            Assert.AreEqual("534678912672195348198342567859761423426853791713924856961537284287419635345286179", SudokuBoardFormatter.BoardAsString(solvedBoard));
        }

        [TestMethod]
        public void SolveSudoku_WithValidBoard_ShouldSolveBoard2()
        {
            string input = "10023400<06000700080007003009:6;0<00:0010=0;00>0300?200>000900<0=000800:0<201?000;76000@000?005=000:05?0040800;0@0059<00100000800200000=00<580030=00?0300>80@000580010002000=9?000<406@0=00700050300<0006004;00@0700@050>0010020;1?900=002000>000>000;0200=3500<";
            board = new MatrixBoard(input);
            ISudokuBoard solvedBoard = SudokuSolver.SolveSudoku(board);

            Assert.AreEqual("15:2349;<@6>?=78>@8=5?7<43129:6;9<47:@618=?;35>236;?2=8>75:94@<1=4>387;:5<261?@98;76412@9:>?<35=<91:=5?634@8>2;7@?259<>31;7=:68462@>;94=?1<587:37=91?235;>8:@<46583;1:<7264@=9?>?:<4>6@8=9372;152358<>:?6794;1=@:7=<@359>8;1642?;1?968=4@25<7>3:4>6@7;12:?=3589<", SudokuBoardFormatter.BoardAsString(solvedBoard));
        }

        [TestMethod]
        public void SolveSudoku_WithValidBoard_ShouldSolveBoard3()
        {
            string input = "000006000059000008200008000045000000003000000006003054000325006000000000000000000";
            board = new MatrixBoard(input);
            ISudokuBoard solvedBoard = SudokuSolver.SolveSudoku(board);

            Assert.AreEqual("387456219659132478214798563845267391193584627726913854978325146432671985561849732", SudokuBoardFormatter.BoardAsString(solvedBoard));
        }

        [TestMethod]
        public void SolveSudoku_WithUnsolvableBoard_ShouldThrowException()
        {
            string unsolvableInput = "100000000000100000000000005000000100000000000000000000000000000000000010000000000";
            board = new MatrixBoard(unsolvableInput);

            Assert.ThrowsException<NotSolvableBoardException>(() => SudokuSolver.SolveSudoku(board));
        }

        [TestMethod]
        public void FindCellWithLeastOptions_ReturnsCorrectCell()
        {
            Cell min = new Cell(0, 0, 0);

            min.connected.Add(new Cell(0, 4, 0) { options = { 1, 2, 3 } });
            min.connected.Add(new Cell(0, 5, 0) { options = { 1, 2 } });
            min.connected.Add(new Cell(0, 6, 0) { options = { 1, 2, 3, 4 } });
            min.connected.Add(new Cell(0, 7, 0) { options = { 1, 2, 3, 4, 5 } });

            Cell result = SudokuSolver.FindCellWithLeastOptions(min);

            Assert.AreEqual(0, result.row);
            Assert.AreEqual(5, result.col);
            Assert.AreEqual(0, result.number);
        }

        [TestMethod]
        public void FindCellWithLeastOptions_ReturnsDefaultCellIfNoOptionsFound()
        {
            Cell min = new Cell(0, 0, 0);
            min.connected.Add(new Cell(3, 4, 7));
            min.connected.Add(new Cell(2, 4, 8));
            min.connected.Add(new Cell(6, 4, 9));

            Cell result = SudokuSolver.FindCellWithLeastOptions(min);

            Assert.AreEqual(-1, result.row);
            Assert.AreEqual(-1, result.col);
            Assert.AreEqual(-1, result.number);
        }

        [TestMethod]
        public void IsOnlyOneSolve_ReturnsTrue_WhenOnlyOneSolution()
        {
            string input = "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
            MatrixBoard board = new MatrixBoard(input);

            bool result = SudokuSolver.IsOnlyOneSolve(board);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsOnlyOneSolve_ReturnsFalse_WhenMultipleSolutionsPossible()
        {
            string input = "000006000059000008200008000045000000003000000006003054000325006000000000000000000";
            MatrixBoard board = new MatrixBoard(input);

            bool result = SudokuSolver.IsOnlyOneSolve(board);

            Assert.IsFalse(result);
        }
    }
}
