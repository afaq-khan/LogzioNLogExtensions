# Logzio.NLog.Extensions
[![Nuget](https://img.shields.io/nuget/v/Logzio.NLog.Extensions?style=plastic)](https://www.nuget.org/packages/Logzio.NLog.Extensions)

A logging extension to simplify configuration of [Logz.io's NLog package](https://www.nuget.org/packages/Logzio.DotNet.NLog) for sending log entries to Logz.io

Install the package from the Package Manager Console:

    Install-Package Logzio.NLog.Extensions

## Configuration
### appsettings.json
```json

{
  "Logging": {
    "LogLevel": {
      "Default": "__Logging.LogLevel.Default__"
    },
    "LogzioNLog": {
      "Options": {
        "Name": "__LogzioNLog.Options.Name__",
        "Token": "__LogzioNLog.Options.Token__",
        "LogzioType": "__LogzioNLog.Options.LogzioType__",
        "ListenerUrl": "__LogzioNLog.Options.ListenerUrl__",
        "BufferSize": "__LogzioNLog.Options.BufferSize__",
        "BufferTimeout": "__LogzioNLog.Options.BufferTimeout__",
        "RetriesMaxAttempts": "__LogzioNLog.Options.RetriesMaxAttempts__",
        "RetriesInterval": "__LogzioNLog.Options.RetriesInterval__",
        "Debug": "__LogzioNLog.Options.Debug__"
      }
    }
  }
}
```
### Code
```csharp
IServiceCollection services = new ServiceCollection();
services.AddLogging(builder =>
    builder.AddLogzioNLog(
        configuration.GetSection("Logging").GetSection("LogzioNLog").GetSection("Options")));
```
