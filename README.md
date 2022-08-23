# MultipleDbProvider

## Creating Migrations 

#### Prerequisite
- You must have dotnet ef tools globally installed.
```
dotnet tool install --global dotnet-ef
```

#### Steps to Add Migrations for Sql Server

- Open Terminal in root folder "MultipleDbProviderDemo"
- Run migration command for Sql Server
```
dotnet ef migrations add "Initial Db" -s "MultipleDbProvider" -p "MultipleDbProvider.Infrastructure.SqlServerMigrations"   -- --provider SqlServer
```
- This will create migrations in project "MultipleDbProvider.Infrastructure.SqlServerMigrations".


#### Steps to Add Migrations for Post Gre SQL 
- Open Terminal in root folder "MultipleDbProviderDemo"
- Run migration command for Post Gre SQL 
```
dotnet ef migrations add "Initial Db" -s "MultipleDbProvider" -p "MultipleDbProvider.Infrastructure.PostGreMigrations"  -- --provider PostGreSql
```
- This will create migrations in project "MultipleDbProvider.Infrastructure.PostGreMigrations".


## Running the project
- Change the appsettings.json to use sqlserver or postgresql as default provider.
- Change the connection string accordingly.
- Build and Run the Project using VS.
- Browse to api [Get Products API](https://localhost:7068/api/Products)

# References
[Managing Multiple Providers (Microsoft Docs)](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/providers?tabs=dotnet-core-cli)

# Thank you!
