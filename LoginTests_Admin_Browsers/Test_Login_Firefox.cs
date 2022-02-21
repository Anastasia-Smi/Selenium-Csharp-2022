using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Selenium_Csharp_2022;

namespace csharp_example_Firefox
{
    [TestFixture]
    public class Login_Firefox
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Start()
        {
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void LoginTest()
        {
            BaseLog.Given("The user is logged out");

            
            driver.Navigate().GoToUrl("http://localhost/litecart/admin/login.php?redirect_url=%2Flitecart%2Fadmin%2F");
            
            BaseLog.When(" The user inserts valid credentials");
            string username = "admin";
            string password = "admin";
            string expectedUrl = "http://localhost/litecart/admin/";

            driver.FindElement(By.Name("username")).SendKeys(username);
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.Name("login")).Click();


            BaseLog.Then("The home page is opened");
            Assert.AreEqual(expectedUrl, driver.Url);


        }

        [TearDown]
        public void Stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}