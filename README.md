# Selenium_AXE-Accessibility_POM_Framework

https://the-internet.herokuapp.com/challenging_dom

Automated tests created for the Challenging DOM web page, using .NET, Selenium, SpecFlow & Visual Studio. Utilising Chrome Driver and currently using version 106 (Important to update this before running tests on your own machine as you may be using a different version of Chrome than myself).

Also, included some additional code to cover Firefox and Edge should you wish to expand upon this framework.

Utilising POM (Page Object Model) in this framework and decided to only include ONE test per feature file for simplicity, contained within the ChallengingDom folder. If I was to expand out this framework then I would create new folders for different pages/areas of the application and house relevant feature files within.

Tags also added to denote specific test types/areas - currently only 3 tags in use which are @UI, @ChallengingDOM and @AXE (First two are self explanatory, final @AXE tag relates to accessibility tests).

2 Basic sample tests added for demo purposes:

1. Navigate to Challenging DOM Page
2. Perform an accessibility scan of the web page (NOTE: this test will always fail but this is expected)

I've also integrated these tests in an Azure DevOps pipeline so they can be ran as part of a regression pack or on a schedule (for now a schedule has not been set). Azure DevOps project can be found using this link and the project is public so users will be able to view the Build & Release pipelines along with test results. Lastly - I've noticed that if you are not signed into Azure DevOps the release sometimes does not allow you to view the Test Logs so I have included screenshots within this ReadMe to demo: (https://dev.azure.com/adammcclintock0222/Selenium_AXE-Accessibility_POM_Framework/_releaseProgress?releaseId=2&_a=release-pipeline-progress)

![image](https://user-images.githubusercontent.com/58269427/220155443-2dcc7aed-0687-4ee4-b5a3-540bdefe23fb.png)

NOTE: AXE Acessibility test will almost always fail due to the Heroku Challenging DOM page not being developed with accessibility in mind, I'd be surprised if we ever see that test passing :)

UI Tests - 1 Total - 100% Pass:

![image](https://user-images.githubusercontent.com/58269427/220155646-501d0593-53a5-44c0-8fbe-dfce0eaf3c6e.png)

AXE Accessibility Tests - 1 Total - 0% Pass (Expected):

![image](https://user-images.githubusercontent.com/58269427/220155791-4a5871e3-f1cb-4695-9815-da95fb618986.png)

I've also included a HTML report that is attached upon an accessibility test failure for the user to review - can access via the attachments tab.

![image](https://user-images.githubusercontent.com/58269427/220155948-58bbb663-fa68-4800-a684-fc93654a4345.png)

![image](https://user-images.githubusercontent.com/58269427/220156016-e7617f34-5823-4f29-b03d-783039fbc2f4.png)
