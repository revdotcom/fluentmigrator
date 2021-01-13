# Migrate.exe v3.2.10

This is a build of a fork of https://github.com/fluentmigrator/fluentmigrator that is hosted here https://github.com/revdotcom/fluentmigrator

It makes a very simple change of changing how we name the default constraints. It also changes the project to use the signed packages for the parts that the revdotcom code base also uses (FluentMigrator package). It also makes some minor changes the golbal.props file as well as adding a nuspec file to package up the FluentMigrator.Console for uploading to Rev's myget.

In order to upload the FluentMigrator.Console.
1. Build the project from Visual Studio
2. Make sure the nuspec version matches the version of FluentMigrator you are packing up
3. Pack the output using the following command
`dotnet pack -p:NuspecFile=.\Rev.FluentMigrator.Console.nuspec --output Rev.FluentMigrator.Console --no-build`
4. Upload the package to myget using the following command (note you need to add the API key)
`dotnet nuget push bin/Release/FluentMigrator.Console.3.2.10.nupkg -s https://www.myget.org/F/revdotcom/auth/YOURAPIKEYHERE/api/v3/index.json`


Note:
When developing a new version make sure to add an extra dot version and add a dev post tag e.g. when working on 3.2.10 create new versions for every test like 3.2.10.1-dev. You want to create a unique version for every test to avoid issues with myget and local nuget package caching.