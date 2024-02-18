using Microsoft.VisualStudio.TestTools.UnitTesting;
using sudoku.InputAndOutput;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.UnitTests.SudokuTests
{
    [TestClass]
    public class FileInputReaderTests
    {
        [TestMethod]
        public void ReadInput_FromExistingFile_ReturnsCorrectContent()
        {
            string ValidFilePath = "ValidFilePath.txt";
            string expectedContent = "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
            File.WriteAllText(ValidFilePath, expectedContent);
            FileInputReader reader = new FileInputReader(ValidFilePath);

            string actualContent = reader.ReadInput();

            Assert.AreEqual(expectedContent, actualContent);
            File.Delete(ValidFilePath);
        }

        [TestMethod]
        public void ReadInput_FromNonExistingFile_ThrowsIOException()
        {
            string NonExistingFilePath = "NonExistingFilePath.txt";
            FileInputReader reader = new FileInputReader(NonExistingFilePath);

            Assert.ThrowsException<IOException>(() => reader.ReadInput());
        }

    }
}
