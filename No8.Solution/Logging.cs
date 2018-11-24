using NLog;

namespace No8.Solution
{
    public class Logging : ILogging
    {
        private Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Event Handler method. Write messages into log file
        /// </summary>
        /// <param name="message">Input message for logging</param>
        public void Log(object sender, LoggingEventArgs args) => log.Debug(args.message);
    }
}