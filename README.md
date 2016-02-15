# criccard

__Project Structure__

###### Exact.CricCard.Domain

> >It contains Core elements of the server side application. Here, Entities are implemented by using Entity Framework Code First, Logging is implemented by using Log4Net.

###### Exact.CricCard.Services

> >It contains the Game Engine. Logger is used in here also.

###### Exact.CricCard.CricAPI

> >It contains Restful API. It is implemented by using ASP.NET WebAPI & Dependency Injection by using StructuredMap.WebApi2

###### Exact.CricCard.WebApp

> >It c.ontains the client side application. It is implemented by using HTTP, CSS, Bootstrap, Angularjs, Angular Filter & Loading Bar modules

__How to run the application__

###### Exact.CricCard.CricAPI

> > Build the project with NuGet packages.
> >Host into IIS and change the "Identity" of Application Pool to LocalSystem to access Attached Database which is in APP_DATA.
> >Change the AppSettings for CORS sites access & ConnectionStrings for Database.

###### Exact.CricCard.WebApp

> >Build the project with npm & bower
> >Change the API Host & Port in settings.js
> >Host it into IIS or Run by "npm start"
