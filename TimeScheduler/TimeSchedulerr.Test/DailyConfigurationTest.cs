using Xunit;

namespace TimeScheduler.Test
{
    public class DailyConfigurationTest
    {
        private Scheduler scheduler;

        [Fact]
        public void validate_next_daily_configuration_occurs_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Occurs is null.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_occurs_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = string.Empty;
            this.scheduler.SchedulerConfiguration.OccursOnce = string.Empty;

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Occurs is empty.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_occurs_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursOnce = "none";
            this.scheduler.SchedulerConfiguration.OccursEvery = "none";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Occurs bad format.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_occurs_false()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "false";
            this.scheduler.SchedulerConfiguration.OccursOnce = "false";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Occurs is two times false.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_occurs_true()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Occurs is two times true.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_occurs_once_time_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.scheduler.SchedulerConfiguration.OccursEvery = "none";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Occurs once time is null.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_occurs_once_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.scheduler.SchedulerConfiguration.OccursEvery = "false";
            this.scheduler.SchedulerConfiguration.OccursOnceTime = string.Empty;

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Occurs once time is empty.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_occurs_once_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.scheduler.SchedulerConfiguration.OccursOnceTime = "none";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Occurs once time bad format.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_occurs_every_times_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Occurs every times is null.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_occurs_every_times_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryTimes = string.Empty;

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Occurs every times is empty.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_occurs_every_times_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryTimes = "none";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Occurs every times bad format.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_occurs_every_times_negative()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryTimes = "-1";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Occurs every times is negative.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_occurs_every_mode_null()
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

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Occurs every type is null.", exception.Message);
        }


        [Fact]
        public void validate_next_daily_configuration_occurs_every_mode_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryTimes = "1";
            this.scheduler.SchedulerConfiguration.EveryType = string.Empty;

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Occurs every type is empty.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_occurs_every_mode_bad_format()
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
            this.scheduler.SchedulerConfiguration.EveryType = "none";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Occurs every type bad format.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_starting_time_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.scheduler.SchedulerConfiguration.OccursOnceTime = "00:00:00";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Start time is null.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_starting_time_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.scheduler.SchedulerConfiguration.OccursOnceTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.StartTime = string.Empty;

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Start time is empty.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_starting_time_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.scheduler.SchedulerConfiguration.OccursOnceTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.StartTime = "none";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Start time bad format.", exception.Message);
        }


        [Fact]
        public void validate_next_daily_configuration_end_time_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.scheduler.SchedulerConfiguration.OccursOnceTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("End time is null.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_end_time_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.scheduler.SchedulerConfiguration.OccursOnceTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = string.Empty;

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("End time is empty.", exception.Message);
        }

        [Fact]
        public void validate_next_daily_configuration_end_time_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.scheduler.SchedulerConfiguration.OccursOnceTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "none";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("End time bad format.", exception.Message);
        }     
    }
}
