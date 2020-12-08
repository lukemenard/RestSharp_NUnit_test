using System;
using NUnit.Framework;
using RestSharp;
using RestSharp_Demo_NUnit.Base;
using RestSharp_Demo_NUnit.Model;
using RestSharp_Demo_NUnit.Utilities;
using TechTalk.SpecFlow;

namespace RestSharp_Demo_NUnit.Steps
{
    [Binding]
    public class GetPostsSteps
    {
        private Settings _settings;
        public GetPostsSteps(Settings settings) => _settings = settings;

        //public RestClient client = new RestClient("http://localhost:3000");

        [Given(@"I perform GET operation for ""(.*)""")]
        public void GivenIPerformGETOperationFor(string url)
        {
            _settings.Request = new RestRequest(url, Method.GET);
        }

        [Given(@"I perform operation for post ""(.*)""")]
        public void GivenIPerformOperationForPost(int postId)
        {
            _settings.Request.AddUrlSegment("postid", postId.ToString());
            _settings.Response = _settings.RestClient.ExecuteAsyncRequest<Posts>(_settings.Request).GetAwaiter().GetResult();
        }

        [Then(@"I should see the ""(.*)"" name as ""(.*)""")]
        public void ThenIShouldSeeTheNameAs(string key, string value)
        {
            Assert.That(_settings.Response.GetResponseObject(key), Is.EqualTo(value), $"The {key} is not matching");
        }
    }
}
