using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeScheduler.Test
{
    public class WeeklyConfigurationTest
    {
        private SchedulerController schedulerController;

        [TestMethod]
        public void validate_next_weekly_configuration_times_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryType = "hours";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_weekly_configuration_times_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryType = "hours";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = string.Empty;

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_weekly_configuration_times_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryType = "hours";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "none";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_weekly_configuration_times_negative()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryType = "hours";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "-1";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_weekly_configuration_week_days_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryType = "hours";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "1";

            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_weekly_configuration_week_days_length()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryType = "hours";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "1";

            Assert.AreEqual(7, this.schedulerController.Scheduler.SchedulerConfiguration.WeekDays.Length);
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }
    }
}
