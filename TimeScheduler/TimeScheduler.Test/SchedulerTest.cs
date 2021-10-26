using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TimeScheduler.Test.Resources;

namespace TimeScheduler.Test
{
    [TestClass]
    public class SchedulerTest
    {
        private const string DESCRIPTION_ONCE = "Occurs {0}. Schedule will be used on {1} at {2} starting on {3} and ending on {4}.";
        private const string DESCRIPTION_RECURRING = "Occurs every {0} weeks on {1} {2} between {3} and {4} starting on {5} and ending on {6}.";
        private SchedulerController schedulerController;       

        [TestMethod]
        public void validate_next_execution_date_once()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00"; 
            string[] execution = this.schedulerController.GetNextExecution();
            Assert.AreEqual(execution[0], "01/01/2000 00:00:00");
            Assert.AreEqual(execution[1], Global.DescriptionOnce);
        }

        [TestMethod]
        public void validate_next_execution_date_recurring_every_hours()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.DailyConfiguration.EveryType = "hours";
            this.schedulerController.Scheduler.DailyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.WeeklyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.WeeklyConfiguration.WeekDays[0] = "true";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            string[] execution = this.schedulerController.GetNextExecution();
            Assert.AreEqual(execution[0], "02/01/2000 00:00:00");
            Assert.AreEqual(execution[1], Global.DescriptionRecurringEveryHours);
        }

        [TestMethod]
        public void validate_next_execution_date_recurring_every_minutes()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.DailyConfiguration.EveryType = "minutes";
            this.schedulerController.Scheduler.DailyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.WeeklyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.WeeklyConfiguration.WeekDays[0] = "true";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            string[] execution = this.schedulerController.GetNextExecution();
            Assert.AreEqual(execution[0], "02/01/2000 00:00:00");
            Assert.AreEqual(execution[1], Global.DescriptionRecurringEveryMinutes);
        }


        [TestMethod]
        public void validate_next_execution_date_recurring_every_seconds()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.DailyConfiguration.EveryType = "seconds";
            this.schedulerController.Scheduler.DailyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.WeeklyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.WeeklyConfiguration.WeekDays[0] = "true";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            string[] execution = this.schedulerController.GetNextExecution();
            Assert.AreEqual(execution[0], "02/01/2000 00:00:00");
            Assert.AreEqual(execution[1], Global.DescriptionRecurringEverySeconds);
        }

        [TestMethod]
        public void validate_next_execution_date_recurring_once()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.DailyConfiguration.OccursOnceTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.WeeklyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.WeeklyConfiguration.WeekDays[0] = "true";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            string[] execution = this.schedulerController.GetNextExecution();
            Assert.AreEqual(execution[0], "02/01/2000 00:00:00");
            Assert.AreEqual(execution[1], Global.DescriptionRecurringOnce);
        }

        [TestMethod]
        public void validate_next_execution_date_recurring_two_days()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.DailyConfiguration.EveryType = "seconds";
            this.schedulerController.Scheduler.DailyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.WeeklyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.WeeklyConfiguration.WeekDays[0] = "true";
            this.schedulerController.Scheduler.WeeklyConfiguration.WeekDays[1] = "true";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            string[] execution = this.schedulerController.GetNextExecution();
            Assert.AreEqual(execution[0], "02/01/2000 00:00:00");
            Assert.AreEqual(execution[1], Global.DescriptionRecurringTwoDays);
        }

        [TestMethod]
        public void validate_next_execution_date_recurring_all_days()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.GeneralConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.GeneralConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.GeneralConfiguration.CurrentDate = "01/01/2000";
            this.schedulerController.Scheduler.GeneralConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.LimitsConfiguration.StartDate = "01/01/2000";
            this.schedulerController.Scheduler.LimitsConfiguration.EndDate = "01/01/2000";
            this.schedulerController.Scheduler.DailyConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.DailyConfiguration.EveryType = "seconds";
            this.schedulerController.Scheduler.DailyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.WeeklyConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.WeeklyConfiguration.WeekDays[0] = "true";
            this.schedulerController.Scheduler.WeeklyConfiguration.WeekDays[1] = "true";
            this.schedulerController.Scheduler.WeeklyConfiguration.WeekDays[2] = "true";
            this.schedulerController.Scheduler.WeeklyConfiguration.WeekDays[3] = "true";
            this.schedulerController.Scheduler.WeeklyConfiguration.WeekDays[4] = "true";
            this.schedulerController.Scheduler.WeeklyConfiguration.WeekDays[5] = "true";
            this.schedulerController.Scheduler.WeeklyConfiguration.WeekDays[6] = "true";            
            this.schedulerController.Scheduler.DailyConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.DailyConfiguration.EndTime = "00:00:00";
            string[] execution = this.schedulerController.GetNextExecution();
            Assert.AreEqual(execution[0], "02/01/2000 00:00:00");
            Assert.AreEqual(execution[1], Global.DescriptionRecurringAllDays);
        }

    }
}
