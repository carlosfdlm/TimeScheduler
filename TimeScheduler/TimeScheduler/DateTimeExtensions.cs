using System;

namespace TimeScheduler
{
    public static class DateTimeExtensions
    {
        public static DateTime ChangeTime(this DateTime dateTime, TimeSpan timeSpan)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                timeSpan.Hours,
                timeSpan.Minutes,
                timeSpan.Seconds,
                timeSpan.Milliseconds,
                dateTime.Kind);
        }
    }
}
