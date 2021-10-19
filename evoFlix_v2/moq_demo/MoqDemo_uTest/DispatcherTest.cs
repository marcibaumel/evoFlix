using Moq;
using NUnit.Framework;
using StorageModel;
using StorageModel.Helpers;
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
    public class DispatcherTest
    {
        [SetUp]
        public void SetUp()
        {

           
            myDispatcher = new Dispatcher();

        }

        [Test]
        public void MessageDumper_GetMessageDumper_ReturnMessageDumper()
        {
            var Result = myDispatcher.MessageDumper;
            bool TestResult = Result.GetType() == typeof(MessageDumper);
            Assert.IsTrue(TestResult);
        }

        [Test]
        public void ProcessDispatchRequest_NullPayload_ReturnArgumentNullException()
        {
            myPayload = null;
            Assert.Throws<NullReferenceException>(() => myDispatcher.ProcessDispatchRequest(myPayload.Object));
        }

        

        private Dispatcher myDispatcher;
        private Mock<IPayload> myPayload;
        
    }

}
