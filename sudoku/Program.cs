using sudoku.Algorithm;
using sudoku.Exceptions;
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
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------Welcome to Liam's sudoku solver!--------");
            while (true)
            {
                Console.WriteLine("Please select an option:\n1. Enter the sudoku in the console\n2. Load sudoku from file\n3. Exit");
                Console.Write("Enter your choice (1, 2, or 3): ");
                string choice = Console.ReadLine();
                string input = "";

                switch (choice)
                {
                    case "1":
                        IInputReader consoleReader = new ConsoleInputReader();
                        input = consoleReader.ReadInput();
                        break;
                    case "2":
                        Console.WriteLine("Enter the file path:");
                        string filePath = Console.ReadLine();
                        try
                        {
                            IInputReader fileReader = new FileInputReader(filePath);
                            input = fileReader.ReadInput();
                            Console.WriteLine(input);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                        break;
                    case "3":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        continue;
                }

                ISudokuBoard board;
                try
                {
                    board = new MatrixBoard(input);
                }
                catch (InvalidBoardException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    continue;
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Error: Input is null");
                    continue;
                }

                Console.WriteLine("Initial Sudoku Board:");
                SudokuBoardFormatter.PrintBoard(board);
                Console.WriteLine();

                Stopwatch stopwatch = Stopwatch.StartNew();
                try
                {
                    board = SudokuSolver.SolveSudoku(board);
                }
                catch(NotSolvableBoardException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    continue;
                }
                stopwatch.Stop();

                Console.WriteLine("Solved Sudoku Board:");
                SudokuBoardFormatter.PrintBoard(board);
                Console.WriteLine();
                Console.WriteLine(SudokuBoardFormatter.BoardAsString(board));

                Console.WriteLine();
                Console.WriteLine($"Time taken to solve the Sudoku board: {stopwatch.ElapsedMilliseconds} ms");
                Console.WriteLine();
                if (choice == "2")
                {
                    File.WriteAllText("answer.txt", SudokuBoardFormatter.BoardAsString(board));
                    Console.WriteLine("Solved Sudoku board has been saved to 'answer.txt' file.");
                }
                Console.WriteLine();
            }

        }
    }
}
