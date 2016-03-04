using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1;


namespace Task1UnitTesting
{
    [TestFixture]
    public class ParsingTests
    {

        [Test]
        public void ParsingResultNotNull()
        {
            List<string>  strings = new List<string>(){"1 2 3 4","9 11 8 10"};
            Parser parser = new Parser(strings);

            var matrix = parser.getMatrix();
            Assert.AreNotEqual(matrix.getMatrixElementsCount(),0);

        }

        [Test]
        public void MatrixParsedRight()
        {
            List<string> strings = new List<string>() { "1 2 3 4", "9 11 8 10" };
            Parser parser = new Parser(strings);

            var matrix = parser.getMatrix();
            Assert.AreEqual(matrix.getMatrixElementsCount(), 8);
            Assert.AreEqual(matrix.getColumn(0), new List<int>(){1,9});
            Assert.AreEqual(matrix.getRow(0), new List<int>() { 1, 2,3,4 });
        }

        [Test]
        public void MatrixParsedWithNotEqualColumnsAndRows()
        {
            List<string> strings = new List<string>() { "1 2 3 4 8 9 7 9", "9 11 8 10","7 5"};
            Parser parser = new Parser(strings);

            var matrix = parser.getMatrix();
            Assert.AreEqual(matrix.getMatrixElementsCount(), 14);
            Assert.AreEqual(matrix.getColumn(0), new List<int>(){1,9,7});
            Assert.AreEqual(matrix.getRow(2), new List<int>() { 7,5 });
            Assert.AreEqual(matrix.getColumn(5), new List<int>() {9});
        }
    }

    [TestFixture]
    public class MonoFinderTest
    {
        [Test]
        public void getMaxMonoCountTest()
        {
            MonoFinder monoFinder = new MonoFinder();

            List<int> numbers = new List<int>() {1, 2, 3, 4, 8, 9, 7, 9};
            monoFinder.setCollection(numbers);

            Assert.AreEqual(monoFinder.getMaxMonoCount(), 6);

            List<int> numbers2 = new List<int>() { 1, 2, 5, 4, 1, 0, 7, 9 };
            monoFinder.setCollection(numbers2);

            Assert.AreEqual(monoFinder.getMaxMonoCount(), 4);

            List<int> numbers3 = new List<int>() { 2,2,2,2, 4, 1, 0, 7, 9,10,20};
            monoFinder.setCollection(numbers3);

            Assert.AreEqual(monoFinder.getMaxMonoCount(), 5);

            List<int> numbers4 = new List<int>() { 1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,4,3,2,1,0 };
            monoFinder.setCollection(numbers4);

            Assert.AreEqual(monoFinder.getMaxMonoCount(), 9);

            List<int> numbers5 = new List<int>() { 8,-800,6,1,4,5,4,3,2,1,0,-1 };
            monoFinder.setCollection(numbers5);

            Assert.AreEqual(monoFinder.getMaxMonoCount(), 7);
        }
    }


    [TestFixture]
    public class MatrixReplaceTest
    {
        [Test]
        public void replacementRows()
        {
            MatrixModel matrixModel = new MatrixModel();
            matrixModel.setRow(new List<int>() { 1, 2, 3, 4});
            matrixModel.setRow(new List<int>() {9, 11, 8, 10});
            matrixModel.setRow(new List<int>() { 5, 6, 12, 7 });

            matrixModel.replaceRows();

            Assert.AreEqual(matrixModel.getRow(0), new List<int>() { 1, 2, 3, 4 });
            Assert.AreEqual(matrixModel.getColumn(0), new List<int>() { 1, 5,9 });
        }

        [Test]
        public void replacementColumns()
        {
            MatrixModel matrixModel = new MatrixModel();
            matrixModel.setRow(new List<int>() { 1, 2, 3, 4 });
            matrixModel.setRow(new List<int>() { 5, 6, 12, 7  });
            matrixModel.setRow(new List<int>() { 9, 11, 8, 10 });

            matrixModel.replaceColumns();

            Assert.AreEqual(matrixModel.getRow(0), new List<int>() { 1, 2, 4, 3 });
            Assert.AreEqual(matrixModel.getColumn(3), new List<int>() { 3, 12, 8 });
        }

        [Test]
        public void replacementColumnsAndRows()
        {
            MatrixModel matrixModel = new MatrixModel();
            matrixModel.setRow(new List<int>() { 1, 2, 3, 4 });
            matrixModel.setRow(new List<int>() { 9, 11, 8, 10 });
            matrixModel.setRow(new List<int>() { 5, 6, 12, 7 });

            matrixModel.replaceRows();
            matrixModel.replaceColumns();

            Assert.AreEqual(matrixModel.getRow(0), new List<int>() { 1, 2, 4, 3 });
            Assert.AreEqual(matrixModel.getRow(1), new List<int>() { 5, 6, 7, 12 });
            Assert.AreEqual(matrixModel.getRow(2), new List<int>() { 9, 11, 10, 8 });

        }
        [Test]
        public void convertToText()
        {
            MatrixModel matrixModel = new MatrixModel();
            matrixModel.setRow(new List<int>() { 1, 2, 4, 3 });
            matrixModel.setRow(new List<int>() { 5, 6, 7, 12 });
            matrixModel.setRow(new List<int>() { 9, 11, 10, 8 });

            var text = matrixModel.toText();
            Assert.AreEqual(text, new List<string>() { "1 2 4 3","5 6 7 12","9 11 10 8"});
        }
    }

    [TestFixture]
    public class MainModelTest
    {
        private class DumbSource : IFileSource
        {
            public void setFileName(string name)
            {
                
            }

            public List<string> getTextData()
            {
                return new List<string>() {"3,4","1 2 3 4", "9 11 8 10", "5 6 12 7"};
            }

            public void saveTextData(List<string> data)
            {
                Assert.AreEqual(data, new List<string>() { "1 2 4 3", "5 6 7 12", "9 11 10 8" });
            }
        }
        [Test]
        public void SimpleTest()
        {
            MainModel mainModel = new MainModel(new DumbSource());

            mainModel.run();
        }
    }
}
