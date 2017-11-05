using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SoftwareDesign.ThirdPartyCreditCard.Controllers
{
    public class ValuesController : ApiController
    {
        // POST api/values
        public string PostRegisterBuy([FromBody]string creditCardNumber, string experationDate, string cvc, decimal value)
        {
            var transactionAccepted = true;
            var message = string.Empty;
            long creditCardNumberAux;
            DateTime experationDateAux;

            if (!long.TryParse(creditCardNumber, out creditCardNumberAux))
            {
                transactionAccepted = false;
                message = "Credit Card Number Invalid";
            }
            else if (!DateTime.TryParse(experationDate, out experationDateAux))
            {
                transactionAccepted = false;
                message = "Experation Date Invalid";
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