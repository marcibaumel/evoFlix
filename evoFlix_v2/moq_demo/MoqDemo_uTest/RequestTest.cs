using Moq;
using NUnit.Framework;
using StorageModel;
using StorageModel.Implementations;
using StorageModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqDemo_uTest
{
    [TestFixture]
    public class RequestTest
    {
        [SetUp]
        public void SetUp()
        {
            myPayloadMock = new Mock<IPayload>();
            myRequestMock = new Mock<IRequest>();
            myRequest = new Request(myRequestMock.Object.Type, myPayloadMock.Object);

        }

        [Test]
        public void RequestTest_GivingValues_GivenValueAreEquels()
        {
            myRequestMock.SetupGet(x => x.Type).Returns(RequestType.Dispatch);
            myRequest = new Request(myRequestMock.Object.Type, myPayloadMock.Object);

            myRequestMock.Verify(x => x.Type);
            myPayloadMock.Verify();

            Assert.IsTrue(myRequest.Type == RequestType.Dispatch);
        }

        private Request myRequest;
        private Mock<IPayload> myPayloadMock;
        private Mock<IRequest> myRequestMock;
    }
}
