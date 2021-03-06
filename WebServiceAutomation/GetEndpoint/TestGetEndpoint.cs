using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceAutomation.GetEndpoint
{
    [TestClass]
    public class TestGetEndpoint
    {   
        
        private string getUrl = "http://localhost:8080/laptop-bag/webapi/api/all";

        [TestMethod]
        public void _1TestGetAllEndpoints()
        {
            //Step 1- create the HTTP Client
            HttpClient httpclient = new HttpClient();

            //Step 2 and 3- Create the request an dexecute it
            httpclient.GetAsync(getUrl);
            Task<HttpResponseMessage> httpResponseMessage = httpclient.GetAsync(getUrl);
            var result = httpResponseMessage.Result.ToString();
            Console.WriteLine($"Get all endpoints {result}");
            //Close connection
            httpclient.Dispose();

        }



        [TestMethod]
        public void _2TestGetAllEndpointsWithURI()
        {
            //Step 1- create the HTTP Client
            HttpClient httpclient = new HttpClient();

            //Step 2 and 3- Create the request an dexecute it
            Uri getUri = new Uri(getUrl);
            httpclient.GetAsync(getUri);
            Task<HttpResponseMessage> httpResponseMessage = httpclient.GetAsync(getUri);
            var result1 = httpResponseMessage.Result.ToString();
            Console.WriteLine(String.Format("Get all endpoints with URI {0}", result1));
            //Close connection
            httpclient.Dispose();

        }
        
        [TestMethod]
        public void _3TestGetAllEndPointWithInvalidURL()
        {
            HttpClient httpclient = new HttpClient();

            //Step 2 and 3- Create the request an dexecute it
            Uri getUri = new Uri(getUrl);
            httpclient.GetAsync(getUri);
            Task<HttpResponseMessage> httpResponseMessage = httpclient.GetAsync(getUri);
            var result1 = httpResponseMessage.Result.ToString();
            Console.WriteLine(String.Format("Get all endpoints with URI {0}", result1));

            //Close connection
            httpclient.Dispose();
            Assert.IsTrue(result1.Contains("StatusCode: 200"));

            //response data
            HttpContent responsedata= httpResponseMessage.Result.Content;
            HttpStatusCode statusCode = httpResponseMessage.Result.StatusCode;
            Console.WriteLine("The content of the message is:"+responsedata.ToString());
            Console.WriteLine("The Status code is:" + statusCode);
            Console.WriteLine("The Status code is:" + (int)statusCode);
            Task<string> reponse1 = responsedata.ReadAsStringAsync();
            string data= reponse1.Result;
            Console.WriteLine(data);

        }

        [TestMethod]
        public void _4TestGetAllEndpointInJsonFormat()
        {

            //Step 1- create the HTTP Client
            HttpClient httpclient = new HttpClient();

            var requestheader= httpclient.DefaultRequestHeaders;
            requestheader.Add("Accept", "application/json");

            Task<HttpResponseMessage> httpResponseMessage = httpclient.GetAsync(getUrl);
            var result = httpResponseMessage.Result;
            
            HttpContent responsedata = httpResponseMessage.Result.Content;
            
            Task<string> reponse1 = responsedata.ReadAsStringAsync();
            string data = reponse1.Result;
            Console.WriteLine(data);
            //Close connection
            httpclient.Dispose();

        }



        [TestMethod]
        public void _5TestGetAllEndpointInXMLFormat()
        {

            //Step 1- create the HTTP Client
            HttpClient httpclient = new HttpClient();

            var requestheader = httpclient.DefaultRequestHeaders;
            requestheader.Add("Accept", "application/json");

            Task<HttpResponseMessage> httpResponseMessage = httpclient.GetAsync(getUrl);
            var result = httpResponseMessage.Result;

            HttpContent responsedata = httpResponseMessage.Result.Content;

            Task<string> reponse1 = responsedata.ReadAsStringAsync();
            string data = reponse1.Result;
            Console.WriteLine(data);
            //Close connection
            httpclient.Dispose();

        }


        [TestMethod]
        public void _6TestGetAllEndpointInJSONLFormatUsingAcceptHeader()
        {

            //Step 1- create the HTTP Client
            HttpClient httpclient = new HttpClient();
             MediaTypeWithQualityHeaderValue jsonHeader = new MediaTypeWithQualityHeaderValue("application/json");
            var requestheader = httpclient.DefaultRequestHeaders;
            requestheader.Accept.Add(jsonHeader);

            Task<HttpResponseMessage> httpResponseMessage = httpclient.GetAsync(getUrl);
            var result = httpResponseMessage.Result;

            HttpContent responsedata = httpResponseMessage.Result.Content;

            Task<string> reponse1 = responsedata.ReadAsStringAsync();
            string data = reponse1.Result;
            Console.WriteLine(data);
            //Close connection
            httpclient.Dispose();
        }
       
        
        [TestMethod]
        public void _7TestSendEndpointUsingSendAsync()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.RequestUri = new Uri(getUrl);
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.Headers.Add("Accept", "application/json");

            HttpClient httpclient = new HttpClient();
            Task<HttpResponseMessage> httpResponse= httpclient.SendAsync(httpRequestMessage);


            HttpResponseMessage httpResponseMessage = httpResponse.Result;

            HttpContent responsedata = httpResponse.Result.Content;

            Task<string> reponse1 = responsedata.ReadAsStringAsync();
            string data = reponse1.Result;
            Console.WriteLine(data);
            //Close connection
            httpclient.Dispose();
        }
       
        
        [TestMethod]
        public void _8TestUsingStatement()
        {
            using (HttpClient httpClient= new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    
                    httpRequestMessage.RequestUri = new Uri(getUrl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("Accept", "application/json");

                    Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUrl);

                    using (HttpResponseMessage httpResponseMessage= httpResponse.Result)
                    {
                         
                        Console.WriteLine(httpResponseMessage);

                        //Status Code
                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                        Console.WriteLine("Status Code= "+ statusCode);
                        Console.WriteLine("Status Code= " + (int)statusCode);


                        //Reponse Data
                        HttpContent responsedata = httpResponseMessage.Content;
                        Task<string> response= responsedata.ReadAsStringAsync();
                        string data =response.Result;
                        Console.WriteLine(data);


                        JsonRootObject jsonRootObject= JsonConvert.DeserializeObject<JsonRootObject>(response.ResponseContent)
                    }
                }
            }
        }

        [TestMethod]
        public void _9TestDeserializationofJsonResponse()
        {

        }











    }
}
