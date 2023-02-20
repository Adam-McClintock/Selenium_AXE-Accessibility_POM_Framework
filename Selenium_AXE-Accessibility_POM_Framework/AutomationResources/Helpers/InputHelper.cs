using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.Extensions;

namespace Selenium_AXE_Accessibility_POM_Framework.AutomationResources.Helpers
{
    public static class InputHelper
    {
        public static void Click(IWebElement element, IWebDriver Driver)
        {
            // Using JS as I've been getting the error Element is not clickable at point
            WaitHelper.WaitForElementClickable(element, Driver);
            element.Click();
        }

        public static void javascriptClick(IWebElement element, IWebDriver Driver)
        {
            // Using JS as I've been getting the error Element is not clickable at point
            WaitHelper.WaitForElementClickable(element, Driver);
            Driver.ExecuteJavaScript("arguments[0].click()", element);
        }

        public static void dropDownSelector(IWebElement dropDown, string option)
        {
            var selectElement = new SelectElement(dropDown);
            selectElement.SelectByText(option);
        }

        public static void InputText(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public static void ClickButtonsAndAssertRedirect(IList<IWebElement> list, string redirectURL, IWebDriver Driver)
        {
            foreach (IWebElement button in list)
            {
                InputHelper.Click(button, Driver);
                string currentURL = Driver.Url;
                Assert.That(currentURL == redirectURL);
            }
        }
    }
}
