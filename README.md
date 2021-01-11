# Migrate.exe v3.2.10.1 (fork of v3.2.10)

This is a build of a fork of https://github.com/fluentmigrator/fluentmigrator that is hosted here https://github.com/revdotcom/fluentmigrator

It makes a very simple change of changing how we name the default constraints. It also changes the project to use the signed packages for the parts that the revdotcom code base also uses (FluentMigrator package). It also changes the global.props to point the user back to here for future discovery.

You should upload new versions to myget with the following commands. Replaces the version with the version you are basing the package on.

From the each folder, in order, run the following. FluentMigrator.SqlServer => FluentMigrator.Runner => FluentMigrator.Console

`dotnet pack -c Release --include-symbols /p:SymbolPackageFormat=snupkg`

` dotnet nuget push bin/Release/FluentMigrator.Console.3.2.10.1.nupkg -s https://www.myget.org/F/revdotcom/auth/YOURAPIKEYHERE/api/v3/index.json`