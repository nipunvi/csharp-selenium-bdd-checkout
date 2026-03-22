using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemoCheckoutAutomation.Utilities
{
    namespace SauceDemoCheckoutAutomation.Models
    {
        public class Config
        {
            public string BaseUrl { get; set; }
            public string Username { get; set; }

            public string lockedOutUser { get; set; }
            public string Password { get; set; }
            public string Browser { get; set; }
        }

        public class CheckoutData
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PostalCode { get; set; }
        }
    }

}
