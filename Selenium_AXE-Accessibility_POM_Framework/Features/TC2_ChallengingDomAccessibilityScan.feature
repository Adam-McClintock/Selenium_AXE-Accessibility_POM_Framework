@AXE
@ChallengingDOM
Feature: TC2_ChallengingDomAccessibilityScan

In this test the user validates whether the Challenging DOM page contains any accessibility
violations. Chances are it will and this test will always fail. 

Background: 
	Given I have navigated to the Challenging DOM page
	Then I confirm that the Challenging DOM page is visible

Scenario: TC2_ChallengingDomAccessibilityScan
	Then I confirm the Challenging Dom Page meets accessibility standards
