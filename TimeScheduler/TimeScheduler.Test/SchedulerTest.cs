using Xunit;
using TimeScheduler.Test.Resources;
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
        public void Validate_Next_Daily_Configuration_Occurs_False()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = false
            };
            schedulerConfiguration.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Occurs is false two times.");
        }


        [Fact]
        public void Validate_Next_Daily_Configuration_Occurs_True()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = true
            };
            schedulerConfiguration.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Occurs is true two times.");
        }

        [Fact]
        public void Validate_Next_Daily_Configuration_Occurs_Every_Times_Null()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = true
            };
            schedulerConfiguration.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Occurs every times is zero.");
        }

        [Fact]
        public void Validate_Next_Daily_Configuration_Occurs_Every_Less_Than_Zero()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = true,
                EveryTimes = -1
            };
            schedulerConfiguration.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Occurs every times is negative.");
        }

        [Fact]
        public void Validate_MontlyType_False()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = true,
                EveryTimes = 1,
                DaySelector = false,
                WeekDaySelector = false
            };
            schedulerConfiguration.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Monthly Type is false two times.");
        }

        [Fact]
        public void Validate_MontlyType_True()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = true,
                EveryTimes = 1,
                DaySelector = true,
                WeekDaySelector = true
            };
            schedulerConfiguration.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Monthly Type is true two times.");
        }

        [Fact]
        public void Validate_Next_Monthly_Configuration_Every_Day_Negative()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = false,
                OccursOnceTime = new DateTime(2000, 1, 1),
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                DaySelector = true,
                WeekDaySelector = false,
                EveryMonthDay = -1
            };
            schedulerConfiguration.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Every month day can't be negative.");
        }

        [Fact]
        public void Validate_Next_Monthly_Configuration_Every_Day_Zero()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = false,
                OccursOnceTime = new DateTime(2000, 1, 1),
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                DaySelector = true,
                WeekDaySelector = false,
                EveryMonthDay = 32
            };
            schedulerConfiguration.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Every month day out of range.");
        }

        [Fact]
        public void Validate_Next_Monthly_Configuration_Every_Months_Of_Day_Negative()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = false,
                OccursOnceTime = new DateTime(2000, 1, 1),
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                DaySelector = true,
                WeekDaySelector = false,
                EveryMonthDay = 3,
                MonthsDay = -2
            };
            schedulerConfiguration.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Every months is negative.");
        }

        [Fact]
        public void Validate_Next_Monthly_Configuration_Every_Months_Of_Day_Zero()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = false,
                OccursOnceTime = new DateTime(2000, 1, 1),
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                DaySelector = true,
                WeekDaySelector = false,
                EveryMonthDay = 3,
                MonthsDay = 0
            };
            schedulerConfiguration.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Every months is zero.");
        }

        [Fact]
        public void Validate_Next_Monthly_Configuration_Every_Months_Of_WeekDay_Negative()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = false,
                OccursOnceTime = new DateTime(2000, 1, 1),
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                DaySelector = false,
                WeekDaySelector = true,
                EveryMonthDay = -2
            };
            schedulerConfiguration.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Every months is negative.");
        }

        [Fact]
        public void Validate_Next_Monthly_Configuration_Every_Months_Of_WeekDay_Zero()
        {
            SchedulerConfiguration schedulerConfiguration = new()
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = false,
                OccursOnceTime = new DateTime(2000, 1, 1),
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                DaySelector = false,
                WeekDaySelector = true,
                EveryMonthDay = 0
            };
            schedulerConfiguration.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Every months is zero.");
        }

        //[Fact]
        //public void Validate_Next_Weekly_Configuration_No_Week_Day()
        //{
        //    SchedulerConfiguration schedulerConfiguration = new()
        //    {
        //        Enabled = true,
        //        ExecutionType = ExecutionType.Recurring,
        //        CurrentDate = new DateTime(2000, 1, 1),
        //        ExecutionDate = new DateTime(2000, 1, 1),
        //        StartDate = new DateTime(2000, 1, 1),
        //        EndDate = new DateTime(2000, 1, 1),
        //        OccursOnce = true,
        //        OccursEvery = false,
        //        OccursOnceTime = new DateTime(2000, 1, 1),
        //        StartingAt = new DateTime(2000, 1, 1),
        //        EndAt = new DateTime(2000, 1, 1),
        //        EveryTimesWeek = 1
        //    };
        //    schedulerConfiguration.Invoking(y => y.GetNextExecution())
        //        .Should().Throw<TimeSchedulerException>()
        //        .WithMessage("No week days selected.");
        //}

        //        [Fact]
        //        public void Validate_Next_Execution_Date_Once()
        //        {
        //            SchedulerConfiguration schedulerConfiguration = new()
        //            {
        //                Enabled = true,
        //                ExecutionType = ExecutionType.Once,
        //                CurrentDate = new DateTime(2000, 1, 1),
        //                ExecutionDate = new DateTime(2000, 1, 1),
        //                StartDate = new DateTime(2000, 1, 1),
        //                EndDate = new DateTime(2000, 1, 1)
        //            };
        //            var execution = schedulerConfiguration.GetNextExecution();
        //            execution.Length.Should().Be(2);
        //            execution[0].Should().Be(new DateTime(2000, 1, 1).ToShortDateString());
        //            execution[1].Should().Be(string.Format(Global.DescriptionOnce,
        //                                                       new DateTime(2000, 1, 1).ToShortDateString(),
        //                                                       new DateTime(2000, 1, 1).ToShortTimeString(),
        //                                                       new DateTime(2000, 1, 1),
        //                                                       new DateTime(2000, 1, 1)));
        //        }

        //        [Fact]
        //        public void Validate_Next_Execution_Date_Recurring_Every_Hours()
        //        {
        //            SchedulerConfiguration schedulerConfiguration = new()
        //            {
        //                Enabled = true,
        //                ExecutionType = ExecutionType.Recurring,
        //                CurrentDate = new DateTime(2000, 1, 1),
        //                ExecutionDate = new DateTime(2000, 1, 1),
        //                StartDate = new DateTime(2000, 1, 1),
        //                EndDate = new DateTime(2000, 1, 1),
        //                OccursOnce = false,
        //                OccursEvery = true,
        //                StartingAt = new DateTime(2000, 1, 1),
        //                EndAt = new DateTime(2000, 1, 1),
        //                EveryTimesWeek = 2,
        //                TimeUnit = TimeUnit.Hours,
        //                EveryTimes = 2,
        //                MondayEnabled = true
        //            };
        //            var execution = schedulerConfiguration.GetNextExecution();
        //            execution[0].Should().Be(new DateTime(2000, 1, 1).ToShortDateString() + " " + new DateTime(2000, 1, 1).ToShortTimeString());
        //            execution[1].Should().Be(string.Format(Global.DescriptionRecurringEveryHours,
        //                                                     new DateTime(2000, 1, 2).ToShortTimeString(),
        //                                                     new DateTime(2000, 1, 1).ToShortTimeString(),
        //                                                     new DateTime(2000, 1, 1),
        //                                                     new DateTime(2000, 1, 1)));
        //        }

        //        [Fact]
        //        public void Validate_Next_Execution_Date_Recurring_Every_Minutes()
        //        {
        //            SchedulerConfiguration schedulerConfiguration = new()
        //            {
        //                Enabled = true,
        //                ExecutionType = ExecutionType.Recurring,
        //                CurrentDate = new DateTime(2000, 1, 1),
        //                ExecutionDate = new DateTime(2000, 1, 1),
        //                StartDate = new DateTime(2000, 1, 1),
        //                EndDate = new DateTime(2000, 1, 1),
        //                OccursOnce = false,
        //                OccursEvery = true,
        //                StartingAt = new DateTime(2000, 1, 1),
        //                EndAt = new DateTime(2000, 1, 1),
        //                EveryTimesWeek = 2,
        //                TimeUnit = TimeUnit.Minutes,
        //                EveryTimes = 2,
        //                MondayEnabled = true
        //            };
        //            var execution = schedulerConfiguration.GetNextExecution();
        //            execution[0].Should().Be(new DateTime(2000, 1, 1).ToShortDateString() + " " + new DateTime(2000, 1, 1).ToShortTimeString());
        //            execution[1].Should().Be(string.Format(Global.DescriptionRecurringEveryMinutes,
        //                                                     new DateTime(2000, 1, 2).ToShortTimeString(),
        //                                                     new DateTime(2000, 1, 1).ToShortTimeString(),
        //                                                     new DateTime(2000, 1, 1),
        //                                                     new DateTime(2000, 1, 1)));
        //        }


        //        [Fact]
        //        public void Validate_Next_Execution_Date_Recurring_Every_Seconds()
        //        {
        //            SchedulerConfiguration schedulerConfiguration = new()
        //            {
        //                Enabled = true,
        //                ExecutionType = ExecutionType.Recurring,
        //                CurrentDate = new DateTime(2000, 1, 1),
        //                ExecutionDate = new DateTime(2000, 1, 1),
        //                StartDate = new DateTime(2000, 1, 1),
        //                EndDate = new DateTime(2000, 1, 1),
        //                OccursOnce = false,
        //                OccursEvery = true,
        //                StartingAt = new DateTime(2000, 1, 1),
        //                EndAt = new DateTime(2000, 1, 1),
        //                EveryTimesWeek = 2,
        //                TimeUnit = TimeUnit.Seconds,
        //                EveryTimes = 2,
        //                MondayEnabled = true
        //            };
        //            var execution = schedulerConfiguration.GetNextExecution();
        //            execution[0].Should().Be(new DateTime(2000, 1, 1).ToShortDateString() + " " + new DateTime(2000, 1, 1).ToShortTimeString());
        //            execution[1].Should().Be(string.Format(Global.DescriptionRecurringEverySeconds,
        //                                                    new DateTime(2000, 1, 2).ToShortTimeString(),
        //                                                    new DateTime(2000, 1, 1).ToShortTimeString(),
        //                                                    new DateTime(2000, 1, 1),
        //                                                    new DateTime(2000, 1, 1)));
        //        }

        //        [Fact]
        //        public void Validate_Next_Execution_Date_Recurring_Once_Monday()
        //        {
        //            SchedulerConfiguration schedulerConfiguration = new()
        //            {
        //                Enabled = true,
        //                ExecutionType = ExecutionType.Recurring,
        //                CurrentDate = new DateTime(2000, 1, 1),
        //                ExecutionDate = new DateTime(2000, 1, 1),
        //                StartDate = new DateTime(2000, 1, 1),
        //                EndDate = new DateTime(2000, 1, 1),
        //                OccursOnce = true,
        //                OccursEvery = false,
        //                OccursOnceTime = new DateTime(2000, 1, 1),
        //                StartingAt = new DateTime(2000, 1, 1),
        //                EndAt = new DateTime(2000, 1, 1),
        //                EveryTimesWeek = 2,
        //                MondayEnabled = true
        //            };
        //            var execution = schedulerConfiguration.GetNextExecution();
        //            execution[0].Should().Be(new DateTime(2000, 1, 1).ToShortDateString() + " " + new DateTime(2000, 1, 1).ToShortTimeString());
        //            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringOnce,
        //                                                            "monday",
        //                                                            new DateTime(2000, 1, 1).ToShortTimeString(),
        //                                                            new DateTime(2000, 1, 1).ToShortTimeString(),
        //                                                            new DateTime(2000, 1, 1).ToShortTimeString(),
        //                                                            new DateTime(2000, 1, 1).ToString(),
        //                                                            new DateTime(2000, 1, 1).ToString()));
        //        }

        //        [Fact]
        //        public void Validate_Next_Execution_Date_Recurring_Once_Monday_Tuesday_Wednesday_Thursday_Friday_Saturday_And_Sunday()
        //        {
        //            SchedulerConfiguration schedulerConfiguration = new()
        //            {
        //                Enabled = true,
        //                ExecutionType = ExecutionType.Recurring,
        //                CurrentDate = new DateTime(2000, 1, 1),
        //                ExecutionDate = new DateTime(2000, 1, 1),
        //                StartDate = new DateTime(2000, 1, 1),
        //                EndDate = new DateTime(2000, 1, 1),
        //                OccursOnce = true,
        //                OccursEvery = false,
        //                OccursOnceTime = new DateTime(2000, 1, 1),
        //                StartingAt = new DateTime(2000, 1, 1),
        //                EndAt = new DateTime(2000, 1, 1),
        //                EveryTimesWeek = 2,
        //                MondayEnabled = true,
        //                TuesdayEnabled = true,
        //                WednesdayEnabled = true,
        //                ThursdayEnabled = true,
        //                FridayEnabled = true,
        //                SaturdayEnabled = true,
        //                SundayEnabled = true
        //            };
        //            var execution = schedulerConfiguration.GetNextExecution();
        //            execution[0].Should().Be(new DateTime(2000, 1, 1).ToShortDateString() + " " + new DateTime(2000, 1, 1).ToShortTimeString());
        //            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringOnce,
        //                            "monday, tuesday, wednesday, thursday, friday, saturday and sunday",
        //                            new DateTime(2000, 1, 1).ToShortTimeString(),
        //                            new DateTime(2000, 1, 1).ToShortTimeString(),
        //                            new DateTime(2000, 1, 1).ToShortTimeString(),
        //                            new DateTime(2000, 1, 1).ToString(),
        //                            new DateTime(2000, 1, 1).ToString()));
        //        }

        //        [Fact]
        //        public void Validate_Next_Execution_Date_Recurring_Monday()
        //        {
        //            SchedulerConfiguration schedulerConfiguration = new()
        //            {
        //                Enabled = true,
        //                ExecutionType = ExecutionType.Recurring,
        //                CurrentDate = new DateTime(2000, 1, 1),
        //                ExecutionDate = new DateTime(2000, 1, 1),
        //                StartDate = new DateTime(2000, 1, 1),
        //                EndDate = new DateTime(2000, 1, 1),
        //                OccursOnce = false,
        //                OccursEvery = true,
        //                StartingAt = new DateTime(2000, 1, 1),
        //                EndAt = new DateTime(2000, 1, 1),
        //                EveryTimesWeek = 2,
        //                TimeUnit = TimeUnit.Seconds,
        //                EveryTimes = 2,
        //                MondayEnabled = true,
        //            };
        //            var execution = schedulerConfiguration.GetNextExecution();
        //            execution[0].Should().Be(new DateTime(2000, 1, 1).ToShortDateString() + " " + new DateTime(2000, 1, 1).ToShortTimeString());
        //            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringEvery,
        //                        "monday",
        //                        new DateTime(2000, 1, 1).ToShortTimeString(),
        //                        new DateTime(2000, 1, 1).ToShortTimeString(),
        //                        new DateTime(2000, 1, 1).ToString(),
        //                        new DateTime(2000, 1, 1).ToString()));
        //        }

        //        [Fact]
        //        public void Validate_Next_Execution_Date_Recurring_Monday_Tuesday_Wednesday_Thursday_Friday_Saturday_And_Sunday()
        //        {
        //            SchedulerConfiguration schedulerConfiguration = new()
        //            {
        //                Enabled = true,
        //                ExecutionType = ExecutionType.Recurring,
        //                CurrentDate = new DateTime(2000, 1, 1),
        //                ExecutionDate = new DateTime(2000, 1, 1),
        //                StartDate = new DateTime(2000, 1, 1),
        //                EndDate = new DateTime(2000, 1, 1),
        //                OccursOnce = false,
        //                OccursEvery = true,
        //                StartingAt = new DateTime(2000, 1, 1),
        //                EndAt = new DateTime(2000, 1, 1),
        //                EveryTimesWeek = 2,
        //                TimeUnit = TimeUnit.Seconds,
        //                EveryTimes = 2,
        //                MondayEnabled = true,
        //                TuesdayEnabled = true,
        //                WednesdayEnabled = true,
        //                ThursdayEnabled = true,
        //                FridayEnabled = true,
        //                SaturdayEnabled = true,
        //                SundayEnabled = true
        //            };
        //            var execution = schedulerConfiguration.GetNextExecution();
        //            execution[0].Should().Be(new DateTime(2000, 1, 1).ToShortDateString() + " " + new DateTime(2000, 1, 1).ToShortTimeString());
        //            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringEvery,
        //                         "monday, tuesday, wednesday, thursday, friday, saturday and sunday",
        //                         new DateTime(2000, 1, 1).ToShortTimeString(),
        //                         new DateTime(2000, 1, 1).ToShortTimeString(),
        //                         new DateTime(2000, 1, 1).ToString(),
        //                         new DateTime(2000, 1, 1).ToString()));
        //        }

        //        [Fact]
        //        public void Validate_Next_Execution_Date_Recurring_Every_Seconds_Series()
        //        {
        //            SchedulerConfiguration schedulerConfiguration = new()
        //            {
        //                Enabled = true,
        //                ExecutionType = ExecutionType.Recurring,
        //                CurrentDate = new DateTime(2000, 1, 1),
        //                ExecutionDate = new DateTime(2000, 1, 1),
        //                StartDate = new DateTime(2000, 1, 1),
        //                EndDate = new DateTime(2000, 1, 1),
        //                OccursOnce = false,
        //                OccursEvery = true,
        //                StartingAt = new DateTime(2000, 1, 1),
        //                EndAt = new DateTime(2000, 1, 1, 0, 0, 40),
        //                EveryTimesWeek = 2,
        //                TimeUnit = TimeUnit.Seconds,
        //                EveryTimes = 15,
        //                MondayEnabled = true,
        //                TuesdayEnabled = true,
        //                WednesdayEnabled = true,
        //                ThursdayEnabled = true,
        //                FridayEnabled = true,
        //                SaturdayEnabled = true,
        //                SundayEnabled = true
        //            };

        //            var result = schedulerConfiguration.CalculateSerie(8);
        //            result[0].Should().Be(new DateTime(2000, 1, 1, 0, 0, 0).ToString());
        //            result[1].Should().Be(new DateTime(2000, 1, 1, 0, 0, 15).ToString());
        //            result[2].Should().Be(new DateTime(2000, 1, 1, 0, 0, 30).ToString());
        //            result[3].Should().Be(new DateTime(2000, 1, 2, 0, 0, 5).ToString());
        //            result[4].Should().Be(new DateTime(2000, 1, 2, 0, 0, 20).ToString());
        //            result[5].Should().Be(new DateTime(2000, 1, 2, 0, 0, 35).ToString());
        //            result[6].Should().Be(new DateTime(2000, 1, 3, 0, 0, 10).ToString());
        //            result[7].Should().Be(new DateTime(2000, 1, 3, 0, 0, 25).ToString());
        //        }

        //        [Fact]
        //        public void Validate_Next_Execution_Date_Recurring_Every_Minutes_Series()
        //        {
        //            SchedulerConfiguration schedulerConfiguration = new()
        //            {
        //                Enabled = true,
        //                ExecutionType = ExecutionType.Recurring,
        //                CurrentDate = new DateTime(2000, 1, 1),
        //                ExecutionDate = new DateTime(2000, 1, 1),
        //                StartDate = new DateTime(2000, 1, 1),
        //                EndDate = new DateTime(2000, 1, 1),
        //                OccursOnce = false,
        //                OccursEvery = true,
        //                StartingAt = new DateTime(2000, 1, 1),
        //                EndAt = new DateTime(2000, 1, 1, 0, 10, 0),
        //                EveryTimesWeek = 2,
        //                TimeUnit = TimeUnit.Minutes,
        //                EveryTimes = 2,
        //                MondayEnabled = true,
        //                TuesdayEnabled = true,
        //                WednesdayEnabled = true,
        //                ThursdayEnabled = true,
        //                FridayEnabled = true,
        //                SaturdayEnabled = true,
        //                SundayEnabled = true
        //            };

        //            var result = schedulerConfiguration.CalculateSerie(8);
        //            result[0].Should().Be(new DateTime(2000, 1, 1, 0, 0, 0).ToString());
        //            result[1].Should().Be(new DateTime(2000, 1, 1, 0, 2, 0).ToString());
        //            result[2].Should().Be(new DateTime(2000, 1, 1, 0, 4, 0).ToString());
        //            result[3].Should().Be(new DateTime(2000, 1, 1, 0, 6, 0).ToString());
        //            result[4].Should().Be(new DateTime(2000, 1, 1, 0, 8, 0).ToString());
        //            result[5].Should().Be(new DateTime(2000, 1, 1, 0, 10, 0).ToString());
        //            result[6].Should().Be(new DateTime(2000, 1, 2, 0, 0, 0).ToString());
        //            result[7].Should().Be(new DateTime(2000, 1, 2, 0, 2, 0).ToString());
        //        }

        //        [Fact]
        //        public void Validate_Next_Execution_Date_Recurring_Every_Hours_Series()
        //        {
        //            SchedulerConfiguration schedulerConfiguration = new()
        //            {
        //                Enabled = true,
        //                ExecutionType = ExecutionType.Recurring,
        //                CurrentDate = new DateTime(2000, 1, 1),
        //                ExecutionDate = new DateTime(2000, 1, 1),
        //                StartDate = new DateTime(2000, 1, 1),
        //                EndDate = new DateTime(2000, 1, 1),
        //                OccursOnce = false,
        //                OccursEvery = true,
        //                StartingAt = new DateTime(2000, 1, 1),
        //                EndAt = new DateTime(2000, 1, 1, 10, 0, 0),
        //                EveryTimesWeek = 2,
        //                TimeUnit = TimeUnit.Hours,
        //                EveryTimes = 2,
        //                MondayEnabled = true,
        //                TuesdayEnabled = true,
        //                WednesdayEnabled = true,
        //                ThursdayEnabled = true,
        //                FridayEnabled = true,
        //                SaturdayEnabled = true,
        //                SundayEnabled = true
        //            };

        //            var result = schedulerConfiguration.CalculateSerie(8);
        //            result[0].Should().Be(new DateTime(2000, 1, 1, 0, 0, 0).ToString());
        //            result[1].Should().Be(new DateTime(2000, 1, 1, 2, 0, 0).ToString());
        //            result[2].Should().Be(new DateTime(2000, 1, 1, 4, 0, 0).ToString());
        //            result[3].Should().Be(new DateTime(2000, 1, 1, 6, 0, 0).ToString());
        //            result[4].Should().Be(new DateTime(2000, 1, 1, 8, 0, 0).ToString());
        //            result[5].Should().Be(new DateTime(2000, 1, 1, 10, 0, 0).ToString());
        //            result[6].Should().Be(new DateTime(2000, 1, 2, 0, 0, 0).ToString());
        //            result[7].Should().Be(new DateTime(2000, 1, 2, 2, 0, 0).ToString());
        //        }

        //        [Fact]
        //        public void Validate_Next_Execution_Date_Recurring_Every_Hours_Monday_And_Tuesday_Series()
        //        {
        //            SchedulerConfiguration schedulerConfiguration = new()
        //            {
        //                Enabled = true,
        //                ExecutionType = ExecutionType.Recurring,
        //                CurrentDate = new DateTime(2000, 1, 1),
        //                ExecutionDate = new DateTime(2000, 1, 1),
        //                StartDate = new DateTime(2000, 1, 1),
        //                EndDate = new DateTime(2000, 1, 1),
        //                OccursOnce = false,
        //                OccursEvery = true,
        //                StartingAt = new DateTime(2000, 1, 1),
        //                EndAt = new DateTime(2000, 1, 1, 10, 0, 0),
        //                EveryTimesWeek = 2,
        //                TimeUnit = TimeUnit.Hours,
        //                EveryTimes = 4,
        //                MondayEnabled = true,
        //                WednesdayEnabled = true,             
        //            };

        //            var result = schedulerConfiguration.CalculateSerie(8);
        //            result[0].Should().Be(new DateTime(2000, 1, 1, 0, 0, 0).ToString());
        //            result[1].Should().Be(new DateTime(2000, 1, 1, 4, 0, 0).ToString());
        //            result[2].Should().Be(new DateTime(2000, 1, 1, 8, 0, 0).ToString());
        //            result[3].Should().Be(new DateTime(2000, 1, 3, 0, 0, 0).ToString());
        //            result[4].Should().Be(new DateTime(2000, 1, 3, 4, 0, 0).ToString());
        //            result[5].Should().Be(new DateTime(2000, 1, 3, 8, 0, 0).ToString());
        //            result[6].Should().Be(new DateTime(2000, 1, 5, 0, 0, 0).ToString());
        //            result[7].Should().Be(new DateTime(2000, 1, 5, 4, 0, 0).ToString());
        //        }

        //        [Fact]
        //        public void Validate_Next_Execution_Date_Recurring_Every_Hours_All_Days()
        //        {
        //            SchedulerConfiguration schedulerConfiguration = new()
        //            {
        //                Enabled = true,
        //                ExecutionType = ExecutionType.Recurring,
        //                CurrentDate = new DateTime(2000, 1, 1),
        //                ExecutionDate = new DateTime(2000, 1, 1),
        //                StartDate = new DateTime(2000, 1, 1),
        //                EndDate = new DateTime(2000, 1, 1),
        //                OccursOnce = false,
        //                OccursEvery = true,
        //                StartingAt = new DateTime(2000, 1, 1),
        //                EndAt = new DateTime(2000, 1, 1, 6, 0, 0),
        //                EveryTimesWeek = 2,
        //                TimeUnit = TimeUnit.Hours,
        //                EveryTimes = 4,
        //                MondayEnabled = true,
        //                TuesdayEnabled = true,
        //                WednesdayEnabled = true,
        //                ThursdayEnabled = true,
        //                FridayEnabled = true,
        //                SaturdayEnabled = true,
        //                SundayEnabled = true
        //            };

        //            var result = schedulerConfiguration.CalculateSerie(14);
        //            result[0].Should().Be(new DateTime(2000, 1, 1, 0, 0, 0).ToString());
        //            result[1].Should().Be(new DateTime(2000, 1, 1, 4, 0, 0).ToString());
        //            result[2].Should().Be(new DateTime(2000, 1, 2, 0, 0, 0).ToString());
        //            result[3].Should().Be(new DateTime(2000, 1, 2, 4, 0, 0).ToString());
        //            result[4].Should().Be(new DateTime(2000, 1, 3, 0, 0, 0).ToString());
        //            result[5].Should().Be(new DateTime(2000, 1, 3, 4, 0, 0).ToString());
        //            result[6].Should().Be(new DateTime(2000, 1, 4, 0, 0, 0).ToString());
        //            result[7].Should().Be(new DateTime(2000, 1, 4, 4, 0, 0).ToString());
        //            result[8].Should().Be(new DateTime(2000, 1, 5, 0, 0, 0).ToString());
        //            result[9].Should().Be(new DateTime(2000, 1, 5, 4, 0, 0).ToString());
        //            result[10].Should().Be(new DateTime(2000, 1, 6, 0, 0, 0).ToString());
        //            result[11].Should().Be(new DateTime(2000, 1, 6, 4, 0, 0).ToString());
        //            result[12].Should().Be(new DateTime(2000, 1, 7, 0, 0, 0).ToString());
        //            result[13].Should().Be(new DateTime(2000, 1, 7, 4, 0, 0).ToString());
        //        }
    }
}
