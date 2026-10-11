# MultipleDbProvider

A .NET demonstration project showing how to manage **multiple Entity Framework Core database providers** in a single application using separate migration projects for Microsoft SQL Server and PostgreSQL.

This approach allows the application to use different database providers while keeping their database migrations isolated and independently managed.

## Table of Contents

- [Overview](#overview)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Creating Database Migrations](#creating-database-migrations)
  - [Microsoft SQL Server](#microsoft-sql-server)
  - [PostgreSQL](#postgresql)
- [Running the Application](#running-the-application)
- [API Endpoint](#api-endpoint)
- [References](#references)
- [Author](#author)

## Overview

The project demonstrates how to configure Entity Framework Core to support multiple database providers, with a dedicated migration project for each provider.

Supported database providers:

- **Microsoft SQL Server**
- **PostgreSQL**

### Migration Projects

| Database Provider | Migration Project |
|---|---|
| Microsoft SQL Server | `MultipleDbProvider.Infrastructure.SqlServerMigrations` |
| PostgreSQL | `MultipleDbProvider.Infrastructure.PostGreMigrations` |

Each migration project maintains its own database migration history, allowing schema changes to be generated separately for each provider.

## Project Structure

The solution contains the main application project and separate migration projects for each supported database provider.

```text
MultipleDbProviderDemo/
├── MultipleDbProvider/
├── MultipleDbProvider.Infrastructure.SqlServerMigrations/
└── MultipleDbProvider.Infrastructure.PostGreMigrations/
```

*Note: This tree illustrates the project layout based on the project names used in the migration commands.*

## Prerequisites

Before getting started, ensure you have:

- The required .NET SDK installed.
- Visual Studio or another compatible .NET development environment.
- Access to a Microsoft SQL Server or PostgreSQL instance.
- The Entity Framework Core CLI tool (`dotnet-ef`) installed globally.

Install the EF Core CLI tool using:

```bash
dotnet tool install --global dotnet-ef
```

If it is already installed, you can update it with:

```bash
dotnet tool update --global dotnet-ef
```

## Creating Database Migrations

Open a terminal in the solution's root directory:

```text
MultipleDbProviderDemo
```

Choose the appropriate command based on the database provider for which you want to generate migrations.

### Microsoft SQL Server

Run the following command to create a migration for SQL Server:

```bash
dotnet ef migrations add "Initial Db" \
  -s "MultipleDbProvider" \
  -p "MultipleDbProvider.Infrastructure.SqlServerMigrations" \
  -- --provider SqlServer
```

This generates the migration in the `MultipleDbProvider.Infrastructure.SqlServerMigrations` project.

### PostgreSQL

Run the following command to create a migration for PostgreSQL:

```bash
dotnet ef migrations add "Initial Db" \
  -s "MultipleDbProvider" \
  -p "MultipleDbProvider.Infrastructure.PostGreMigrations" \
  -- --provider PostGreSql
```

This generates the migration in the `MultipleDbProvider.Infrastructure.PostGreMigrations` project.

### Adding Subsequent Migrations

For future schema changes, replace `Initial Db` with a descriptive migration name, for example:

```text
AddProductDescription
```

Generate migrations separately for each database provider to keep their schemas synchronized with the application's model changes.

> **Note:** Creating a migration generates migration files; it does not automatically apply the changes to the database.

## Running the Application

Follow these steps to run the project:

1. Open the solution in Visual Studio.
2. Update `appsettings.json` to select the desired database provider.
3. Configure the connection string for the selected database.
4. Build the solution.
5. Run the `MultipleDbProvider` project.

Ensure that the configured database is accessible and that the appropriate migrations have been applied before testing database-dependent endpoints.

## API Endpoint

Once the application is running, access the Products API using the following endpoint:

**GET Products**

[https://localhost:7068/api/Products](https://localhost:7068/api/Products)

*The URL assumes the application is configured to use HTTPS on port `7068`.*

## References

- [Managing Migrations for Multiple Providers — Microsoft Learn](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/providers)

## Author

**Sanjit Raj Shakya**

Website: [https://sanjitrajshakya.com.np](https://sanjitrajshakya.com.np)

---

If you find this project useful, feel free to explore, learn, and build upon it.

**Thank you!**
