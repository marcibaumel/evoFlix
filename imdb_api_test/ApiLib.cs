using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;


namespace imdb_api_test
{
    public partial class ApiLib
    {
        public string BaseUrl => "https://imdb-api.com";

        private readonly string _apiKey;
        private readonly WebProxy _webProxy;

        public ApiLib(string apiKey)
        {
            _apiKey = apiKey;
            _webProxy = null;
        }

        

        public ApiLib(string apiKey, WebProxy webProxy)
        {
            _apiKey = apiKey;
            _webProxy = webProxy;
        }
    }
}
