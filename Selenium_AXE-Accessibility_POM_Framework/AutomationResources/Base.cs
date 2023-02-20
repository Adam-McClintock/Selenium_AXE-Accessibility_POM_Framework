using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Selenium_AXE_Accessibility_POM_Framework.AutomationResources
{
    [Binding]
    public class Base : TechTalk.SpecFlow.Steps
    {
        protected IWebDriver Driver { get; }
        public Base(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
