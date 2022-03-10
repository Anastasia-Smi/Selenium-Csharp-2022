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
    public class NewWindows : ApplicationManager
    {
        [TestMethod]
        [Description("TASK_14_Verification Opening New Windows")]
        [TestCategory("Regression")]
        [Priority(9)]
       
        //Сценарий должен состоять из следующих частей:
        //1) зайти в админку
        //2) открыть пункт меню Countries(или страницу http://localhost/litecart/admin/?app=countries&doc=countries)
        //3) открыть на редактирование какую-нибудь страну или начать создание новой
        //4) возле некоторых полей есть ссылки с иконкой в виде квадратика со стрелкой -- они ведут
        //на внешние страницы и открываются в новом окне, именно это и нужно проверить.
        //Конечно, можно просто убедиться в том, что у ссылки есть атрибут target = "_blank".
        //Но в этом упражнении требуется именно кликнуть по ссылке, чтобы она открылась в новом окне,
        //потом переключиться в новое окно, закрыть его, вернуться обратно, и повторить эти действия для всех таких ссылок.
        //Не забудьте, что новое окно открывается не мгновенно, поэтому требуется ожидание открытия окна.

        public void HeaderAppearanceIsPresented()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));

            Navigator.OpenLoginPage();
            loginHelper.LogIn();

            Navigator.OpenCountries();
            Navigator.ClicAddNewCountryButton();



            ReadOnlyCollection<IWebElement> externalLinks = Driver.FindElements(By.XPath
            ("//td/a[@target= '_blank']"));

            List<string> links = new List<string>();

            foreach (var link in externalLinks)
            {
                //var externalLink = link.FindElement(By.XPath(".//td/a[@target= '_blank']")); 

                links.Add(link.GetDomProperty("href"));
            }

            
            string mainWindow = Driver.CurrentWindowHandle;
            ICollection<string> oldWindows = Driver.WindowHandles;
            Assert.AreEqual(Driver.WindowHandles.Count, 1);


            foreach (var link in links)
            {
                Driver.Navigate().GoToUrl(link);
                {
                    wait.Until(wd => wd.WindowHandles.Count == 2);
                    foreach (string window in Driver.WindowHandles)
                    {
                        if (mainWindow != window)
                        {
                            Driver.SwitchTo().Window(window);
                            break;
                        }
                    }
                    ////Wait for the new tab to finish loading content
                    //wait.Until(wd => wd.Title == "Selenium documentation");
                    //Driver.SwitchTo().Window(newWindow);
                    //Driver.Close();
                    //Driver.SwitchTo().Window(mainWindow);

                }

            }
           



        }
    }
}
