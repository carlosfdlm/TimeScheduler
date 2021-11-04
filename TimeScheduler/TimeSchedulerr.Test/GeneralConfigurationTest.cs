using Xunit;

namespace TimeScheduler.Test
{
    public class GeneralConfigurationTest
    {
        private Scheduler scheduler;

        [Fact]
        public void validate_enabled_null()
        {
            this.scheduler = new Scheduler();
            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Enabled check null.", exception.Message);
        }

        [Fact]
        public void validate_enabled_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = string.Empty;

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Enabled check empty.", exception.Message);
        }

        [Fact]
        public void validate_enabled_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "bad_format";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Enabled check bad format.", exception.Message);
        }

        [Fact]
        public void validate_enabled_false()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "false";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Enabled check is not enabled.", exception.Message);
        }

        [Fact]
        public void validate_execution_type_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Execution type is null.", exception.Message);
        }

        [Fact]
        public void validate_execution_type_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = string.Empty;

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Execution type is empty.", exception.Message);
        }

        [Fact]
        public void validate_execution_type_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Other";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Execution type bad format.", exception.Message);
        }

        [Fact]
        public void validate_current_date_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Once";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Current date is null.", exception.Message);
        }

        [Fact]
        public void validate_current_date_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.scheduler.SchedulerConfiguration.CurrentDate = string.Empty;

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Current date is empty.", exception.Message);
        }

        [Fact]
        public void validate_current_date_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.scheduler.SchedulerConfiguration.CurrentDate = "144/188/1000 00:00:00";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Current date bad format.", exception.Message);
        }

        [Fact]
        public void validate_execution_date_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Execution date is null.", exception.Message);
        }

        [Fact]
        public void validate_execution_date_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.ExecutionDate = string.Empty;

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Execution date is empty.", exception.Message);
        }

        [Fact]
        public void validate_execution_date_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.ExecutionDate = "144/188/1000 00:00:00";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Execution date bad format.", exception.Message);
        }

        [Fact]
        public void validate_num_days_null()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Num days is null.", exception.Message);
        }

        [Fact]
        public void validate_num_days_empty()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = string.Empty;

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Num days is empty.", exception.Message);
        }

        [Fact]
        public void validate_num_days_bad_format()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "mal_formato";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Num days bad format.", exception.Message);
        }

        [Fact]
        public void validate_num_days_less_than_zero()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "-1";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Num days is negative.", exception.Message);
        }


        [Fact]
        public void validate_next_execution_date_max_date()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/9900 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "999999";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";

            var exception = Assert.Throws<TimeSchedulerException>(() => this.scheduler.GetNextExecution());
            Assert.Equal("Next execution date is max date.", exception.Message);
        }
    }
}
