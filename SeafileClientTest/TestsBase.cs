using RestSharp;
using SeafileClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SeafileClientTest
{
    public class TestsBase
    {
        protected string AccessToken { get; set; }
        protected string UserName { get; set; }
        protected string Password { get; set; }
        protected string ServiceRoot { get; set; }
        protected string DefaultRepoId { get; set; }

        protected IApi Api { get; }

        public TestsBase()
        {
            var config = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("./appsettings.json"));
            UserName = config["userName"];
            Password = config["password"];
            ServiceRoot = config["serviceRoot"];
            Api = SeafileClient.Api.GetApi(ServiceRoot);
            AccessToken = Api.Login(UserName, Password);
            DefaultRepoId = Api.GetDefaultRepo(AccessToken).RepoId;
        }
    }

    public class MockErrorRequestDecorator<T>: RequestDecorator<T> where T: IApi
    {
        public static int HttpStatusCode = 200;
        public override void BeforeRequest(RestRequest req, string methodName, object[] args)
        {
            if(HttpStatusCode != 200)
                req.AddHeader("RESPONSECODE", HttpStatusCode.ToString());
        }
    }

}
