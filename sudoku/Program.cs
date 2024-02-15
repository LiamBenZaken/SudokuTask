using sudoku.Algorithm;
using sudoku.InputAndOutput;
using sudoku.SudokuBoardParts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///* FILE INPUT
            string filePath = "inputfile.txt";
            IInputReader fileReader = new FileInputReader(filePath);

            string fileInput = fileReader.ReadInput();
            Console.WriteLine(fileInput);

            ISudokuBoard board = new MatrixBoard(fileInput);

            Console.WriteLine("Initial Sudoku Board:");
            SudokuBoardFormatter.PrintBoard(board);
            Console.WriteLine();

            Stopwatch stopwatch = Stopwatch.StartNew();
            board = SudokuSolver.Solve(board);
            stopwatch.Stop();

            Console.WriteLine("Solved Sudoku Board:");
            SudokuBoardFormatter.PrintBoard(board);
            Console.WriteLine();
            Console.WriteLine(SudokuBoardFormatter.BoardAsString(board));

            Console.WriteLine();
            Console.WriteLine($"Time taken to solve the Sudoku board: {stopwatch.ElapsedMilliseconds} ms");

            /* CONSOLE INPUT
            IInputReader consoleReader = new ConsoleInputReader();
            string consoleInput = consoleReader.ReadInput();

            ISudokuBoard board = new MatrixBoard(consoleInput);
            SudokuBoardFormatter.PrintBoard(board);

            board = SudokuSolver.Solve(board);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            SudokuBoardFormatter.PrintBoard(board);
            */


        }
    }
}
