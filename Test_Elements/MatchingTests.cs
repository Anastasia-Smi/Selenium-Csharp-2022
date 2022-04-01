using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Selenium_Csharp_2022
{
    [TestClass]
    public class MatchingTests : ApplicationManager

    { 
        [TestCategory("Regression")]
        [Priority(9)]
        [TestMethod]
        [Description("TASK_10_Verification of Matching Products Names")]

        public void _MatchingProductPriceColorFont()
        {
            Console.WriteLine("The user login to the App");

            Navigator.OpenLoginPage();
            loginHelper.LogIn();
            Navigator.OpenRubberDucksPage();

            Console.WriteLine("The user navigates to the Ducks page");


            var product = Driver.FindElement(By.XPath
           ("//div[@id = 'box-campaigns']//*[@class='product column shadow hover-light']"));

            var link = product.FindElement(By.XPath(".//*[@class = 'link']")).GetAttribute("href");
            var productName = product.FindElement(By.XPath(".//*[@class = 'name']")).Text;
            var regPrice = product.FindElement(By.XPath(".//*[@class = 'regular-price']")).Text;
            var regPriceDecor = product.FindElement(By.XPath(".//*[@class = 'regular-price']")).GetCssValue("text-decoration");

            var regPriceDecorLine = regPriceDecor.Substring(0,12);

            var regPriceColor = product.FindElement(By.XPath
                (".//*[@class = 'regular-price']")).GetCssValue("color");
            var regPriceColorRGB = regPriceColor.Substring(5, 13);


            var auPrice = product.FindElement(By.XPath(".//*[@class = 'campaign-price']"))?.Text;

            string auPricefont = product.FindElement(By.XPath(".//*[@class = 'campaign-price']")).TagName;



            var auPriceColor = Driver.FindElement(By.CssSelector
                ("#box-campaigns .campaign-price")).GetCssValue("color");
            var  auPriceColorRGB = auPriceColor.Substring(5, 12);


            var auPriceSize = Driver.FindElement(By.CssSelector
                ("#box-campaigns .campaign-price")).GetCssValue("font-size").Trim(new char[] { 'p', 'x' });

            var regPriceSize = product.FindElement(By.XPath
                 (".//*[@class = 'regular-price']")).GetCssValue("font-size").Trim(new char[] { 'p', 'x' });


            Driver.Navigate().GoToUrl(link);

            var nameInt = Driver.FindElement(By.CssSelector("h1.title")).Text;
            var regPriceInt = Driver.FindElement(By.XPath(".//*[@class = 'regular-price']")).Text;
            var auPriceInt = Driver.FindElement(By.XPath(".//*[@class = 'campaign-price']")).Text;


            var regPriceIntColor = Driver.FindElement(By.XPath(".//*[@class = 'regular-price']")).GetCssValue("color");

            var regPriceIntSize = Driver.FindElement(By.XPath(".//*[@class = 'regular-price']")).GetCssValue("font-size").Trim(new char[] { 'p', 'x' });
            var regPriceIntRGB = regPriceIntColor.Substring(5, 13);
            var regPriceIntTxtDecor = Driver.FindElement(By.XPath(".//*[@class = 'regular-price']")).GetCssValue("text-decoration");

            var regPriceIntTxtDecorLine = regPriceIntTxtDecor.Substring(0, 12);



            var auPriceIntColor = Driver.FindElement(By.XPath(".//*[@class = 'campaign-price']")).GetCssValue("color");
            var auPriceIntColorRGB = auPriceIntColor.Substring(5, 12);


            var auPriceIntFont = Driver.FindElement(By.XPath(".//*[@class = 'campaign-price']")).TagName;
            var auPriceIntSizeFont = Driver.FindElement(By.XPath(".//*[@class = 'campaign-price']")).GetCssValue("font-size").Trim(new char[] { 'p', 'x' });
           
            var sizeAuIntPrice = int.Parse(auPriceIntSizeFont);
            var sizeAuPrice = int.Parse(auPriceSize);

            var sizeRegPrice =float.Parse(regPriceSize);
            var sizeIntRegPrice = int.Parse(regPriceIntSize);


            Assert.AreEqual(productName, nameInt);

            Assert.AreEqual(regPrice, regPriceInt);
            Assert.AreEqual(auPrice, auPriceInt);

            Assert.AreEqual(regPriceDecorLine, "line-through");
            Assert.AreEqual(regPriceIntTxtDecorLine, "line-through");
            Assert.AreEqual(regPriceColorRGB, "119, 119, 119" );
            Assert.AreEqual(regPriceIntRGB, "102, 102, 102");

            Assert.AreEqual(auPricefont, "strong");
            Assert.AreEqual(auPriceIntFont, "strong");
            Assert.AreEqual(auPriceColorRGB, "204, 0, 0, 1" );
            Assert.AreEqual(auPriceIntColorRGB, "204, 0, 0, 1" );

            Assert.IsTrue(sizeAuIntPrice > sizeIntRegPrice);
            Assert.IsTrue(sizeAuPrice > sizeRegPrice);
        }
    }
}



