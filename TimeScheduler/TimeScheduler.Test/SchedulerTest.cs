using Xunit;
using TimeScheduler.Test.Resources;
using FluentAssertions;
using System;

namespace TimeScheduler.Test
{
    public class SchedulerTest
    {
        [Fact]
        public void Validate_enabled_false()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = false
            });
            scheduler.Invoking(s => s.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Enabled is false.");
        }

        [Fact]
        public void Validate_num_days_zero()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1)
            });
            scheduler.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Num Days is zero.");
        }

        [Fact]
        public void Validate_num_days_less_than_zero()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = -1
            });
            scheduler.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Num Days is negative.");
        }

        [Fact]
        public void Validate_next_execution_date_max_date()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(8000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 999999,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1)
            });
            scheduler.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Next execution date is max date.");
        }

        [Fact]
        public void Validate_next_daily_configuration_occurs_false()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = false
            });
            scheduler.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Occurs is false two times.");
        }


        [Fact]
        public void Validate_next_daily_configuration_occurs_true()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = true
            });
            scheduler.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Occurs is true two times.");
        }

        [Fact]
        public void Validate_next_daily_configuration_occurs_every_times_null()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = true
            });
            scheduler.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Occurs every times is zero.");
        }

        [Fact]
        public void Validate_next_daily_configuration_occurs_every_less_than_zero()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = true,
                EveryTimes = -1
            });
            scheduler.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Occurs every times is negative.");
        }

        [Fact]
        public void Validate_next_weekly_configuration_times_zero()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = false,
                OccursOnceTime = new DateTime(2000, 1, 1),
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1)
            });
            scheduler.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Every times week is zero.");
        }

        [Fact]
        public void Validate_next_weekly_configuration_times_negative()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = false,
                OccursOnceTime = new DateTime(2000, 1, 1),
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = -1
            });
            scheduler.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("Every times week is negative.");
        }

        [Fact]
        public void Validate_next_weekly_configuration_no_week_day()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = false,
                OccursOnceTime = new DateTime(2000, 1, 1),
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 1
            });
            scheduler.Invoking(y => y.GetNextExecution())
                .Should().Throw<TimeSchedulerException>()
                .WithMessage("No week days selected.");
        }
        [Fact]
        public void Validate_next_execution_date_once()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Once,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1)
            });
            var execution = scheduler.GetNextExecution();
            execution.Length.Should().Be(2);
            execution[0].Should().Be(new DateTime(2000, 1, 1).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionOnce,
                                                       new DateTime(2000, 1, 1).ToShortDateString(),
                                                       new DateTime(2000, 1, 1).ToShortTimeString(),
                                                       new DateTime(2000, 1, 1),
                                                       new DateTime(2000, 1, 1)));
        }

        [Fact]
        public void Validate_next_execution_date_recurring_every_hours()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = true,
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 2,
                TimeUnit = TimeUnit.Hours,
                EveryTimes = 2,
                MondayEnabled = true
            });
            var execution = scheduler.GetNextExecution();
            execution[0].Should().Be(new DateTime(2000, 1, 2).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionRecurringEveryHours,
                                                     new DateTime(2000, 1, 2).ToShortTimeString(),
                                                     new DateTime(2000, 1, 1).ToShortTimeString(),
                                                     new DateTime(2000, 1, 1),
                                                     new DateTime(2000, 1, 1)));
        }

        [Fact]
        public void Validate_next_execution_date_recurring_every_minutes()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = true,
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 2,
                TimeUnit = TimeUnit.Minutes,
                EveryTimes = 2,
                MondayEnabled = true
            });
            var execution = scheduler.GetNextExecution();
            execution[0].Should().Be(new DateTime(2000, 1, 2).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionRecurringEveryMinutes,
                                                     new DateTime(2000, 1, 2).ToShortTimeString(),
                                                     new DateTime(2000, 1, 1).ToShortTimeString(),
                                                     new DateTime(2000, 1, 1),
                                                     new DateTime(2000, 1, 1)));
        }


        [Fact]
        public void Validate_next_execution_date_recurring_every_seconds()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = true,
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 2,
                TimeUnit = TimeUnit.Seconds,
                EveryTimes = 2,
                MondayEnabled = true
            });
            var execution = scheduler.GetNextExecution();
            execution[0].Should().Be(new DateTime(2000, 1, 2).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionRecurringEverySeconds,
                                                    new DateTime(2000, 1, 2).ToShortTimeString(),
                                                    new DateTime(2000, 1, 1).ToShortTimeString(),
                                                    new DateTime(2000, 1, 1),
                                                    new DateTime(2000, 1, 1)));
        }

        [Fact]
        public void Validate_next_execution_date_recurring_once_monday()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = false,
                OccursOnceTime = new DateTime(2000, 1, 1),
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 2,
                MondayEnabled = true
            });
            var execution = scheduler.GetNextExecution();
            execution[0].Should().Be(new DateTime(2000, 1, 2).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringOnce,
                                                            "monday",
                                                            new DateTime(2000, 1, 1).ToShortTimeString(),
                                                            new DateTime(2000, 1, 1).ToShortTimeString(),
                                                            new DateTime(2000, 1, 1).ToShortTimeString(),
                                                            new DateTime(2000, 1, 1).ToString(),
                                                            new DateTime(2000, 1, 1).ToString()));
        }

        [Fact]
        public void Validate_next_execution_date_recurring_once_monday_and_tuesday()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = false,
                OccursOnceTime = new DateTime(2000, 1, 1),
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 2,
                MondayEnabled = true,
                TuesdayEnabled = true
            });
            var execution = scheduler.GetNextExecution();
            execution[0].Should().Be(new DateTime(2000, 1, 2).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringOnce,
                                                            "monday and tuesday",
                                                            new DateTime(2000, 1, 1).ToShortTimeString(),
                                                            new DateTime(2000, 1, 1).ToShortTimeString(),
                                                            new DateTime(2000, 1, 1).ToShortTimeString(),
                                                            new DateTime(2000, 1, 1).ToString(),
                                                            new DateTime(2000, 1, 1).ToString()));
        }

        [Fact]
        public void Validate_next_execution_date_recurring_once_monday_tuesday_and_wednesday()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = false,
                OccursOnceTime = new DateTime(2000, 1, 1),
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 2,
                MondayEnabled = true,
                TuesdayEnabled = true,
                WednesdayEnabled = true
            });
            var execution = scheduler.GetNextExecution();
            execution[0].Should().Be(new DateTime(2000, 1, 2).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringOnce,
                                                        "monday, tuesday and wednesday",
                                                        new DateTime(2000, 1, 1).ToShortTimeString(),
                                                        new DateTime(2000, 1, 1).ToShortTimeString(),
                                                        new DateTime(2000, 1, 1).ToShortTimeString(),
                                                        new DateTime(2000, 1, 1).ToString(),
                                                        new DateTime(2000, 1, 1).ToString()));
        }

        [Fact]
        public void Validate_next_execution_date_recurring_once_monday_tuesday_wednesday_and_thursday()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = false,
                OccursOnceTime = new DateTime(2000, 1, 1),
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 2,
                MondayEnabled = true,
                TuesdayEnabled = true,
                WednesdayEnabled = true,
                ThursdayEnabled = true
            });
            var execution = scheduler.GetNextExecution();
            execution[0].Should().Be(new DateTime(2000, 1, 2).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringOnce,
                                               "monday, tuesday, wednesday and thursday",
                                               new DateTime(2000, 1, 1).ToShortTimeString(),
                                               new DateTime(2000, 1, 1).ToShortTimeString(),
                                               new DateTime(2000, 1, 1).ToShortTimeString(),
                                               new DateTime(2000, 1, 1).ToString(),
                                               new DateTime(2000, 1, 1).ToString()));
        }

        [Fact]
        public void Validate_next_execution_date_recurring_once_monday_tuesday_wednesday_thursday_and_friday()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = false,
                OccursOnceTime = new DateTime(2000, 1, 1),
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 2,
                MondayEnabled = true,
                TuesdayEnabled = true,
                WednesdayEnabled = true,
                ThursdayEnabled = true,
                FridayEnabled = true
            });
            var execution = scheduler.GetNextExecution();
            execution[0].Should().Be(new DateTime(2000, 1, 2).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringOnce,
                                   "monday, tuesday, wednesday, thursday and friday",
                                   new DateTime(2000, 1, 1).ToShortTimeString(),
                                   new DateTime(2000, 1, 1).ToShortTimeString(),
                                   new DateTime(2000, 1, 1).ToShortTimeString(),
                                   new DateTime(2000, 1, 1).ToString(),
                                   new DateTime(2000, 1, 1).ToString()));
        }

        [Fact]
        public void Validate_next_execution_date_recurring_once_monday_tuesday_wednesday_thursday_friday_and_saturday()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = false,
                OccursOnceTime = new DateTime(2000, 1, 1),
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 2,
                MondayEnabled = true,
                TuesdayEnabled = true,
                WednesdayEnabled = true,
                ThursdayEnabled = true,
                FridayEnabled = true,
                SaturdayEnabled = true
            });
            var execution = scheduler.GetNextExecution();
            execution[0].Should().Be(new DateTime(2000, 1, 2).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringOnce,
                       "monday, tuesday, wednesday, thursday, friday and saturday",
                       new DateTime(2000, 1, 1).ToShortTimeString(),
                       new DateTime(2000, 1, 1).ToShortTimeString(),
                       new DateTime(2000, 1, 1).ToShortTimeString(),
                       new DateTime(2000, 1, 1).ToString(),
                       new DateTime(2000, 1, 1).ToString()));
        }

        [Fact]
        public void Validate_next_execution_date_recurring_once_monday_tuesday_wednesday_thursday_friday_saturday_and_sunday()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = true,
                OccursEvery = false,
                OccursOnceTime = new DateTime(2000, 1, 1),
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 2,
                MondayEnabled = true,
                TuesdayEnabled = true,
                WednesdayEnabled = true,
                ThursdayEnabled = true,
                FridayEnabled = true,
                SaturdayEnabled = true,
                SundayEnabled = true
            });
            var execution = scheduler.GetNextExecution();
            execution[0].Should().Be(new DateTime(2000, 1, 2).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringOnce,
                            "monday, tuesday, wednesday, thursday, friday, saturday and sunday",
                            new DateTime(2000, 1, 1).ToShortTimeString(),
                            new DateTime(2000, 1, 1).ToShortTimeString(),
                            new DateTime(2000, 1, 1).ToShortTimeString(),
                            new DateTime(2000, 1, 1).ToString(),
                            new DateTime(2000, 1, 1).ToString()));
        }

        [Fact]
        public void Validate_next_execution_date_recurring_monday_and_tuesday()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = true,
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 2,
                TimeUnit = TimeUnit.Seconds,
                EveryTimes = 2,
                MondayEnabled = true,
                TuesdayEnabled = true
            });
            var execution = scheduler.GetNextExecution();
            execution[0].Should().Be(new DateTime(2000, 1, 2).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringEvery,
                        "monday and tuesday",
                        new DateTime(2000, 1, 1).ToShortTimeString(),
                        new DateTime(2000, 1, 1).ToShortTimeString(),
                        new DateTime(2000, 1, 1).ToString(),
                        new DateTime(2000, 1, 1).ToString()));
        }

        [Fact]
        public void Validate_next_execution_date_recurring_monday_tuesday_and_wednesday()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = true,
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 2,
                TimeUnit = TimeUnit.Seconds,
                EveryTimes = 2,
                MondayEnabled = true,
                TuesdayEnabled = true,
                WednesdayEnabled = true
            });
            var execution = scheduler.GetNextExecution();
            execution[0].Should().Be(new DateTime(2000, 1, 2).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringEvery,
                        "monday, tuesday and wednesday",
                        new DateTime(2000, 1, 1).ToShortTimeString(),
                        new DateTime(2000, 1, 1).ToShortTimeString(),
                        new DateTime(2000, 1, 1).ToString(),
                        new DateTime(2000, 1, 1).ToString()));
        }

        [Fact]
        public void Validate_next_execution_date_recurring_monday_tuesday_wednesday_and_thursday()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = true,
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 2,
                TimeUnit = TimeUnit.Seconds,
                EveryTimes = 2,
                MondayEnabled = true,
                TuesdayEnabled = true,
                WednesdayEnabled = true,
                ThursdayEnabled = true
            });
            var execution = scheduler.GetNextExecution();
            execution[0].Should().Be(new DateTime(2000, 1, 2).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringEvery,
                            "monday, tuesday, wednesday and thursday",
                            new DateTime(2000, 1, 1).ToShortTimeString(),
                            new DateTime(2000, 1, 1).ToShortTimeString(),
                            new DateTime(2000, 1, 1).ToString(),
                            new DateTime(2000, 1, 1).ToString()));
        }

        [Fact]
        public void Validate_next_execution_date_recurring_monday_tuesday_wednesday_thursday_and_friday()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = true,
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 2,
                TimeUnit = TimeUnit.Seconds,
                EveryTimes = 2,
                MondayEnabled = true,
                TuesdayEnabled = true,
                WednesdayEnabled = true,
                ThursdayEnabled = true,
                FridayEnabled = true
            });
            var execution = scheduler.GetNextExecution();
            execution[0].Should().Be(new DateTime(2000, 1, 2).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringEvery,
                  "monday, tuesday, wednesday, thursday and friday",
                  new DateTime(2000, 1, 1).ToShortTimeString(),
                  new DateTime(2000, 1, 1).ToShortTimeString(),
                  new DateTime(2000, 1, 1).ToString(),
                  new DateTime(2000, 1, 1).ToString()));
        }

        [Fact]
        public void Validate_next_execution_date_recurring_monday_tuesday_wednesday_thursday_friday_and_saturday()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = true,
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 2,
                TimeUnit = TimeUnit.Seconds,
                EveryTimes = 2,
                MondayEnabled = true,
                TuesdayEnabled = true,
                WednesdayEnabled = true,
                ThursdayEnabled = true,
                FridayEnabled = true,
                SaturdayEnabled = true
            });
            var execution = scheduler.GetNextExecution();
            execution[0].Should().Be(new DateTime(2000, 1, 2).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringEvery,
                         "monday, tuesday, wednesday, thursday, friday and saturday",
                         new DateTime(2000, 1, 1).ToShortTimeString(),
                         new DateTime(2000, 1, 1).ToShortTimeString(),
                         new DateTime(2000, 1, 1).ToString(),
                         new DateTime(2000, 1, 1).ToString()));
        }

        [Fact]
        public void Validate_next_execution_date_recurring_monday_tuesday_wednesday_thursday_friday_saturday_and_sunday()
        {
            Scheduler scheduler = new(new SchedulerConfiguration
            {
                Enabled = true,
                ExecutionType = ExecutionType.Recurring,
                CurrentDate = new DateTime(2000, 1, 1),
                ExecutionDate = new DateTime(2000, 1, 1),
                NumDays = 1,
                StartDate = new DateTime(2000, 1, 1),
                EndDate = new DateTime(2000, 1, 1),
                OccursOnce = false,
                OccursEvery = true,
                StartingAt = new DateTime(2000, 1, 1),
                EndAt = new DateTime(2000, 1, 1),
                EveryTimesWeek = 2,
                TimeUnit = TimeUnit.Seconds,
                EveryTimes = 2,
                MondayEnabled = true,
                TuesdayEnabled = true,
                WednesdayEnabled = true,
                ThursdayEnabled = true,
                FridayEnabled = true,
                SaturdayEnabled = true,
                SundayEnabled = true
            });
            var execution = scheduler.GetNextExecution();
            execution[0].Should().Be(new DateTime(2000, 1, 2).ToShortDateString());
            execution[1].Should().Be(string.Format(Global.DescriptionNextDateRecurringEvery,
                         "monday, tuesday, wednesday, thursday, friday, saturday and sunday",
                         new DateTime(2000, 1, 1).ToShortTimeString(),
                         new DateTime(2000, 1, 1).ToShortTimeString(),
                         new DateTime(2000, 1, 1).ToString(),
                         new DateTime(2000, 1, 1).ToString()));
        }
    }
}
