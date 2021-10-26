using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeScheduler.Test
{
    [TestClass]
    public class WeeklyConfigurationTest
    {
        private SchedulerController schedulerController;

        [TestMethod]
        public void validate_next_weekly_configuration_times_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.DailyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.DailyConfiguration.EveryType = "hours";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_weekly_configuration_times_empty()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.DailyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.DailyConfiguration.EveryType = "hours";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.WeeklyConfiguration.EveryTimes = string.Empty;
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_weekly_configuration_times_bad_format()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.DailyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.DailyConfiguration.EveryType = "hours";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.WeeklyConfiguration.EveryTimes = "none";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_weekly_configuration_times_negative()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.DailyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.DailyConfiguration.EveryType = "hours";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.WeeklyConfiguration.EveryTimes = "-1";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_weekly_configuration_week_days_null()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.DailyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.DailyConfiguration.EveryType = "hours";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.WeeklyConfiguration.EveryTimes = "1";
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }

        [TestMethod]
        public void validate_next_weekly_configuration_week_days_length()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.DailyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.DailyConfiguration.EveryType = "hours";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.WeeklyConfiguration.EveryTimes = "1";
            Assert.AreEqual(7, this.schedulerController.Scheduler.WeeklyConfiguration.WeekDays.Length);
            Assert.ThrowsException<TimeSchedulerException>(() => this.schedulerController.GetNextExecution());
        }
    }
}
