using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Csharp_2022
{
    public class AddToCardHelper : HelperBase
    {
        public AddToCardHelper(ApplicationManager manager, string baseURL)
         : base(manager) { }
        public AddToCardHelper(ApplicationManager manager) : base(manager)
        {
        }


        public AddToCardHelper SelectTheFirstProduct()
        {
            var firstProduct = Driver.FindElement(By.XPath("(//li[@class='product column shadow hover-light'])[1]"));
            firstProduct.Click();

            return this;
        }
        public AddToCardHelper AddToCardButtonClick()
        {
            var addToCardButton = Driver.FindElement(By.Name("add_cart_product"));
            addToCardButton.Click();

            return this;
        }

        public AddToCardHelper CheckoutClick()
        {
            Driver.Navigate().GoToUrl("http://localhost/litecart/en/checkout");

            return this;
        }

        public AddToCardHelper RemoveButtonClick()
        {
            var removeButtonClick = Driver.FindElement(By.Name("remove_cart_item"));
            removeButtonClick.Click();

            return this;
        }
    }
}
