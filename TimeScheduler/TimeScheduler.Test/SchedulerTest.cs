using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TimeScheduler.Test.Resources;

namespace TimeScheduler.Test
{
    public class SchedulerTest
    {
        private const string DESCRIPTION_ONCE = "Occurs {0}. Schedule will be used on {1} at {2} starting on {3} and ending on {4}.";
        private const string DESCRIPTION_RECURRING = "Occurs every {0} weeks on {1} {2} between {3} and {4} starting on {5} and ending on {6}.";
        private SchedulerController schedulerController;       

        [TestMethod]
        public void validate_next_execution_date_once()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00"; 

            string[] execution = this.schedulerController.GetNextExecution();
            Assert.AreEqual(execution[0], "01/01/2000 00:00:00");
            Assert.AreEqual(execution[1], Global.DescriptionOnce);
        }

        [TestMethod]
        public void validate_next_execution_date_recurring_every_hours()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryType = "hours";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.WeekDays[0] = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            string[] execution = this.schedulerController.GetNextExecution();
            Assert.AreEqual(execution[0], "02/01/2000 00:00:00");
            Assert.AreEqual(execution[1], Global.DescriptionRecurringEveryHours);
        }

        [TestMethod]
        public void validate_next_execution_date_recurring_every_minutes()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryType = "minutes";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.WeekDays[0] = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            string[] execution = this.schedulerController.GetNextExecution();
            Assert.AreEqual(execution[0], "02/01/2000 00:00:00");
            Assert.AreEqual(execution[1], Global.DescriptionRecurringEveryMinutes);
        }


        [TestMethod]
        public void validate_next_execution_date_recurring_every_seconds()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryType = "seconds";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.WeekDays[0] = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            string[] execution = this.schedulerController.GetNextExecution();
            Assert.AreEqual(execution[0], "02/01/2000 00:00:00");
            Assert.AreEqual(execution[1], Global.DescriptionRecurringEverySeconds);
        }

        [TestMethod]
        public void validate_next_execution_date_recurring_once()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnce = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursOnceTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.WeekDays[0] = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            string[] execution = this.schedulerController.GetNextExecution();
            Assert.AreEqual(execution[0], "02/01/2000 00:00:00");
            Assert.AreEqual(execution[1], Global.DescriptionRecurringOnce);
        }

        [TestMethod]
        public void validate_next_execution_date_recurring_two_days()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryType = "seconds";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.WeekDays[0] = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.WeekDays[1] = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            string[] execution = this.schedulerController.GetNextExecution();
            Assert.AreEqual(execution[0], "02/01/2000 00:00:00");
            Assert.AreEqual(execution[1], Global.DescriptionRecurringTwoDays);
        }

        [TestMethod]
        public void validate_next_execution_date_recurring_all_days()
        {
            this.schedulerController = new SchedulerController();
            this.schedulerController.Scheduler.SchedulerConfiguration.Enabled = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.schedulerController.Scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000";
            this.schedulerController.Scheduler.SchedulerConfiguration.NumDays = "1";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartDate = "01/01/2000";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndDate = "01/01/2000";
            this.schedulerController.Scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryType = "seconds";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.schedulerController.Scheduler.SchedulerConfiguration.WeekDays[0] = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.WeekDays[1] = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.WeekDays[2] = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.WeekDays[3] = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.WeekDays[4] = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.WeekDays[5] = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.WeekDays[6] = "true";
            this.schedulerController.Scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.schedulerController.Scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            string[] execution = this.schedulerController.GetNextExecution();
            Assert.AreEqual(execution[0], "02/01/2000 00:00:00");
            Assert.AreEqual(execution[1], Global.DescriptionRecurringAllDays);
        }
    }
}
