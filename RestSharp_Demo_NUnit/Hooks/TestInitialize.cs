using System;
using System.Configuration;
using RestSharp_Demo_NUnit.Base;
using TechTalk.SpecFlow;

namespace RestSharp_Demo_NUnit.Hooks
{
    [Binding]
    public class TestInitialize
    {
        private Settings _settings;
        public TestInitialize(Settings settings)
        {
            _settings = settings;
        }

        [BeforeScenario]
        public void TestSetup()
        {
            _settings.BaseUrl = new Uri(ConfigurationManager.AppSettings["baseUrl"].ToString());
            _settings.RestClient.BaseUrl = _settings.BaseUrl;
        }

    }
}
