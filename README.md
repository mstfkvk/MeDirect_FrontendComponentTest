[MeDirect_FrontendComponentTest]

# Test Plan for SauceDemo Website

## Overview
The purpose of this test plan is to outline test cases and scenarios for the SauceDemo website to ensure it is functioning properly and meets the expected requirements. For login functionality, Testing is done for all user types in one features. For shopping after logged in, _standard_user_' and _performance_glitch_user_'s tests are made with same feature file, you just need to change one step in **Background**.

## Test Environment&Tools
The following test environment will be used for testing:

- Programming Language: C#
- IDE: Visual Studio
- Web Browser: Google Chrome
- SpecFlow - BDD testing framework
- NUnit - Testing framework
- Selenium 4 - Web automation tool
- Page Object Model - Design pattern for web automation
- Hooks - Selenium event handlers for setup and teardown of test environment

## Test Cases

_Verify the login functionality of the website for all user types:_

#### Positive Test Scenarios
1. standart-user should be logged in with own valid credentials
2. locked_out_user should not be logged in with own valid credentials
3. problem_user should be logged in with own valid credentials
4. performance_glitch_user should be logged in with own valid credentials

#### Negative Test Scenarios
1. trying to login with invalid credentials

_Verify the shopping functionality of the website for **standard_user** and  **performance_glitch_user** types:_

#### Positive-Negative Test Scenarios
1. standart-user adds randomly 3 products to the shopping chart then control with 2 verifications
2. standart-user adds randomly one products to the shopping chart then control with 2 verifications
3. after adding one product user enter invalid credentials
4. after adding one product user enter with missing valid credentials
5. user filters according to name or price
6. user goes to social media

_Verify the shopping functionality of the website for **problem_user**  types:_

#### Positive-Negative Test Scenarios
1. all items picture are same and when user looks inventory-item it doesn't match with before clicked
2. user tries to add some item and then remove
3. Filter doesn't work anyway
4. User wants to go ABOUT page but not found


## Test Data:

- Base url: https://www.saucedemo.com/
- Valid and invalid data is given with scenario outlines as examples
- user-types:
  1. standard_user
  2. locked_out_user
  3. problem_user
  4. performance_glitch_user
- password: secret_sauce


## Conclusion
The tests outlined in this test plan will ensure that the SauceDemo website works as expected and meets the desired requirements. By following a BDD approach with SpecFlow and NUnit and using Selenium 4, the tests will be comprehensive and maintainable.
