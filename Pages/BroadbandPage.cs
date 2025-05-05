using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using Telenor.Pages;

namespace Telenor.Pages
{
    public class BredbandPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public BredbandPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        // Accept cookies popup on this page too (if it shows again)
        public void AcceptCookies()
        {
            try
            {
                var acceptCookies = wait.Until(d => d.FindElement(By.Id(Locators.AcceptCookiesButtonId)));
                acceptCookies.Click();
            }
            catch (WebDriverTimeoutException) { }
        }

        // Enters the address into the input box and selects from the suggestions
        public void EnterAddress(string address)
        {
            var addressInput = wait.Until(d => d.FindElement(By.XPath(Locators.AddressInputXpath)));
            addressInput.Clear();
            addressInput.SendKeys(address);

            // Wait until suggestion appears
            wait.Until(d => d.FindElement(By.CssSelector(Locators.RoleOptionCss)));
            addressInput.SendKeys(Keys.Enter);
        }

        // Randomly selects one of the available apartments from dropdown
        public void SelectRandomApartment()
        {
            var dropdown = wait.Until(d => d.FindElement(By.TagName("select")));
            var options = dropdown.FindElements(By.TagName("option"));

            if (options.Count <= 1)
                throw new NoSuchElementException("No apartment options found.");

            var rnd = new Random();
            int index = rnd.Next(1, options.Count);
            string valueToSelect = options[index].GetAttribute("value") ?? string.Empty;

            // Use JS to select option (some dropdowns behave better this way)
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(@"
                const select = arguments[0];
                const value = arguments[1];
                select.value = value;
                select.dispatchEvent(new Event('input', { bubbles: true }));
                select.dispatchEvent(new Event('change', { bubbles: true }));
            ", dropdown, valueToSelect);
        }

        // Checks if the page mentions "Bredband via 5G"
        public bool IsBredbandVia5GAvailable() =>
            wait.Until(d => d.FindElement(By.XPath("//*[contains(text(), 'Bredband via 5G')]"))) != null;

        // Checks if the page mentions "Bredband 500"
        public bool IsBredband500Available() =>
            wait.Until(d => d.FindElement(By.XPath("//*[contains(text(), 'Bredband 500')]"))) != null;
    }
}
