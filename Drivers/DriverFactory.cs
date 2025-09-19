using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using ReqnrollProject_DI.Enums;
using ReqnrollProject_DI.Model;
using ReqnrollProject_DI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject_DI.Drivers
{
    public class DriverFactory
    {

        private readonly ConfigurationManager _config;

        public DriverFactory(ConfigurationManager config)
        {
            _config = config;
        }

        public IWebDriver InitWebDriver()
        {
            var browser = _config.GetBrowserType1();
            //var tes1t = _config.GetSection<UI>(AppConfig.UI);
            //var test1 = _config.Get(AppConfig.Name);
            //Console.WriteLine(tes1t.BaseUrl);
            Console.WriteLine(browser.ToString());

            //IWebDriver _driver;

            switch (browser)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                case BrowserType.Edge:
                    return GetEdgeDriver();
                case BrowserType.Firefox:
                    return GetFirefoxDriver();
                default:
                    throw new ArgumentException($"Browser not supported: {browser}");
            }

           /* driver.Manage().Window.Maximize();
            return driver;*/
        }






        public IWebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }

        public IWebDriver GetEdgeDriver()
        {
            var options = new EdgeOptions();
            options.AddArgument("--start-maximized");
            return new EdgeDriver(options);
        }

        public IWebDriver GetFirefoxDriver()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--start-maximized");
            return new FirefoxDriver(options);
        }

    }
}
