using Newtonsoft.Json;
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
    public class MakePaymentRepository
    {
        ParameterStore ps = new ParameterStore();
        public JObject GetPaymentResponse(string paymentMethod)
        {
            string data = "";
            if (paymentMethod.Contains("clientStateDataIndicator"))
            {
                 data = @"{
  ""amount"":{
    ""currency"":""EUR"",
    ""value"":1000
  },
        ""reference"":" + '"' + ps.reference + '"' + @",
  ""shopperReference"":""B_checkoutChallenge"",
  ""returnUrl"":" + '"' + ps.returnUrl + '"' + @",
  ""merchantAccount"":" + '"' + ps.merchantAccount + '"' + @",
               " + paymentMethod.Substring(1, paymentMethod.Length - 2)+"}" ;
            }
            else
            {
                 data = @"{
  ""amount"":{
    ""currency"":""EUR"",
    ""value"":1000
  },
        ""reference"":" + '"' + ps.reference + '"' + @",
  ""shopperReference"":""B_checkoutChallenge"",
  ""returnUrl"":" + '"' + ps.returnUrl + '"' + @",
  ""merchantAccount"":" + '"' + ps.merchantAccount + '"' + @",
                ""paymentMethod"":" + paymentMethod + "}";
            }
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ps.PaymentsAPI);
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