using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll;
using SauceDemoCheckoutAutomation.Drivers;

namespace SauceDemoCheckoutAutomation.DI
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<DriverContext>();
        }
    }
}
