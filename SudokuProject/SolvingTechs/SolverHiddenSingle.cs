using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    internal partial class Solver
    {

        public static bool HiddenSingle(IBoard board, int row, int col, char removedCand)
        {
            return HiddenSingleInRow(board, row, removedCand) && HiddenSingleInCol(board, col, removedCand) && HiddenSingleInBox(board, row, col, removedCand);
        }


        public static bool HiddenSingleInCol(IBoard b, int col, char removedCand)
        {
            int count = 0;
            int index = -1;
            for (int i = 0; i < b.Size; i++)
            {
                foreach (char cand in b.Matrix[i, col].Candidates)
                {
                    if (removedCand == cand)
                    {
                        index = i;
                        count++;
                        break;
                    }
                }
            }
            if (count == 0)
                return false;
            if (count == 1)
                b.Matrix[index, col].Clue = removedCand;
            return true;
        }

        public static bool HiddenSingleInRow(IBoard b, int row, char removedCand)
        {
            int count = 0;
            int index = -1;
            for (int i = 0; i < b.Size; i++)
            {
                foreach (char cand in b.Matrix[row, i].Candidates)
                {
                    if (removedCand == cand)
                    {
                        index = i;
                        count++;
                        break;
                    }
                }
            }
            if(count == 0)
                return false;
            if(count == 1)
                b.Matrix[row,index].Clue = removedCand;
            return true;
        }

        public static bool HiddenSingleInBox(IBoard b, int row, int col, char removedCand)
        {
            int count = 0;
            int startRow = row - (row % (int)Math.Sqrt(b.Size));
            int startCol = col - (col % (int)Math.Sqrt(b.Size));
            int rowIndex = -1;
            int colIndex = -1;
            for (int i = startRow; i < startRow + (int)Math.Sqrt(b.Size); i++)
            {
                for (int j = startCol; j < startCol + (int)Math.Sqrt(b.Size); j++)
                {
                    foreach (char cand in b.Matrix[i, j].Candidates)
                    {
                        if (removedCand == cand)
                        {
                            rowIndex = i;
                            colIndex = j;
                            count++;
                            break;
                        }
                    }
                }
            }
            if (count == 0)
                return false;
            if (count == 1)
                b.Matrix[rowIndex, colIndex].Clue = removedCand;
            return true;
        }
        
    }
}
