Feature: Counter
![Counter](https://github.com/Stadzior/BlazorApp/blob/master/BlazorApp.Specs/Assets/51G26e3Y9XL._AC_SX425_.jpg)
	Simple counter which value is incrementing and decrementing upon

Link to a feature: [Counter](BlazorApp.NUnitSpecsCLI/Features/Counter.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@increment
Scenario: Increment counter
	Given the counter value is 50
	When the user clicks "++" button
	Then the counter value should be 51
	
@decrement
Scenario: Decrement counter with initial positive value
	Given the counter value is 50
	When the user clicks "--" button
	Then the counter value should be 49
	
@decrement
Scenario: Decrement counter with initial zero value
	Given the counter value is 0
	When the user clicks "--" button
	Then the counter value should be 0
	
@reset
Scenario: Reset counter
	Given the counter value is 50
	When the user clicks "Reset" button
	Then the counter value should be 0