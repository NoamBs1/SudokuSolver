using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SudokuProject.UnitTests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void IsBoardValidAndComplete_ValidBoard_ReturnsTrue()
        {
            IBoardPrinter printer = new BoardPrinterConsole();
            Constants con = new Constants(4);
            Board b = new Board(4, printer);
            Parser p = new Parser("1234341221434321");
            IBoard sb = p.Parse(b);

            var result = Solver.IsBoardValidAndComplete(sb);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBoardValidAndComplete_NotValidBoard_ReturnsFalse()
        {
            Solver solver = new Solver();
            IBoardPrinter printer = new BoardPrinterConsole();
            Constants con = new Constants(4);
            Board b = new Board(4, printer);
            Parser p = new Parser("1234241221434321");
            IBoard sb = p.Parse(b);

            var result = Solver.IsBoardValidAndComplete(sb);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FindCellMinCandidatesV2_ValidBoard_ReturnsIndexesOfCellMinCandidates()
        {
            Solver solver = new Solver();
            IBoardPrinter printer = new BoardPrinterConsole();
            Constants con = new Constants(4);
            Board b = new Board(4, printer);
            b.Matrix[1, 1].Candidates = new List<char> { '1' };

            var minCell = solver.FindCellMinCandidatesV2(b, solver.GetEmptyCells(b));

            Assert.AreEqual(minCell, (1, 1));
        }

        [TestMethod]
        public void Solve_SolvableBoard_ReturnsValidAndCompleteBoard()
        {
            Solver solver = new Solver();
            IBoardPrinter printer = new BoardPrinterConsole();
            Constants con = new Constants(4);
            Board b = new Board(4, printer);
            Parser p = new Parser("1234000000000000");
            IBoard sb = p.Parse(b);

            IBoard solvedBoard = solver.Solve(sb);

            Assert.AreEqual(Parser.ConvertToString(solvedBoard), "1234341221434321");
        }

        [TestMethod]
        public void Solve_SolvableBoard2_ReturnsValidAndCompleteBoard()
        {
            Solver solver = new Solver();
            IBoardPrinter printer = new BoardPrinterConsole();
            Constants con = new Constants(9);
            Board b = new Board(9, printer);
            Parser p = new Parser("800000070006010053040600000000080400003000700020005038000000800004050061900002000");
            IBoard sb = p.Parse(b);

            IBoard solvedBoard = solver.Solve(sb);

            Assert.AreEqual(Parser.ConvertToString(solvedBoard), "831529674796814253542637189159783426483296715627145938365471892274958361918362547");
        }

        [TestMethod]
        public void Solve_NotSolvableBoard_ReturnsNull()
        {
            Solver solver = new Solver();
            IBoardPrinter printer = new BoardPrinterConsole();
            Constants con = new Constants(9);
            Board b = new Board(9, printer);
            Parser p = new Parser("100000000000100000000000005000000100000000000000000000000000000000000010000000000");
            IBoard sb = p.Parse(b);

            IBoard solvedBoard = solver.Solve(sb);

            Assert.IsNull(solvedBoard);
        }

        [TestMethod]
        public void NakedSingle_BoardWithAtLeastOneCellWithOneCandidate_ReturnsTrue()
        {
            Solver solver = new Solver();
            IBoardPrinter printer = new BoardPrinterConsole();
            Constants con = new Constants(4);
            Board b = new Board(4, printer);
            b.Matrix[1, 2].Candidates = new List<char> { '1' };

            var result = solver.NakedSingle(b);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NakedSingle_BoardWithNoCellsWithOneCandidate_ReturnsFalse()
        {
            Solver solver = new Solver();
            IBoardPrinter printer = new BoardPrinterConsole();
            Constants con = new Constants(4);
            Board b = new Board(4, printer);

            var result = solver.NakedSingle(b);

            Assert.IsFalse(result);
        }

    }
}
