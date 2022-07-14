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
    public class RedirectController : ApiController
    {
        private RedirectRepository RedirectRepo;
        public RedirectController()
        {
            this.RedirectRepo = new RedirectRepository();
        }
        [HttpGet]
        public JObject Get(string redirectData)
        {
            return RedirectRepo.GetRedirectDetails(redirectData);
        }
    }
}
