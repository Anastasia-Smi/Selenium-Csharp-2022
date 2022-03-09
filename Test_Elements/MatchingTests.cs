using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Selenium_Csharp_2022
{
    [TestClass]
    public class MatchingTests : ApplicationManager
    //а) на главной странице и на странице товара совпадает текст названия товара
    //б) на главной странице и на странице товара совпадают цены(обычная и акционная)
    //в) обычная цена зачёркнутая и серая(можно считать, что "серый" цвет это такой, у которого в RGBa представлении одинаковые значения для каналов R, G и B)
    //г) акционная жирная и красная(можно считать, что "красный" цвет это такой, у которого в RGBa представлении каналы G и B имеют нулевые значения)
    //(цвета надо проверить на каждой странице независимо, при этом цвета на разных страницах могут не совпадать)
    //д) акционная цена крупнее, чем обычная(это тоже надо проверить на каждой странице независимо)
    {
        [TestCategory("Regression")]
        [Priority(9)]
        [TestMethod]
        [Description("TASK_10_Verification of Matching Products Names")]

        public void _MatchingProductNames()
        {
            Console.WriteLine("The user login to the App");

            Navigator.OpenLoginPage();
            loginHelper.LogIn();
            Navigator.OpenRubberDucksPage();

            Console.WriteLine("The user navigates to the Ducks page");


            ReadOnlyCollection<IWebElement> products = Driver.FindElements(By.XPath
           ("//*[@class='product column shadow hover-light']"));

            List<string> links = new List<string>();
            List<string> titles = new List<string>();
            List<string> prices = new List<string>();// in black
            List<string> regularPrices = new List<string>();//in grey
            List<string> auctionPrices = new List<string>();// in red

            List<TitlePageValue> titlePageValues = new List<TitlePageValue>();

            foreach (var product in products)
            {


                var link = product.FindElement(By.XPath(".//*[@class = 'link']")).GetAttribute("href");
                var name = product.FindElement(By.XPath(".//*[@class = 'name']")).Text;

                links.Add(link);
                titles.Add(name);

                //check if regular price exists on the element
                var isRegPrice = product.FindElements(By.XPath(".//*[@class = 'price']"));

                if (isRegPrice.Count > 0)
                {
                    var price = product.FindElement(By.XPath(".//*[@class = 'price']"))?.Text;
                    prices.Add(price);
                    regularPrices.Add(null);
                    auctionPrices.Add(null);
                }
                else
                {
                    var regPrice = product.FindElement(By.XPath(".//*[@class = 'regular-price']"))?.Text;
                    var auPrice = product.FindElement(By.XPath(".//*[@class = 'campaign-price']"))?.Text;
                    prices.Add(null);
                    regularPrices.Add(regPrice);
                    auctionPrices.Add(auPrice);
                }

                //product.wai(By.XPath(".//*[@class = 'regular-price']"))?.Text;

                //titlePageValues.Add(new TitlePageValue()
                //{
                //   Name = name,
                //   Href = link,
                //   Price = price,
                //   RegPrice = regPrice,
                //   AuctionPrice = auPrice
                //});

                //var discountPriceMainPage = product.FindElements(By.XPath
                //(".//*[@class = 'campaign-price']"));
                //var discountPriceMainPgeValue = discountPriceMainPage.ToString();              

            }



            for (int i = 0; i < links.Count; i++)
            {
                Driver.Navigate().GoToUrl(links[i]);

                List<string> IntName = new List<string>();
                List<string> IntRegPrice = new List<string>();// in black
                List<string> IntregularPrices = new List<string>();//in grey
                List<string> IntauctionPrices = new List<string>();// in red

                var nameInternal = Driver.FindElement(By.CssSelector("h1.title")).Text;

                IntName.Add(nameInternal);
                Assert.AreEqual(IntName[0], titles[i]);



                var isIntRegPrice = Driver.FindElements(By.CssSelector("div .information span.price"));

                if (isIntRegPrice.Count > 0)
                {
                    var Intprice = Driver.FindElement(By.CssSelector("div .information span.price")).Text;
                    IntRegPrice.Add(Intprice);
                    IntregularPrices.Add(null);
                    IntauctionPrices.Add(null);


                    Assert.AreEqual(IntRegPrice[0], prices[i]);
                }
                else
                {
                    var regIntPrice = Driver.FindElement(By.XPath(".//*[@class = 'regular-price']")).Text;
                    var auIntPrice = Driver.FindElement(By.XPath(".//*[@class = 'campaign-price']")).Text;
                    IntregularPrices.Add(regIntPrice);
                    IntauctionPrices.Add(auIntPrice);


                    Assert.AreEqual(IntregularPrices[0], regularPrices[i]);
                    Assert.AreEqual(IntauctionPrices[0], auctionPrices[i]);
                }
            }
        }


        [TestCategory("Regression")]
        [Priority(9)]
        [TestMethod]
        [Description("TASK_10_в,г,д_Verification of Pricing labels")]

        //в) обычная цена зачёркнутая и серая (можно считать, что "серый" цвет это такой,
        //у которого в RGBa представлении одинаковые значения для каналов R, G и B)
        //г) акционная жирная и красная(можно считать, что "красный" цвет это такой,
        //у которого в RGBa представлении каналы G и B имеют нулевые значения)
        //д) акционная цена крупнее, чем обычная(это тоже надо проверить на каждой странице независимо)


        public void _DisplayingPricesLabels()
        {
            // var productCompaign = Driver.FindElement(By.XPath
            //("//*[@id ='box - campaigns']//*[@class='product column shadow hover-light']"));


            Navigator.OpenLoginPage();
            loginHelper.LogIn();
            Navigator.OpenRubberDucksPage();

        
            var auPrice = Driver.FindElement(By.XPath("//*[@id ='box-campaigns']//*[@class='campaign-price']"));
            var regPrice = Driver.FindElement(By.XPath("//*[@id ='box-campaigns']//*[@class='regular-price']"));


            string auPriceColor = auPrice.GetCssValue("color");
            string auPriceFont = auPrice.GetCssValue("font-weight");
            var auPriceSize = auPrice.GetCssValue("font-size");

            string regPriceColor = regPrice.GetCssValue("color");
            string regPriceDecor = regPrice.GetCssValue("text- decoration");
            string regPriceFont = auPrice.GetCssValue("font-weight");
            var  regPriceSize = auPrice.GetCssValue("font-size");

            Assert.IsTrue(regPriceColor.Equals("rgba(119, 119, 119, 1)"), "color is grey");
            Assert.IsTrue(regPriceDecor.Equals(""));
            Assert.IsTrue(auPriceColor.Equals("rgba(204, 0, 0, 1)"), "color is red");
            Assert.IsTrue(auPriceFont.Equals("700"));
            //Assert.AreEqual(auPriceSize, regPriceSize);
        }


        class TitlePageValue
        {
            public string Name { get; set; }
            public string Href { get; set; }
            public string Price { get; set; }
            public string RegPrice { get; set; }
            public string AuctionPrice { get; set; }
        }
    }
}


