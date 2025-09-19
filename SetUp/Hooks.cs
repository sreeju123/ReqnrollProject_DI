using ReqnrollProject_DI.Drivers;
using ReqnrollProject_DI.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject_DI.SetUp
{
    public class Hooks
    {
      
        private readonly DriverManager _driverManager;
        //private readonly PageObjectManager _pages;

        public Hooks(DriverManager driverManager)
        {
            _driverManager = driverManager;
            //_pages = pages;
        }

        [AfterScenario]
        public void Cleanup()
        {
            _driverManager.Dispose();

        }

    }
}
