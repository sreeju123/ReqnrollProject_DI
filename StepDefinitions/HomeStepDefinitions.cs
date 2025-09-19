
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollProject_DI.Drivers;
using ReqnrollProject_DI.PageObjects;
using System;

namespace ReqnrollProject_DI.StepDefinitions
{
    [Binding]
    public class HomeStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly PageObjectManager _pages;
        private readonly DriverManager _driverManager;

        public HomeStepDefinitions(ScenarioContext scenarioContext, DriverManager driverManager, PageObjectManager pages)
        {
            _scenarioContext = scenarioContext;
            _pages = pages;
            _driverManager = driverManager;
        }


        [Given("Launch the URL")]
        public void GivenLaunchTheURL()

        {

            _driverManager.Driver.Url = "https://rahulshettyacademy.com/angularpractice/";
        }

        [When(@"Enter all the mandatory details")]
        public void WhenEnterAllTheMandatoryDetails()
        {
            _pages.HomePage.EnterName("Sreejith");
          



        }

        [Then(@"Click submit")]
        public void ThenClickSubmit()
        {

            _pages.HomePage.CLickSubmit();
            //_driverManager.Driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        [Then(@"The successfull form submisson message is displayed")]
        public void ThenTheSuccessfullFormSubmissonMessageIsDisplayed()
        {
            Assert.True(_driverManager.Driver.FindElement(By.XPath("//*[@class='alert alert-success alert-dismissible']")).Text.Contains("success"));

            Console.WriteLine("***************" + _driverManager.Driver.FindElement(By.XPath("//*[@class='alert alert-success alert-dismissible']")).Text.Contains("success"));


        }
    }
}
