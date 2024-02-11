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
    internal partial class Solver
    {
        public IBoard Board { get; set; }
        public Solver(IBoard board)
        {
            Board = board;
        }

        public IBoard Solve(IBoard board)
        {
            bool flag = true;
            while (flag)
            {
                flag = NakedSingle(board);
            }
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

        public (int, int) FindCellMinCandidates(IBoard board)
        {
            (int, int) minCell = (-1, -1);
            int minCandidates = board.Size;
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    if (board.Matrix[i, j].Clue == '0' && board.Matrix[i, j].Candidates.Count < minCandidates)
                    {
                        minCell = (i, j);
                        minCandidates = board.Matrix[i, j].Candidates.Count;
                    }
                }
            }
            return minCell;
        }

        public bool IsBoardValidAndComplete(IBoard b)
        {
            return IsRowsValidAndComplete(b) && IsColumnsValidAndComplete(b) && IsBlocksValidAndComplete(b);
        }

        public bool IsRowsValidAndComplete(IBoard b)
        {
            for (int i = 0; i < b.Size; i++)
            {
                if (!IsSingleRowValidAndComplete(b, i))
                    return false;
            }
            return true;
        }

        public bool IsColumnsValidAndComplete(IBoard b)
        {
            for (int i = 0; i < b.Size; i++)
            {
                if (!IsSingleColoumnValidAndComplete(b, i))
                    return false;
            }
            return true;
        }

        public bool IsBlocksValidAndComplete(IBoard b)
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

        public bool IsSingleRowValidAndComplete(IBoard b, int row)
        {
            HashSet<char> allChars = new HashSet<char>();
            for (int i = 0; i < b.Size; i++)
            {
                char clue = b.Matrix[row, i].Clue;
                if (clue == '0' || !allChars.Add(clue))
                    return false;
            }
            return true;
        }

        public bool IsSingleColoumnValidAndComplete(IBoard b, int column)
        {
            HashSet<char> allChars = new HashSet<char>();
            for (int i = 0; i < b.Size; i++)
            {
                char clue = b.Matrix[i, column].Clue;
                if (clue == '0' || !allChars.Add(clue))
                    return false;
            }
            return true;
        }

        public bool IsSingleBoxValidAndComplete(IBoard b, int startRow, int startColumn)
        {
            HashSet<char> allChars = new HashSet<char>();
            int sizeOfBlock = (int)Math.Sqrt(b.Size);
            for (int i = startRow; i < startRow + sizeOfBlock; i++)
            {
                for (int j = startColumn; j < startColumn + sizeOfBlock; j++)
                {
                    char clue = b.Matrix[i, j].Clue;
                    if (clue == '0' || !allChars.Add(clue))
                        return false;
                }
            }
            return true;
        }


        /*
        public bool NakedPair()
        {
            
        }
        

        public void DeleteCandidateFromRow(int row, int col, char candidate)
        {
            for(int i=0; i< Board.Size;i++)
            {
                if(i!=col)
                    Board.Matrix[row, i].RemoveCandidate(candidate);

            }
        }
        public (int, int)? FindPairInRow(int row)
        {
            for (int i = 0;i<Board.Size;i++)
            {
                if (Board.Matrix[row,i].Candidates.Count == 2)
                {
                    for(int j=i+1;j<Board.Size;j++)
                    {
                        if (Board.Matrix[row, j].Candidates.Count == 2 &&
                            Board.Matrix[row, j].Candidates.SetEquals(Board.Matrix[row, i].Candidates))
                            return (i, j);
                    }
                }
            }
            return null;
        }
        
        */
    }
}
