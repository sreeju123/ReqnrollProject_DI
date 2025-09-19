using OpenQA.Selenium;
using ReqnrollProject_DI.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject_DI.Utils
{
    public class InputManager
    {

        private readonly IWebDriver _driver;
        private readonly GenericHelper _genericHelper;
        private readonly DriverManager _driverManager;
        // private readonly ILog _logger;

        public InputManager(DriverManager driverManager, GenericHelper genericHelper)
        {
            _driverManager = driverManager;
            _genericHelper = genericHelper;
            //   _logger = Log4NetHelper.GetLogger(typeof(InputManager));
        }

        public void Click(By locator, int seconds = 20, int minutes=0, int hours=0)
        {
            _genericHelper.WaitforElementToBeEnabled(locator, seconds,minutes,hours);

            _driverManager.Driver.FindElement(locator).Click();
        }

       

       /* public void Click(IWebElement element, int seconds = 20, int minutes = 0, int hours = 0)
        {
            GenericHelper.WaitforElementToBeEnabled(element, seconds);
            element.Click();
        }*/

    }
}
