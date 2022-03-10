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
    public class TestUserRegistration : ApplicationManager
    {
        [TestMethod]
        [Description("TASK_11_Verification of a User Registration")]
        [TestCategory("Regression")]
        [Priority(9)]


        public void RegistrationTest()

        {
            Navigator.OpenFirstPage();
            Navigator.NewCustomerPage();

            var Password = $"P{DateTime.Now:MMddhhmmss}";
            var TaxID = "12345";
            var Company = "TestCompany";
            var FirstName = $"FN{DateTime.Now:MMddhhmmss}"; 
            var LastName = $"LN{DateTime.Now:MMddhhmmss}";
            var Address1 = "TestAddress1";
            var Address2 = "TestAddress2";
            var Postcode = "12395";
            var City = $"City{DateTime.Now:MMddhhmmss}";
            var Email = $"AAA_{DateTime.Now:MMddyyyyhhmmsstt}" + "@gmail.com";
            var Phone = $"1{DateTime.Now:MMddhhmmss}";


            var TaxIDfIELD = Driver.FindElement(By.Name("tax_id"));
            TaxIDfIELD.Clear();
            TaxIDfIELD.SendKeys(TaxID);


            var CompanyField = Driver.FindElement(By.Name("company"));
            CompanyField.Clear();
            CompanyField.SendKeys(Company);

            var FirstNameField = Driver.FindElement(By.Name("firstname"));
            FirstNameField.Clear();
            FirstNameField.SendKeys(FirstName);

            var LastNameField = Driver.FindElement(By.Name("lastname"));
            LastNameField.Clear();
            LastNameField.SendKeys(LastName);

            var Address1Field = Driver.FindElement(By.Name("address1"));
            Address1Field.Clear();
            Address1Field.SendKeys(Address1);

            var Address2Field = Driver.FindElement(By.Name("address2"));
            Address2Field.Clear();
            Address2Field.SendKeys(Address2);


            var PostcodeField = Driver.FindElement(By.Name("postcode"));
            PostcodeField.Clear();
            PostcodeField.SendKeys(Postcode);


            var CityField = Driver.FindElement(By.Name("city"));
            CityField.Clear();
            CityField.SendKeys(City);

            var EmailField = Driver.FindElement(By.Name("email"));
            EmailField.Clear();
            EmailField.SendKeys(Email);

            var PhoneField = Driver.FindElement(By.Name("phone"));
            PhoneField.Clear();
            PhoneField.SendKeys(Phone);

            var DesiredPasswordField = Driver.FindElement(By.Name("password"));
            DesiredPasswordField.Clear();
            DesiredPasswordField.SendKeys(Password);

            var ConfirmPasswordField = Driver.FindElement(By.Name("confirmed_password"));
            ConfirmPasswordField.Clear();
            ConfirmPasswordField.SendKeys(Password);

            accountCreator.CountryDropDown();

            accountCreator.CreateAccountButton();


            ///select country from dropdown
            //verify successfull message 
            //Assert.IsTrue(Driver.FindElement(By.CssSelector(".notice success")).Displayed);

            accountCreator.ClickLogOutButton();

            //succes message
            var EmailAddressFiels = Driver.FindElement(By.Name("email"));
            EmailAddressFiels.Clear();
            EmailAddressFiels.SendKeys(Email);

            var PasswordField = Driver.FindElement(By.Name("password"));
            PasswordField.Clear();
            PasswordField.SendKeys(Password);
            //Assert.IsTrue(Driver.FindElement(By.CssSelector(".notice success")).Displayed);

            loginHelper.ClickLogInButton();
           
        }

    }
}
