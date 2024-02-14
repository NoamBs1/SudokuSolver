using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SudokuProject
{
    /// <summary>
    /// the class that solving the board
    /// </summary>
    internal partial class Solver
    {
        public IBoard Board { get; set; }

        /// <summary>
        /// Initialized a solver with the required board
        /// </summary>
        /// <param name="board">the board you want to be solved</param>
        public Solver(IBoard board)
        {
            Board = board;
        }
        /// <summary>
        /// solving the board
        /// </summary>
        /// <param name="board">the board you want to be solved</param>
        /// <returns>the solved board</returns>

        public IBoard Solve(IBoard board)
        {
            (int row, int col) minCell = FindCellMinCandidates(board);
            if (minCell == (-1, -1))
            {
                return board;
            }
            foreach (char candidate in board.Matrix[minCell.row, minCell.col].Candidates)
            {
                IBoard clonedBoard = (IBoard)board.Clone();
                if (clonedBoard.AddToBoard(minCell.row, minCell.col, candidate))
                {
                    IBoard tempBoard = Solve(clonedBoard);
                    if (tempBoard != null && IsBoardValidAndComplete(tempBoard))
                        return tempBoard;
                }
            }
            return null;
        }


        /// <summary>
        /// finds the cell with minimal candidates
        /// </summary>
        /// <param name="board">the board you want to be solved</param>
        /// <returns>the indexes of the cell with the min candidates</returns>
        public (int, int) FindCellMinCandidates(IBoard board)
        {
            (int, int) minCell = (-1, -1);
            int minCandidates = board.Size + 1;
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    if (board.Matrix[i, j].Clue == '0' && board.Matrix[i, j].Candidates.Count < minCandidates)
                    {
                        minCell = (i, j);
                        minCandidates = board.Matrix[i, j].Candidates.Count;
                        if (minCandidates == 1)
                            return minCell;
                    }
                }
            }
            return minCell;
        }


        /// <summary>
        /// checks if all the board is valid and completed
        /// </summary>
        /// <param name="b">the board you want to check</param>
        /// <returns>true if it is valid and completed, otherwise false</returns>
        public static bool IsBoardValidAndComplete(IBoard b)
        {
            return IsRowsValidAndComplete(b) && IsColumnsValidAndComplete(b) && IsBlocksValidAndComplete(b);
        }
        /// <summary>
        /// checks if all the rows are valid and completed
        /// </summary>
        /// <param name="b">the board you want to check</param>
        /// <returns>true if it is valid and completed, otherwise false</returns>
        public static bool IsRowsValidAndComplete(IBoard b)
        {
            for (int i = 0; i < b.Size; i++)
            {
                if (!IsSingleRowValidAndComplete(b, i))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// checks if all the cols are valid and completed
        /// </summary>
        /// <param name="b">the board you want to check</param>
        /// <returns>true if it is valid and completed, otherwise false</returns>
        public static bool IsColumnsValidAndComplete(IBoard b)
        {
            for (int i = 0; i < b.Size; i++)
            {
                if (!IsSingleColoumnValidAndComplete(b, i))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// checks if all the boxes are valid and completed
        /// </summary>
        /// <param name="b">the board you want to check</param>
        /// <returns>true if it is valid and completed, otherwise false</returns>
        public static bool IsBlocksValidAndComplete(IBoard b)
        {
            int sizeOfBlock = (int)Math.Sqrt(b.Size);
            for (int startRow = 0; startRow < b.Size; startRow += sizeOfBlock)
            {
                for (int startColumn = 0; startColumn < b.Size; startColumn += sizeOfBlock)
                {
                    if (!IsSingleBoxValidAndComplete(b, startRow, startColumn))
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        /// checks if one row is valid and completed
        /// </summary>
        /// <param name="b">the board you want to check</param>
        /// <param name="row">the row you want to check</param>
        /// <returns>true if it is valid and completed, otherwise false</returns>
        public static bool IsSingleRowValidAndComplete(IBoard b, int row)
        {
            int[] allChars = new int[b.Size + 1];
            for (int i = 0; i < b.Size; i++)
            {
                char clue = b.Matrix[row, i].Clue;
                if (clue == '0')
                    return false;
                allChars[clue - '0']++;
            }
            for (int i = 1; i < b.Size + 1; i++)
                if (allChars[i] > 1)
                    return false;
            return true;
        }
        /// <summary>
        /// checks if one column is valid and completed
        /// </summary>
        /// <param name="b">the board you want to check</param>
        /// <param name="column">the column you want to check</param>
        /// <returns>true if it is valid and completed, otherwise false</returns>
        public static bool IsSingleColoumnValidAndComplete(IBoard b, int column)
        {
            int[] allChars = new int[b.Size + 1];
            for (int i = 0; i < b.Size; i++)
            {
                char clue = b.Matrix[i, column].Clue;
                if (clue == '0')
                    return false;
                allChars[clue - '0']++;
            }
            for (int i = 1; i < b.Size + 1; i++)
                if (allChars[i] > 1)
                    return false;
            return true;
        }
        /// <summary>
        /// checks if one box is valid and completed
        /// </summary>
        /// <param name="b">the board you want to check</param>
        /// <param name="startRow">the start row of the box</param>
        /// <param name="startColumn">the start column of the box</param>
        /// <returns>true if it is valid and completed, otherwise false</returns>
        public static bool IsSingleBoxValidAndComplete(IBoard b, int startRow, int startColumn)
        {
            int[] allChars = new int[b.Size + 1];
            int sizeOfBlock = (int)Math.Sqrt(b.Size);
            for (int i = startRow; i < startRow + sizeOfBlock; i++)
            {
                for (int j = startColumn; j < startColumn + sizeOfBlock; j++)
                {
                    char clue = b.Matrix[i, j].Clue;
                    if (clue == '0')
                        return false;
                    allChars[clue - '0']++;
                }
            }
            for (int i = 1; i < b.Size + 1; i++)
                if (allChars[i] > 1)
                    return false;
            return true;
        }
    }
}
