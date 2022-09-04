# Blank-of-the-day web application

This web app combines various APIs from the web and assembles them into a simple interface. 

The APIs fetch data for "blanks" of the day (e.g. word of the day, quote of the day, joke of the day, etc.

The API requests are cached and set to expire at midnight, so each day has a new set of items. 

This is a hobby project written with .NET 6, using C# and Razor pages. 


## Development

The web app has been developed in VS Code and deployed as an Azure App service. 

API Keys are required for API-Ninjas and Unsplash. As of writing this, they are free, but subject to request limits. These must be added to an appsettings.Production.json file.

To deploy:
- Have the Azure App service package installed in VS code
- Run `dotnet publish -c Release -o ./bin/Publish`
- Right-click the publish folder and deploy to the app service



## APIs used

Most data comes from [API Ninjas](https://api-ninjas.com/)

Photos come from [Unsplash](https://api-ninjas.com/)

## Possible Future ideas
- Add in Unit tests
- Better Error handling and logging
- More variety of dailies (Nutrition tips, artwork)
- Find better sources for some of the dailies (e.g. word of the day)
- Do some language filtering on the jokes
- Add a database to store the dailies
- Add user-based functionality, so users could save favourites for a more customized experience
