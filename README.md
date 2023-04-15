# YuGiOh Cards Database
Based on the API of YGOProDeck: https://db.ygoprodeck.com/api/v7/cardinfo.php

## Info
YuGiOh is a very popular Card Game with multiple Games based around it, making this a perfect fit for this project. 

# How To Use
When opening the program, you will start to ask the API for the entire database. This is the OverviewPage. 
We will get all the cards from the API, and display them when they are ready.

## Detail Page
You can double click a card, or select it and press the button in the middle on the bottom, to get to the DetailPage. </br>
This page will display any useful information linked to the card.

You can click the image on the left to make this fullscreen.
Click again to revert this.

To get back to the OverviewPage, click the button in the top right corner.

## Filters
There are 2 filters in place. </br>
The type of card and the archetype of the card.
Both will be used when filtering through the cards. This makes it possible to have combinations where no cards can be shown.

When the cards are ready, these filters will be made automatically and display the possible options. (including the select, which will ignore the filter)



![Usage_Gif](/ReadmeImages/Usage.gif)


## Switching to Local
To use the Local API, you simple just have to press on the button on the OverviewPage in the bottom right corner.
This will reset all filters.

Keep in mind, this is just a small sample taken from the online API.
Images will still be accessed via internet; these are not stored locally.

![LocalSwitch_Gif](/ReadmeImages/ReposSwitch.gif)


# Possible Extensions in the Future
Currently the DetailPage displays a green color to add a bit of flavor.
This however could be made so that every card has a color depending on the frameType. (e.g. green for Spells, orange for Effect monsters,...)

I could've added this already, yet this would've looked really ugly in code because this is not included in the api, meaning that I'd have to go through every possible frameType after making the card and assign their color based on that.

Something other that I would've loved to add but didn't have enough time for; is a search bar.
Using Regex, this should be fairly easy and since the database is so huge, this would've been nice to have.



# Known Problems
Currently the DetailPage will check every Property of both card classes. </br>
This will give Binding failures for Spell/Trap cards since these don't have the Attack, Defense,... property. </br>
I tried finding a solution for this, but sadly couldn't find anything. </br>
As these are mere warnings, I'm not going to try and fix this in the near future.

Something else I noticed the hard way is that I really rely on the API itselves.</br>
As of writing this (15 april 2023) a new card that was recently announced got added to the database. </br>
Not a big deal, however this card has `Attack: ? and Defense: ?`, nothing new. But all other cards with this had their Attack and Defense as 0 in the API data. </br>
This card didn't... It has/had `null` as a value. Because I didn't account for this, because no other card had this, this would throw an exception thus causing only a select few cards to be displayed.

I now do handle a null for those properties, but it's very scary how 1 (well 2 in this case) unexpected null values can ruin a project.

