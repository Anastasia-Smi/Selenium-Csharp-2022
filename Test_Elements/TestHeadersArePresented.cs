using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Selenium_Csharp_2022;
using OpenQA.Selenium.Chrome;


namespace Selenium_Csharp_2022
{

    [TestClass]
    public class HeadersArePresented : ApplicationManager
    {
        [TestMethod]
        [Description("Verification of Headers Displaying")]
        [TestCategory("Regression")]
        [Priority(9)]

        public void HeaderAppearanceIsPresented()
        {
            BaseLog.Given("The User is LogOut");
            BaseLog.When("The User LogIn with valid credentials");
            Navigator.OpenLoginPage();
            loginHelper.LogIn();

            BaseLog.Then("The user navigates through left table clicking all existing tabs" +
                "and verifying that all headers are presented on the relevant page");


            var elementsMenuCount = Driver.FindElements(By.CssSelector("#app-")).Count;
           
            for (int i = 0; i < elementsMenuCount; i++)
            {
                
                var elementsMenuList = Driver.FindElements(By.CssSelector("span.name"));

                elementsMenuList[i].Click();

                Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

                var subelementsMenu = Driver.FindElements(By.XPath(".//ul[@class = 'docs']/li"));

                for (int a = 0; a < subelementsMenu.Count; a++)
                {
                    IList<IWebElement> subelementsMenuList = Driver.FindElements(By.XPath(".//ul[@class = 'docs']/li"));
                    subelementsMenuList[a].Click();
                    
                    Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);
                    
                }

                Driver.Navigate().Back();
            }
        }
    }
            
}





