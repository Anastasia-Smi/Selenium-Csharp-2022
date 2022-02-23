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



            IList<IWebElement> elements = Driver.FindElements(By.CssSelector("span.name"));


                foreach (IWebElement element in elements)
                {

                       element.Click();
                    {
                        for (int i = 0; i < elements.Count; i++)
                    {
                        element.FindElements(By.CssSelector("span.name"));
                        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);
                    }
                }
                }
            
        }




        //    List<Headers> GetHeadersList()
        //    {

            //        {
            //            var myMenu = Driver.FindElement(By.Id("box-apps-menu-wrapper"));
            //            List<IWebElement> rows = myMenu.FindElements(By.TagName("li")).ToList();

            //            rows.ForEach(row =>
            //            {
            //                row.Click();
            //                Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);
            //            });

            //        }
            //        return new List<Headers>();
            //    }
            //}








            //foreach (IWebElement headerispresented in header)
            //{
            //    Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);
            //}


            //        Navigator.OpenAppearance();
            //        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

            //        Navigator.OpenCatalog();
            //        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

            //        Navigator.OpenCountries();
            //        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

            //        Navigator.OpenCustomers();
            //        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

            //        Navigator.OpenGeoZones();
            //        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

            //        Navigator.OpenLanguages();
            //        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

            //        Navigator.OpenModules();
            //        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

            //        Navigator.OpenOrders();
            //        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

            //        Navigator.OpenPages();
            //        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

            //        Navigator.OpenReports();
            //        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

            //        Navigator.OpenSettings();
            //        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

            //        Navigator.OpenSlides();
            //        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

            //        Navigator.OpenTax();
            //        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);


            //        Navigator.OpenTranslations();
            //        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

            //        Navigator.OpenUsers();
            //        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

            //        Navigator.OpenvQmods();
            //        Assert.IsTrue(Driver.FindElement(By.CssSelector("#content >h1")).Displayed);

            //    }
            //}

        internal class Headers
        {
        }
    }
}



