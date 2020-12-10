using System;
using RestSharp;
using RestSharp_Demo_NUnit.Model;

namespace RestSharp_Demo_NUnit.Base
{
    public class Settings
    {
        public Uri BaseUrl { get; set; }
        public IRestResponse Response { get; set; }
        public IRestRequest Request { get; set; }
        public RestClient RestClient { get; set; } = new RestClient();
    }
}
