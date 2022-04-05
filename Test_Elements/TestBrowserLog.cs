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
using System.Diagnostics;
using System.Linq;

namespace Selenium_Csharp_2022
{



    [TestClass]
    public class BrowserLogs : ApplicationManager
    {
        [TestMethod]
        [Description("TASK_17_Verification of abcense of messages in browser log ")]
        [TestCategory("Regression")]
        [Priority(9)]


        public void TestBrowserLog()
        {


            Navigator.OpenLoginPage();
            loginHelper.LogIn();

            Navigator.OpenCatalog();
            Navigator.OpenCatalogRubberDucs();



            ReadOnlyCollection<IWebElement> rubberDucks = Driver.FindElements(By.PartialLinkText("Duck"));

            List<string> links = new List<string>();

            foreach (var link in rubberDucks)
            {
                links.Add(link.GetDomProperty("href"));
            }
          
            foreach (var link in links)
            {
                Driver.Navigate().GoToUrl(link);
                Debug.WriteLine(Driver.Manage().Logs.GetLog("browser"));

                //var logs = Driver.Manage().Logs.AvailableLogTypes;
                var log = Driver.Manage().Logs.GetLog("browser").ToList();

                //var listLogs = log.ToList();
                //log.ForEach(lg => Debug.WriteLine(lg));
                
                foreach (LogEntry lg in log)
                {
                    Console.WriteLine(lg);

                }
            }
        }    
    }    
}    

