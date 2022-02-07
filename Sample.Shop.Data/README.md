# Database Class Library

## Overview

This class library holds the database schema and migrations. This class library will be referenced by other projects which needs to communicate with the postgres DB.

### Handle Migrations

Whenever there is any change in the DB Schema (Models), we need to create the migration scripts.

To create a migration script after modifying an exiting table,
- Open terminal and go to `Sample.Shop.Data/`
- Then run `dotnet ef migrations add <MigrationName> --startup-project <startup-project-path>`
For eg: 
```csharp
dotnet ef migrations add AddedModifiedDate --startup-project ../Sample.Shop.WebApi/Sample.Shop.WebApi.csproj
```

To changing connection string of database, 
-Update connection string inside 'appsettings.json' file of <startup-project>.

To remove a last migration script
-Sometimes you add a migration and realize you need to make additional changes to your EF Core model before applying it. To remove the last migration, use this command.
```csharp
dotnet ef migrations remove --startup-project ../Sample.Shop.WebApi/Sample.Shop.WebApi.csproj
```

To update dtabase
- Open terminal and go to `Sample.Shop.Data/`
- Then run `dotnet ef database update --startup-project <startup-project-path>`

```csharp
dotnet ef database update --startup-project ..\Sample.Shop.WebApi\Sample.Shop.WebApi.csproj
```