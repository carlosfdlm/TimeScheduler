namespace TimeScheduler
{
    public class SchedulerConfiguration
    {
        private string[] weekDays;

        public SchedulerConfiguration() 
        {
            this.weekDays = new string[7] { "", "", "", "", "", "", "" };
        }

        #region GeneralConfiguration

        public string CurrentDate { get; set; }
        public string ExecutionDate { get; set; }
        public string Enabled { get; set; }
        public string NumDays { get; set; }
        public string ExecutionType { get; set; }

        #endregion GeneralConfiguration

        #region DailyConfiguration

        public string OccursEvery { get; set; }
        public string OccursOnce { get; set; }
        public string OccursOnceTime { get; set; }
        public string EveryType { get; set; }
        public string EveryTimes { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        #endregion DailyConfiguration


        #region WeeklyConfiguration

        public string EveryTimesWeekly { get; set; }

        public string[] WeekDays
        {
            get
            {
                return this.weekDays;
            }
            set
            {
                this.weekDays = value;
            }
        }
        #endregion WeeklyConfiguration

        #region LimitsConfiguration

        public string StartDate { get; set; }
        public string EndDate { get; set; }

        #endregion LimitsConfiguration
    }
}
