using OpenQA.Selenium;
using ReqnrollProject_DI.Drivers;
using ReqnrollProject_DI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject_DI.PageObjects
{
    public class PageBase
    {
        //protected IWebDriver Driver { get; }

        protected DriverManager DriverManager { get; }
        protected InputManager InputManager { get; }

        protected PageBase(DriverManager driverManager, InputManager inputManager)
        {
            //Driver = driver;
            DriverManager = driverManager;
            InputManager = inputManager;
        }


    }
}
