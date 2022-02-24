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

            //            Начните с прокликивания пунктов меню верхнего уровня.
            //            Для этого нужно научиться получать список элементов,
            //            которые соответствуют этим пунктам меню.

            //            Затем нужно сделать цикл со счётчиком
            //            for (int i = 0; i < elementsMenu.Count; i++)
            //            внутри цикла находить пункт меню с порядковым номером i
            //            и кликать по нему, а потом проверять наличие заголовка(элемента с тегом h1).
            //            Когда это заработает, можно будет добавить вложенный цикл, который прокликивает элементы второго уровня.



          var elementsMenuCount = Driver.FindElements(By.CssSelector("span.name")).Count;
           
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





