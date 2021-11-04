using Xunit;
using TimeScheduler.Test.Resources;

namespace TimeScheduler.Test
{
    public class SchedulerTest
    {
        private Scheduler scheduler;

        [Fact]
        public void validate_next_execution_date_once()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Once";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.ExecutionDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";

            string[] execution = this.scheduler.GetNextExecution();
            Assert.Equal ("01/01/2000 00:00:00", execution[0]);
            Assert.Equal(execution[1], Global.DescriptionOnce);
        }

        [Fact]
        public void validate_next_execution_date_recurring_every_hours()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryType = "hours";
            this.scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EveryTimesWeekly = "2";
            this.scheduler.SchedulerConfiguration.WeekDays[0] = "true";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            string[] execution = this.scheduler.GetNextExecution();
            Assert.Equal("02/01/2000 00:00:00", execution[0]);
            Assert.Equal(Global.DescriptionRecurringEveryHours, execution[1]);
        }

        [Fact]
        public void validate_next_execution_date_recurring_every_minutes()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryType = "minutes";
            this.scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EveryTimesWeekly = "2";
            this.scheduler.SchedulerConfiguration.WeekDays[0] = "true";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            string[] execution = this.scheduler.GetNextExecution();
            Assert.Equal("02/01/2000 00:00:00", execution[0]);
            Assert.Equal(Global.DescriptionRecurringEveryMinutes, execution[1]);
        }


        [Fact]
        public void validate_next_execution_date_recurring_every_seconds()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryType = "seconds";
            this.scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EveryTimesWeekly = "2";
            this.scheduler.SchedulerConfiguration.WeekDays[0] = "true";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            string[] execution = this.scheduler.GetNextExecution();
            Assert.Equal("02/01/2000 00:00:00", execution[0]);
            Assert.Equal(Global.DescriptionRecurringEverySeconds, execution[1]);
        }

        [Theory]
        [InlineData(0, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday once at 00:00:00 between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(1, "02/01/2000 00:00:00", "Occurs every 2 weeks on tuesday once at 00:00:00 between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(2, "02/01/2000 00:00:00", "Occurs every 2 weeks on wednesday once at 00:00:00 between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(3, "02/01/2000 00:00:00", "Occurs every 2 weeks on thursday once at 00:00:00 between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(4, "02/01/2000 00:00:00", "Occurs every 2 weeks on friday once at 00:00:00 between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(5, "02/01/2000 00:00:00", "Occurs every 2 weeks on saturday once at 00:00:00 between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(6, "02/01/2000 00:00:00", "Occurs every 2 weeks on sunday once at 00:00:00 between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        public void validate_next_execution_date_recurring_once(int weekDay, string expectedDate, string expectedDescription)
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
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EveryTimesWeekly = "2";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDay] = "true";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            string[] execution = this.scheduler.GetNextExecution();
            Assert.Equal(expectedDate, execution[0]);
            Assert.Equal(expectedDescription, execution[1]);
        }

        [Theory]
        [InlineData(new int[2] { 0, 1 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday and tuesday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[2] { 1, 2 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on tuesday and wednesday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[2] { 2, 3 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on wednesday and thursday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[2] { 3, 4 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on thursday and friday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[2] { 4, 5 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on friday and saturday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[2] { 5, 6 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on saturday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[2] { 6, 0 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        public void validate_next_execution_date_recurring_two_days(int[] weekDays, string expectedDate, string expectedDescription)
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryType = "seconds";
            this.scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EveryTimesWeekly = "2";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[0]] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[1]] = "true";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            string[] execution = this.scheduler.GetNextExecution();
            Assert.Equal(expectedDate, execution[0]);
            Assert.Equal(expectedDescription, execution[1]);
        }

        [Theory]
        [InlineData(new int[3] { 0, 1, 2}, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, tuesday and wednesday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[3] { 1, 2, 3 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on tuesday, wednesday and thursday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[3] { 2, 3, 4 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on wednesday, thursday and friday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[3] { 3, 4, 5}, "02/01/2000 00:00:00", "Occurs every 2 weeks on thursday, friday and saturday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[3] { 4, 5, 6}, "02/01/2000 00:00:00", "Occurs every 2 weeks on friday, saturday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[3] { 5, 6, 0 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, saturday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[3] { 6, 0, 1 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, tuesday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        public void validate_next_execution_date_recurring_three_days(int[] weekDays, string expectedDate, string expectedDescription)
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryType = "seconds";
            this.scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EveryTimesWeekly = "2";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[0]] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[1]] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[2]] = "true";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            string[] execution = this.scheduler.GetNextExecution();
            Assert.Equal(expectedDate, execution[0]);
            Assert.Equal(expectedDescription, execution[1]);
        }

        [Theory]
        [InlineData(new int[4] { 0, 1, 2, 3 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, tuesday, wednesday and thursday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[4] { 1, 2, 3, 4 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on tuesday, wednesday, thursday and friday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[4] { 2, 3, 4, 5 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on wednesday, thursday, friday and saturday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[4] { 3, 4, 5, 6 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on thursday, friday, saturday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[4] { 4, 5, 6, 0 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, friday, saturday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[4] { 5, 6, 0, 1 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, tuesday, saturday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[4] { 6, 0, 1, 2 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, tuesday, wednesday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        public void validatenext_execution_date_recurring_four_days(int[] weekDays, string expectedDate, string expectedDescription)
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryType = "seconds";
            this.scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EveryTimesWeekly = "2";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[0]] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[1]] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[2]] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[3]] = "true";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            string[] execution = this.scheduler.GetNextExecution();
            Assert.Equal(expectedDate, execution[0]);
            Assert.Equal(expectedDescription, execution[1]);
        }

        [Theory]
        [InlineData(new int[5] { 0, 1, 2, 3, 4 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, tuesday, wednesday, thursday and friday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[5] { 1, 2, 3, 4, 5 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on tuesday, wednesday, thursday, friday and saturday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[5] { 2, 3, 4, 5, 6 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on wednesday, thursday, friday, saturday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[5] { 3, 4, 5, 6, 0 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, thursday, friday, saturday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[5] { 4, 5, 6, 0, 1 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, tuesday, friday, saturday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[5] { 5, 6, 0, 1, 2 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, tuesday, wednesday, saturday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[5] { 6, 0, 1, 2, 3 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, tuesday, wednesday, thursday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        public void validatenext_execution_date_recurring_five_days(int[] weekDays, string expectedDate, string expectedDescription)
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryType = "seconds";
            this.scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EveryTimesWeekly = "2";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[0]] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[1]] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[2]] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[3]] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[4]] = "true";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            string[] execution = this.scheduler.GetNextExecution();
            Assert.Equal(expectedDate, execution[0]);
            Assert.Equal(expectedDescription, execution[1]);
        }

        [Theory]
        [InlineData(new int[6] { 0, 1, 2, 3, 4, 5 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, tuesday, wednesday, thursday, friday and saturday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[6] { 1, 2, 3, 4, 5, 6 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on tuesday, wednesday, thursday, friday, saturday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[6] { 2, 3, 4, 5, 6, 0 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, wednesday, thursday, friday, saturday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[6] { 3, 4, 5, 6, 0, 1 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, tuesday, thursday, friday, saturday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[6] { 4, 5, 6, 0, 1, 2 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, tuesday, wednesday, friday, saturday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[6] { 5, 6, 0, 1, 2, 3 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, tuesday, wednesday, thursday, saturday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        [InlineData(new int[6] { 6, 0, 1, 2, 3, 4 }, "02/01/2000 00:00:00", "Occurs every 2 weeks on monday, tuesday, wednesday, thursday, friday and sunday every 2 seconds between 00:00:00 and 00:00:00 starting on 01/01/2000 00:00:00 and ending on 01/01/2000 00:00:00.")]
        public void validatenext_execution_date_recurring_six_days(int[] weekDays, string expectedDate, string expectedDescription)
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000 00:00:00";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryType = "seconds";
            this.scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EveryTimesWeekly = "2";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[0]] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[1]] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[2]] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[3]] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[4]] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[weekDays[5]] = "true";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            string[] execution = this.scheduler.GetNextExecution();
            Assert.Equal(expectedDate, execution[0]);
            Assert.Equal(expectedDescription, execution[1]);
        }

        [Fact]
        public void validate_next_execution_date_recurring_all_days()
        {
            this.scheduler = new Scheduler();
            this.scheduler.SchedulerConfiguration.Enabled = "true";
            this.scheduler.SchedulerConfiguration.ExecutionType = "Recurring";
            this.scheduler.SchedulerConfiguration.CurrentDate = "01/01/2000";
            this.scheduler.SchedulerConfiguration.NumDays = "1";
            this.scheduler.SchedulerConfiguration.StartDate = "01/01/2000";
            this.scheduler.SchedulerConfiguration.EndDate = "01/01/2000";
            this.scheduler.SchedulerConfiguration.OccursEvery = "true";
            this.scheduler.SchedulerConfiguration.EveryType = "seconds";
            this.scheduler.SchedulerConfiguration.EveryTimes = "2";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EveryTimesWeekly = "2";
            this.scheduler.SchedulerConfiguration.WeekDays[0] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[1] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[2] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[3] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[4] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[5] = "true";
            this.scheduler.SchedulerConfiguration.WeekDays[6] = "true";
            this.scheduler.SchedulerConfiguration.StartTime = "00:00:00";
            this.scheduler.SchedulerConfiguration.EndTime = "00:00:00";

            string[] execution = this.scheduler.GetNextExecution();
            Assert.Equal("02/01/2000 00:00:00", execution[0]);
            Assert.Equal(Global.DescriptionRecurringAllDays, execution[1]);
        }
    }
}
