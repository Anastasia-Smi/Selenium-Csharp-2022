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
    public class AddingNewProduct : ApplicationManager
    {
        [TestMethod]
        [Description("TASK_12_Verification of Adding a new product")]
        [TestCategory("Regression")]
        [Priority(9)]
        //Сделайте сценарий для добавления нового товара(продукта) в учебном приложении litecart(в админке).

        //Для добавления товара нужно открыть меню Catalog,
        //в правом верхнем углу нажать кнопку "Add New Product", заполнить поля с информацией о товаре и сохранить.

        //Достаточно заполнить только информацию на вкладках General,
        //Information и Prices.Скидки(Campains) на вкладке Prices можно не добавлять.

        //Переключение между вкладками происходит не мгновенно,
        //поэтому после переключения можно сделать небольшую паузу(о том, как делать
        //более правильные ожидания, будет рассказано в следующих занятиях).

        //Картинку с изображением товара нужно уложить в репозиторий
        //вместе с кодом.При этом указывать в коде полный абсолютный путь к
        //файлу плохо, на другой машине работать не будет.
        //Надо средствами языка
        //программирования преобразовать относительный путь в абсолютный.


        //После сохранения товара нужно убедиться, что он появился
        //в каталоге (в админке). 

        public void RegistrationTest()
        {

            var productName = "Test Duck";
            var productCode = "123";
            var Quantity = "7";
            var keyWords = "Duck";
            var shortDescription = "Duck to test";
            var description = "This duck was added to test adding product functionality";
            var headTitle = "DUCK";
            var metaDescription = "This is a duck";
            var SKU = "SKU";
            var GTIN = "GTIN";
            var TARIC = "TARIC";
            var attributes = "this is test attributes for duck";
            var weight = "9.9";
            var width = "0.2";
            var height = "0.2";
            var thickness = "0.2";
            var quantity = "40";
            var dateFrom = "02222022";
            var dateTo = "03032023";
            var imgAddress = "C:/Users/akurd/Downloads/duck-central-park-img.jpg";



            Navigator.OpenLoginPage();
            loginHelper.LogIn();
            Navigator.OpenCatalog();
            Navigator.AddNewProductPage();

            addProductHelper.SelectStatusRadiobutton();
            addProductHelper.NamePlaceholder(productName);
            addProductHelper.CodePlaceholder(productCode);

            //select category skip for now
            addProductHelper.ProductGroups();
            addProductHelper.Quantity(quantity);


            //select quantity unit skip for now

            //select sold out status
            addProductHelper.UploadImages(imgAddress);

            addProductHelper.DateValidFrom(dateFrom);
            addProductHelper.DateValidTo(dateTo);


            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            //IWebElement PageInfoTab = wait.Until(d => d.FindElement(By.XPath("//a[@class = '#tab-information']")));

            Navigator.AddNewProductPageInformationTab();

            addProductHelper.ManuFacturerDropDown();

            //select supplier-- skip for now
            addProductHelper.KeywordsPlaceholder(keyWords);
            addProductHelper.ShortDescriptionPlaceholder(shortDescription);
            addProductHelper.DescriptionField(description);
            addProductHelper.HeadTitlePlace(headTitle);


            //IWebElement DataTab = wait.Until(d => d.FindElement(By.XPath("//a[@class = '#tab-information']")));

            Navigator.AddNewProductPageDataTab();

            addProductHelper.SKUPlaceholder(SKU);
            addProductHelper.TARICPlaceholder(TARIC);
            addProductHelper.GTINPlaceholder(GTIN);
            addProductHelper.WeightSelector(weight);


            addProductHelper.Dimensions(width, height, thickness);
            addProductHelper.AttributesPlaceholder(attributes);

            Navigator.AddNewProductPageSave();

            Navigator.OpenCatalogCatalog();

            //Assert.IsTrue(Driver.FindElement(By.LinkText(productName)).Displayed);

        }
    }
}
