using Logzio.DotNet.NLog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Targets;
using LogLevel = NLog.LogLevel;

namespace Logzio.NLog.Extensions
{
    public static class ConfigureExtensions
    {
        public static ILoggingBuilder AddLogzioNLog(this ILoggingBuilder builder,
            IConfigurationRoot configuration)
        {
            var options = new Options();
            configuration.GetSection("Logging").GetSection("LogzioNLog").GetSection("Options").Bind(options);

            return AddLogzioNLog(builder, options);
        }

        public static ILoggingBuilder AddLogzioNLog(this ILoggingBuilder builder,
            IConfigurationSection configurationSection)
        {
            var options = new Options();
            configurationSection.Bind(options);

            return AddLogzioNLog(builder, options);
        }

        public static ILoggingBuilder AddLogzioNLog(this ILoggingBuilder builder, Options options)
        {
            builder.AddNLog();

            var target = GetTarget(options);
            SetLoggingConfiguration(target);

            return builder;
        }

        private static Target GetTarget(Options options)
        {
            var target = new LogzioTarget
            {
                Name = options.Name,
                Token = options.Token,
                LogzioType = options.LogzioType,
                ListenerUrl = options.ListenerUrl,
                BufferSize = options.BufferSize,
                BufferTimeout = options.BufferTimeOut,
                RetriesMaxAttempts = options.RetriesMaxAttempts,
                RetriesInterval = options.RetriesInterval,
                Debug = options.Debug,
                JsonKeysCamelCase = options.JsonKeysCamelCase
            };

            return target;
        }

        private static void SetLoggingConfiguration(Target target)
        {
            var loggingConfiguration = new LoggingConfiguration();
            loggingConfiguration.AddRule(LogLevel.Debug, LogLevel.Fatal, target);
            LogManager.Configuration = loggingConfiguration;
        }
    }
}