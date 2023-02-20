using OpenQA.Selenium;
using Selenium_AXE_Accessibility_POM_Framework.AutomationResources;
using Selenium_AXE_Accessibility_POM_Framework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Selenium_AXE_Accessibility_POM_Framework.Steps
{
    [Binding]
    public class ChallengingDOMSteps : Base
    {
        private ChallengingDOMPage challengingDOMPage;

        public ChallengingDOMSteps(IWebDriver driver) : base(driver)
        {
            challengingDOMPage = new ChallengingDOMPage(Driver);
        }

        [Given(@"I have navigated to the Challenging DOM page")]
        public void GivenIHaveNavigatedToTheChallengingDOMPage() => challengingDOMPage.GoTo();

        [When(@"I click the blue button")]
        public void WhenIClickTheBlueButton() => challengingDOMPage.ClickBlueButton();

        [When(@"I click the red button")]
        public void WhenIClickTheRedButton() => challengingDOMPage.ClickRedButton();

        [When(@"I click the green button")]
        public void WhenIClickTheGreenButton() => challengingDOMPage.ClickGreenButton();

        [Then(@"I confirm that the Challenging DOM page is visible")]
        public void ThenIConfirmThatTheChallengingDOMPageIsVisible() => challengingDOMPage.AssertPageVisible();

        [Then(@"I confirm that the Challening DOM canvas is visible")]
        public void ThenIConfirmThatTheChalleningDOMCanvasIsVisible() => challengingDOMPage.AssertCanvasIsVisible();

        [Then(@"I confirm that the Challening DOM table is visible")]
        public void ThenIConfirmThatTheChalleningDOMTableIsVisible() => challengingDOMPage.AssertTableIsVisible();

        [Then(@"I confirm that the table headers displayed are correct")]
        public void ThenIConfirmThatTheTableHeadersDisplayedAreCorrect() => challengingDOMPage.ValidateTableHeadersDisplayed();

        [Then(@"I confirm that table row one contains the correct values")]
        public void ThenIConfirmThatTableRowOneContainsTheCorrectValues() => challengingDOMPage.ValidateRowValuesDisplayed();

        [Then(@"I confirm the total rows within the table equal ""([^""]*)""")]
        public void ThenIConfirmTheTotalRowsWithinTheTableEqual(int rowCount) => challengingDOMPage.ValidateRowCount(rowCount);

        [Then(@"the user clicks the Edit buttons and is redirected")]
        public void ThenTheUserClicksTheEditButtonsAndIsRedirected() => challengingDOMPage.ClickEditButtonsAndAssertRedirect();

        [Then(@"the user clicks the Delete buttons and is redirected")]
        public void ThenTheUserClicksTheDeleteButtonsAndIsRedirected() => challengingDOMPage.ClickDeleteButtonsAndAssertRedirect();

        [Then(@"I confirm the Challenging Dom Page meets accessibility standards")]
        public void ThenIConfirmTheChallengingDomPageMeetsAccessibilityStandards() => challengingDOMPage.AccessibilityScan();

    }
}
