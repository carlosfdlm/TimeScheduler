using Xunit;
using FluentAssertions;
using System;

namespace TimeScheduler.Test
{
    public class SchedulerTest
    {
        [Fact]
        public void Validate_Enabled_False()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = false
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Enabled is false.");
        }

        [Fact]
        public void Validate_End_Date_Less_Than_Start_Date()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Once,
                StartDate = new DateTime(2000, 2, 1),
                EndDate = new DateTime(2000, 1, 1)
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("End date is less than start date.");
        }

        [Fact]
        public void Validate_Once_Date_Time_Is_Less_Than_Current_Date()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Once,
                CurrentDate = new DateTime(2000, 2, 1),
                OnceDateTime = new DateTime(2000, 1, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 2, 1)
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Once date time is less than current date.");
        }

        [Fact]
        public void Validate_Current_Date_Is_Out_Of_Range()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Once,
                CurrentDate = new DateTime(2000, 3, 1),
                OnceDateTime = new DateTime(2000, 4, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 2, 1)
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Current date is out of range.");
        }

        [Fact]
        public void Validate_Once_Execution()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Once,
                CurrentDate = new DateTime(2000, 3, 1),
                OnceDateTime = new DateTime(2000, 4, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1)
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution = new DateTime(2000, 4, 1);
            result.Description = $"Occurs Once. Schedule will be used on {new DateTime(2000, 4, 1).ToShortDateString()}" +
                $" at {new DateTime(2000, 4, 1).ToShortTimeString()} starting on { new DateTime(2000, 1, 1).ToShortDateString()}" +
                $" and ending on {new DateTime(2000, 10, 1).ToShortDateString()}";
        }

        [Fact]
        public void Validate_End_Time_Less_Than_Start_Time()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(2, 0, 0),
                EndTime = new TimeSpan(0, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1)
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("The end time is less than the start time.");
        }

        [Fact]
        public void Validate_Once_Time_Out_Of_Range()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Once,
                OccursOnceTime = new TimeSpan(9, 0, 0)
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Occurs once time is out of range.");
        }

        [Fact]
        public void Validate_Time_Unit_Frequency_Zero()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnitFrequency = 0
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("The times of time unit is zero.");
        }

        [Fact]
        public void Validate_Time_Unit_Frequency_Negative()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnitFrequency = -1
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("The times of time unit is negative.");
        }

        [Fact]
        public void Validate_Week_Frequency_Zero()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Weekly,
                WeekFrequency = 0
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("The week frequency is zero.");
        }

        [Fact]
        public void Validate_Week_Frequency_Negative()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Weekly,
                WeekFrequency = -1
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("The week frequency is negative.");
        }

        [Fact]
        public void Validate_Not_Week_Days()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Weekly,
                WeekFrequency = 1
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("No week days selected.");
        }

        [Fact]
        public void Validate_Every_Month_Zero()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Monthly,
                EveryMonth = 0
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Every month is zero.");
        }

        [Fact]
        public void Validate_Every_Month_Is_Negative()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Monthly,
                EveryMonth = -1
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Every month is negative.");
        }

        [Fact]
        public void Validate_Month_Day_Is_Zero()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Monthly,
                EveryMonth = 1,
                MonthlyType = MonthlyType.Day,
                DayOfMonth = 0
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Day of month is zero.");
        }

        [Fact]
        public void Validate_Month_Day_Is_Negative()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Monthly,
                EveryMonth = 1,
                MonthlyType = MonthlyType.Day,
                DayOfMonth = -1
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Day of month is negative.");
        }

        [Fact]
        public void Validate_Frequency_Days_Is_Zero()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Daily,
                FrequencyDays = 0
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("The frequency days is zero.");
        }

        [Fact]
        public void Validate_Frequency_Days_Is_Negative()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Daily,
                FrequencyDays = -1
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("The frequency days is negative.");
        }

        [Fact]
        public void Validate_Daily_Frequency_Max_Date()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(9999, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(9999, 10, 1),
                OccursType = OccursType.Every,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Daily,
                FrequencyDays = 9999
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("The date can't be represented.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Hour()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Daily,
                FrequencyDays = 1
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 1, 0, 0, 0));
            result.Description.Should().Be("Occurs every day. Schedule will be used on 01/01/2000 at " +
                "00:00:00 every 1 Hours between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Seconds()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Seconds,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Daily,
                FrequencyDays = 1
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 1, 0, 0, 0));
            result.Description.Should().Be("Occurs every day. Schedule will be used on 01/01/2000 at " +
                "00:00:00 every 1 Seconds between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Minutes()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Minutes,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Daily,
                FrequencyDays = 1
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 1));
            result.Description.Should().Be("Occurs every day. Schedule will be used on 01/01/2000 at " +
                "00:00:00 every 1 Minutes between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Hour_Seconds_Series()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Seconds,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Daily,
                FrequencyDays = 1
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 10));
            result[20].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 20));
            result[10].Description.Should().Be("Occurs every day. Schedule will be used on 01/01/2000 at " +
                "00:00:00 every 1 Seconds between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Minute_Series()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Minutes,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Daily,
                FrequencyDays = 1
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 10, 0));
            result[20].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 20, 0));
            result[10].Description.Should().Be("Occurs every day. Schedule will be used on 01/01/2000 at " +
                "00:00:00 every 1 Minutes between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Hour_Series()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Daily,
                FrequencyDays = 1
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2000, 01, 04, 1, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2000, 01, 07, 2, 0, 0));
            result[10].Description.Should().Be("Occurs every day. Schedule will be used on 01/01/2000 at " +
                "00:00:00 every 1 Hours between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Weekly_Recurring_Description_Hour()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Weekly,
                FrequencyDays = 1,
                WeekFrequency = 2,
                MondayEnabled = true
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 3, 0, 0, 0));
            result.Description.Should().Be("Occurs every 2 weeks on monday every 1 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Weekly_Recurring_Description_Hour_Series()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Weekly,
                FrequencyDays = 1,
                WeekFrequency = 2,
                MondayEnabled = true,
                WednesdayEnabled = true
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2000, 01, 12, 1, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2000, 01, 24, 2, 0, 0));
            result[10].Description.Should().Be("Occurs every 2 weeks on monday and wednesday every 1 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Weekly_Recurring_Description_Hour_Series_Different_Days()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Weekly,
                FrequencyDays = 1,
                WeekFrequency = 2,
                MondayEnabled = true,
                WednesdayEnabled = true,
                TuesdayEnabled = true,
                ThursdayEnabled = true,
                FridayEnabled = true,
                SaturdayEnabled = true,
                SundayEnabled = true
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2000, 01, 05, 1, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2000, 01, 08, 2, 0, 0));
            result[10].Description.Should().Be("Occurs every 2 weeks on monday, tuesday, wednesday, thursday, friday, saturday and sunday every 1 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_First_Tuesday()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Tuesday,
                OrdinalConfiguration = OrdinalConfiguration.First,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 4, 0, 0, 0));
            result.Description.Should().Be("Occurs the First Tuesday of every 2 months every 1 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_First_Tuesday()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Tuesday,
                OrdinalConfiguration = OrdinalConfiguration.First,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2000, 04, 04, 1, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2000, 07, 04, 2, 0, 0));
            result[10].Description.Should().Be("Occurs the First Tuesday of every 2 months every 1 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Second_Tuesday()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Tuesday,
                OrdinalConfiguration = OrdinalConfiguration.Second,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 11, 0, 0, 0));
            result.Description.Should().Be("Occurs the Second Tuesday of every 2 months every 1 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_Second_Tuesday()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Tuesday,
                OrdinalConfiguration = OrdinalConfiguration.Second,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2000, 04, 11, 1, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2000, 07, 11, 2, 0, 0));
            result[10].Description.Should().Be("Occurs the Second Tuesday of every 2 months every 1 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Third_Tuesday()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Tuesday,
                OrdinalConfiguration = OrdinalConfiguration.Third,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 18, 0, 0, 0));
            result.Description.Should().Be("Occurs the Third Tuesday of every 2 months every 1 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_Third_Tuesday()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Tuesday,
                OrdinalConfiguration = OrdinalConfiguration.Third,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2000, 04, 18, 1, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2000, 07, 18, 2, 0, 0));
            result[10].Description.Should().Be("Occurs the Third Tuesday of every 2 months every 1 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Fourth_Tuesday()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Tuesday,
                OrdinalConfiguration = OrdinalConfiguration.Fourth,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 25, 0, 0, 0));
            result.Description.Should().Be("Occurs the Fourth Tuesday of every 2 months every 1 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_Fourth_Tuesday()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Tuesday,
                OrdinalConfiguration = OrdinalConfiguration.Fourth,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2000, 04, 25, 1, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2000, 07, 25, 2, 0, 0));
            result[10].Description.Should().Be("Occurs the Fourth Tuesday of every 2 months every 1 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Last_Tuesday()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Tuesday,
                OrdinalConfiguration = OrdinalConfiguration.Last,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 25, 0, 0, 0));
            result.Description.Should().Be("Occurs the Last Tuesday of every 2 months every 1 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_Last_Tuesday()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 1,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Tuesday,
                OrdinalConfiguration = OrdinalConfiguration.Fourth,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2000, 04, 25, 1, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2000, 07, 25, 2, 0, 0));
            result[10].Description.Should().Be("Occurs the Fourth Tuesday of every 2 months every 1 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/01/2000 and ending on 01/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_Last_Tuesday_Change_Year()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2010, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Tuesday,
                OrdinalConfiguration = OrdinalConfiguration.Fourth,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 23, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 06, 26, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the Fourth Tuesday of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 01/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_First_Day()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2010, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Day,
                OrdinalConfiguration = OrdinalConfiguration.First,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 01, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 06, 01, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the First Day of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 01/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Second_Day()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2010, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Day,
                OrdinalConfiguration = OrdinalConfiguration.Second,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 02, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 06, 02, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the Second Day of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 01/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Third_Day()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2010, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Day,
                OrdinalConfiguration = OrdinalConfiguration.Third,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 03, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 06, 03, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the Third Day of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 01/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Fourth_First_Day()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2010, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Day,
                OrdinalConfiguration = OrdinalConfiguration.Fourth,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 04, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 06, 04, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the Fourth Day of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 01/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Last_Day()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2010, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Day,
                OrdinalConfiguration = OrdinalConfiguration.Last,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 31, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 06, 30, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the Last Day of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 01/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_First_WeekDay()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2010, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Weekday,
                OrdinalConfiguration = OrdinalConfiguration.First,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 01, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 06, 01, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the First Weekday of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 01/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Second_WeekDay()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2010, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Weekday,
                OrdinalConfiguration = OrdinalConfiguration.Second,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 02, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 06, 04, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the Second Weekday of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 01/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Third_WeekDay()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2010, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Weekday,
                OrdinalConfiguration = OrdinalConfiguration.Third,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 03, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 06, 05, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the Third Weekday of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 01/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Fourth_WeekDay()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2010, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Weekday,
                OrdinalConfiguration = OrdinalConfiguration.Fourth,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 04, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 06, 06, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the Fourth Weekday of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 01/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Last_WeekDay()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2010, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.Weekday,
                OrdinalConfiguration = OrdinalConfiguration.Last,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 31, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 06, 29, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the Last Weekday of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 01/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_First_Weekend()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2010, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.WeekendDay,
                OrdinalConfiguration = OrdinalConfiguration.First,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 06, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 06, 02, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the First WeekendDay of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 01/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Second_Weekend()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2010, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.WeekendDay,
                OrdinalConfiguration = OrdinalConfiguration.Second,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 13, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 06, 09, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the Second WeekendDay of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 01/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Third_Weekend()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2010, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.WeekendDay,
                OrdinalConfiguration = OrdinalConfiguration.Third,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 20, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 06, 16, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the Third WeekendDay of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 01/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Fourth_Weekend()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2010, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.WeekendDay,
                OrdinalConfiguration = OrdinalConfiguration.Fourth,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 27, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 06, 23, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the Fourth WeekendDay of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 01/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Last_Weekend()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2010, 10, 1),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.WeekendDay,
                OrdinalConfiguration = OrdinalConfiguration.Last,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 27, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 06, 30, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the Last WeekendDay of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 01/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_End_Date()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2001, 01, 27),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.WeekendDay,
                OrdinalConfiguration = OrdinalConfiguration.Last,
                EveryMonth = 2
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(30);
            result[10].NextExecution.Should().Be(new DateTime(2001, 01, 27, 0, 0, 0));
            result[20].NextExecution.Should().Be(new DateTime(2001, 01, 27, 0, 0, 0));
            result[10].Description.Should().Be("Occurs the Last WeekendDay of every 2 months every 2 " +
                "Hours between 00:00:00 and 02:00:00 starting on 01/08/2000 and ending on 27/01/2001.");
        }
    }
}
