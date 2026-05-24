using System;
using System.IO;
using SolidDesignPatterns.SOLID.Interfaces;

namespace SolidDesignPatterns.SOLID.Services
{
    /// <summary>
    /// Implements SRP: Dedicated solely to saving text content to the filesystem.
    /// </summary>
    public class ReportSaver : IReportSaver
    {
        public bool Save(string content, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return false;
            }

            try
            {
                File.WriteAllText(fileName, content ?? string.Empty);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
