using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Telenor.Pages;

namespace Telenor.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        // Clicks the "Accept Cookies" button if it appears
        public void AcceptCookies()
        {
            try
            {
                var acceptCookies = wait.Until(d => d.FindElement(By.Id(Locators.AcceptCookiesButtonId)));
                acceptCookies.Click();
            }
            catch (WebDriverTimeoutException) { } // Ignore if the cookie popup doesn’t show
        }

        // Navigates to the "Bredband" (Broadband) page using the menu
        public void NavigateToBredband()
        {
            try
            {
                var handlaMenu = wait.Until(d => d.FindElement(By.LinkText(Locators.HandlaLinkText)));
                handlaMenu.Click();
            }
            catch (WebDriverTimeoutException)
            {
                var produkterMenu = wait.Until(d => d.FindElement(By.LinkText(Locators.ProdukterLinkText)));
                produkterMenu.Click();
            }

            var bredbandLink = wait.Until(d => d.FindElement(By.LinkText(Locators.BredbandLinkText)));
            bredbandLink.Click();
        }
    }
}
