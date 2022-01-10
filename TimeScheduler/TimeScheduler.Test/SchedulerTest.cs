using Xunit;
using FluentAssertions;
using System;
using System.Globalization;

namespace TimeScheduler.Test
{
    public class SchedulerTest
    {
        #region english test
        [Fact]
        public void Validate_Enabled_False_Eng()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = false,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Enabled is false.");
        }

        [Fact]
        public void Validate_End_Date_Less_Than_Start_Date_Eng()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Once,
                StartDate = new DateTime(2000, 2, 1),
                EndDate = new DateTime(2000, 1, 1),
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("End date is less than start date.");
        }

        [Fact]
        public void Validate_Once_Date_Time_Is_Less_Than_Current_Date_Eng()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Once,
                CurrentDate = new DateTime(2000, 2, 1),
                OnceDateTime = new DateTime(2000, 1, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 2, 1),
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Once date time is less than current date.");
        }

        [Fact]
        public void Validate_Current_Date_Is_Out_Of_Range_Eng()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Once,
                CurrentDate = new DateTime(2000, 3, 1),
                OnceDateTime = new DateTime(2000, 4, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 2, 1),
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Current date is out of range.");
        }

        [Fact]
        public void Validate_Once_Execution_Eng()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Once,
                CurrentDate = new DateTime(2000, 3, 1),
                OnceDateTime = new DateTime(2000, 4, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 4, 1));
            result.Description.Should().Be("Occurs once. Schedule will be used on 4/1/2000 at 12:00 AM starting on 1/1/2000 and ending 10/1/2000.");
        }

        [Fact]
        public void Validate_End_Time_Less_Than_Start_Time_Eng()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(2, 0, 0),
                EndTime = new TimeSpan(0, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("The end time is less than the start time.");
        }

        [Fact]
        public void Validate_Once_Time_Out_Of_Range_Eng()
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
                OccursOnceTime = new TimeSpan(9, 0, 0),
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Occurs once time is out of range.");
        }

        [Fact]
        public void Validate_Time_Unit_Frequency_Zero_Eng()
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
                TimeUnitFrequency = 0,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("The times of time unit is zero.");
        }

        [Fact]
        public void Validate_Time_Unit_Frequency_Negative_Eng()
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
                TimeUnitFrequency = -1,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("The times of time unit is negative.");
        }

        [Fact]
        public void Validate_Week_Frequency_Zero_Eng()
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
                WeekFrequency = 0,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("The week frequency is zero.");
        }

        [Fact]
        public void Validate_Week_Frequency_Negative_Eng()
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
                WeekFrequency = -1,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("The week frequency is negative.");
        }

        [Fact]
        public void Validate_Not_Week_Days_Eng()
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
                WeekFrequency = 1,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("No week days selected.");
        }

        [Fact]
        public void Validate_Every_Month_Zero_Eng()
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
                EveryMonth = 0,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Every month is zero.");
        }

        [Fact]
        public void Validate_Every_Month_Is_Negative_Eng()
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
                EveryMonth = -1,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Every month is negative.");
        }

        [Fact]
        public void Validate_Month_Day_Is_Zero_Eng()
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
                DayOfMonth = 0,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Day of month is zero.");
        }

        [Fact]
        public void Validate_Month_Day_Is_Negative_Eng()
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
                DayOfMonth = -1,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Day of month is negative.");
        }

        [Fact]
        public void Validate_Frequency_Days_Is_Zero_Eng()
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
                FrequencyDays = 0,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("The frequency days is zero.");
        }

        [Fact]
        public void Validate_Frequency_Days_Is_Negative_Eng()
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
                FrequencyDays = -1,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("The frequency days is negative.");
        }

        [Fact]
        public void Validate_Daily_Frequency_Max_Date_Eng()
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
                FrequencyDays = 9999,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("The date can't be represented.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Hour_Eng()
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
                FrequencyDays = 1,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 1, 0, 0, 0));
            result.Description.Should().Be("Occurs every day. Schedule will be used on 1/1/2000 at " +
                "12:00 AM every 1 hours between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Seconds_Eng()
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
                FrequencyDays = 1,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 1, 0, 0, 0));
            result.Description.Should().Be("Occurs every day. Schedule will be used on 1/1/2000 at " +
                "12:00 AM every 1 seconds between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Minutes_Eng()
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
                FrequencyDays = 1,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 1));
            result.Description.Should().Be("Occurs every day. Schedule will be used on 1/1/2000 at " +
                "12:00 AM every 1 minutes between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Hour_Seconds_Series_Eng()
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
                FrequencyDays = 1,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 00));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 01));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 02));
            result[3].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 03));
            result[4].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 04));
            result[5].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 05));
            result[6].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 06));
            result[7].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 07));
            result[8].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 08));
            result[9].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 09));
            result[9].Description.Should().Be("Occurs every day. Schedule will be used on 1/1/2000 at " +
                "12:00 AM every 1 seconds between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Minute_Series_Eng()
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
                FrequencyDays = 1,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 00, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 01, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 02, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 03, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 04, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 05, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 06, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 07, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 08, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 09, 0));
            result[9].Description.Should().Be("Occurs every day. Schedule will be used on 1/1/2000 at " +
                "12:00 AM every 1 minutes between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Hour_Series_Eng()
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
                FrequencyDays = 1,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 01, 01, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 01, 02, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 01, 02, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 01, 02, 01, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 01, 02, 02, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 01, 03, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 01, 03, 01, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 01, 03, 02, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 01, 04, 0, 0, 0));
            result[9].Description.Should().Be("Occurs every day. Schedule will be used on 1/1/2000 at " +
                "12:00 AM every 1 hours between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Weekly_Recurring_Description_Hour_Eng()
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
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 03, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 03, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 03, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 01, 10, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 01, 10, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 01, 10, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 01, 17, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 01, 17, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 01, 17, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 01, 24, 0, 0, 0));
            result[9].Description.Should().Be("Occurs every 2 weeks on monday every 1 " +
                "hours between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Weekly_Recurring_Description_Hour_Series_Eng()
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
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 03, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 03, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 03, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 01, 05, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 01, 05, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 01, 05, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 01, 10, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 01, 10, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 01, 10, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 01, 12, 0, 0, 0));
            result[9].Description.Should().Be("Occurs every 2 weeks on monday and wednesday every 1 " +
                "hours between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Weekly_Recurring_Description_Hour_Series_Different_Days_Eng()
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
                SundayEnabled = true,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 02, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 02, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 02, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 01, 03, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 01, 03, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 01, 03, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 01, 04, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 01, 04, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 01, 04, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 01, 05, 0, 0, 0));
            result[9].Description.Should().Be("Occurs every 2 weeks on monday, tuesday, wednesday, thursday, friday, saturday and sunday every 1 " +
                "hours between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_First_Tuesday_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 04, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 04, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 04, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 02, 01, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 02, 01, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 02, 01, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 03, 07, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 03, 07, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 03, 07, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 04, 04, 0, 0, 0));
            result[9].Description.Should().Be("Occurs the first tuesday of every 2 months every 1 " +
                "hours between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_First_Tuesday_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 04, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 04, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 04, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 02, 01, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 02, 01, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 02, 01, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 03, 07, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 03, 07, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 03, 07, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 04, 04, 0, 0, 0));
            result[9].Description.Should().Be("Occurs the first tuesday of every 2 months every 1 " +
                "hours between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Second_Tuesday_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 11, 0, 0, 0));
            result.Description.Should().Be("Occurs the second tuesday of every 2 months every 1 " +
                "hours between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_Second_Tuesday_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 11, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 11, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 11, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 02, 08, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 02, 08, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 02, 08, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 03, 14, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 03, 14, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 03, 14, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 04, 11, 0, 0, 0));
            result[9].Description.Should().Be("Occurs the second tuesday of every 2 months every 1 " +
                "hours between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Third_Tuesday_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 18, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 18, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 18, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 02, 15, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 02, 15, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 02, 15, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 03, 21, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 03, 21, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 03, 21, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 04, 18, 0, 0, 0));
            result[9].Description.Should().Be("Occurs the third tuesday of every 2 months every 1 " +
                "hours between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_Third_Tuesday_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 18, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 18, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 18, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 02, 15, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 02, 15, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 02, 15, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 03, 21, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 03, 21, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 03, 21, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 04, 18, 0, 0, 0));
            result[9].Description.Should().Be("Occurs the third tuesday of every 2 months every 1 " +
                "hours between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Fourth_Tuesday_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 25, 0, 0, 0));
            result.Description.Should().Be("Occurs the fourth tuesday of every 2 months every 1 " +
                "hours between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_Fourth_Tuesday_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 25, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 25, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 25, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 02, 22, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 02, 22, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 02, 22, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 03, 28, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 03, 28, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 03, 28, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 4, 25, 0, 0, 0));
            result[9].Description.Should().Be("Occurs the fourth tuesday of every 2 months every 1 " +
                "hours between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Last_Tuesday_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 25, 0, 0, 0));
            result.Description.Should().Be("Occurs the last tuesday of every 2 months every 1 " +
                "hours between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_Last_Tuesday_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 25, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 25, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 25, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 02, 22, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 02, 22, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 02, 22, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 03, 28, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 03, 28, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 03, 28, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 04, 25, 0, 0, 0));
            result[9].Description.Should().Be("Occurs the fourth tuesday of every 2 months every 1 " +
                "hours between 12:00 AM and 2:00 AM starting on 1/1/2000 and ending on 10/1/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_Last_Tuesday_Change_Year_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 22, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 22, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 26, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 26, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 24, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 24, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 28, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 28, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 26, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 26, 2, 0, 0));
            result[9].Description.Should().Be("Occurs the fourth tuesday of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 10/1/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_First_Day_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 01, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 01, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 01, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 01, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 01, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 01, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 01, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 01, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 01, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 01, 2, 0, 0));
            result[9].Description.Should().Be("Occurs the first day of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 10/1/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Second_Day_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 02, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 02, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 02, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 02, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 02, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 02, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 02, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 02, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 02, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 02, 2, 0, 0));
            result[9].Description.Should().Be("Occurs the second day of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 10/1/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Third_Day_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 03, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 03, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 03, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 03, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 03, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 03, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 03, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 03, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 03, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 03, 2, 0, 0));
            result[9].Description.Should().Be("Occurs the third day of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 10/1/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Fourth_First_Day_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 8, 4, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 8, 4, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 04, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 9, 4, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 4, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 4, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 4, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 4, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 04, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 04, 2, 0, 0));
            result[9].Description.Should().Be("Occurs the fourth day of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 10/1/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Last_Day_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 31, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 31, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 30, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 30, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 31, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 31, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 30, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 30, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 31, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 31, 2, 0, 0));
            result[9].Description.Should().Be("Occurs the last day of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 10/1/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_First_WeekDay_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 01, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 01, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 01, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 01, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 02, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 02, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 01, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 01, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 01, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 01, 2, 0, 0));
            result[9].Description.Should().Be("Occurs the first week day of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 10/1/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Second_WeekDay_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 02, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 02, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 04, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 04, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 03, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 03, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 02, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 02, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 04, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 04, 2, 0, 0));
            result[9].Description.Should().Be("Occurs the second week day of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 10/1/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Third_WeekDay_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 8, 3, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 8, 3, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 9, 5, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 9, 5, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 4, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 4, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 3, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 3, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 5, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 5, 2, 0, 0));
            result[9].Description.Should().Be("Occurs the third week day of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 10/1/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Fourth_WeekDay_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 04, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 8, 04, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 9, 6, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 9, 6, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 5, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 5, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 6, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 6, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 6, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 6, 2, 0, 0));
            result[9].Description.Should().Be("Occurs the fourth week day of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 10/1/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Last_WeekDay_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 31, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 31, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 29, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 29, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 31, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 31, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 30, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 30, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 29, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 29, 2, 0, 0));
            result[9].Description.Should().Be("Occurs the last week day of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 10/1/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_First_Weekend_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 5, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 5, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 02, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 2, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 01, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 01, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 04, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 04, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 02, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 02, 2, 0, 0));
            result[9].Description.Should().Be("Occurs the first weekend day of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 10/1/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Second_Weekend_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 12, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 12, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 09, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 09, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 07, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 07, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 11, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 11, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 09, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 09, 2, 0, 0));
            result[9].Description.Should().Be("Occurs the second weekend day of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 10/1/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Third_Weekend_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 19, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 19, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 16, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 16, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 14, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 14, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 18, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 18, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 16, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 16, 2, 0, 0));
            result[9].Description.Should().Be("Occurs the third weekend day of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 10/1/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Fourth_Weekend_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 26, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 26, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 23, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 23, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 21, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 21, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 25, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 25, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 23, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 23, 2, 0, 0));
            result[9].Description.Should().Be("Occurs the fourth weekend day of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 10/1/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Last_Weekend_Eng()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 26, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 26, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 30, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 30, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 28, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 28, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 25, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 25, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 30, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 30, 2, 0, 0));
            result[9].Description.Should().Be("Occurs the last weekend day of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 10/1/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_End_Date_Eng()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2000, 12, 10),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.WeekendDay,
                OrdinalConfiguration = OrdinalConfiguration.Last,
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("en-US")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 26, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 26, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 30, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 30, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 28, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 28, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 25, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 25, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 10, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 10, 0, 0, 0));
            result[9].Description.Should().Be("Occurs the last weekend day of every 2 months every 2 " +
                "hours between 12:00 AM and 2:00 AM starting on 8/1/2000 and ending on 12/10/2000.");
        }
        #endregion english test

        #region spanish test
        [Fact]
        public void Validate_Enabled_False_Esp()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = false,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Está desactivado.");
        }

        [Fact]
        public void Validate_End_Date_Less_Than_Start_Date_Esp()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Once,
                StartDate = new DateTime(2000, 2, 1),
                EndDate = new DateTime(2000, 1, 1),
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("La fecha final es anterior a la fecha inicial.");
        }

        [Fact]
        public void Validate_Once_Date_Time_Is_Less_Than_Current_Date_Esp()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Once,
                CurrentDate = new DateTime(2000, 2, 1),
                OnceDateTime = new DateTime(2000, 1, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 2, 1),
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("La fecha no puede ser menor que la fecha actual.");
        }

        [Fact]
        public void Validate_Current_Date_Is_Out_Of_Range_Esp()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Once,
                CurrentDate = new DateTime(2000, 3, 1),
                OnceDateTime = new DateTime(2000, 4, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 2, 1),
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("La fecha actual está fuera de rango.");
        }

        [Fact]
        public void Validate_Once_Execution_Esp()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Once,
                CurrentDate = new DateTime(2000, 3, 1),
                OnceDateTime = new DateTime(2000, 4, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 4, 1));
            result.Description.Should().Be("Ocurre una vez. El Planificador " +
                "será utilizado el 1/4/2000 a las 0:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_End_Time_Less_Than_Start_Time_Esp()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 3, 1),
                StartTime = new TimeSpan(2, 0, 0),
                EndTime = new TimeSpan(0, 0, 0),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 10, 1),
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("La hora final es anterior a la hora inicial.");
        }

        [Fact]
        public void Validate_Once_Time_Out_Of_Range_Esp()
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
                OccursOnceTime = new TimeSpan(9, 0, 0),
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("La fecha está fuera de rango.");
        }

        [Fact]
        public void Validate_Time_Unit_Frequency_Zero_Esp()
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
                TimeUnitFrequency = 0,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("El número de unidades de tiempo es cero.");
        }

        [Fact]
        public void Validate_Time_Unit_Frequency_Negative_Esp()
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
                TimeUnitFrequency = -1,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("El número de unidades de tiempo es negativo.");
        }

        [Fact]
        public void Validate_Week_Frequency_Zero_Esp()
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
                WeekFrequency = 0,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("La frecuencia semanal es cero.");
        }

        [Fact]
        public void Validate_Week_Frequency_Negative_Esp()
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
                WeekFrequency = -1,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("La frecuencia semanal es negativa.");
        }

        [Fact]
        public void Validate_Not_Week_Days_Esp()
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
                WeekFrequency = 1,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("No hay días de la semana seleccionados.");
        }

        [Fact]
        public void Validate_Every_Month_Zero_Esp()
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
                EveryMonth = 0,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("El número de meses es 0.");
        }

        [Fact]
        public void Validate_Every_Month_Is_Negative_Esp()
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
                EveryMonth = -1,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("El número de meses es negativa.");
        }

        [Fact]
        public void Validate_Month_Day_Is_Zero_Esp()
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
                DayOfMonth = 0,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("El día del mes es cero.");
        }

        [Fact]
        public void Validate_Month_Day_Is_Negative_Esp()
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
                DayOfMonth = -1,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("El día del mes es negativo.");
        }

        [Fact]
        public void Validate_Frequency_Days_Is_Zero_Esp()
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
                FrequencyDays = 0,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("La frecuencia diaria es cero.");
        }

        [Fact]
        public void Validate_Frequency_Days_Is_Negative_Esp()
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
                FrequencyDays = -1,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("La frecuencia diaria es negativa.");
        }

        [Fact]
        public void Validate_Daily_Frequency_Max_Date_Esp()
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
                FrequencyDays = 9999,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            schedulerConfiguration.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("La fecha no puede ser representada.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Hour_Esp()
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
                FrequencyDays = 1,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 1, 0, 0, 0));
            result.Description.Should().Be("Ocurre cada día. El planificador será usado el 1/1/2000 " +
                "a las 0:00 cada 1 horas entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Seconds_Esp()
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
                FrequencyDays = 1,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 1, 0, 0, 0));
            result.Description.Should().Be("Ocurre cada día. El planificador será usado el 1/1/2000 a las " +
                "0:00 cada 1 segundos entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Minutes_Esp()
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
                FrequencyDays = 1,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 1));
            result.Description.Should().Be("Ocurre cada día. El planificador será usado el 1/1/2000 a las " +
                "0:00 cada 1 minutos entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Hour_Seconds_Series_Esp()
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
                FrequencyDays = 1,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 00));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 01));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 02));
            result[3].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 03));
            result[4].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 04));
            result[5].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 05));
            result[6].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 06));
            result[7].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 07));
            result[8].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 08));
            result[9].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 09));
            result[9].Description.Should().Be("Ocurre cada día. El planificador será usado el 1/1/2000 a las " +
                "0:00 cada 1 segundos entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Minute_Series_Esp()
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
                FrequencyDays = 1,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 00, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 01, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 02, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 03, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 04, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 05, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 06, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 07, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 08, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 09, 0));
            result[9].Description.Should().Be("Ocurre cada día. El planificador será usado el 1/1/2000 a las " +
                "0:00 cada 1 minutos entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Daily_Recurring_Description_Hour_Series_Esp()
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
                FrequencyDays = 1,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 01, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 01, 01, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 01, 02, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 01, 02, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 01, 02, 01, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 01, 02, 02, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 01, 03, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 01, 03, 01, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 01, 03, 02, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 01, 04, 0, 0, 0));
            result[9].Description.Should().Be("Ocurre cada día. El planificador será usado el 1/1/2000 a las " +
                "0:00 cada 1 horas entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Weekly_Recurring_Description_Hour_Esp()
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
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 03, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 03, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 03, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 01, 10, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 01, 10, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 01, 10, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 01, 17, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 01, 17, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 01, 17, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 01, 24, 0, 0, 0));
            result[9].Description.Should().Be("Ocurre cada 2 semanas en lunes cada 1 " +
                "horas entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Weekly_Recurring_Description_Hour_Series_Esp()
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
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 03, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 03, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 03, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 01, 05, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 01, 05, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 01, 05, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 01, 10, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 01, 10, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 01, 10, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 01, 12, 0, 0, 0));
            result[9].Description.Should().Be("Ocurre cada 2 semanas en lunes y miércoles cada 1 " +
                "horas entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Weekly_Recurring_Description_Hour_Series_Different_Days_Esp()
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
                SundayEnabled = true,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 02, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 02, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 02, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 01, 03, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 01, 03, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 01, 03, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 01, 04, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 01, 04, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 01, 04, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 01, 05, 0, 0, 0));
            result[9].Description.Should().Be("Ocurre cada 2 semanas en lunes, martes, miércoles, jueves, viernes, sábado y domingo cada 1 " +
                "horas entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_First_Tuesday_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 04, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 04, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 04, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 02, 01, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 02, 01, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 02, 01, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 03, 07, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 03, 07, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 03, 07, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 04, 04, 0, 0, 0));
            result[9].Description.Should().Be("Ocurre el primer martes de cada 2 meses cada 1 " +
                "horas entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_First_Tuesday_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 04, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 04, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 04, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 02, 01, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 02, 01, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 02, 01, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 03, 07, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 03, 07, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 03, 07, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 04, 04, 0, 0, 0));
            result[9].Description.Should().Be("Ocurre el primer martes de cada 2 meses cada 1 " +
                "horas entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Second_Tuesday_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 11, 0, 0, 0));
            result.Description.Should().Be("Ocurre el segundo martes de cada 2 meses cada 1 " +
                "horas entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_Second_Tuesday_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 11, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 11, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 11, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 02, 08, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 02, 08, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 02, 08, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 03, 14, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 03, 14, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 03, 14, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 04, 11, 0, 0, 0));
            result[9].Description.Should().Be("Ocurre el segundo martes de cada 2 meses cada 1 " +
                "horas entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Third_Tuesday_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 18, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 18, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 18, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 02, 15, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 02, 15, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 02, 15, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 03, 21, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 03, 21, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 03, 21, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 04, 18, 0, 0, 0));
            result[9].Description.Should().Be("Ocurre el tercer martes de cada 2 meses cada 1 " +
                "horas entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_Third_Tuesday_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 18, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 18, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 18, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 02, 15, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 02, 15, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 02, 15, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 03, 21, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 03, 21, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 03, 21, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 04, 18, 0, 0, 0));
            result[9].Description.Should().Be("Ocurre el tercer martes de cada 2 meses cada 1 " +
                "horas entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Fourth_Tuesday_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 25, 0, 0, 0));
            result.Description.Should().Be("Ocurre el cuarto martes de cada 2 meses cada 1 " +
                "horas entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_Fourth_Tuesday_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 25, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 25, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 25, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 02, 22, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 02, 22, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 02, 22, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 03, 28, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 03, 28, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 03, 28, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 4, 25, 0, 0, 0));
            result[9].Description.Should().Be("Ocurre el cuarto martes de cada 2 meses cada 1 " +
                "horas entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Last_Tuesday_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecution();
            result.NextExecution.Should().Be(new DateTime(2000, 1, 25, 0, 0, 0));
            result.Description.Should().Be("Ocurre el último martes de cada 2 meses cada 1 " +
                "horas entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_Last_Tuesday_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 01, 25, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 01, 25, 1, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 01, 25, 2, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 02, 22, 0, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 02, 22, 1, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 02, 22, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 03, 28, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 03, 28, 1, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 03, 28, 2, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 04, 25, 0, 0, 0));
            result[9].Description.Should().Be("Ocurre el cuarto martes de cada 2 meses cada 1 " +
                "horas entre 0:00 y 2:00 empezando el 1/1/2000 y acabando el 1/10/2000.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Series_Last_Tuesday_Change_Year_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 22, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 22, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 26, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 26, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 24, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 24, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 28, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 28, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 26, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 26, 2, 0, 0));
            result[9].Description.Should().Be("Ocurre el cuarto martes de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 1/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_First_Day_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 01, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 01, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 01, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 01, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 01, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 01, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 01, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 01, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 01, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 01, 2, 0, 0));
            result[9].Description.Should().Be("Ocurre el primer día de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 1/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Second_Day_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 02, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 02, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 02, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 02, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 02, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 02, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 02, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 02, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 02, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 02, 2, 0, 0));
            result[9].Description.Should().Be("Ocurre el segundo día de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 1/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Third_Day_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 03, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 03, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 03, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 03, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 03, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 03, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 03, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 03, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 03, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 03, 2, 0, 0));
            result[9].Description.Should().Be("Ocurre el tercer día de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 1/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Fourth_First_Day_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 8, 4, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 8, 4, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 04, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 9, 4, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 4, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 4, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 4, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 4, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 04, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 04, 2, 0, 0));
            result[9].Description.Should().Be("Ocurre el cuarto día de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 1/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Last_Day_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 31, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 31, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 30, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 30, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 31, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 31, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 30, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 30, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 31, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 31, 2, 0, 0));
            result[9].Description.Should().Be("Ocurre el último día de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 1/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_First_WeekDay_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 01, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 01, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 01, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 01, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 02, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 02, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 01, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 01, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 01, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 01, 2, 0, 0));
            result[9].Description.Should().Be("Ocurre el primer día de la semana de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 1/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Second_WeekDay_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 02, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 02, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 04, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 04, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 03, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 03, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 02, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 02, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 04, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 04, 2, 0, 0));
            result[9].Description.Should().Be("Ocurre el segundo día de la semana de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 1/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Third_WeekDay_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 8, 3, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 8, 3, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 9, 5, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 9, 5, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 4, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 4, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 3, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 3, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 5, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 5, 2, 0, 0));
            result[9].Description.Should().Be("Ocurre el tercer día de la semana de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 1/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Fourth_WeekDay_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 04, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 8, 04, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 9, 6, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 9, 6, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 5, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 5, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 6, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 6, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 6, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 6, 2, 0, 0));
            result[9].Description.Should().Be("Ocurre el cuarto día de la semana de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 1/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Last_WeekDay_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 31, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 31, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 29, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 29, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 31, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 31, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 30, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 30, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 29, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 29, 2, 0, 0));
            result[9].Description.Should().Be("Ocurre el último día de la semana de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 1/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_First_Weekend_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 5, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 5, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 02, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 2, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 01, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 01, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 04, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 04, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 02, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 02, 2, 0, 0));
            result[9].Description.Should().Be("Ocurre el primer día de fin de semana de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 1/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Second_Weekend_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 12, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 12, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 09, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 09, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 07, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 07, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 11, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 11, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 09, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 09, 2, 0, 0));
            result[9].Description.Should().Be("Ocurre el segundo día de fin de semana de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 1/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Third_Weekend_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 19, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 19, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 16, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 16, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 14, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 14, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 18, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 18, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 16, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 16, 2, 0, 0));
            result[9].Description.Should().Be("Ocurre el tercer día de fin de semana de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 1/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Fourth_Weekend_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 26, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 26, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 23, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 23, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 21, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 21, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 25, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 25, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 23, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 23, 2, 0, 0));
            result[9].Description.Should().Be("Ocurre el cuarto día de fin de semana de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 1/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_Hour_Last_Weekend_Esp()
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
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 26, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 26, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 30, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 30, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 28, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 28, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 25, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 25, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 30, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 30, 2, 0, 0));
            result[9].Description.Should().Be("Ocurre el último día de fin de semana de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 1/10/2010.");
        }

        [Fact]
        public void Validate_Monthly_Recurring_Description_End_Date_Esp()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 9, 1),
                StartTime = new TimeSpan(0, 0, 0),
                EndTime = new TimeSpan(2, 0, 0),
                StartDate = new DateTime(2000, 8, 1),
                EndDate = new DateTime(2000, 12, 10),
                OccursType = OccursType.Every,
                TimeUnit = TimeUnit.Hours,
                TimeUnitFrequency = 2,
                FrecuencyType = FrecuencyType.Monthly,
                MonthlyType = MonthlyType.WeeksDay,
                DayOfWeek = DaysConfiguration.WeekendDay,
                OrdinalConfiguration = OrdinalConfiguration.Last,
                EveryMonth = 2,
                CultureInfo = CultureInfo.GetCultureInfo("es-ES")
            };
            var result = schedulerConfiguration.GetNextExecutionSeries(10);
            result[0].NextExecution.Should().Be(new DateTime(2000, 08, 26, 0, 0, 0));
            result[1].NextExecution.Should().Be(new DateTime(2000, 08, 26, 2, 0, 0));
            result[2].NextExecution.Should().Be(new DateTime(2000, 09, 30, 0, 0, 0));
            result[3].NextExecution.Should().Be(new DateTime(2000, 09, 30, 2, 0, 0));
            result[4].NextExecution.Should().Be(new DateTime(2000, 10, 28, 0, 0, 0));
            result[5].NextExecution.Should().Be(new DateTime(2000, 10, 28, 2, 0, 0));
            result[6].NextExecution.Should().Be(new DateTime(2000, 11, 25, 0, 0, 0));
            result[7].NextExecution.Should().Be(new DateTime(2000, 11, 25, 2, 0, 0));
            result[8].NextExecution.Should().Be(new DateTime(2000, 12, 10, 0, 0, 0));
            result[9].NextExecution.Should().Be(new DateTime(2000, 12, 10, 0, 0, 0));
            result[9].Description.Should().Be("Ocurre el último día de fin de semana de cada 2 meses cada 2 " +
                "horas entre 0:00 y 2:00 empezando el 1/8/2000 y acabando el 10/12/2000.");
        }
        #endregion spanish test

    }
}
