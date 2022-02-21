using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace csharp_example_firefox
{
    [TestFixture]
    public class Login_Edge
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Start()
        {
            driver = new EdgeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void LoginTest()
        {
            driver.Navigate().GoToUrl("http://localhost/litecart/admin/login.php?redirect_url=%2Flitecart%2Fadmin%2F");

            string username = "admin";
            string password = "admin";
            string expectedUrl = "http://localhost/litecart/admin/";
            ;

            driver.FindElement(By.Name("username")).SendKeys(username);

            driver.FindElement(By.Name("password")).SendKeys(password);

            driver.FindElement(By.Name("login")).Click();




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