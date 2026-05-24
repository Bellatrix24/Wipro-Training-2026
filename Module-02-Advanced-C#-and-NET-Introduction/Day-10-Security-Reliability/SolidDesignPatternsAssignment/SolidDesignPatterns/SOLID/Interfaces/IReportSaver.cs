using System;

namespace SolidDesignPatterns.SOLID.Interfaces
{
    /// <summary>
    /// ISP Interface for report persistence saving behavior.
    /// </summary>
    public interface IReportSaver
    {
        bool Save(string content, string fileName);
    }
}
