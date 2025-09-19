 using OpenQA.Selenium;
using ReqnrollProject_DI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject_DI.Drivers
{
    public class DriverManager : IDisposable
    {
        public IWebDriver Driver { get; }

        /* public DriverManager(IDriverFactory factory)
         {
             _driver = factory.CreateDriver(); // Each scenario gets its own driver
         }*/


        //private readonly DriverFactory _factory;

        public DriverManager(DriverFactory factory)
        {
            Driver = factory.InitWebDriver() ?? throw new NullReferenceException("WebDriver initialization failed!");
            Driver.Manage().Window.Maximize();

        }

        public void Dispose()
        {
            Driver?.Quit();
            // Optional: check if process still exists
            Console.WriteLine("Driver quit. Checking processes...");

            foreach (var process in System.Diagnostics.Process.GetProcessesByName("chromedriver"))
            {
                Console.WriteLine($"Chromedriver still running: {process.Id}");
            }
        }
    }

}
