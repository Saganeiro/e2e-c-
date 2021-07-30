Feature: Google search

Scenario: Search Saganeiro GitHub link in Google
Given I have entered the Google Home page
And I have entered Saganeiro into google search bar
When I press search button
Then In the link list there is link https://github.com/Saganeiro

Scenario: Search Saganeiro Facebook link in Google
Given I have entered the Google Home page
And I have entered Saganeiro into google search bar
When I press search button
Then In the link list there is link https://www.facebook.com/Saganeiro/