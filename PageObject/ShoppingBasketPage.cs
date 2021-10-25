using CdsAssessment.CustomMethods;
using CdsAssessment.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CdsAssessment.PageObject
{
    public class ShoppingBasketPage
    {
        IWebDriver browser;
        private readonly CustomHelpers customHelpers;

        public ShoppingBasketPage(IWebDriver browser, CustomHelpers customHelpers)
        {
            this.browser = browser;
            this.customHelpers = customHelpers;
        }
        private IWebElement hoverMouseOnItem =>
            browser.FindThisElementandClick(locatorType.XPath, "(//img[contains(@class, 'replace')])[1]");

        private IWebElement addItemToCart => 
            browser.FindThisElementandClick(locatorType.XPath, "(//span[text()='Add to cart'])[1]");

        private IWebElement proceedToCart => 
            browser.FindElement(By.XPath("//a[@title='Proceed to checkout']"));

        private IWebElement cartProductCount =>
            browser.FindElement(By.XPath("(//a[@title='View my shopping cart']/span)[1]"));

        private IWebElement Basket =>
            browser.FindElement(By.XPath("//a[@title='View my shopping cart']"));


        private IWebElement Removeproduct =>
            browser.FindElement(By.XPath("//span[@class='remove_link']"));

        private IWebElement searchField =>
            browser.FindThisElementandEnterText(locatorType.Name, "search_query");

        private IWebElement searchResult =>
            browser.FindElement(By.XPath("//*[@id='center_column']/h1"));

        private IList<IWebElement> ProductResultCount =>
            browser.FindElements(By.XPath("//ul[@class='product_list grid row']/li"));

        private IList<IWebElement> CheckOutProductList =>
            browser.FindElements(By.XPath("//div[@id='order-detail-content']//tbody/tr"));

        private IWebElement GetproductName =>
            browser.FindElement(By.XPath("(//h5[@itemprop='name'])[1]"));

        private IWebElement GetproductSummary(string param) =>
            browser.FindElement(By.XPath($"//td[text()='{param}']/following-sibling::td"));


        public void navigateToAutomationPracticeWebsite()
        {
            browser.Navigate().GoToUrl(SettingsReader.automationPracticeUrl);
        }

        public void HoverMouseOnImg()
        {
            Actions actions = new Actions(browser);
            customHelpers.WaitFor(browser, By.XPath("(//img[contains(@class, 'replace')])[1]"));
            actions.MoveToElement(hoverMouseOnItem).Perform();
            customHelpers.WaitFor(browser, By.XPath("(//span[text()='Add to cart'])[1]"));
            addItemToCart.Click();
        }

        public string GetItemName() => GetproductName.Text;

        public void RemoveItemFromBasket()
        {
            Actions actions = new Actions(browser);
            customHelpers.WaitFor(browser, By.XPath("//a[@title='View my shopping cart']"));
            actions.MoveToElement(Basket).Perform();
            customHelpers.WaitFor(browser, By.XPath("//span[@class='remove_link']"));
            Removeproduct.Click();
        }

        public IList<IWebElement> getproductresultcount()
        {
            Task.Delay(1000).Wait();
            return ProductResultCount.ToList();
        }

        public IList<IWebElement> GetCheckoutProductSummary()
        {
            customHelpers.WaitFor(browser, By.XPath("//div[@id='order-detail-content']//tbody/tr"));
            return CheckOutProductList.ToList();
        }

        public string GetSearchResult()
        {
            customHelpers.WaitFor(browser, By.XPath("//*[@id='center_column']/h1"));
            return searchResult.Text;
        }

        public string GetProductSummaryAtCheckOut(string param) => GetproductSummary(param).Text;

        public void searchKeyword(string value)
        {
            customHelpers.WaitFor(browser, By.Name("search_query"));
            searchField.SendKeys(value + Keys.Enter);
        }

        public void AddItemSelectedToCart()
        {
            Task.Delay(5000).Wait();
            proceedToCart.Click();
        }

        public string GetCartProductCount()
        {
            customHelpers.WaitFor(browser, By.XPath("(//a[@title='View my shopping cart']/span)[1]"));
            return cartProductCount.Text;
        }

        public string IsBasketEmpty()
        {
            Task.Delay(3000).Wait();
            return Basket.Text.Split("(")[1].Split(")")[0];
        }
    }
}
