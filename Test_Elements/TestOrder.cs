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
        [Description("TASK_ 8(a)Verification of Alphabetical Countries Order")]
        //а) проверяет, что страны расположены в алфавитном порядке
      
        public void _CountriesInAlphabeticalOrder()
        {
            
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

            CollectionAssert.AreEqual(allCountries, sortedAllCountries);
        }


        [TestCategory("Regression")]
        [Priority(9)]
        [TestMethod]
        [Description("TASK_8(b)_Verification of Alphabetical Countries Order that have more Zones than 0")]

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

            foreach (var row in rows)
            {
                var zone = row.FindElement(By.XPath(".//td[6]"));
                var zoneValue = zone.Text;
                var zoneName = row.FindElement(By.XPath(".//td[5]/a")).Text;

                System.Diagnostics.Debug.WriteLine(zoneName + " / " + zoneValue);

                if (int.Parse(zoneValue) > 0)
                {
                    var link = row.FindElement(By.XPath(".//td[5]/a"));
                    //link.Click();

                    links.Add(link.GetDomProperty("href"));

                }
            }

            foreach (var link in links)
            {
                Driver.Navigate().GoToUrl(link);

                {
                    ReadOnlyCollection<IWebElement> subcountryNameCell = Driver.FindElements(By.XPath
                    ("//tr [position()>1 and position()<last()] /td[3]"));

                    List<String> allCountriesEditCountryPage = new List<String>();

                    foreach (IWebElement element in subcountryNameCell)
                    {
                        allCountriesEditCountryPage.Add(element.Text);
                    }
                    List<String> sortedAllCountries = new List<String>(allCountriesEditCountryPage);
                    sortedAllCountries.Sort();

                    CollectionAssert.AreEqual(allCountriesEditCountryPage, sortedAllCountries);
                    System.Diagnostics.Debug.WriteLine(sortedAllCountries);
                }
            }
        }



        [TestCategory("Regression")]
        [Priority(9)]
        [TestMethod]
        [Description("Task_9_Проверить сортировку геозон на странице геозон")]

        public void _ZonesInAlphabeticalOrder()
        {
            
           
            Navigator.OpenLoginPage();
            loginHelper.LogIn();

            BaseLog.Then("The user navigates to the 'Geo Zones' page");

            Navigator.OpenGeoZones();

            ReadOnlyCollection<IWebElement> rows = Driver.FindElements(By.XPath
            ("//tr[@class='row']"));

            List<string> links = new List<string>();

            foreach (var row in rows)
            {
                var link = row.FindElement(By.XPath(".//td[3]/a"));

                links.Add(link.GetDomProperty("href"));
            }

                foreach (var link in links)
                {
                   
                    Driver.Navigate().GoToUrl(link);
                    {
                        ReadOnlyCollection<IWebElement> tables = Driver.FindElements(By.XPath
                        ("//table[@class = 'dataTable']"));

                        List< String> allZonesEditZonePage = new List<String>();

                        foreach (IWebElement table in tables)
                        {
                         var ubZoneCell = table.FindElement(By.XPath(".//tr[position()>1 and position()<last()]/td [3]/select/option[@selected='selected']")).Text;         

                         allZonesEditZonePage.Add(ubZoneCell);      

                        }

                        List<String> sortedAllZonesEditZonePage = new List<String>(allZonesEditZonePage);

                        sortedAllZonesEditZonePage.Sort();

                        CollectionAssert.AreEqual(allZonesEditZonePage, sortedAllZonesEditZonePage);
                            //System.Diagnostics.Debug.WriteLine(sortedAllZonesEditZonePage);
                    }

                }
                     
        }
    }
}    
      
    