﻿Feature: HU03-Regulations

A short summary of the feature

@tag1
Scenario: [Create regulation with one article and two penalties]
	Given [The steward is creating a regulation]
	When [The steward selects the article part of the regulation]
    And [The steward selects two penalties for the regulation]
    And [The steward submits the regulation]
	Then [The regulation is created]
