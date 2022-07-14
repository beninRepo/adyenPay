using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace adyenPay.Helpers
{
    class ParameterStore
    {
        public string APIkey
        {
            get { return ConfigurationManager.AppSettings["APIkey"]; }
            set { }
        }
        public string reference
        {
            get { return ConfigurationManager.AppSettings["reference"]; }
            set { }
        }
        public string merchantAccount
        {
            get { return ConfigurationManager.AppSettings["merchantAccount"]; }
            set { }
        }
        public string PaymentMethodAPI
        {
            get { return ConfigurationManager.AppSettings["PaymentMethodAPI"]; }
            set { }
        }
        public string PaymentSessionAPI
        {
            get { return ConfigurationManager.AppSettings["PaymentSessionAPI"]; }
            set { }
        }
        public string returnUrl
        {
            get { return ConfigurationManager.AppSettings["returnUrl"]; }
            set { }
        }
        public string PaymentsAPI
        {
            get { return ConfigurationManager.AppSettings["PaymentsAPI"]; }
            set { }
        }
        public string RedirectAPI
        {
            get { return ConfigurationManager.AppSettings["RedirectAPI"]; }
            set { }
        }

        public string ClientKey
        {
            get { return ConfigurationManager.AppSettings["ClientKey"]; }
            set { }
        }

    }
}