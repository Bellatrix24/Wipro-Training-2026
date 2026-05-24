using System;
using SolidDesignPatterns.SOLID.Interfaces;
using SolidDesignPatterns.SOLID.Models;

namespace SolidDesignPatterns.SOLID.Services
{
    /// <summary>
    /// Implements DIP: Depends solely on abstractions, injected via constructor.
    /// Coordinates generating, formatting, and saving reports.
    /// </summary>
    public class ReportService
    {
        private readonly IReportGenerator _generator;
        private readonly IReportFormatter _formatter;
        private readonly IReportSaver _saver;

        public ReportService(IReportGenerator generator, IReportFormatter formatter, IReportSaver saver)
        {
            _generator = generator ?? throw new ArgumentNullException(nameof(generator));
            _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
            _saver = saver ?? throw new ArgumentNullException(nameof(saver));
        }

        /// <summary>
        /// Generates content, formats it, and saves it. Returns true if successful.
        /// </summary>
        public bool CreateAndSaveReport(Report report, string fileName)
        {
            if (report == null || string.IsNullOrWhiteSpace(fileName))
            {
                return false;
            }

            try
            {
                // Generate raw content (Generator dependency)
                string rawContent = _generator.Generate(report);

                // Format the report (Formatter dependency)
                string formattedReport = _formatter.Format(report);

                // Save report content (Saver dependency)
                return _saver.Save(formattedReport, fileName);
            }
            catch
            {
                return false;
            }
        }
    }
}
