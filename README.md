$ dotnet new console

$ dotnet add package NAudio

# edit your .csproj file and change the TargetFramework element to include -windows. Here's what the .csproj TargetFramework line might look like after the change:
<TargetFramework>net5.0-windows</TargetFramework>

# Write code

$ dotnet run


