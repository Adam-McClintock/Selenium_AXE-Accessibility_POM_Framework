using BoDi;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Selenium_AXE_Accessibility_POM_Framework.AutomationResources.Hooks
{
    public class BeforeHooks : DriverManager
    {
        public BeforeHooks(IObjectContainer container) : base(container) { }

        [BeforeScenario(Order = 0)]
        public void CreateWebDriver()
        {
             DriverFactory();
        }
    }
}
