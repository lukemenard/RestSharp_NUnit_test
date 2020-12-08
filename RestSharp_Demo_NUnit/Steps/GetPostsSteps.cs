using System;
using NUnit.Framework;
using RestSharp;
using RestSharp_Demo_NUnit.Model;
using RestSharp_Demo_NUnit.Utilities;
using TechTalk.SpecFlow;

namespace RestSharp_Demo_NUnit.Steps
{
    [Binding]
    public class GetPostsSteps
    {
        public RestClient client = new RestClient("http://localhost:3000/");
        public RestRequest request = new RestRequest();
        public IRestResponse<Posts> response = new RestResponse<Posts>();

        [Given(@"I perform GET operation for ""(.*)""")]
        public void GivenIPerformGETOperationFor(string url)
        {
            request = new RestRequest(url, Method.GET);
        }

        [Given(@"I perform operation for post ""(.*)""")]
        public void GivenIPerformOperationForPost(int postId)
        {
            request.AddUrlSegment("postid", postId.ToString());
            client.ExecuteAsyncRequest<Posts>(request).GetAwaiter().GetResult();
        }

        [Then(@"I should see the ""(.*)"" name as ""(.*)""")]
        public void ThenIShouldSeeTheNameAs(string key, string value)
        {
            Assert.That(response.GetResponseObject(key), Is.EqualTo(value), $"The {key} is not matching");
        }
    }
}
