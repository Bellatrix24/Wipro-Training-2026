using System;

namespace Day03Practice
{
    class TimeZonePractice
    {
        static void Main(string[] args)
        {
            // 1. Get the current system time
            DateTime localTime = DateTime.Now;
            Console.WriteLine("My System Time: " + localTime);

            // 2. We use TimeZoneInfo to find the specific city's timezone
            // London - GMT Standard Time
            TimeZoneInfo londonZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            DateTime londonTime = TimeZoneInfo.ConvertTime(localTime, londonZone);
            Console.WriteLine("Current Time in London: " + londonTime);

            // 3. Tokyo - Tokyo Standard Time
            TimeZoneInfo tokyoZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            DateTime tokyoTime = TimeZoneInfo.ConvertTime(localTime, tokyoZone);
            Console.WriteLine("Current Time in Tokyo: " + tokyoTime);

            // Simple footer
            Console.WriteLine("\nConversion done. Practice complete!");
        }
    }
}
