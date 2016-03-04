using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;

namespace Task2Tests
{
    [TestFixture]
    public class GraphModelTests
    {
        [Test]
        public void getShortPathsSimpleTest()
        {
            GraphModel graphModel = new GraphModel();
            graphModel.setNumbersPair(1, 3);
            graphModel.setNumbersPair(2, 5);
            graphModel.setNumbersPair(4, 3);
            graphModel.setNumbersPair(2, 3);
            graphModel.setNumbersPair(5, 4);

            Assert.AreEqual(graphModel.getShortestPath(2,4),new List<int>(){2,5,4});
        }
    }

    [TestFixture]
    public class MainModelSimpleTest
    {
        private class DumbSource : IFileSource
        {

            public List<string> getTextData()
            {
                return new List<string>() { "5 2 4", "1 3", "2 5", "4 3", "2 3", "5 4" };
            }

            public void saveTextData(List<string> data)
            {
                Assert.AreEqual(data, new List<string>() { "2 5 4" });
            }
        }
        [Test]
        public void SimpleTest()
        {
            MainModel mainModel = new MainModel(new DumbSource());

            mainModel.run();
        }
    }

    [TestFixture]
    public class MainModelTestWithTwoPaths
    {
        private class DumbSource : IFileSource
        {

            public List<string> getTextData()
            {
                return new List<string>() { "9 5 9","1 3","2 5","5 7","4 3","2 3","5 4","7 8","8 9","4 9" };
            }

            public void saveTextData(List<string> data)
            {
                Assert.AreEqual(data, new List<string>() {"5 4 9"});
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
