using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logzio.NLog.Extensions.Tests
{
    [TestClass]
    public class LogzioNLogExtensionsTests
    {
        [TestMethod]
        public void LogzioNLogLoggerExtensionsWithConfigurationAddsLogProvider()
        {
            var serviceCollection = new ServiceCollection();
            var configuration = new ConfigurationBuilder().Build();

            var provider = serviceCollection
                .AddLogging(builder => builder.AddLogzioNLog(configuration))
                .BuildServiceProvider();

            var loggerProvider = provider.GetRequiredService<ILoggerProvider>();

            Assert.IsNotNull(loggerProvider);
        }

        [TestMethod]
        public void LogzioNLogLoggerExtensionsWithConfigurationSectionAddsLogProvider()
        {
            var serviceCollection = new ServiceCollection();
            var configuration = new ConfigurationBuilder().Build();

            var provider = serviceCollection
                .AddLogging(builder => builder.AddLogzioNLog(configuration.GetSection("test")))
                .BuildServiceProvider();

            var loggerProvider = provider.GetRequiredService<ILoggerProvider>();

            Assert.IsNotNull(loggerProvider);
        }

        [TestMethod]
        public void LogzioNLogLoggerExtensionsWithOptionsAddsLogProvider()
        {
            var serviceCollection = new ServiceCollection();
            var provider = serviceCollection
                .AddLogging(builder => builder.AddLogzioNLog(new Options
                {
                    BufferSize = 100,
                    BufferTimeOut = TimeSpan.FromSeconds(5),
                    IsDebug = false,
                    ListenerUrl = "https://listener.logz.io:1234",
                    LogzioType = "nlog",
                    Name = "Logzio",
                    RetriesMaxAttempts = 3,
                    RetriesInterval = TimeSpan.FromSeconds(2),
                    Token = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                }))
                .BuildServiceProvider();

            var loggerProvider = provider.GetRequiredService<ILoggerProvider>();

            Assert.IsNotNull(loggerProvider);
        }
    }
}