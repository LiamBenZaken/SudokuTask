# Sudoku Solver - Liam Ben Zaken

## Overview
This project implements a Sudoku solver in C#. The solver can read Sudoku puzzles from the console or from a file, solve them, and output the solutions.

## Features
- Input Sudoku puzzles from the console or a file
- Solve Sudoku puzzles
- Output solved Sudoku puzzles to the console or a file
- Determine if a Sudoku puzzle is solvable
- Handle unsolvable Sudoku puzzles gracefully

## Getting Started
To get started with the Sudoku Solver, follow these steps:
 
 - #### Clone the Repository
   Open a terminal. Navigate to the directory where you want to clone the repository and clone it to a new project.

 - #### Input Sudoku Puzzles
   You can input Sudoku puzzles in two ways:

   Console Input: Enter the Sudoku puzzle directly into the console when prompted.
   File Input: Provide the path to a text file containing the Sudoku puzzle.
   Solve Sudoku Puzzles
   Once the puzzle is inputted, the solver will attempt to solve it. If successful, the solved puzzle will be displayed in the console.

 - #### Output Solved Sudoku Puzzles
   You have the option to output the solved Sudoku puzzle to the console or to a file. Follow the on-screen prompts to choose the desired output method.

- #### Verify Solvability
  The solver will also determine if the provided Sudoku puzzle is solvable. If the puzzle is unsolvable, an appropriate message will be displayed.

With these steps, you should now be ready to use the Sudoku Solver to solve your Sudoku puzzles!

## Usage
- Console Input: Run the program and choose option 1 to enter a Sudoku puzzle directly in the console. Follow the prompts to input the puzzle.

- File Input: Run the program and choose option 2 to input a Sudoku puzzle from a file. Enter the file path when prompted.

- Exit: Choose option 3 to exit the program.

## Backtracking Algorithm Explanation:
The Sudoku solver employs a backtracking algorithm, which is a brute-force technique used to solve combinatorial problems like Sudoku puzzles. Here's how it works:

- Start with the cell with the least options: The algorithm starts by selecting an empty cell with the least options in the Sudoku grid and thats for saving most of time that i can because i want to guess the true option by having the least options to guess from.

- Try a valid option from the option list: It then tries placing a valid option into the cell with the least options.

- Starting with the recursion: After placing a random option , the algorithm made the recursion call and repeat again on the process but now it picking the cell with the least options from the affected cells that affcted from the last call. by that the algorithm save a lot of iterations and solve the puzzle more fast.

- Check for validity: the algorithm checks whether it violates any of the Sudoku rules:

  The same number cannot appear more than once in the same row.
  The same number cannot appear more than once in the same column.
  The same number cannot appear more than once in the same subgrid.
- Backtrack if invalid: If the number violates any of these rules, the algorithm backtracks to the previous cell return the last option that was invalid to all the effected cells that this specific option were removed to them and tries a different option. This process continues until a valid option is found or until all possibilities are exhausted, if it happens the method will return null.

- Repeat until solution found: The algorithm repeats this process recursively, exploring all possible combinations until it finds a solution that satisfies all Sudoku rules. if at the end the recursion will return null it means that the board is not solveable.

- Pruning branches: To optimize performance, the algorithm prunes branches whenever it encounters a contradiction, significantly reducing the search space and speeding up the solving process and happens by the steps I described earlier, I never run on all over the board cell and tries to take always the cell with the least amout of options because i want the the algorithm will guess with the leastest amout of options to fill the puzzle fast as it can.

By systematically exploring possible solutions and backtracking when necessary, the backtracking algorithm can efficiently solve even the most challenging Sudoku puzzles. The pruning of branches further enhances its performance, ensuring that solutions are found quickly and accurately.

## The process of writing the project
First , I defined all the project objectives, including developing a Sudoku solver capable of solving puzzles of varying complexities.
Specified requirements for input methods, solving algorithms, output options, and performance expectations.
I started with researching existing Sudoku solving algorithms, evaluating their pros and cons.analyzed different approaches such as brute force, constraint satisfaction, and backtracking.
selected the backtracking algorithm for its effectiveness in solving Sudoku puzzles efficiently and i knew that i always can add optimizations to this algorithm and make him to be even shorter, thats what i wanted to do.
Then i started to Design the architecture of the solution, outlining classes, interfaces, and their interactions.
Created class diagrams and flowcharts to visualize the structure and flow of the application.
Identified core components such as the Sudoku board, cells, input readers, and the solver algorithm.

#### After all the theoretical phase I started with the implementation
Input and Output Classes:
Started by implementing input reader classes (ConsoleInputReader and FileInputReader) to handle user input from the console or file.
Designed interfaces (IInputReader) to decouple input reading functionality, enabling flexibility and extensibility.
Ensured robust error handling in input reader classes to manage exceptions and provide informative error messages to users.

I developed the MatrixBoard class to represent the Sudoku board using a two-dimensional array of Cell objects.
Implemented the Cell class to represent individual cells on the Sudoku board, including properties for number, options, row, column, and connected cells.
Initialized the Sudoku board by parsing input strings and populating cells with initial numbers, empty cells, and their options.
Designed methods for initializing cell connections based on row, column, and box constraints to ensure correct puzzle representation.

I implemented the backtracking algorithm in the SudokuSolver class to find solutions to Sudoku puzzles efficiently.
Designed the solver algorithm to prioritize cells with the fewest options, minimizing the branching factor and improving performance.
Incorporated pruning techniques to eliminate invalid branches early in the solving process, reducing computational overhead.
Ensured the solver algorithm is capable of detecting unsolvable puzzles and handling them gracefully, throwing appropriate exceptions when necessary.

Generics and SOLID Principles:
I utilized interfaces and dependency injection to promote loose coupling and facilitate testability and extensibility.
Designed classes to adhere to SOLID principles, such as Single Responsibility Principle (SRP), Dependency Inversion Principle (DIP), and Interface Segregation Principle (ISP).
I employed generics and abstractions to create flexible and reusable components, enabling easy integration with different input sources and output formats.
Ensured code modularity and maintainability by breaking down functionality into smaller, cohesive units with well-defined responsibilities.

The implementation stage presented significant challenges, particularly in achieving the goal of solving Sudoku puzzles in less than a second. However, through careful design, optimization, and adherence to best practices, these challenges were successfully addressed, resulting in a robust and efficient Sudoku solver solution.

Then, I Documented each class, method, and interface using XML comments to provide detailed explanations and usage instructions.

And the last part was testing and quality assurance of the project
I developed comprehensive unit tests using Unit test project (framework) to verify the correctness and robustness of each component.
Conducted integration testing to ensure seamless interaction between different modules.
Performed stress testing with large and complex Sudoku puzzles to evaluate performance under challenging conditions.
I debugged issues and defects identified during testing, what ensuring me the stability and reliability of the solution.

Of curse I documented the entire project on GitHub, providing comprehensive README.md files with detailed explanations of the project structure, implementation, and usage instructions and
utilized version control effectively by creating branches for each major part of the project and committing changes regularly, ensuring a well-organized and traceable development process.
