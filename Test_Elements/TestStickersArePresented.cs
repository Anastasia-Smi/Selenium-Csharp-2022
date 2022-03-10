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
        [Description("task_7_Verification of Stickers Displaying")]
        [TestCategory("Regression")]
        [Priority(9)]


        public void StickersArePresentedTest()
        {

            Navigator.OpenLoginPage();
            loginHelper.LogIn();

            Navigator.OpenRubberDucksPage();
            System.Threading.Thread.Sleep(9000);


            Console.WriteLine("The user navigates to the Catalog page");

            ReadOnlyCollection<IWebElement> products = Driver.FindElements(By.XPath
            ("//*[@class='product column shadow hover-light']"));


            foreach (var product in products)
            {
               
                var sticker = product.FindElements(By.CssSelector("div.sticker")).Count;

                Assert.IsTrue(sticker == 1);

            }
        }
    }
}


