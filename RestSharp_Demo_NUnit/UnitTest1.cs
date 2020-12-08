using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Serialization.Json;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using RestSharp_Demo_NUnit.Model;
using System.Threading.Tasks;
using RestSharp_Demo_NUnit.Utilities;

namespace RestSharp_Demo_NUnit
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);

            var response = client.Execute(request);

            //var deserialize = new JsonDeserializer();
            //var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            //var result = output["author"];

            //Assert.That(result, Is.EqualTo("Karthik KK"), "Author is not correct");

            JObject obs = JObject.Parse(response.Content);

            Assert.That(obs["author"].ToString(), Is.EqualTo("Karthik KK"), "Author is not correct");
        }

        [Test]
        public void PostWithAnonymousBody()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts/{postid}/profile", Method.POST);

            request.AddJsonBody(new { name = "Raj" });
            request.AddUrlSegment("postid", 1);

            var response = client.Execute(request);

            var result = response.DeserializeResponse()["name"];

            Assert.That(result, Is.EqualTo("Raj"), "Author is not correct");
        }

        [Test]
        public void PostWithTypeClassBody()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts", Method.POST);

            request.AddJsonBody(new Posts() { id = "24", author = "Execute Automation", title = "RestSharp demo course" });

            var response = client.Execute<Posts>(request);

            //var deserialize = new JsonDeserializer();
            //var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            //var result = output["author"];

            Assert.That(response.Data.author, Is.EqualTo("Execute Automation"), "Author is not correct");
        }

        [Test]
        public void PostWithAsync()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts", Method.POST);

            request.AddJsonBody(new Posts() { id = "25", author = "Execute Automation", title = "RestSharp demo course" });

            //var response = client.ExecuteAsync<Posts>(request);

            var response = client.ExecuteAsyncRequest<Posts>(request).GetAwaiter().GetResult();

            Assert.That(response.Data.author, Is.EqualTo("Execute Automation"), "Author is not correct");
        }
    }
}
