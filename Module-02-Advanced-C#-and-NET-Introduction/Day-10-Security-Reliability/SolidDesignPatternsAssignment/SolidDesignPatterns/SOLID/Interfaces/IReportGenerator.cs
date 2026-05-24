using System;
using SolidDesignPatterns.SOLID.Models;

namespace SolidDesignPatterns.SOLID.Interfaces
{
    /// <summary>
    /// ISP Interface for report content generation.
    /// </summary>
    public interface IReportGenerator
    {
        string Generate(Report report);
    }
}
