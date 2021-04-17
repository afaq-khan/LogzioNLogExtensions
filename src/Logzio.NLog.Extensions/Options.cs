using System;

namespace Logzio.NLog.Extensions
{
    public class Options
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public string LogzioType { get; set; }
        public string ListenerUrl { get; set; }
        public int BufferSize { get; set; }
        public TimeSpan BufferTimeOut { get; set; }
        public int RetriesMaxAttempts { get; set; }
        public TimeSpan RetriesInterval { get; set; }
        public bool IsDebug { get; set; }
    }
}