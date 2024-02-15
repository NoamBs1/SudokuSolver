using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    /// <summary>
    /// this class represent a cell in sudoku board
    /// </summary>
    internal class Cell : ICloneable
    {
        public char Clue { get; set; }

        public IList<char> Candidates { get; set; }

        /// <summary>
        /// Initialized a Cell in the board
        /// </summary>
        /// <param name="clue">the char that assigned to the cell</param>
        public Cell(char clue)
        {
            Clue = clue;
            if (clue == '0')
                Candidates = new List<char>(Constants.Values);
        }
        /// <summary>
        /// removes a candidate from the set of candidates that the cell has
        /// </summary>
        /// <param name="clue">the char you want to be removed</param>
        public void RemoveCandidate(char clue)
        {
            this.Candidates.Remove(clue);
        }
        /// <summary>
        /// clones the cell
        /// </summary>
        /// <returns>clone of the cell</returns>
        public object Clone()
        {
            Cell clonedCell = (Cell)MemberwiseClone();
            if (clonedCell.Clue == '0')
                clonedCell.Candidates = new List<char>(Candidates);
            return clonedCell;
        }
    }
}
