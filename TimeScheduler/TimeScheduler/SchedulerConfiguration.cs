using System;
using System.Globalization;

namespace TimeScheduler
{
    public class SchedulerConfiguration
    {
        public SchedulerConfiguration() { }

        public CultureInfo CultureInfo { get; set; }

        #region GeneralConfiguration
        public DateTime CurrentDate { get; set; }
        public DateTime OnceDateTime { get; set; }
        public bool Enabled { get; set; }
        public ExecutionType ExecutionType { get; set; }
        public FrecuencyType FrecuencyType { get; set;}
        public int FrequencyDays { get; set; }
        #endregion GeneralConfiguration

        #region DailyConfiguration
        public OccursType OccursType { get; set; }
        public TimeSpan OccursOnceTime { get; set; }
        public TimeUnit TimeUnit { get; set; }
        public int TimeUnitFrequency { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        #endregion DailyConfiguration

        #region WeeklyConfiguration
        public int WeekFrequency { get; set; }
        public bool MondayEnabled { get; set; }
        public bool TuesdayEnabled { get; set; }
        public bool WednesdayEnabled { get; set; }
        public bool ThursdayEnabled { get; set; }
        public bool FridayEnabled { get; set; }
        public bool SaturdayEnabled { get; set; }
        public bool SundayEnabled { get; set; }
        #endregion WeeklyConfiguration

        #region MonthlyConfiguration
        public MonthlyType MonthlyType { get; set; }
        public DaysConfiguration DayOfWeek { get; set; }
        public OrdinalConfiguration OrdinalConfiguration{ get; set; }
        public int DayOfMonth   { get; set; }
        public int EveryMonth { get; set; }
        #endregion MonthlyConfiguration

        #region LimitsConfiguration
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        #endregion LimitsConfiguration
    }

  

}
