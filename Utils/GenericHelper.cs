using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ReqnrollProject_DI.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject_DI.Utils
{
    public class GenericHelper
    {
      //  private readonly IWebDriver _driver;
        private readonly DriverManager _driverManager;
       

        public GenericHelper(DriverManager driverManager)
        {
            _driverManager = driverManager;
        }

        public string TakeScreenShot(string filename = "Screenshot")
        {
            /* var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
             var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{scenarioName}.png");
             screenshot.SaveAsFile(filePath);
             return filePath;
 */

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            Screenshot screen = ((ITakesScreenshot)_driverManager.Driver).GetScreenshot();
            string file = projectDirectory + "//Living.Donation.Test.Automation//Nhsbt.LD.AutomationTests//Resources//Screenshots//" + filename + "-" + DateTime.Now.ToString("dd-MM-yyyy--HH-mm-ss") + ".png";
            screen.SaveAsFile(file);
            return file;

        }

        public void WaitforElementToBeEnabled(By locator, int seconds = 20, int minutes = 0, int hours = 0)
        {
            var wait = new WebDriverWait(_driverManager.Driver, new TimeSpan(hours, minutes, seconds));
            bool isElementEnabled = wait.Until(condition =>
            
            {
                try
                {
                    
                    isElementEnabled = IsElementEnabled(locator);
                    return isElementEnabled;
                }
                catch (StaleElementReferenceException)
                {
                    // Logger.Error("Stale Element reference");
                    return false;
                }
                catch (NoSuchElementException)
                {
                    //Logger.Debug("Cannot find element using locator");
                    return false;
                }
            });
        }

        public bool IsElementEnabled(By locator)
        {
            try
            {
                bool isElementEnabled = _driverManager.Driver.FindElement(locator).Enabled;
                //Logger.Debug("Element is enabled"); 
                return isElementEnabled;
            }
            catch (StaleElementReferenceException)
            {
                //Logger.Error("Stale Element reference"); 
                return false;
            }
            catch (Exception)
            {
                //Logger.Debug("Cannot find element"); 
                return false;
            }
        }

        public IWebElement GetElement(By locator)
        {
            try
            {
                IsElementEnabled(locator);
                return _driverManager.Driver.FindElement(locator);
            }
            catch(NoSuchElementException exception)
            {
                throw new NoSuchElementException("Stack Trace : " + exception);
            }
        }
    }
}
