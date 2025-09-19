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
    public class PageObjectManager
    {

        private readonly DriverManager _driverManager;
        private readonly InputManager _inputManager;

        public PageObjectManager(DriverManager driverManager, InputManager inputManager)
        {
            _driverManager = driverManager;
            _inputManager = inputManager;
        }

        private HomePage _homePage;
        public HomePage HomePage => _homePage ??= new HomePage(_driverManager, _inputManager);



    }
}
