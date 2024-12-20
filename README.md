# Sudoku Solver

This project is a Sudoku solver implemented in C#. It provides functionalities to solve Sudoku puzzles.

## Features

- Solves Sudoku puzzles of varying difficulty levels and sizes.
- Supports input of Sudoku puzzles in different formats.
- Displays the solved puzzle or indicates if no solution exists.
- Easy-to-use interface for inputting and solving Sudoku puzzles.

## Getting Started

To get started with using the Sudoku solver, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution in your preferred IDE (e.g., Visual Studio).
3. Build the solution to ensure all dependencies are installed.
4. Run the application.
5. Input the size of the sudoku.
6. Input the way you want to input the sudoku (console/file).
7. Input the Sudoku puzzle you want to solve/file's path of the sudoku.
8. Press enter to solve.
9. View the solved puzzle or the message indicating if no solution exists.

## Usage

The Sudoku solver provides a simple interface for inputting and solving Sudoku puzzles. Here's how to use it:

1. Input your Sudoku puzzle:
    - Enter the digits of the puzzle, one after one, in one string.
    - Use '0' to represent empty cells.

2. Press enter:
    - After inputting the puzzle, press enter to start solving the puzzle.

3. View the solution:
    - Once the puzzle is solved, the solution will be displayed.
    - If no solution exists, a message indicating this will be shown.
    - If the input was entered via a file, besides the display on the screen, the solution will be saved in the solved.txt file.

## Algorithms

The Sudoku solver supports multiple solving algorithms, including:
- Backtracking algorithm
- Rule-Based algorithm.
- Optimization backtracking.

## A detailed explanation of the algorithm

In general, the algorithm I implemented is a kind of combination of rule based, and backtracking, while combining optimizations, and pruning the recursion tree.
Before detailing the algorithm, I will explain how the board is built: The board is built from a matrix of cells. Each cell is an object that contains the following properties: the Clue, meaning the value contained in the cell, and Candidates, which is a list of possible values that could be the Clue of that cell.
The algorithm works like this:
It receives the table with the initially received values, so all the cells are updated according to the other cells, meaning their candidate list is updated.
After that, I go through the board and look for cells that have only one candidate, and place the only candidate that has a clue.
When it doesn't find, it exits the loop and starts the backtracking attempt.
The backtracking is performed as follows:
First, you look for the empty cell with the fewest candidates, which increases the chances of a correct choice, then loop through all the candidates of that cell, try to place it, and if it is possible to add it (that is, that placing it does not reset the list of candidates in another cell), then Recursively calling the action again, and trying to perform the same process.
The process terminates under one of two conditions, either the board is completely resolved after all recursive calls, or there are no more empty cells.

## The process of writing the project

The process of developing the Sudoku project began with extensive research into various solving algorithms, exploring options like backtracking and Rule-Based. After careful consideration, I deliberated on the project's structure, envisioning an efficient yet flexible architecture to accommodate different solving methods. The implementation phase involved translating the chosen algorithm into code, iteratively refining and testing to ensure accuracy and reliability. As the project progressed, optimization became a pivotal focus, with strategies such as pruning techniques and heuristic enhancements continuously evaluated and integrated to enhance solving performance. In addition, I tried to implement more methods for the solution, but I found that it overloaded the algorithm. Throughout the process, attention to algorithmic intricacies and strategic optimizations drove the evolution of the Sudoku project, culminating in a robust and versatile solution.

## References

- [A study of Sudoku solving algorithms](https://www.csc.kth.se/utbildning/kth/kurser/DD143X/dkand12/Group6Alexander/final/Patrik_Berggren_David_Nilsson.report.pdf): the idea of the algorithm was taken from here (page 6-7).
