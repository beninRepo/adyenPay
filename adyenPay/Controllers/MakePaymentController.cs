using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using adyenPay.Services;
using Newtonsoft.Json.Linq;

namespace adyenPay.Controllers
{
    public class MakePaymentController : ApiController
    {
        private MakePaymentRepository makePaymentRepo;
        public MakePaymentController()
        {
            this.makePaymentRepo = new MakePaymentRepository();
        }
        [HttpGet]
        public JObject Get(string paymentMethod)
        {
            return makePaymentRepo.GetPaymentResponse(paymentMethod);





        }
    }
}
