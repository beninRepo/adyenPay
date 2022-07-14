using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using adyenPay.Helpers;

namespace adyenPay.Services
{
    public class PaymentRepository
    {
        ParameterStore ps = new ParameterStore();
        public JObject GetPaymentMetheods()
        {
           
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ps.PaymentMethodAPI);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("x-API-key", ps.APIkey);
            var data = @"{
   ""reference"":"+'"'+ps.reference + '"' + @",
  ""merchantAccount"": " + '"' + ps.merchantAccount + '"' + @",
  ""allowedPaymentMethods"": [
    ""ideal"",
    ""scheme""
  ],
""channel"":""Web"",
  ""countryCode"": ""NL"",
  ""amount"": {
                ""value"": 1000,
    ""currency"": ""EUR""
  }
        }";

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

        public JObject GetPaymentSession()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ps.PaymentSessionAPI);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("x-API-key", ps.APIkey);
            var data = @"{
  ""shopperReference"": ""Checkout Components sample code test"",
  ""reference"": " + '"' + ps.reference + '"' + @",
  ""merchantAccount"":" + '"' + ps.merchantAccount + '"' + @",
 ""returnUrl"": " + '"' + ps.returnUrl + '"' + @",
  ""allowedPaymentMethods"": [
    ""ideal"",
    ""scheme""
  ],
   ""countryCode"": ""NL"",
  ""amount"": {
                ""value"": 1000,
    ""currency"": ""EUR""
  }
        }";

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