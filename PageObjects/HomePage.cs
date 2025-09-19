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
    public class HomePage : PageBase
    {

        public HomePage(DriverManager driverManager, InputManager inputManager) : base(driverManager, inputManager)
        {
        }


        private By FieldName = By.Name("name");
        private By SubmitButton = By.XPath("//input[@type='submit']");

               
        public void EnterName(String name)
        {
            DriverManager.Driver.FindElement(FieldName).SendKeys(name);
        }
        public void CLickSubmit()
        {
            InputManager.Click(SubmitButton);
        }
    }
}
