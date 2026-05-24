using System;
using SolidDesignPatterns.SOLID.Models;

namespace SolidDesignPatterns.SOLID.Interfaces
{
    /// <summary>
    /// ISP Interface for report formatting behavior.
    /// Demonstrates OCP: Can implement new formatters without modifying clients.
    /// </summary>
    public interface IReportFormatter
    {
        string Format(Report report);
    }
}
