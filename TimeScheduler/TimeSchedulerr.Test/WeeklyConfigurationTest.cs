using Xunit;

namespace TimeScheduler.Test
{
    public class WeeklyConfigurationTest
    {
        private Scheduler scheduler;

        [Fact]
        public void validate_next_weekly_configuration_times_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.scheduler.SchedulerConfiguration.EveryType = "hours";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Weekly times is null.", exception.Message);
        }

        [Fact]
        public void validate_next_weekly_configuration_times_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.scheduler.SchedulerConfiguration.EveryType = "hours";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EveryTimesWeekly = string.Empty;

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Weekly times is empty.", exception.Message);
        }

        [Fact]
        public void validate_next_weekly_configuration_times_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.scheduler.SchedulerConfiguration.EveryType = "hours";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EveryTimesWeekly = "none";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Weekly times bad format.", exception.Message);
        }

        [Fact]
        public void validate_next_weekly_configuration_times_negative()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.scheduler.SchedulerConfiguration.EveryType = "hours";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EveryTimesWeekly = "-1";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Weekly times negative.", exception.Message);
        }

        [Fact]
        public void validate_next_weekly_configuration_week_days_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.scheduler.SchedulerConfiguration.EveryType = "hours";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EveryTimesWeekly = "1";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Week days is empty.", exception.Message);
        }

        [Fact]
        public void validate_next_weekly_configuration_week_days_length()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.scheduler.SchedulerConfiguration.EveryType = "hours";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EveryTimesWeekly = "1";

            Assert.Equal(7, this.scheduler.SchedulerConfiguration.WeekDays.Length);           
        }
    }
}
