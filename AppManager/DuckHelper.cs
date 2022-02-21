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
    public class DuckHelper : HelperBase

    {
        //public IWebDriver Driver;
        private string baseURL;


        public DuckHelper(ApplicationManager manager)
            : base(manager)
        {
            //this.Driver = driver;
            this.baseURL = baseURL;
        }


        public int GetDucksCount()
        {
            return Driver.FindElements(By.CssSelector("ul a.link")).Count;
        }

        public int GetStickersCount()
        {
            return Driver.FindElements(By.XPath("//*[contains( @class, 'sticker')]")).Count;
        }
    }
}