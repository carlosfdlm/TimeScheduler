using Xunit;

namespace TimeScheduler.Test
{
    public class GeneralConfigurationTest
    {
        private SchedulerController schedulerController;

        [Fact]
        public void validate_enabled_null()
        {
            this.schedulerController = new SchedulerController();
            var exception = Assert.Throws<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
            Assert.Equal("Enabled check7 null", exception.Message);
        }

        //[Fact]
        //public void validate_enabled_empty()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = string.Empty;

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_enabled_bad_format()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "bad_format";

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_enabled_false()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "false";

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_execution_type_null()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_execution_type_empty()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = string.Empty;

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_execution_type_bad_format()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Other";

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_current_date_null()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_current_date_empty()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = string.Empty;

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_current_date_bad_format()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "144/188/1000 00:00:00";

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_current_date_max_value()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/10000 00:00:00";

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_current_date_min_value()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/0000 00:00:00";

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_execution_date_null()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_execution_date_empty()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionDate = string.Empty;

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_execution_date_bad_format()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionDate = "144/188/1000 00:00:00";

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_execution_date_max_value()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionDate = "01/01/10000 00:00:00";

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_execution_date_min_value()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionDate = "01/01/0000 00:00:00";

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_num_days_null()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_num_days_empty()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = string.Empty;

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_num_days_bad_format()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "mal_formato";

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_num_days_less_than_zero()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "-1";

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

        //[TestMethod]
        //public void validate_start_date_null()
        //{
        //    this.schedulerController = new SchedulerController();
        //    this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
        //    this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";

        //    Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        //}

    }
}
