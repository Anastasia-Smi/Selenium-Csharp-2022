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
using SeleniumExtras.WaitHelpers;


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
           wait.Until(ExpectedConditions.TextToBePresentInElement(productQuantity, "2"));

            Navigator.ClickHomeButton();
            addToCardHelper.SelectTheFirstProduct();
            addToCardHelper.AddToCardButtonClick();

            var productQuantity3 = Driver.FindElement(By.CssSelector("span.quantity"));
           

            addToCardHelper.CheckoutClick();

            var productName = Driver.FindElement(By.XPath("(//td[@class ='item'])[1]"));
            var productName2 = Driver.FindElement(By.XPath("(//td[@class ='item'])[2]"));
            var productName3 = Driver.FindElement(By.XPath("(//td[@class ='item'])[3]"));
            
            addToCardHelper.RemoveButtonClick();
            wait.Until(ExpectedConditions.StalenessOf(productName));


            addToCardHelper.RemoveButtonClick();
            wait.Until(ExpectedConditions.StalenessOf(productName2));

        
            addToCardHelper.RemoveButtonClick();
            wait.Until(ExpectedConditions.StalenessOf(productName3));
        }
    }
}
