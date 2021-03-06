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
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;


namespace Selenium_Csharp_2022
{


    [TestClass]
    public class AddingNewProductToCard : ApplicationManager
    {
        [TestMethod]
        [Description("TASK_13_Verification of Adding a New products to Card")]
        [TestCategory("Regression")]
        [Priority(9)]
        //1) открыть главную страницу
        //2) открыть первый товар из списка
        //2) добавить его в корзину(при этом может случайно добавиться товар, который там уже есть, ничего страшного)
        //3) подождать, пока счётчик товаров в корзине обновится
        //4) вернуться на главную страницу, повторить предыдущие шаги ещё два раза, чтобы в общей сложности в корзине было 3 единицы товара
        //5) открыть корзину(в правом верхнем углу кликнуть по ссылке Checkout)
        //6) удалить все товары из корзины один за другим, после каждого удаления подождать, пока внизу обновится таблица
        public void AddingNewProductToCardTest()
        {

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));

            Navigator.OpenLoginPage();
            loginHelper.LogIn();

            Navigator.OpenRubberDucksPage();

            addToCardHelper.SelectTheFirstProduct();
            addToCardHelper.AddToCardButtonClick();

            var productQuantity = Driver.FindElement(By.CssSelector("span.quantity"));
            wait.Until(ExpectedConditions.TextToBePresentInElement(productQuantity, "1"));
            
            Navigator.ClickHomeButton();
            addToCardHelper.SelectTheFirstProduct();
            addToCardHelper.AddToCardButtonClick();

           var productQuantity2 = Driver.FindElement(By.CssSelector("span.quantity"));
           productQuantity2.GetAttribute("textContant");
           wait.Until(ExpectedConditions.TextToBePresentInElement(productQuantity2, "2"));

            Navigator.ClickHomeButton();
            addToCardHelper.SelectTheFirstProduct();
            addToCardHelper.AddToCardButtonClick();

            var productQuantity3 = Driver.FindElement(By.CssSelector("span.quantity"));
            wait.Until(ExpectedConditions.TextToBePresentInElement(productQuantity3, "3"));

            addToCardHelper.CheckoutClick();


            ReadOnlyCollection<IWebElement> products = Driver.FindElements(By.XPath
            ("//li [@class = 'item']"));

            ReadOnlyCollection<IWebElement> buttons = Driver.FindElements(By.XPath
            ("//button [@value = 'Remove']"));

            ReadOnlyCollection<IWebElement> productsInTab = Driver.FindElements(By.XPath
           ("//td [@class = 'item']"));

            List<string> Deletebuttons = new List<string>();

            foreach (var product in products)
            {
                var productName = Driver.FindElement(By.XPath("//td [@class = 'item']"));
     
                wait.Until(ExpectedConditions.ElementToBeClickable((By.XPath("(//p/button [@name = 'remove_cart_item']")))).Click();
           
                wait.Until(ExpectedConditions.StalenessOf(productName));

               
            };



            //var productName = Driver.FindElement(By.XPath("(//button [@value = 'Remove']"));
            //var productName2 = Driver.FindElement(By.XPath("(//td[@class ='item'])[2]"));
            //var productName3 = Driver.FindElement(By.XPath("(//td[@class ='item'])[3]"));



            //addToCardHelper.RemoveButtonClick();
            //wait.Until(ExpectedConditions.StalenessOf(productName));


            //addToCardHelper.RemoveButtonClick();
           // wait.Until(ExpectedConditions.StalenessOf(productName2));

        
            //addToCardHelper.RemoveButtonClick();
           // wait.Until(ExpectedConditions.StalenessOf(productName3));
        }
    }
}
