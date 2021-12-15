using System;

namespace TimeScheduler
{
    public class SchedulerConfiguration
    {
        public SchedulerConfiguration() { }

        #region GeneralConfiguration

        public DateTime CurrentDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public bool Enabled { get; set; }
        public ExecutionType ExecutionType { get; set; }

        #endregion GeneralConfiguration
        #region DailyConfiguration
        public OccursType OccursType { get; set; }
        public bool OccursEvery { get; set; }
        public bool OccursOnce { get; set; }
        public DateTime OccursOnceTime { get; set; }
        public TimeUnit TimeUnit { get; set; }
        public int EveryTimes { get; set; }
        public DateTime StartingAt { get; set; }
        public DateTime EndAt { get; set; }

        #endregion DailyConfiguration
        #region MonthlyConfiguration

        public int MonthsDay { get; set; }
        public FrecuencyType FrecuencyType { get; set; }
        public bool DaySelector { get; set; }
        public bool WeekDaySelector { get; set; }
        public int TheDay { get; set; }
        public int EveryMonthDay { get; set; }
        public SelectedDays DayOfWeek { get; set; }
        public MonthlyType MonthlyType { get; set; }

        #endregion MonthlyConfiguration
        #region LimitsConfiguration

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        #endregion LimitsConfiguration
    }

    public enum ExecutionType
    {
        Once,
        Recurring
    }

    public enum TimeUnit
    {
        Seconds,
        Minutes,
        Hours
    }

    public enum OccursType
    {
        Once,
        Every
    }

    public enum FrecuencyType
    {
        First,
        Second,
        Third,
        Fourth,
        Last
    }

    public enum SelectedDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
        Day,
        Weekday,
        WeekendDay
    }

    public enum MonthlyType
    {
        Day,
        WeeksDay
    }

}
