using JsonPlaceHolderAPI.Model;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace JsonPlaceHolderAPI.Steps
{
    [Binding]
    public class APITestFeatureSteps
    {
        public IRestClient client = new RestClient("https://jsonplaceholder.typicode.com/");
        public IRestRequest request;
        public IRestResponse response;
        public static JsonDeserializer deserialize = new JsonDeserializer();
        string resultId;
        string resultTitle;


        [Given(@"I perform Request ""(.*)"" with ""(.*)""")]
        [Obsolete]
        public void GivenIPerformRequestWith(string _request, Method _method)
        {
            request = new RestRequest(_request, _method);
            request.RequestFormat = DataFormat.Json;
        }

        [Given(@"I perform operatio with following value")]
        public void GivenIPerformOperatioWithFollowingValue(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            request.AddJsonBody(new Posts(){ userId =Convert.ToString(data.userId), title = data.title, body = data.body });
        }

        [Then(@"I can get status code (.*)")]
        public void ThenICanGetStatusCode(int statusCode)
        {
            int result = (int)response.StatusCode;
            Console.WriteLine("Status code:  " + result);
            Assert.True(result.Equals(statusCode), "Status code does not match");
        }
        [Given(@"Deserialize the api content")]
        public void ThenDeserializeTheApiContent()
        {
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            //typeCode_info = deserialize.Deserialize<TypeCode>(response);
            

            resultId = output["id"];
            resultTitle = output["title"];
            //Console.WriteLine("Title:"+resultTitle);
        }
        [Given(@"Execute API")]
        public void GivenExecuteAPI()
        {
            response = client.Execute<Posts>(request);
            //response.Data.userId
        }

        [Then(@"I should the get values ""(.*)""")]
        public void ThenIShouldTheGetValues(string id)
        {
            Assert.That(resultId, Is.EqualTo(id), "Id  is not match");
        }
        [Then(@"I should the get title values ""(.*)""")]
        public void ThenIShouldTheGetTitleValues(string title)
        {
            Assert.That(resultTitle, Is.EqualTo(title), "Title  is not match");
        }



    }
}
