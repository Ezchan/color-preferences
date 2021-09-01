# color-preferences

This project uses .NET CORE, Angular 8, Entity Framework, Bootstrap, and SQL for the db

If you need to download the .NET CORE SDK/.NET CLI you can do so here -> https://dotnet.microsoft.com/download

### Steps to Run:

1. Clone or download the repo
2. Run `npm install` in the project root
3. Run `dotnet restore` in the project root 
4. Veirfy/change your connection string setting in the appsettings.json file and appsettings.Development.json file
5. Run `dotnet ef database update` to run the db migrations and load your db with seed data
6. Run `dotnet watch run` from the project root
