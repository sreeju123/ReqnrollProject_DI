using Microsoft.Extensions.Configuration;
using ReqnrollProject_DI.Enums;
using ReqnrollProject_DI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ReqnrollProject_DI.Utils
{
    public class ConfigurationManager
    {

        private readonly IConfigurationRoot _configuration;

        /* public ConfigurationManager()
         {
             string environment = Environment.GetEnvironmentVariable("TEST_ENV");
             if (string.IsNullOrWhiteSpace(environment))
             {
                 environment = "test";
             }
             Console.WriteLine(Directory.GetCurrentDirectory());
             var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile($"appsettings.{environment}.json", optional: false, reloadOnChange: true);


             _configuration = builder.Build();
         }*/

        public ConfigurationManager()
        {
           /* string environment = Environment.GetEnvironmentVariable("TEST_ENV");
            if (string.IsNullOrWhiteSpace(environment))
            {
                environment = "test";
            }*/
            Console.WriteLine(Directory.GetCurrentDirectory());
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true);


            _configuration = builder.Build();
        }

        public string Get(AppConfig appConfig)
        {
            return _configuration[appConfig.ToString()];
        }

        public T GetRoot<T>()
        {
            return _configuration.Get<T>();
        }

        public T GetSection<T>(AppConfig appConfig)
        {
           // return _configuration.GetSection(appConfig.ToString()).Get<T>();
            var appConfigSection = _configuration.GetSection(appConfig.ToString()).Get<T>();
            if (appConfigSection == null)
                throw new InvalidOperationException($"Configuration section '{appConfig}' not found.");
            return appConfigSection;
        }



        /*public BrowserType GetBrowserType()
        {
            BrowserType browser;
            var UI = _configuration.GetSection("UI").Get<UI>();
            bool isParsed = Enum.TryParse(UI.Browser, true, out browser);

            if (isParsed)
            {
                return browser;
            }
            else
            {
                return BrowserType.Chrome; // default
            }
        }*/

        public BrowserType GetBrowserType()
        {
            var uiSettings = GetSection<UI>(AppConfig.UI);
            if (!string.IsNullOrEmpty(uiSettings.Browser) && Enum.TryParse(uiSettings.Browser, true, out BrowserType browser))
            {
                return browser;
            }
            return BrowserType.Edge;
        }

       /* public BrowserType GetBrowserType1()
        {
            var browserValue = Get(AppConfig.Browser);
            if (!string.IsNullOrEmpty(browserValue) && Enum.TryParse(browserValue, true, out BrowserType browser))
            {
                return browser;
            }
            throw new InvalidOperationException("Invalid browser");
           // return BrowserType.Chrome;
        }*/

        public BrowserType GetBrowserType1()
        {
            string browserValue = Get(AppConfig.Browser); // directly read root key

            if (!string.IsNullOrEmpty(browserValue) && Enum.TryParse(browserValue, true, out BrowserType browser))
            {
                return browser;
            }

            throw new InvalidOperationException($"Invalid or missing browser value '{browserValue}'.");
        }

    }
}

