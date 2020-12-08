using System;
using RestSharp;
using RestSharp_Demo_NUnit.Base;
using RestSharp_Demo_NUnit.Model;
using RestSharp_Demo_NUnit.Utilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestSharp_Demo_NUnit.Steps
{
    [Binding]
    public class PostProfileSteps
    {

        private Settings _settings;
        public PostProfileSteps(Settings settings) => _settings = settings;

        [Given(@"I Perform POST operation for ""(.*)"" with body")]
        public void GivenIPerformPOSTOperationForWithBody(string url, Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            _settings.Request = new RestRequest(url, Method.POST);

            _settings.Request.AddJsonBody(new { name = data.name.ToString() });
            _settings.Request.AddUrlSegment("profileNo", ((int)data.profile).ToString());

            _settings.Response = _settings.RestClient.ExecuteAsyncRequest<Posts>(_settings.Request).GetAwaiter().GetResult();
        }


    }
}
