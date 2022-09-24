dotnet restore
dotnet build --no-restore
dotnet stryker -tp tests/PowerUtils.Results.Validations.Tests/PowerUtils.Results.Validations.Tests.csproj --reporter cleartext --reporter html -o