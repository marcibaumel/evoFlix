using evoFlix.API;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace evoFlix.uTest.OmdbTests
{
    public class OmdbAPITests
    {
        [Category("Test")]
        [Test]
        public async Task TestApiCall()
        {

            Mock<HttpClientHandler> mockHandler = new Mock<HttpClientHandler>();
            mockHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.OK, Content = new StringContent("Success!") });

            HttpClient httpClient = new HttpClient(mockHandler.Object);

            OmdbProcessor sunProcessor = new OmdbProcessor();
            var response = await sunProcessor.testRequest(httpClient);
            Assert.That(response == "Success!");
        }
    }
}
