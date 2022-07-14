using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adyenPay.Models
{
    public class paymentMethodConfig
    {
        public string shopperReference { get; set; }
        public string reference { get; set; }
        public string merchantAccount { get; set; }
        public string countryCode { get; set; }
        public string[] amount { get; set; }

    }
}