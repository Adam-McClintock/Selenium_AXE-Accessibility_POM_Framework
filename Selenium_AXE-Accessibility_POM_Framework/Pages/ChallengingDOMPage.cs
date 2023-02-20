using OpenQA.Selenium;
using Selenium_AXE_Accessibility_POM_Framework.AutomationResources;
using Selenium_AXE_Accessibility_POM_Framework.AutomationResources.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Selenium_AXE_Accessibility_POM_Framework.Pages
{
    public class ChallengingDOMPage : Base
    {
        public ChallengingDOMPage(IWebDriver driver) : base(driver) { }

        #region Variables / Elements
        private string PageHeader => "Challenging DOM";
        private IWebElement blueBtn => Driver.FindElement(By.XPath("//a[@class='button']"));
        private IWebElement redBtn => Driver.FindElement(By.XPath("//a[@class='button alert']"));
        private IWebElement greenBtn => Driver.FindElement(By.XPath("//a[@class='button success']"));
        private IWebElement canvasElement => Driver.FindElement(By.Id("canvas"));
        private IWebElement tableElement => Driver.FindElement(By.XPath("//table"));

        private IList<IWebElement> editBtns => Driver.FindElements(By.XPath("//a[@href='#edit']"));

        private IList<IWebElement> deleteBtns => Driver.FindElements(By.XPath("//a[@href='#delete']"));

        private IList<IWebElement> tableHeadersElements => Driver.FindElements(By.XPath("//table//thead//tr//th"));
        private IEnumerable<string> tableHeadersStrings => tableHeadersElements.Select(element => element.Text);

        private List<string> tableHeaders = new List<string>() { "Lorem", "Ipsum", "Dolor", "Sit", "Amet", "Diceret", "Action" };
        private IList<IWebElement> rowOneElements => Driver.FindElements(By.XPath("//table//tbody//tr//td"));
        private IEnumerable<string> rowOneStrings => rowOneElements.Select(element => element.Text);

        private List<string> rowOneValues = new List<string>() { "Iuvaret0", "Apeirian0", "Adipisci0", "Definiebas0", "Consequuntur0", "Phaedrum0" };

        private IList<IWebElement> rowCount => Driver.FindElements(By.XPath("//table//tbody//tr"));
        private IEnumerable<string> rowStrings => rowCount.Select(element => element.Text);
        private string editRedirect => "https://the-internet.herokuapp.com/challenging_dom#edit";
        private string deleteRedirect => "https://the-internet.herokuapp.com/challenging_dom#delete";


        #endregion

        #region Page Methods
        public void GoTo() => Driver.Navigate().GoToUrl(Settings.Default.AppURL);

        public void ClickBlueButton() => InputHelper.Click(blueBtn, Driver);

        public void ClickRedButton() => InputHelper.Click(redBtn, Driver);

        public void ClickGreenButton() => InputHelper.Click(greenBtn, Driver);
        public void ClickEditButtonsAndAssertRedirect() => InputHelper.ClickButtonsAndAssertRedirect(editBtns, editRedirect, Driver);
        public void ClickDeleteButtonsAndAssertRedirect() => InputHelper.ClickButtonsAndAssertRedirect(deleteBtns, deleteRedirect, Driver);
        public void AccessibilityScan() => AXEHelper.AXEReportScan("ChallengingDOM", Driver);

        #endregion

        #region Assertions
        public void AssertPageVisible() => PageHelper.ThenAPageIsDisplayed(PageHeader, Driver);

        public void AssertCanvasIsVisible() => PageHelper.ConfirmElementVisible(canvasElement);

        public void AssertTableIsVisible() => PageHelper.ConfirmElementVisible(tableElement);

        public void ValidateTableHeadersDisplayed() => CollectionAssert.AreEqual(tableHeaders, tableHeadersStrings);

        public void ValidateRowValuesDisplayed() => CollectionAssert.AreEqual(rowOneValues, rowOneStrings.Take(6));
        public void ValidateRowCount(int count) => Assert.That(rowCount.Count, Is.EqualTo(count));

        #endregion
    }
}
