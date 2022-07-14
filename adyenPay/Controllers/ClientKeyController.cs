using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using adyenPay.Helpers;

namespace adyenPay.Controllers
{
    public class ClientKeyController : ApiController
    {
        ParameterStore ps = new ParameterStore();
        [HttpGet]
        public string Get()
        {
            
            return ps.ClientKey;

        }
    }
}
