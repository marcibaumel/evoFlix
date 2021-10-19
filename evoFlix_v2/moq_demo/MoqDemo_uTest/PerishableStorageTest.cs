using Moq;
using NUnit.Framework;
using StorageModel;
using StorageModel.Helpers;
using StorageModel.Implementations;
using StorageModel.Products;
using StorageModel.Products.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqDemo_uTest
{
    [TestFixture]
    public class PerishableStorageTest
    {
        [SetUp]
        public void TestCaseSetup()
        {
            myClassHelperMock = new Mock<IClassHelperProxy>();
            myMessDumperMock = new Mock<IMessageDumper>();
            myPerishableMock = new Mock<IPerishable>();
            myPerishableStorageMock = new Mock<IStorage<IPerishable>>();

            uint capacity = 50;
            
            myPerishableStorage = new PerishableStorage(capacity, myMessDumperMock.Object, myClassHelperMock.Object);
        }

        [Test]
        public void Capacity_GetCapacity_ReturnSetUpCapacity()
        {
            myPerishableStorage = new PerishableStorage(myPerishableStorage.Capacity, myMessDumperMock.Object, myClassHelperMock.Object);

            Assert.IsTrue(myPerishableStorage.Capacity == 50);
        }

        [TestCase(0, 10, -3)]
        public void StoredQuantity_GetStoredQuantity_ReturnSetUpStoredQuantity(int n, int d, int q)
        {
            myPerishableStorage = new PerishableStorage(myPerishableStorage.Capacity, myMessDumperMock.Object, myClassHelperMock.Object);

            Assert.IsTrue(myPerishableStorage.StoredQuantity == n);
            Assert.IsFalse(myPerishableStorage.StoredQuantity == d);
            Assert.IsFalse(myPerishableStorage.StoredQuantity == q);
        }

        [Test]
        public void MessageDumper_GetMessageDumper_ReturnTrueBySetUp()
        {
            Assert.IsTrue(myPerishableStorage.MessageDumper is IMessageDumper);
        }

        [Test]
        public void WithDraw_CanBeDelete_ReturnWithTheGivenPayload()
        {
            myClassHelperMock.Setup(x => x.GetClass(myPerishableMock.Object)).Returns(typeof(ICanned));
            myPerishableMock.SetupGet(x => x.Quantity).Returns(10);

            myPerishableStorage = new PerishableStorage(myPerishableStorage.Capacity, myMessDumperMock.Object, myClassHelperMock.Object);
            var ListItem = myPerishableMock.Object;
            myPerishableStorage.Products.Add(ListItem);
            myPerishableStorage.WithDraw(typeof(IPerishable), ListItem.Quantity);

            Assert.IsFalse(myPerishableStorage.Products.Contains(ListItem));
        }

        private PerishableStorage myPerishableStorage;
        private Mock<IStorage<IPerishable>> myPerishableStorageMock;
        private Mock<IClassHelperProxy> myClassHelperMock;
        private Mock<IMessageDumper> myMessDumperMock;
        private Mock<IPerishable> myPerishableMock;
    }  
}
