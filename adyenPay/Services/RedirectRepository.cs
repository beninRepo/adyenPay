using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using adyenPay.Helpers;

namespace adyenPay.Services
{
    public class RedirectRepository
    {
        ParameterStore ps = new ParameterStore();
        public JObject GetRedirectDetails(string redirectData)
        {


            string data = "";
           
           
                 data = @"{
              ""details"": {
                ""redirectResult"":" +'"'+ redirectData +'"'+ "}}";
            
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ps.RedirectAPI);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("x-API-key", ps.APIkey);


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return JObject.Parse(result);
            }

        }
    }
}