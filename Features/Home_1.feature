Feature: Automation 1 Home

@regression
Scenario: Submit the Form
	Given Launch the URL
	When Enter all the mandatory details
	Then Click submit
	Then The successfull form submisson message is displayed

@smoke
Scenario: Submit the Form1
	Given Launch the URL
	When Enter all the mandatory details
	Then Click submit
	Then The successfull form submisson message is displayed
