using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_Csharp_2022;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace Selenium_Csharp_2022
{

    [TestClass]
    public class StickersArePresented : ApplicationManager
    {
        [TestMethod]
        [Description("Verification of Stickers Displaying")]
        [TestCategory("Regression")]
        [Priority(9)]

        public void StickersArePresentedTest()
        {
            BaseLog.Given("The User is LogOut");
            BaseLog.When("The User LogIn with valid credentials");
            Navigator.OpenLoginPage();
            loginHelper.LogIn();

            Navigator.OpenRubberDucksPage();
            System.Threading.Thread.Sleep(9000);


            Console.WriteLine("The user navigates to the Catalog page");

            ReadOnlyCollection<IWebElement> ducks = Driver.FindElements(By.CssSelector
            ("li a.link"));

            foreach (var duck in ducks)
            {
                var sticker = Driver.FindElement(By.CssSelector("div.sticker"));
                Assert.IsTrue(Driver.FindElement((By)sticker).Displayed);
               
            }
        }
    }
}


