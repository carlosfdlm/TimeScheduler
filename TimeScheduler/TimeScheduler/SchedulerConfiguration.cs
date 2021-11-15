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
        public int NumDays { get; set; }
        public ExecutionType ExecutionType { get; set; }

        #endregion GeneralConfiguration

        #region DailyConfiguration

        public bool OccursEvery { get; set; }
        public bool OccursOnce { get; set; }
        public DateTime OccursOnceTime { get; set; }
        public TimeUnit TimeUnit { get; set; }
        public int EveryTimes { get; set; }
        public DateTime StartingAt { get; set; }
        public DateTime EndAt { get; set; }

        #endregion DailyConfiguration


        #region WeeklyConfiguration

        public int EveryTimesWeek { get; set; }

        public bool MondayEnabled { get; set; }
        public bool TuesdayEnabled { get; set; }
        public bool WednesdayEnabled { get; set; }
        public bool ThursdayEnabled { get; set; }
        public bool FridayEnabled { get; set; }
        public bool SaturdayEnabled { get; set; }
        public bool SundayEnabled { get; set; }

        #endregion WeeklyConfiguration

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
}
