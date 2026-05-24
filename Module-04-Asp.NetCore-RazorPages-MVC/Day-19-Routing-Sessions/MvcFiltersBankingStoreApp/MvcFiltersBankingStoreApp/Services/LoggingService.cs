using System;
using System.Collections.Generic;

namespace MvcFiltersBankingStoreApp.Services
{
    public class LoggingService
    {
        public static List<string> RequestLogs { get; } = new List<string>();
        public static List<string> UserActionLogs { get; } = new List<string>();
        public static List<string> ExceptionLogs { get; } = new List<string>();

        public void LogRequest(string url, string method, int statusCode)
        {
            var log = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {method} {url} - Status: {statusCode}";
            RequestLogs.Add(log);
        }

        public void LogUserAction(string userId, string action, DateTime timestamp)
        {
            var log = $"[{timestamp:yyyy-MM-dd HH:mm:ss}] User: {userId} - Action: {action}";
            UserActionLogs.Add(log);
        }

        public void LogException(string message, string stackTrace)
        {
            var log = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error: {message} | Stack: {stackTrace}";
            ExceptionLogs.Add(log);
        }
    }
}
