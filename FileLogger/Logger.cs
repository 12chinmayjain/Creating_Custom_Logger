namespace Checking_Logger_Checking_Singleton.FileLogger
{
    public class Logger
    {
        private Logger()
        {
            logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "log.txt");

            // Ensure directory exists
            var logDir = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }
        }

        private static readonly Lazy<Logger> logger = new Lazy<Logger>(() => new Logger());

        public static Logger Instance => logger.Value;

        private readonly string logFilePath;

        public void Log(string message) 
        {
            var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }
    }
}
