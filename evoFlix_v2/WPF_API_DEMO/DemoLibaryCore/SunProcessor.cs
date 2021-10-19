using DemoLibary;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoLibaryCore
{
    public class SunProcessor
    {
        public static async Task<SunModel> LoadSunInformation()
        {
            string url = "https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400&date=today";

            

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    SunResultModel sunResult = await response.Content.ReadAsAsync<SunResultModel>();

                    return sunResult.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /*
         * Test Part
         */

        private HttpClient restClient = new HttpClient(new HttpClientHandler() );
        private string URI = "google.com/teapot";
        public async Task<string> testRequest(HttpClient httpClient)
        {
             
            var Builder = new System.UriBuilder(URI);
            var response = await httpClient.GetAsync(Builder.Uri);
            var context = await response.Content.ReadAsStringAsync();
            
            return context;
        }
    }
}
