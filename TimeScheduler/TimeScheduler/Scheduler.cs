namespace TimeScheduler
{
    public class Scheduler
    {
        private WeeklyConfiguration weeklyConfiguration;
        private DailyConfiguration dailyConfiguration;
        private LimitsConfiguration limitsConfiguration;
        private GeneralConfiguration generalConfiguration;

        public Scheduler() 
        {
            this.limitsConfiguration = new LimitsConfiguration();
            this.weeklyConfiguration = new WeeklyConfiguration();
            this.dailyConfiguration = new DailyConfiguration();
            this.generalConfiguration = new GeneralConfiguration();
        }

        public Execution Execution { get; set; }                 

        public WeeklyConfiguration WeeklyConfiguration
        {
            get
            {
                return this.weeklyConfiguration;
            }
        }

        public DailyConfiguration DailyConfiguration
        {
            get
            {
                return this.dailyConfiguration;
            }
        }

        public LimitsConfiguration LimitsConfiguration
        {
            get
            {
                return this.limitsConfiguration;
            }
        }

        public GeneralConfiguration GeneralConfiguration
        {
            get
            {
                return this.generalConfiguration;
            }
        }    
    }
}
