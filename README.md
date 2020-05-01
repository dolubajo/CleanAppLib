Publishing this package

https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package-using-the-dotnet-cli


Each build creates a new nupkg file ready for publishing

Publish to nuget
dotnet nuget push CleanAppLib.1.1.0.nupkg -k <KEY_HERE> -s https://api.nuget.org/v3/index.json