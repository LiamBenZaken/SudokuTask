using sudoku.InputAndOutput;
using System;
using System.Collections.Generic;
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

            int[,] boardFromConsole = SudokuBoardFormatter.FormatInputToBoard(fileInput);
            SudokuBoardFormatter.PrintBoard(boardFromConsole);
            

            /* CONSOLE INPUT
            IInputReader consoleReader = new ConsoleInputReader();
            string consoleInput = consoleReader.ReadInput();

            int[,] boardFromConsole = SudokuBoardFormatter.FormatInputToBoard(consoleInput);
            SudokuBoardFormatter.PrintBoard(boardFromConsole);
            */
        }
    }
}
