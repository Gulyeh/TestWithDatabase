Feature: TC1


Background:
    Given I navigate to url
    When I accept cookies
    Then Main page is opened

@TC1
Scenario: Open newsletter page successfuly and insert test result to the database
    When I click Newsletter button
    Then Newsletter page is opened 

@TC1
Scenario: Open games page unsuccessfuly and insert test result to the database
    When I click Games button
    Then Newsletter page is opened 