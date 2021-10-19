using DemoLibaryCore;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ApiUnitTest
{
    
    public class ApiTest
    {
       
        [Category("Test")]
        [Test]
        public async Task TestApiCall()
        {
           
            Mock<HttpClientHandler> mockHandler = new Mock<HttpClientHandler>();
            mockHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.OK, Content = new StringContent("Success!") });
            
            HttpClient httpClient = new HttpClient(mockHandler.Object);
            
            SunProcessor sunProcessor = new SunProcessor();
            var response = await sunProcessor.testRequest(httpClient);
            Assert.That(response == "Success!");
        }

    }
}
