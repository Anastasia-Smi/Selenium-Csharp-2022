using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using OpenQA.Selenium;



namespace Selenium_Csharp_2022
{

    [TestClass]
    public class HeadersArePresented : ApplicationManager
    {
        [TestMethod]
        [Description("TASK_6_Verification of Headers Displaying")]
        [TestCategory("Regression")]
        [Priority(9)]

        public void HeaderAppearanceIsPresented()
        {
            Navigator.OpenLoginPage();
            loginHelper.LogIn();

            //var elementsMenuCount = Driver.FindElements(By.CssSelector("#app-")).Count;
            
            var elementsMenuCount = Driver.FindElements(By.XPath("//li[@id = 'app-']")).Count;
            for (int i = 0; i < elementsMenuCount; i++)
            {
                
                var elementsMenuList = Driver.FindElements(By.XPath(".//li[@id = 'app-']"));

                elementsMenuList[i].Click();

                Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

                var subelementsMenu = Driver.FindElements(By.XPath(".//ul[@class = 'docs']/li"));

                for (int a = 0; a < subelementsMenu.Count; a++)
                {
                    IList<IWebElement> subelementsMenuList = Driver.FindElements(By.XPath(".//ul[@class = 'docs']/li"));
                    subelementsMenuList[a].Click();
                    
                    Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);  
                }
            }
        }
    }         
}





