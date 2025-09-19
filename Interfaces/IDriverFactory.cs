using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject_DI.Interfaces
{
    public interface IDriverFactory
    {
        
    IWebDriver CreateDriver();
    }

}
