using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    /// <summary>
    /// this class prints the board to the console
    /// </summary>
    public class BoardPrinterConsole : IBoardPrinter
    {
        /// <summary>
        /// prints a delimiter line
        /// </summary>
        /// <param name="sizeOfBoard"> the size of the board</param>
        /// <param name="sb">a string builder</param>
        public void PrintDelimiterLine(int sizeOfBoard, StringBuilder sb)
        {
            int sizeOfBlock = (int)Math.Sqrt(sizeOfBoard);
            for (int k = 0; k < sizeOfBlock; k++)
            {
                sb.Append("+");
                for (int j = 0; j < sizeOfBlock * 2 + 1; j++)
                {
                    sb.Append("-");
                }
            }
            sb.Append("+");
            sb.AppendLine();
        }
        /// <summary>
        /// prints the board in a nice way
        /// </summary>
        /// <param name="board">the board object</param>
        public void Print(IBoard board)
        {
            StringBuilder sb = new StringBuilder();
            int sizeOfBlock = (int)Math.Sqrt(board.Size);
            for (int i = 0; i < board.Size; i++)
            {
                if (i % sizeOfBlock == 0)
                {
                    PrintDelimiterLine(board.Size, sb);
                }
                sb.Append("| ");
                for (int j = 0; j < board.Size; j++)
                {
                    sb.Append(board.Matrix[i, j].Clue);
                    sb.Append(' ');
                    if ((j + 1) % sizeOfBlock == 0)
                        sb.Append("| ");
                }
                sb.AppendLine();
            }
            PrintDelimiterLine(board.Size, sb);
            Console.WriteLine(sb);
        }
    }
}
