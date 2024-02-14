using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    internal partial class Solver
    {
        /*
        public bool NakedPair(IBoard b)
        {
            for (int i = 0; i < b.Size; i++)
            {
                HashSet<char> visited = new HashSet<char>();
                (int col1, int col2)? Pair = FindPairInRow(b,i, visited);
                if (Pair != null)
                {
                    DeleteCandidatesFromRow(b, i, visited.Take(2).ToList(), new HashSet<int> { Pair.Value.col1, Pair.Value.col2 });
                    return true;
                }
            }

            for (int i = 0; i < b.Size; i++)
            {
                HashSet<char> visited = new HashSet<char>();
                (int col1, int col2)? Pair = FindPairInCol(b, i, visited);
                if (Pair != null)
                {
                    DeleteCandidatesFromCol(b, i, visited.Take(2).ToList(), new HashSet<int> { Pair.Value.col1, Pair.Value.col2 });
                    return true;
                }
            }

            int sizeOfBlock = (int)Math.Sqrt(b.Size);
            for (int startRow = 0; startRow < b.Size; startRow += sizeOfBlock)
            {
                for (int startColumn = 0; startColumn < b.Size; startColumn += sizeOfBlock)
                {
                    HashSet<char> visited = new HashSet<char>();
                    (int col1, int col2)? Pair = FindPairInBox(b, startRow, startColumn, visited);
                    if (Pair != null)
                    {
                        DeleteCandidatesFromBox(b, startRow, startColumn, visited.Take(2).ToList(), new HashSet<int> { Pair.Value.col1, Pair.Value.col2 });
                        return true;
                    }
                }
            }

            return false; ;
        }


        public void DeleteCandidatesFromRow(IBoard b, int row, List<char> candidates, HashSet<int> except)
        {
            for (int i = 0; i < b.Size; i++)
            {
                if (b.Matrix[row,i].Clue == '0' && !except.Contains(i))
                {
                    b.Matrix[row, i].RemoveCandidate(candidates[0]);
                    b.Matrix[row, i].RemoveCandidate(candidates[1]);
                }
            }
        }

        public void DeleteCandidatesFromCol(IBoard b, int col, List<char> candidates, HashSet<int> except)
        {
            for (int i = 0; i < b.Size; i++)
            {
                if (b.Matrix[i, col].Clue == '0' && !except.Contains(i))
                {
                    b.Matrix[i, col].RemoveCandidate(candidates[0]);
                    b.Matrix[i, col].RemoveCandidate(candidates[1]);
                }
            }
        }

        public void DeleteCandidatesFromBox(IBoard b, int startRow, int startCol, List<char> candidates, HashSet<int> except)
        {
            int sizeOfBlock = (int)Math.Sqrt(b.Size);
            for (int i = startRow; i < startRow + sizeOfBlock; i++)
            {
                for (int j = startCol; j < startCol + sizeOfBlock; j++)
                {
                    if (b.Matrix[i,j].Clue == '0' && !except.Contains(i))
                    {
                        b.Matrix[i, j].RemoveCandidate(candidates[0]);
                        b.Matrix[i, j].RemoveCandidate(candidates[1]);
                    }
                }
            }
        }
        public (int, int)? FindPairInRow(IBoard b, int row, HashSet<char> set)
        {
            for (int i = 0; i < b.Size; i++)
            {
                if (b.Matrix[row, i].Candidates.Count == 2)
                {
                    for (int j = i + 1; j < b.Size; j++)
                    {
                        if (b.Matrix[row, j].Candidates.Count == 2 &&
                            b.Matrix[row, j].Candidates.SetEquals(b.Matrix[row, i].Candidates))
                        {
                            set.UnionWith(b.Matrix[row, i].Candidates);
                            return (i, j);
                        }
                    }
                }
            }
            return null;
        }

        public (int, int)? FindPairInCol(IBoard b, int col, HashSet<char> set)
        {
            for (int i = 0; i < b.Size; i++)
            {
                if (b.Matrix[i, col].Candidates.Count == 2)
                {
                    for (int j = i + 1; j < b.Size; j++)
                    {
                        if (b.Matrix[j, col].Candidates.Count == 2 &&
                            b.Matrix[j, col].Candidates.SetEquals(b.Matrix[j, col].Candidates))
                        {
                            set.UnionWith(b.Matrix[i, col].Candidates);
                            return (i, j);
                        }
                    }
                }
            }
            return null;
        }

        public (int, int)? FindPairInBox(IBoard b, int startRow, int startCol, HashSet<char> set)
        {
            int sizeOfBlock = (int)Math.Sqrt(b.Size);

            for (int i = startRow; i < startRow + sizeOfBlock; i++)
            {
                for (int j = startCol; j < startCol + sizeOfBlock; j++)
                {
                    if (b.Matrix[i, j].Candidates.Count == 2)
                    {
                        for (int x = i; x < startRow + sizeOfBlock; x++)
                        {
                            for (int y = j + 1; y < startCol + sizeOfBlock; y++)
                            {
                                if (b.Matrix[x, y].Candidates.Count == 2 &&
                                    b.Matrix[x, y].Candidates.SetEquals(b.Matrix[i, j].Candidates))
                                {
                                    set.UnionWith(b.Matrix[i, j].Candidates);
                                    return (i, x);
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
        */

    }
}
