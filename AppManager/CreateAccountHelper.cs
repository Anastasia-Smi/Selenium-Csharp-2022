using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Csharp_2022

{
    public class CreateAccountHelper : HelperBase

    {
        //public IWebDriver Driver;
        private string baseURL;


        public CreateAccountHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            //this.Driver = driver;
            this.baseURL = baseURL;
        }

        public CreateAccountHelper TaxIDField()
        {
            Driver.FindElement(By.Name("tax_id")).Click();
            return this;
        }

        public CreateAccountHelper CompanyField()
        {
            Driver.FindElement(By.Name("company")).Click();
            return this;
        }
        public CreateAccountHelper FirstNameField()
        {
            Driver.FindElement(By.Name("firstname")).Click();
            return this;
        }
        public CreateAccountHelper LastNameField()
        {
            Driver.FindElement(By.Name("lastname")).Click();
            return this;
        }
        public CreateAccountHelper Address1Field()
        {
            Driver.FindElement(By.Name("address1")).Click();
            return this;
        }
        public CreateAccountHelper Address2Field()
        {
            Driver.FindElement(By.Name("address2")).Click();
            return this;
        }
        public CreateAccountHelper PostcodeField()
        {
            Driver.FindElement(By.Name("postcode")).Click();
            return this;
        }

        public CreateAccountHelper CityField()
        {
            Driver.FindElement(By.Name("city")).Click();
            return this;
        }
        public CreateAccountHelper CountryDropDown()
        {
            IWebElement dropdown = Driver.FindElement(By.CssSelector(".select2-selection__arrow"));
            dropdown.Click();
            IWebElement countryPlaceholder = Driver.FindElement(By.CssSelector(".select2-search__field"));
            countryPlaceholder.SendKeys("United States" + Keys.Enter);

            return this;
        }
        public CreateAccountHelper EmailField()
        {
            Driver.FindElement(By.Name("email")).Click();
            return this;
        }

        public CreateAccountHelper PhoneField()
        {
            Driver.FindElement(By.Name("phone")).Click();
            return this;
        }

        public CreateAccountHelper DesiredPasswordField()
        {
            Driver.FindElement(By.Name("password")).Click();
            return this;
        }

        public CreateAccountHelper ConfirmPasswordField()
        {
            Driver.FindElement(By.Name("confirmed_password")).Click();
            return this;
        }

        public CreateAccountHelper CreateAccountButton()
        {
            Driver.FindElement(By.Name("create_account")).Click();
            return this;
        }

        public CreateAccountHelper ClickLogOutButton()
        {
            Driver.FindElement(By.XPath("//div/ul/li/a[contains(@href, 'logout')]")).Click();
            return this;

        }
    }

}