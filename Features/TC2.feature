Feature: TC2


@TC2
Scenario: Select tests from database, change start time, insert new test and delete it
    Given I select no more than 10 tests with repeatitve digits and save as 'selectedTests'
    When I update start time of each test saved as 'selectedTests'
    And I get amount of current rows in test table and save as 'amountOfRows'
    And I insert updated tests saved as 'selectedTests' to database
    Then Amount of existing rows in test table equals amount saved as 'amountOfRows' adjusted by amount of tests saved as 'selectedTests'
    When I delete inserted records to database saved as 'selectedTests' from database
    Then Amount of existing records in database equals amount saved as 'amountOfRows'
