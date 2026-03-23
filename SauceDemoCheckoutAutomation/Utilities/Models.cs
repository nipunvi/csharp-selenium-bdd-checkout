using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemoCheckoutAutomation.Utilities
{
    namespace SauceDemoCheckoutAutomation.Models
    {
        public class Config
        {
            public required string BaseUrl { get; set; }
            public required string Username { get; set; }

            public required string lockedOutUser { get; set; }
            public required string Password { get; set; }
            public required string Browser { get; set; }
        }

        public class CheckoutData
        {
            public required string FirstName { get; set; }
            public required string LastName { get; set; }
            public required string PostalCode { get; set; }
        }
    }

}
