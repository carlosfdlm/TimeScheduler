using Xunit;

namespace TimeScheduler.Test
{
    public class LimitsConfigurationTest
    {
        private Scheduler scheduler;

        [Fact]
        public void validate_start_date_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Start date is null.", exception.Message);
        }

        [Fact]
        public void validate_start_date_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.StartDate = string.Empty;

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Start date is empty.", exception.Message);
        }

        [Fact]
        public void validate_start_date_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.StartDate = "144/188/1000 00:00:00";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Start date bad format.", exception.Message);
        }

        [Fact]
        public void validate_end_date_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("End date is null.", exception.Message);
        }

        [Fact]
        public void validate_end_date_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = string.Empty;

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("End date is empty.", exception.Message);
        }

        [Fact]
        public void validate_end_date_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "144/188/1000 00:00:00";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("End date bad format.", exception.Message);
        }
    }
}
