using System;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp_Demo_NUnit.Base;
using RestSharp_Demo_NUnit.Utilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestSharp_Demo_NUnit.Steps
{

    [Binding]
    public class CommonSteps
    {

        private Settings _settings;
        public CommonSteps(Settings settings)
        {
            _settings = settings;
        }

        [Given(@"I get JWT authentication of User with following details")]
        public void GivenIGetJWTAuthenticationOfUserWithFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            _settings.Request = new RestRequest("auth/login", Method.POST);
            _settings.Request.AddJsonBody(new { email = (string)data.Email, password = (string)data.Password });

            _settings.Response = _settings.RestClient.ExecutePostAsync(_settings.Request).GetAwaiter().GetResult();
            var access_token = _settings.Response.GetResponseObject("access_token");

            var authenticator = new JwtAuthenticator(access_token);
            _settings.RestClient.Authenticator = authenticator;
        }
    }
}
