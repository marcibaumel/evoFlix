using Moq;
using NUnit.Framework;
using StorageModel;
using StorageModel.Helpers;
using StorageModel.Implementations;
using StorageModel.Products;
using System;

namespace MoqDemo_uTest
{
    [TestFixture]
    public class CannedStoreageTest
    {
        [SetUp]
        public void TestCaseSetup()
        {
            myClassHelperMock = new Mock<IClassHelperProxy>();
            myMessDumperMock = new Mock<IMessageDumper>();
            uint capacity = 50;
            
            myCannedStorage = new CannedStoreage(capacity, myMessDumperMock.Object, myClassHelperMock.Object);

            myCannedMock = new Mock<ICanned>();
        }

        [Test]
        public void Store_CanBeFit_True()
        {
            //Arrange
            myClassHelperMock.Setup(x => x.GetClass(myCannedMock.Object)).Returns(typeof(ICanned));       
            myCannedMock.SetupGet(x => x.Quantity).Returns(10);

            //Act
            myCannedStorage = new CannedStoreage(myCannedStorage.Capacity, myMessDumperMock.Object, myClassHelperMock.Object);

            //Asset
            Assert.IsTrue(myCannedStorage.Store(myCannedMock.Object));
        }

        [Test]
        public void WithDraw_CanBeDelete_ReturnWithTheGivenPayload()
        {
            myClassHelperMock.Setup(x => x.GetClass(myCannedMock.Object)).Returns(typeof(ICanned));
            myCannedMock.SetupGet(x => x.Quantity).Returns(10);

            myCannedStorage = new CannedStoreage(myCannedStorage.Capacity, myMessDumperMock.Object, myClassHelperMock.Object);
            var ListItem = myCannedMock.Object;
            myCannedStorage.Products.Add(ListItem);
            myCannedStorage.WithDraw(typeof(ICanned), ListItem.Quantity);
            
            Assert.IsFalse(myCannedStorage.Products.Contains(ListItem));
        }



        private CannedStoreage myCannedStorage;

        private Mock<IClassHelperProxy> myClassHelperMock;
        private Mock<IMessageDumper> myMessDumperMock;
        private Mock<ICanned> myCannedMock;

    }
}
