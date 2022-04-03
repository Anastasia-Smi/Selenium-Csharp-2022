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
            var  regPriceColorRGB = regPriceColor.Substring(5, 13);

            string[] regPriceColorRGB1s = regPriceColorRGB.Split(',',' ');
            var regPriceColorR = regPriceColorRGB1s[0];
            var regPriceColorG = regPriceColorRGB1s[2];
            var regPriceColorB= regPriceColorRGB1s[4];

            Assert.IsTrue(regPriceColorR == regPriceColorG);
            Assert.IsTrue(regPriceColorG == regPriceColorB);



            var auPrice = product.FindElement(By.XPath(".//*[@class = 'campaign-price']"))?.Text;

            string auPricefont = product.FindElement(By.XPath(".//*[@class = 'campaign-price']")).TagName;



            var auPriceColor = Driver.FindElement(By.CssSelector
                ("#box-campaigns .campaign-price")).GetCssValue("color");
            var auPriceColorRGB = auPriceColor.Substring(5, 12);
            
            string[] auPriceColorRGB2 = auPriceColorRGB.Split(',', ' ');
            var auPriceColorRGB_G = auPriceColorRGB2[2];
            var auPriceColorRGB_B = auPriceColorRGB2[4];
            
            var auPriceColorRGB_Gg = int.Parse(auPriceColorRGB_G);
            var auPriceColorRGB_Bb = int.Parse(auPriceColorRGB_B);


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

            string[] regPriceColorRGB2s = regPriceIntRGB.Split(',', ' ');
            var regPriceIntColorR = regPriceColorRGB1s[0];
            var regPriceIntColorG = regPriceColorRGB1s[2];
            var regPriceIntColorB = regPriceColorRGB1s[4];


            var regPriceIntTxtDecor = Driver.FindElement(By.XPath(".//*[@class = 'regular-price']")).GetCssValue("text-decoration");

            var regPriceIntTxtDecorLine = regPriceIntTxtDecor.Substring(0, 12);

           


            var auPriceIntColor = Driver.FindElement(By.XPath(".//*[@class = 'campaign-price']")).GetCssValue("color");
            var auPriceIntColorRGB = auPriceIntColor.Substring(5, 12);
            string[] auPriceIntColorRGB2 = auPriceIntColorRGB.Split(',', ' ');
            var auPriceIntColorRGB_G = auPriceIntColorRGB2[2];
            var auPriceIntColorRGB_B = auPriceIntColorRGB2[4];
            var auPriceIntColorRGB_Gg = int.Parse(auPriceIntColorRGB_G);
            var auPriceIntColorRGB_Bb = int.Parse(auPriceIntColorRGB_B);


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
            
            Assert.IsTrue(regPriceColorR == regPriceColorG);
            Assert.IsTrue(regPriceColorG == regPriceColorB);
            Assert.IsTrue(regPriceIntColorR == regPriceIntColorG);
            Assert.IsTrue(regPriceIntColorG == regPriceIntColorB);


            Assert.AreEqual(auPricefont, "strong");
            Assert.AreEqual(auPriceIntFont, "strong");
            Assert.IsTrue(auPriceIntColorRGB_Gg == 0);
            Assert.IsTrue(auPriceIntColorRGB_Bb == 0);
            Assert.IsTrue(auPriceColorRGB_Gg == 0);
            Assert.IsTrue(auPriceColorRGB_Bb==0);

            Assert.IsTrue(sizeAuIntPrice > sizeIntRegPrice);
            Assert.IsTrue(sizeAuPrice > sizeRegPrice);
        }
    }
}



