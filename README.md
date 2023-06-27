# TFG.RulesPenaltiesF1

_____Developed by Jorge Rebé Martín\_\____

The aim of this project is to develop a web application to manage the regulations and penalties in Formula One, as well as the course of the seasons, competitions, and sessions in which those penalties can be imposed.

The app has been developed using ASP.NET Core MVC, with Scrum as agile framework, and using Domain Driven Design (DDD) and Behaviour Driven Development (BDD) as software development approaches. It’s been built using a Clean architecture, applying good practices in the development of quality software following design principles and patterns.

## Domain Model

In the following class diagram you can see the domain model that was obtained after analysing the domain of Formula One.

Several sporting regulations were read and the functionality that the app should have was studied, and one of the resulting artifacts of this was the following domain model:

![Domain Model](https://github.com/jorgerebe/TFG.RulesPenaltiesF1/assets/48808378/bd59fd4e-c436-4137-858d-b13aea21ea2f)


## Architecture

The application uses a clean architecture. Inside the _src/_ folder, three are three project, each of which implements one layer of the architecture.

Firstly, the **Web** project (the UI layer) that contains an ASP.NET Core MVC project, that depends on the Infrastructure and Core projects. 

The **Infrastructure** project (the Infrastructure layer) contains all the logic for data access (repositories) and different classes that contain configurations for the database. This project depends on the Core project.

The **Core** project (the Application Core or Business Logic layer) contain domain entities, domain services, and different repositories interfaces that are implemented in the infrastructure layer.

With this architecture, it is possible to test the domain entities easily because they do not depend on any other layer.

![General Architecture](https://github.com/jorgerebe/TFG.RulesPenaltiesF1/assets/48808378/e0aa2276-b65e-4db8-88f0-f7099e42128b)




## Testing

Several Unit Tests have been developed for the domain entities, as they have the most complex logic. Those Unit Tests have been coded using xUnit.net

Acceptance Tests for creating articles, creating regulations and logging in have been made using SpecFlow, xUnit.net and Selenium.

In the _tests/_ folder both tests projects can be found.



## Visual Studio Template

A Clean Architecture template with ASP.NET Core for Visual Studio, developed by Steve Smith (ardalis) was the base for the project.

[https://github.com/ardalis/CleanArchitecture](https://github.com/ardalis/CleanArchitecture)

## Deployment

### Local Deployment

To deploy the application in a local machine, the following must be installed:

- .NET 7
- SQL Server
- Visual Studio 2022 (this is not required, as the app can be launched from _dotnet cli_, but the app will be launched from the IDE in this guide)

Download the project from the repository and open the solution file **_TFG.RulesPenaltiesF1.sln_**

Once open, select the desired launch setting (_i.e._, https) and press the keys _**ctrl+F5**_. The app will be launched, and the database will be populated if empty.


### Deployment to Azure

The web application was deployed as an Azure Container App, that uses an Azure SQL Database to store and retrieve data.
In the following Figure a deployment diagram is shown.

![Deployment Diagram](https://github.com/jorgerebe/TFG.RulesPenaltiesF1/assets/48808378/fd30e6db-68cb-4941-b7f9-0b85ceab4492)

