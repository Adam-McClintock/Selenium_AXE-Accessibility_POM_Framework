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
    [Binding]
    public class AfterHooks : DriverManager
    {
        public AfterHooks(IObjectContainer container) : base(container) { }

        [AfterScenario]
        public void DestroyWebDriver() => DestroyDriver();
    }
}
