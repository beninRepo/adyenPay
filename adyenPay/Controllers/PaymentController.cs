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
    public class PaymentController : ApiController
    {
        private PaymentRepository paymentRepo;
        public PaymentController()
        {
            this.paymentRepo = new PaymentRepository();
        }
        [HttpGet]
        public JObject Get()
        {
            //return paymentRepo.GetPaymentSession();
            return paymentRepo.GetPaymentMetheods();
            




        }
    }
}
