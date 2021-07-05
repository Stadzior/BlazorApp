Feature: Counter
![Counter](https://github.com/Stadzior/BlazorApp/blob/master/BlazorApp.Specs/Assets/51G26e3Y9XL._AC_SX425_.jpg)
	Simple counter which value is incrementing and decrementing upon

Link to a feature: [Counter](BlazorApp.UISpecs/Features/Counter.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@increment
Scenario: Increment counter
	Given main page of the website is opened
	When the user clicks "Counter" link from menu
	And the user clicks "++" button
	Then the counter value should be 1
	
@decrement
Scenario: Decrement counter
	Given main page of the website is opened
	When the user clicks "Counter" link from menu
	And the user clicks "--" button
	Then the counter value should be 0
	
@decrement
Scenario: Increment counter twice and then Decrement counter once
	Given main page of the website is opened
	When the user clicks "Counter" link from menu
	And the user clicks "++" button
	And the user clicks "++" button
	And the user clicks "--" button
	Then the counter value should be 1
	
@reset
Scenario: Increment counter twice and then Reset counter
	Given main page of the website is opened
	When the user clicks "Counter" link from menu
	And the user clicks "++" button
	And the user clicks "++" button
	And the user clicks "Reset" button
	Then the counter value should be 0