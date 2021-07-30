using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowSimpleProject.PageObjects
{
    using System.Linq;

    using FluentAssertions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    public class GoogleMainPageObject
    {
        private const string GoogleUrl = "https://www.google.pl/";

        private readonly IWebDriver _webDriver;

        public GoogleMainPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IWebElement SearchField => _webDriver.FindElement(By.Name("q"));

        private IWebElement GoogleAgreeButton => _webDriver.FindElement(By.Id("L2AGLb"));

        private IList<IWebElement> SearchedLink => _webDriver.FindElements(By.XPath("//div[@class='g']//a[not(@class)]"));

        public void OpenGoogle()
        {
            this._webDriver.Url = GoogleUrl;
        }

        public void ClickGoogleAgreeButton()
        {
            GoogleAgreeButton.Click();
        }

        public void EnterSearchedWord(string searchedWord)
        {
            SearchField.Clear();
            SearchField.SendKeys(searchedWord);
        }

        public void ClickSearch()
        {
            Actions action = new Actions(_webDriver);
            action.SendKeys(Keys.Enter);
            action.Perform();
            action.Build();

        }

        public void CheckThatSearchedWordLinkIsPresent(string linkText)
        {
            var sarchedWord = linkText;
            var linkList = SearchedLink.Select(x => x.GetAttribute("href").ToString());
            for (int i = 0; i <= SearchedLink.Count; i++)
            {
                linkList.Should().Contain(sarchedWord);
            }
        }
    }
}