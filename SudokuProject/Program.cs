using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    internal class Program
    {
        /// <summary>
        /// the main app of the sudoku
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Stopwatch stopWatch = new Stopwatch();

                Console.WriteLine("welcome to my sudoku (:");
                Console.WriteLine("-------------------------");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("choose size:");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("note: for console the max size of a board can be 9");
                Console.ResetColor();
                try
                {
                    int size = int.Parse(Console.ReadLine());
                    if (Math.Sqrt(size) % 1 != 0)
                    {
                        Console.WriteLine("that's not a valid size for a sudoku board");
                        continue;
                    }
                    Constants con = new Constants(size);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("that's not a valid number for a board");
                    continue;
                }
                IBoard board = new Board(Constants.Values.Length, new BoardPrinterConsole());

                Console.WriteLine("-------------------------");
                Console.WriteLine("please choose a way to enter the sudoku:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\tc: for console\n\tf: for file");

                char option = Console.ReadKey().KeyChar;
                Console.ForegroundColor = ConsoleColor.Red;

                switch (option)
                {
                    case 'c':
                        Console.WriteLine("\nenter the sudoku:");
                        Console.ResetColor();
                        try
                        {
                            Parser parserConsole = new Parser(new ConsoleInputHandler());
                            IBoard parsedConsoleBoard = parserConsole.Parse(board);
                            parsedConsoleBoard.PrintBoard();
                            Solver solverConsole = new Solver();
                            stopWatch.Start();
                            IBoard solvedConsoleBoard = solverConsole.Solve(parsedConsoleBoard);
                            stopWatch.Stop();
                            if (solvedConsoleBoard != null)
                            {
                                solvedConsoleBoard.PrintBoard();
                                Console.WriteLine(Parser.ConvertToString(solvedConsoleBoard));
                                Console.WriteLine((stopWatch.ElapsedMilliseconds / 1000.0) + "s");
                            }
                            else
                            {
                                Console.WriteLine("not solvable");
                                Console.WriteLine(stopWatch.ElapsedMilliseconds / 1000.0 + "s");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 'f':
                        Console.WriteLine("\nthe result will save in solved.txt");
                        Console.WriteLine("enter the file path:");
                        Console.ResetColor();
                        string filePath = Console.ReadLine();
                        try
                        {
                            Parser parserFile = new Parser(new FileInputHandler(filePath));
                            IBoard parsedFileBoard = parserFile.Parse(board);
                            parsedFileBoard.PrintBoard();
                            Solver solverFile = new Solver();
                            stopWatch.Start();
                            IBoard solvedFileBoard = solverFile.Solve(parsedFileBoard);
                            stopWatch.Stop();
                            if (solvedFileBoard != null)
                            {
                                solvedFileBoard.PrintBoard();
                                Console.WriteLine(Parser.ConvertToString(solvedFileBoard));
                                BoardPrinterFile printerFile = new BoardPrinterFile("solved.txt");
                                printerFile.Print(solvedFileBoard);
                                Console.WriteLine((stopWatch.ElapsedMilliseconds / 1000.0) + "s");
                            }
                            else
                            {
                                Console.WriteLine("not solvable");
                                Console.WriteLine(stopWatch.ElapsedMilliseconds / 1000.0 + "s");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    default:
                        Console.WriteLine("\ntry again...");
                        continue;
                }
            }
        }
    }
}
