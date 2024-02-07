using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    internal class BoardPrinterConsole : IBoardPrinter
    {
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
        public void Print(Board board)
        {
            StringBuilder sb = new StringBuilder();
            int sizeOfBlock = (int)Math.Sqrt(board.Size);
            for(int i=0;i<board.Size;i++)
            {
                if (i % sizeOfBlock == 0)
                {
                    PrintDelimiterLine(board.Size, sb);   
                }
                sb.Append("| ");
                for (int j=0;j<board.Size;j++)
                {
                    sb.Append(board.Matrix[i,j].Clue);
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
