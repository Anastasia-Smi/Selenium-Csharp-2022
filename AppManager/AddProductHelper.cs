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
    public class AddProductHelper : HelperBase
    {
        public AddProductHelper(ApplicationManager manager, string baseURL)
          : base(manager)
        {
            //this.Driver = driver;
            //this.baseURL = baseURL;
        }

        public AddProductHelper(ApplicationManager manager) : base(manager)
        {
        }

        public AddProductHelper SelectStatusRadiobutton()

        {
            var radiobuttonEnabled = Driver.FindElement(By.XPath("//td/label/input[@value ='1'] "));
            radiobuttonEnabled.Click();
            

            return this;
        }


        public AddProductHelper NamePlaceholder(string productName)

        {
            var nameplaceholder = Driver.FindElement(By.Name("name[en]"));
            nameplaceholder.Click();
            nameplaceholder.SendKeys(productName);

            return this;
        }


        public AddProductHelper CodePlaceholder(string productCode)

        {
            var productcode = Driver.FindElement(By.Name("code"));
            productcode.Click();
            productcode.SendKeys(productCode);
            return this;
        }
        public AddProductHelper ProductGroups()

        {
            var unisex = Driver.FindElement(By.XPath("//td/input[@value ='1-3'] "));
            unisex.Click();
            return this;
        }

        public AddProductHelper Quantity(string quantityValue)

        {
            var quantity = Driver.FindElement(By.Name("quantity"));
            quantity.Click();
            quantity.SendKeys(quantityValue);
            return this;
        }
        public AddProductHelper DeliveryStatusDropDown()

        {
            Driver.FindElement(By.Name("delivery_status_id")).Click();
            return this;
        }
        public AddProductHelper SoldOutStatusDropDown()

        {
            Driver.FindElement(By.Name("delivery_status_id")).Click();
            return this;
        }

        public AddProductHelper UploadImages(string localAddress)

        {
            var chooseFile = Driver.FindElement(By.Name("new_images[]"));
            //chooseFile.Click();
            chooseFile.SendKeys(localAddress);
            return this;
        }

        public AddProductHelper DateValidFrom(string dateFromValue)

        {
            var calendar = Driver.FindElement(By.Name("date_valid_from"));
            calendar.Click();
            calendar.SendKeys(dateFromValue);

            return this;
        }

        public AddProductHelper DateValidTo(string dateToValue)

        {
            var calendarTo = Driver.FindElement(By.Name("date_valid_to"));
            calendarTo.Click();
            calendarTo.SendKeys(dateToValue);
            return this;
        }
        /// <summary>
        /// /////
        /// </summary>
        /// <returns></returns>
        public AddProductHelper ManuFacturerDropDown()

        {
            var manufacturerDropdown = Driver.FindElement(By.Name("manufacturer_id"));
            //manufacturerDropdown.Click();
            SelectElement select = new SelectElement(manufacturerDropdown);
            select.SelectByText("ACME Corp.");

            return this;
        }
        public AddProductHelper SupplierDropDown()

        {
            Driver.FindElement(By.Name("date_valid_to")).Click();
            return this;
        }

        public AddProductHelper KeywordsPlaceholder(string keywords)

        {
            var keywordsplaceholder = Driver.FindElement(By.Name("keywords"));
            keywordsplaceholder.Click();
            keywordsplaceholder.SendKeys(keywords);
            return this;
        }
        public AddProductHelper ShortDescriptionPlaceholder(string shortdescription)

        {
            var shortDescrplaceholder = Driver.FindElement(By.Name("short_description[en]"));
            shortDescrplaceholder.Click();
            shortDescrplaceholder.SendKeys(shortdescription);
            return this;
        }
        public AddProductHelper DescriptionField(string description)

        {
            var descrfield = Driver.FindElement(By.ClassName("trumbowyg-editor"));
            descrfield.Click();
            descrfield.SendKeys(description);
            return this;
        }
        public AddProductHelper HeadTitlePlace(string headtitle)
        {
            var headtitleplace = Driver.FindElement(By.Name("sku"));
            headtitleplace.Click();
            headtitleplace.SendKeys(headtitle);
            return this;
        }
        public AddProductHelper SKUPlaceholder(string skuValue)

        {
            var sku = Driver.FindElement(By.Name("date_valid_to"));
            sku.Click();
            sku.SendKeys(skuValue);
            return this;
        }
        public AddProductHelper GTINPlaceholder(string gtinValue)

        {
            var gtin = Driver.FindElement(By.Name("gtin"));
            gtin.Click();
            gtin.SendKeys(gtinValue);
            return this;
        }
        public AddProductHelper TARICPlaceholder(string taricValue)

        {
            var taric = Driver.FindElement(By.Name("taric"));
            taric.Click();
            taric.SendKeys(taricValue);
            return this;
        }

        public AddProductHelper WeightSelector(string weightValue)

        {
            var weightSelector = Driver.FindElement(By.Name("date_valid_to"));
            weightSelector.Click();
            weightSelector.SendKeys(weightValue);
            return this;
        }
        public AddProductHelper Dimensions(string  a, string b, string c )
            
        {
            var width = Driver.FindElement(By.Name("dim_x"));
            var height = Driver.FindElement(By.Name("dim_y"));
            var thickness = Driver.FindElement(By.Name("dim_z"));
            width.Click();
            width.SendKeys(a);
            height.Click();
            height.SendKeys(b);
            thickness.Click();
            thickness.SendKeys(c);

            return this;
        }
        public AddProductHelper AttributesPlaceholder(string attributeValue)
        {
            var attributes = Driver.FindElement(By.Name("attributes[en]"));
            attributes.Click();
            attributes.SendKeys(attributeValue);
            return this;
        }
    }
}
