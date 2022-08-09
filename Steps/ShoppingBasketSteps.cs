using BoDi;
using CdsAssessment.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Threading.Tasks;

namespace CdsAssessment.Steps
{
    [Binding]
    public sealed class ShoppingBasketSteps
    {
        private readonly ShoppingBasketPage shoppingBasketPage;
        private readonly ScenarioContext _scenarioContext;
        private static string ItemProductName;

        public ShoppingBasketSteps(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            shoppingBasketPage = objectContainer.Resolve<ShoppingBasketPage>();
        }

        [Given(@"I navite to automationpractice\.com")]
        public void GivenINaviteToAutomationpractice_Com()
        {
            shoppingBasketPage.navigateToAutomationPracticeWebsite();
        }

        [When(@"I hover mouse on the Item")]
        public void WhenIHoverMouseOnTheItem()
        {
            shoppingBasketPage.HoverMouseOnImg();
            ItemProductName = shoppingBasketPage.GetItemName();
        }

        [When(@"I add an Item to basket")]
        public void WhenIAddAnItemToBasket()
        {
            shoppingBasketPage.AddItemSelectedToCart();
        }

        [Then(@"I have (\d+) Item in the basket")]
        public void ThenIHaveOneItemInTheBasket(int count)
        {
            var productCount = 
            shoppingBasketPage.GetCartProductCount();
            Assert.AreEqual(count.ToString(), productCount);
        }

        [When(@"I remove Item from the basket")]
        public void WhenIRemoveItemFromTheBasket()
        {
            shoppingBasketPage.RemoveItemFromBasket();
        }

        [Then(@"basket is (empty)")]
        public void ThenBasketIsEmpty(string value)
        {
            var count = shoppingBasketPage.IsBasketEmpty();
            Assert.AreEqual(value, count);
        }

        [When(@"I search item with name '(.*)'")]
        public void WhenISearchItemWithName(string value)
        {
            shoppingBasketPage.searchKeyword(value);
        }

        [Then(@"I search result has a key word '(.*)'")]
        public void ThenISearchResultHasAKeyWord(string expected)
        {
           var result = shoppingBasketPage.GetSearchResult();
            Assert.IsTrue(result.Contains(expected));
        }

        [Then(@"search result has (\d+) item count")]
        public void ThenSearchResultHasOneItemCount(int expectedCount)
        {
            var actualCount = shoppingBasketPage.getproductresultcount();
            Assert.AreEqual(expectedCount, actualCount.Count);
        }

        [Then(@"I have (\d+) Item in checkout")]
        public void ThenIHaveOneItemInCheckout(int expectedCount)
        {
            var actualCount = shoppingBasketPage.GetCheckoutProductSummary();
            Assert.AreEqual(expectedCount, actualCount.Count);
        }

        [Then(@"the item name matches the item added to the basket")]
        public void ThenTheItemNameMatchesTheItemAddedToTheBasket()
        {
            var actualProductName = shoppingBasketPage.GetCheckoutProductSummary();
            Assert.IsTrue(actualProductName[0].Text.Contains(ItemProductName));
        }

        [Then(@"the summary of the product is as follows:")]
        public void ThenTheSummaryOfTheProductIsAsFollows(Table table)
        {
            var tabledetails = table.CreateInstance<summarydetails>();
            Task.Delay(3000).Wait();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(tabledetails.Totalproducts, 
                    shoppingBasketPage.GetProductSummaryAtCheckOut(table.Header.ElementAt((int)EnumValue.Default)));
                Assert.AreEqual(tabledetails.Totalshipping,
                    shoppingBasketPage.GetProductSummaryAtCheckOut(table.Header.ElementAt((int)EnumValue.First)));
                Assert.AreEqual(tabledetails.Total,
                    shoppingBasketPage.GetProductSummaryAtCheckOut(table.Header.ElementAt((int)EnumValue.Second)));
                Assert.AreEqual(tabledetails.Tax,
                    shoppingBasketPage.GetProductSummaryAtCheckOut(table.Header.ElementAt((int)EnumValue.Third)));
                Assert.AreEqual(tabledetails.Total,
                    shoppingBasketPage.GetProductSummaryAtCheckOut(table.Header.ElementAt((int)EnumValue.Fourth)));
            });
        }

        public class summarydetails
        {
            public string Totalproducts { get; set; }
            public string Totalshipping { get; set; }
            public string Total { get; set; }
            public string Tax { get; set; }
        }

        public enum EnumValue
        {
            Default = 0,
            First = 1,
            Second = 2,
            Third = 3,
            Fourth = 4
        }
    }
}