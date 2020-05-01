Publishing this package

https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package-using-the-dotnet-cli


Each build creates a new nupkg file ready for publishing

Publish to nuget
dotnet nuget push bin/Debug/CleanAppLib.x.x.x.nupkg -k xxxKEYxHERExxx -s https://api.nuget.org/v3/index.json