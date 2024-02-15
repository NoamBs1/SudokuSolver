using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    /// <summary>
    /// this class represent a sudoku board
    /// </summary>
    internal class Board : IBoard, ICloneable
    {
        public int Size { get; set; }
        public Cell[,] Matrix { get; set; }

        private readonly IBoardPrinter printer;

        /// <summary>
        /// Initialized a sudoku board
        /// </summary>
        /// <param name="size">
        /// the size of the board
        /// </param>
        /// <param name="printer">
        /// this attribute defines the way that the board is printed
        /// </param>
        public Board(int size, IBoardPrinter printer)
        {
            this.Size = size;
            this.Matrix = new Cell[size, size];
            this.printer = printer;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Matrix[i, j] = new Cell('0');
                }
            }
        }

        /// <summary>
        /// this function adding a clue to the board
        /// </summary>
        /// <param name="row">thw row of a cell in the matrix</param>
        /// <param name="col">the column of a cell in the matrix</param>
        /// <param name="val">the value of the char you want to add</param>
        /// <returns>true if the function success to add the value, otherwise false</returns>
        /// <exception cref="ArgumentOutOfRangeException">if the row or col not valid</exception>
        public bool AddToBoard(int row, int col, char val)
        {
            if (row < 0 || col < 0 || row > this.Size || col > this.Size)
                throw new ArgumentOutOfRangeException("row or column not valid");
            if (val != '0')
            {
                Matrix[row, col].Clue = val;
                Matrix[row, col].Candidates.Clear();
                Matrix[row, col].Candidates.Add(val);

                if (!UpdateCellRegions(row, col))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// this function updates the candidadates of the cells in the row
        /// </summary>
        /// <param name="row">thw row of a cell in the matrix</param>
        /// <param name="column">the column of a cell in the matrix</param>
        /// <returns>true if the board is still valid, otherwise false</returns>
        public bool UpdateCellRow(int row, int column)
        {
            for (int i = 0; i < Size; i++)
            {
                if (Matrix[row, i].Clue == '0')
                {
                    Matrix[row, i].RemoveCandidate(Matrix[row, column].Clue);
                    if (Matrix[row, i].Candidates.Count == 0)
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        /// this function updates the candidadates of the cells in the column
        /// </summary>
        /// <param name="row">thw row of a cell in the matrix</param>
        /// <param name="column">the column of a cell in the matrix</param>
        /// <returns>true if the board is still valid, otherwise false</returns>
        public bool UpdateCellColumn(int row, int column)
        {
            for (int i = 0; i < Size; i++)
            {
                if (Matrix[i, column].Clue == '0')
                {
                    Matrix[i, column].RemoveCandidate(Matrix[row, column].Clue);
                    if (Matrix[i, column].Candidates.Count == 0)
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        /// this function updates the candidadates of the cells in the box
        /// </summary>
        /// <param name="row">thw row of a cell in the matrix</param>
        /// <param name="column">the column of a cell in the matrix</param>
        /// <returns>true if the board is still valid, otherwise false</returns>
        public bool UpdateCellBox(int row, int column)
        {
            int sizeOfBlock = (int)Math.Sqrt(Size);
            int boxRow = row / sizeOfBlock;
            int boxColumn = column / sizeOfBlock;

            for (int i = boxRow * sizeOfBlock; i < (boxRow + 1) * sizeOfBlock; i++)
                for (int j = boxColumn * sizeOfBlock; j < (boxColumn + 1) * sizeOfBlock; j++)
                    if (Matrix[i, j].Clue == '0')
                    {
                        Matrix[i, j].RemoveCandidate(Matrix[row, column].Clue);
                        if (Matrix[i, j].Candidates.Count == 0)
                            return false;
                    }
            return true;
        }
        /// <summary>
        /// this function updates the candidadates of the cell's region
        /// </summary>
        /// <param name="row">thw row of a cell in the matrix</param>
        /// <param name="column">the column of a cell in the matrix</param>
        /// <returns>true if the board is still valid, otherwise false</returns>
        public bool UpdateCellRegions(int row, int column)
        {
            if (UpdateCellRow(row, column) && UpdateCellColumn(row, column) && UpdateCellBox(row, column))
                return true;
            return false;
        }
        /// <summary>
        /// prints the board
        /// </summary>
        public void PrintBoard()
        {
            printer.Print(this);
        }

        /// <summary>
        /// clones the board
        /// </summary>
        /// <returns>clone of the board</returns>
        public object Clone()
        {
            Board clonedBoard = (Board)MemberwiseClone();
            clonedBoard.Matrix = (Cell[,])Matrix.Clone();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    clonedBoard.Matrix[i, j] = (Cell)Matrix[i, j].Clone();
                }
            }
            return clonedBoard;
        }
    }
}
