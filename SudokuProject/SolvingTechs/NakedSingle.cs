using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    public partial class Solver
    {
        /// <summary>
        /// a strategy to solve the board - naked single
        /// </summary>
        /// <param name="b">the board you want to act the strategy on</param>
        /// <returns>true if one naked single was commited, otherwise false</returns>
        public bool NakedSingle(IBoard b)
        {
            bool flag = false;
            for (int i = 0; i < b.Size; i++)
            {
                for (int j = 0; j < b.Size; j++)
                {
                    if (b.Matrix[i, j].Clue == '0' && b.Matrix[i, j].Candidates.Count == 1)
                    {
                        if (b.AddToBoard(i, j, b.Matrix[i, j].Candidates.Last()))
                            flag = true;
                    }
                }
            }
            return flag;
        }
    }
}
