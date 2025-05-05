using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Telenor.Pages;

namespace Telenor.Tests
{
    [TestFixture]
    public class BroadbandTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private HomePage homePage;
        private BredbandPage bredbandPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            // Create page objects
            homePage = new HomePage(driver, wait);
            bredbandPage = new BredbandPage(driver, wait);
        }

        [Test]
        public void TestAddressSearch()
        {
            driver.Navigate().GoToUrl("https://www.telenor.se/");

            homePage.AcceptCookies();
            homePage.NavigateToBredband();

            // Test address
            bredbandPage.EnterAddress("Storgatan 1, Uppsala");
            bredbandPage.SelectRandomApartment();

            // Verify services are available
            Assert.IsTrue(bredbandPage.IsBredbandVia5GAvailable(), "Bredband via 5G not available");
            Assert.IsTrue(bredbandPage.IsBredband500Available(), "Bredband 500 not available");

            Thread.Sleep(5000); // Just to view result before browser closes
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
