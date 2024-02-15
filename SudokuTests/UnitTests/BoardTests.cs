using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SudokuProject.UnitTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddToBoard_RowOrColOutOfRange_ArgumentOutOfRangeExceptionThrown()
        {
            IBoardPrinter printer = new BoardPrinterConsole();
            Constants con = new Constants(9);
            Board b = new Board(9, printer);

            b.AddToBoard(-1, -1, '2');
        }

        [TestMethod]
        public void AddToBoard_ValueAddedSuccessfully_ReturnsTrue()
        {
            IBoardPrinter printer = new BoardPrinterConsole();
            Constants con = new Constants(9);
            Board b = new Board(9, printer);

            var result = b.AddToBoard(2, 3, '6');

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddToBoard_ValueCauseDeletingAllCandidates_ReturnsFalse()
        {
            IBoardPrinter printer = new BoardPrinterConsole();
            Constants con = new Constants(9);
            Board b = new Board(9, printer);
            b.Matrix[0, 0].Candidates = new List<char> { '2' };

            var result = b.AddToBoard(0, 1, '2');

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateCellRegions_ValidUpdate_ReturnsTrue()
        {
            IBoardPrinter printer = new BoardPrinterConsole();
            Constants con = new Constants(9);
            Board b = new Board(9, printer);
            b.Matrix[2, 3].Clue = '6';

            var result = b.UpdateCellRegions(2, 3);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateCellRegions_NotValidUpdate_ReturnsFalse()
        {
            IBoardPrinter printer = new BoardPrinterConsole();
            Constants con = new Constants(9);
            Board b = new Board(9, printer);
            b.Matrix[2, 4].Candidates = new List<char> { '6' };
            b.Matrix[2, 3].Clue = '6';

            var result = b.UpdateCellRegions(2, 3);

            Assert.IsFalse(result);
        }
    }
}
