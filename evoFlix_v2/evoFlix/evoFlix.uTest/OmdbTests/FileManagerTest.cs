using imdb_api_test;
using imdb_api_test.Implementations;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.uTest.OmdbTests
{
    [TestFixture]
    public class FileManagerTest
    {
        [SetUp]
        public void TestCaseSetup()
        {
            myFilmSerializableMock = new Mock<IFilmSerializable>();
            myOmdbAPIMock = new Mock<IOmdbAPI>();
            
            string path = @"evoFlix.uTest/TestData";
            string fullPath = Path.GetFullPath(path);

            string resultPath = @"evoFlix.uTest/TestData/TestResult.txt";
            string fullPathResult = Path.GetFullPath(resultPath);
            
            myFileManager = new FileManager(path, resultPath, myOmdbAPIMock.Object, myFilmSerializableMock.Object);
        }

        [Test]
        public void LastModifiedTest_GetTheDateWhenModifiedLast()
        {
            TestCaseSetup();
            Assert.IsTrue(myFileManager.LastModified() is DateTime);

        }
          

        private FileManager myFileManager;
        private Mock<IOmdbAPI> myOmdbAPIMock;
        private Mock<IFilmSerializable> myFilmSerializableMock;
    }
}
