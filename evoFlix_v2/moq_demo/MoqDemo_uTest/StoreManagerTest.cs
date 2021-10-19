using System;
using System.Security.Cryptography.X509Certificates;
using Moq;
using NUnit.Framework;
using StorageModel;
using StorageModel.Helpers;
using StorageModel.Implementations;
using StorageModel.Products;
using StorageModel.Products.Product;

namespace MoqDemo_uTest
{
    [TestFixture]
    public class StoreManagerTest
    {
        [SetUp]
        public void TestCaseSetup()
        {
            myCannnedStorageMock = new Mock<IStorage<ICanned>>();
            myPerishableStorageMock = new Mock<IStorage<IPerishable>>();
            myDispatcherMock = new Mock<IDispatcher>();
            myClassHelperMock = new Mock<IClassHelperProxy>();

            myStoreManager = new StoreManager(myCannnedStorageMock.Object, myPerishableStorageMock.Object, myDispatcherMock.Object, myClassHelperMock.Object);

            myRequestMock = new Mock<IRequest>();
            myPerishableMock = new Mock<IPerishable>();
            myMessDumperMock = new Mock<IMessageDumper>();
        }

        //[Test]
        public void RequestReceived_Request_Dispatch()
        {
            //Arrange
            myRequestMock.SetupGet(x => x.Type).Returns(RequestType.Dispatch);
            myRequestMock.SetupGet(x => x.Payload).Returns(myPerishableMock.Object);
            myClassHelperMock.Setup(x => x.GetClass(myPerishableMock.Object)).Returns(typeof (IPerishable));
            myDispatcherMock.SetupGet(x => x.MessageDumper).Returns(myMessDumperMock.Object);

            //Act
            myStoreManager.RequestReceived(myRequestMock.Object);

            //Assert
            myMessDumperMock.Verify(x => x.DumpMessage("ssss", It.IsAny<object[]>()), Times.Once());

            
        }

        [Test]
        public void Dispatcher_Test()
        {
            myDispatcherMock.Verify();
            Assert.IsTrue(myStoreManager.Dispatcher is IDispatcher);
        }


        private StoreManager myStoreManager;

        private Mock<IStorage<ICanned>> myCannnedStorageMock;
        private Mock<IStorage<IPerishable>> myPerishableStorageMock;
        private Mock<IDispatcher> myDispatcherMock;
        private Mock<IClassHelperProxy> myClassHelperMock;

        private Mock<IRequest> myRequestMock;
        private Mock<IPerishable> myPerishableMock;
        private Mock<IMessageDumper> myMessDumperMock;
    }
}