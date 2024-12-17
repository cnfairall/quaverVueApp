## C# Hall of Fame

Have you ever wondered what the top 100 most-starred Github repositories written in C# are? This app delivers and saves this information to your MySQL server!
  
## Features
- Consumes Github's API to fetch the top 100 most-starred Github repositories written in C#
- Creates a schema on your local database
- Saves repo data
- Launches a UI in browser for you to view repos and their details
- View name, owner name, github id, URL, description, number of stars (stargazer count), dates of initial creation and last push for each repo

## Architecture
- Built from ASP.Net WebApi/SPA template, using Vite and Vue.js
- Installed Entity Framework Core 8.0.8 to enable creation of database context and migration
- On application start up:
    - services are configured to add the database context created with EF Core and to connect with user's MySQL server
    - An EF Core migration bundle, stored in an .exe file, is run, which creates the schema on the local database if         not already created
    - Service method is called to fetch repo data from Github API, and post data to local database
- Vue frontend accesses app server controllers to fetch data to populate views
- Home page displays index of the top 100 most-starred Github repositories written in C#, in order from most to least starred
- Using vue router, clicking details link mounts detail component, displaying more information for selected repo, including URL and description.
- Clicking back to list link remounts index view

## Installation
- Clone this repo
- In your appsettings.json file, edit your connection string to input your MySQL server instance values
  `` {
  "ConnectionStrings": {
    "QuaverEd_AppDbConnection": "Server=localhost;Database=quavertestdb;User=<user>;Password=<yourpassword>;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
} ``
- Open .sln file in Visual Studio
- install npm
- click green start button with https selected
- in command window that opens, ctrl + click link to frontend

## Contributors
- [Courtney Fairall](https://github.com/cnfairall)
