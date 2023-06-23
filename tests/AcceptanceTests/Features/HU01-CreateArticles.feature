Feature: HU01-CreateArticles

A short summary of the feature

@stewardlogin
Scenario: [Create article with one subarticle]
	Given [The steward is creating an article]
	When [The steward enters the content of the article]
    And [The steward adds the content of the subarticle as a subitem of the first article]
    And [The steward submits the article]
	Then [The article created is stored]