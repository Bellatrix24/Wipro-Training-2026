using System;
using System.IO;

namespace SecureReliableUserManagement.Services
{
    /// <summary>
    /// Implements simple, reliable file-based logging.
    /// Handles file appending safely and avoids crashing application upon filesystem failure.
    /// </summary>
    public class FileLogger
    {
        private const string LogFileName = "app-log.txt";
        private static readonly object _fileLock = new object();

        /// <summary>
        /// Logs informational messages to the application-log file.
        /// </summary>
        public void LogInfo(string message)
        {
            try
            {
                string logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [INFO] {message}";
                WriteToFile(logLine);
            }
            catch
            {
                // Suppressed to guarantee logging itself never crashes the application
            }
        }

        /// <summary>
        /// Logs error messages along with exception details.
        /// </summary>
        public void LogError(string message, Exception ex)
        {
            try
            {
                string logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [ERROR] {message}";
                if (ex != null)
                {
                    logLine += $" | Exception Type: {ex.GetType().FullName} | Exception Message: {ex.Message} | StackTrace: {ex.StackTrace}";
                }
                WriteToFile(logLine);
            }
            catch
            {
                // Suppressed to guarantee logging itself never crashes the application
            }
        }

        /// <summary>
        /// Appends text line thread-safely to app-log.txt.
        /// </summary>
        private void WriteToFile(string line)
        {
            lock (_fileLock)
            {
                File.AppendAllLines(LogFileName, new[] { line });
            }
        }
    }
}
