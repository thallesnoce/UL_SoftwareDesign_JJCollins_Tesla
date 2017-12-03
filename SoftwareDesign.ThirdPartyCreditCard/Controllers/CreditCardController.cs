using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace SoftwareDesign.ThirdPartyCreditCard.Controllers
{
    public class CreditCardController : ApiController
    {
        // POST api/values
        public string Get(string creditCardNumber, string cvc, decimal value)
        {
            var transactionAccepted = true;
            var message = "Transaction successfully completed";
            long creditCardNumberAux;

            if (!long.TryParse(creditCardNumber, out creditCardNumberAux))
            {
                transactionAccepted = false;
                message = "Credit Card Number Invalid";
            }
            if (cvc.Length > 3)
            {
                transactionAccepted = false;
                message = "CVC Invalid";
            }

            return $"{transactionAccepted}|{message}";
        }
    }
}