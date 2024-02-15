using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuProject;
using System;

namespace SudokuProject.UnitTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckLength_NotValidLength_ExceptionThrown()
        {
            Constants con = new Constants(9);
            Parser parser = new Parser("1234");

            parser.CheckLength();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckChars_NotValidCharsForLength_ExceptionThrown()
        {
            Constants con = new Constants(4);
            Parser parser = new Parser("123q123412341234");

            parser.CheckChars();
        }

        [TestMethod]
        public void Parse_ValidBoard_ReturnsParsedBoard()
        {
            Constants con = new Constants(4);
            IBoardPrinter printer = new BoardPrinterConsole();
            string bo = "1234000000000000";
            Parser parser = new Parser("1234000000000000");
            Board b = new Board(4, printer);

            var result = parser.Parse(b);
            var stringedBoard = Parser.ConvertToString(result);

            Assert.AreEqual(stringedBoard, bo);
        }
    }
}
