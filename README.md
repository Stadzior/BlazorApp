# BlazorApp Unit/UI/BDD testing excercises

![Build + Test](https://github.com/Stadzior/BlazorApp/actions/workflows/dotnet.yml/badge.svg)

### Prerequisites:
Install [.NET](https://dotnet.microsoft.com/download)
### Setup project under test:
Create solution:
```
dotnet new sln -n BlazorApp
```
Create [Blazor WASM](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) project and add it to solution:
```
dotnet new blazorwasm -o BlazorApp --no-https --framework "net5.0"
dotnet sln BlazorApp.sln add BlazorApp/BlazorApp.csproj
```
Run the app to check if it builds and runs:
```
dotnet build
dotnet watch run --project BlazorApp/BlazorApp.csproj
```
### Setup, code and run your first unit test:
Create [NUnit](https://nunit.org/) test project, add reference to "project under test", [FluentAssertions](https://fluentassertions.com/) package and add it to solution:
```
dotnet new nunit -o BlazorApp.Tests --framework "net5.0"
dotnet add BlazorApp.Tests/BlazorApp.Tests.csproj reference BlazorApp/BlazorApp.csproj
dotnet add BlazorApp.Tests/BlazorApp.Tests.csproj package FluentAssertions
dotnet sln BlazorApp.sln add BlazorApp.Tests/BlazorApp.Tests.csproj
```
Now you can play with the project. 

For tips and good practises checkout:
- https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
- https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit

When you're done run your tests:
```
dotnet test
```
### Setup, code and run your first BDD test scenario:
Install SpecFlow template:
```
dotnet new -i SpecFlow.Templates.DotNet
```
Create [Specflow](https://specflow.org/) test project, add reference to "project under test", [FluentAssertions](https://fluentassertions.com/) and add it to solution:
```
dotnet new specflowproject -o BlazorApp.Specs --unittestprovider nunit --framework "net5.0"
dotnet add BlazorApp.Specs/BlazorApp.Specs.csproj reference BlazorApp/BlazorApp.csproj
dotnet add BlazorApp.Specs/BlazorApp.Specs.csproj package FluentAssertions
dotnet sln BlazorApp.sln add BlazorApp.Specs/BlazorApp.Specs.csproj
```
Now you can play with the project. 

For quickstart you can checkout [this link](https://docs.specflow.org/projects/getting-started/en/latest/GettingStarted/Step1.html). You have already made all necessary setups and configurations from CLI so skip the config steps. :)

When you're done run your tests:
```
dotnet test
```
### Setup, code and run your first UI Test:

Create [NUnit](https://nunit.org/) test project, add [Selenium WebDriver](https://www.selenium.dev/), [FluentAssertions](https://fluentassertions.com/) and add it to solution:
```
dotnet new nunit -o BlazorApp.UITests --framework "net5.0"
dotnet add BlazorApp.UITests/BlazorApp.UITests.csproj reference BlazorApp/BlazorApp.csproj
dotnet add BlazorApp.UITests/BlazorApp.UITests.csproj package Selenium.WebDriver
dotnet add BlazorApp.UITests/BlazorApp.UITests.csproj package Selenium.WebDriver.ChromeDriver
dotnet add BlazorApp.UITests/BlazorApp.UITests.csproj package FluentAssertions
dotnet sln BlazorApp.sln add BlazorApp.UITests/BlazorApp.UITests.csproj
```
Now you can play with the project. 

When you're done run your tests:
```
dotnet test
```
### Setup, code and run your first UI BDD test scenario:
Create [Specflow](https://specflow.org/) test project, add [Selenium WebDriver](https://www.selenium.dev/), [FluentAssertions](https://fluentassertions.com/) and add it to solution:
```
dotnet new specflowproject -o BlazorApp.UISpecs --unittestprovider nunit --framework "net5.0"
dotnet add BlazorApp.UISpecs/BlazorApp.UISpecs.csproj package Selenium.WebDriver
dotnet add BlazorApp.UISpecs/BlazorApp.UISpecs.csproj package Selenium.WebDriver.ChromeDriver
dotnet add BlazorApp.UISpecs/BlazorApp.UISpecs.csproj package FluentAssertions
dotnet sln BlazorApp.sln add BlazorApp.UISpecs/BlazorApp.UISpecs.csproj
```
Now you can play with the project. 

![Big smoke - all you need to do is to follow the damn instructions cj](https://github.com/Stadzior/BlazorApp/blob/master/99f.jpg)

### Full project with tests and configured github actions pipeline is available in this repo for reference.
