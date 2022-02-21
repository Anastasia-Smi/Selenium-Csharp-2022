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
            
            BaseLog.Then("The user navigates to the Catalog page");

            int ducks = duckHelper.GetDucksCount();
            int stickers = duckHelper.GetStickersCount();

            Assert.AreEqual(ducks, stickers);



        }
    }
}