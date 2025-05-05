# Telenor - Broadband Availability Automation 

- This is a small Selenium automation project created as part of a job interview task. The goal is to search for an address on the [Telenor Sweden website](https://www.telenor.se/), select an apartment, and check if certain broadband services (like "Bredband via 5G" and "Bredband 500") are available.

## Technologies Used

- C#
- Selenium WebDriver
- NUnit (for test framework)
- Page Object Model (POM)
- Visual Studio 2022
- Git

## What the Code Does

1. Opens the Telenor website.
2. Accepts cookies.
3. Navigates to the "Bredband" (Broadband) section using the menu.
4. Searches for a specific address.
5. Randomly selects an apartment from the dropdown (if any).
6. Checks if "Bredband via 5G" and "Bredband 500" are shown on the page.

## Project Structure

Telenor/
  Pages/
    HomePage.cs - Handles home page navigation and cookie handling
    BredbandPage.cs - Handles address input, apartment selection, and result checking
    Locators.cs - Keeps all element locators in one place for easier updates
  Tests/
    BroadbandTests.cs - Contains the test case written using NUnit
  README.md - This file

## How to Run

1. Clone the repo.
2. Open the solution in Visual Studio.
3. Make sure the Chrome browser is installed.
4. Run the test `TestAddressSearch()` from the `BroadbandTests.cs` file.

## Notes

- Locators are kept in a separate file (`Locators.cs`) to make maintenance easier.
- Kept everything simple and readable on purpose, to make the test easy to review and understand.