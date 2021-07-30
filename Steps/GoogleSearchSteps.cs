using System;
using TechTalk.SpecFlow;

namespace SpecFlowSimpleProject.Steps
{
    using SpecFlowSimpleProject.Drivers;
    using SpecFlowSimpleProject.PageObjects;

    [Binding]
    public sealed class GoogleSearchSteps
    {
        private readonly GoogleMainPageObject _googleMainPageObject;

        public GoogleSearchSteps(BrowserDriver browserDriver)
        {
            _googleMainPageObject = new GoogleMainPageObject(browserDriver.Current);
        }

        [Given(@"I have entered the Google Home page")]
        public void GivenIHaveEnteredTheGoogleHomePage()
        {
            this._googleMainPageObject.OpenGoogle();
            this._googleMainPageObject.ClickGoogleAgreeButton();
        }
        
        [Given(@"I have entered (.*) into google search bar")]
        public void GivenIHaveEnteredSaganeiroIntoGoogleSearchBar(string searchedWord)
        {
            this._googleMainPageObject.EnterSearchedWord(searchedWord);
        }
        
        [When(@"I press search button")]
        public void WhenIPressSearchButton()
        {
            this._googleMainPageObject.ClickSearch();
        }

        [Then(@"In the link list there is link (.*)")]
        public void ThenInTheLinkListThereIsLink(string linkText)
        {
            this._googleMainPageObject.CheckThatSearchedWordLinkIsPresent(linkText);
        }

    }
}
