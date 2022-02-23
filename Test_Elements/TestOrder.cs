using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Selenium_Csharp_2022
{
    [TestClass]
    public class AlphabeticalOrder : ApplicationManager
    {
        [TestCategory("Regression")]
        [Priority(9)]
        [TestMethod]
        [Description("Verification of Countries Order")]
        
      
        public void _CountriesInAlphabeticalOrder()
        {
            //а) проверяет, что страны расположены в алфавитном порядке
            BaseLog.Given("The User is LogOut");
            BaseLog.When("The User LogIn with valid credentials");
            Navigator.OpenLoginPage();
            loginHelper.LogIn();

            BaseLog.Then("The user navigates to the countries page");

            Navigator.OpenCountries();

            ReadOnlyCollection<IWebElement> firstCells = Driver.FindElements(By.XPath
            ("//tr/td[5]"));

            List<String> allCountries = new List<String>();

            foreach (IWebElement element in firstCells)
            {
                allCountries.Add(element.Text);
            }
            List<String> sortedAllCountries = new List<String>(allCountries);
            sortedAllCountries.Sort();

            Assert.AreEqual(allCountries.ToString(), sortedAllCountries.ToString());
        }


            [TestCategory("Regression")]
            [Priority(9)]
            [TestMethod]
            [Description("Verification of Countries Order that have more zones than 0")]

            public void _ZonesOrder()
            {
            BaseLog.Given("The User is LogOut");
            BaseLog.When("The User LogIn with valid credentials");
            Navigator.OpenLoginPage();
            loginHelper.LogIn();

            BaseLog.Then("The user navigates to the countries page");

            Navigator.OpenCountries();

            ReadOnlyCollection<IWebElement> rows = Driver.FindElements(By.XPath
            ("//tr[@class='row']"));

            List<string> links = new List<string>(); 

            foreach(var row in rows)
            {
                var zone = row.FindElement(By.XPath(".//td[6]"));
                var zoneValue = zone.Text;
                var zoneName = row.FindElement(By.XPath(".//td[5]/a")).Text;

                System.Diagnostics.Debug.WriteLine(zoneName + " / " + zoneValue);

                if (int.Parse(zoneValue) > 0) {
                    var link = row.FindElement(By.XPath(".//td[5]/a"));
                    //link.Click();

                    links.Add(link.GetDomProperty("href"));

                }
            }

            foreach(var link in links)
            {
                Driver.Navigate().GoToUrl(link);

                {
                    ReadOnlyCollection<IWebElement> subcountryNameCell = Driver.FindElements(By.XPath
                    ("//tr/td[3]"));

                    List<String> allCountriesEditCountryPage = new List<String>();

                    foreach (IWebElement element in subcountryNameCell)
                    {
                        allCountriesEditCountryPage.Add(element.Text);
                    }
                    List<String> sortedAllCountries = new List<String>(allCountriesEditCountryPage);
                    sortedAllCountries.Sort();

                    Assert.AreEqual(allCountriesEditCountryPage.ToString(), sortedAllCountries.ToString());
                    System.Diagnostics.Debug.WriteLine(sortedAllCountries);
                }
            }
            }
        }
    }
