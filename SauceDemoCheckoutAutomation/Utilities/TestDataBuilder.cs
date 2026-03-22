using SauceDemoCheckoutAutomation.Utilities.SauceDemoCheckoutAutomation.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SauceDemoCheckoutAutomation.Utilities
{
    public static class TestDataBuilder
    {
        private static Config _config;
        private static CheckoutData _checkoutData;

        public static Config LoadConfig(string path = "TestData/config.json")
        {
            if (_config == null)
            {
                string json = File.ReadAllText(path);
                _config = JsonSerializer.Deserialize<Config>(json)!;
            }
            return _config;
        }

        public static CheckoutData LoadCheckoutData(string path = "TestData/checkoutData.json")
        {
            if (_checkoutData == null)
            {
                string json = File.ReadAllText(path);
                _checkoutData = JsonSerializer.Deserialize<CheckoutData>(json)!;
            }
            return _checkoutData;
        }
    }
}
