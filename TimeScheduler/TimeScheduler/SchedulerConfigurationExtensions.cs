using System;
using TimeScheduler.Resources;

namespace TimeScheduler
{
    public static class SchedulerConfigurationExtensions
    {
        public static ExecutionResult GetNextExecution(this SchedulerConfiguration schedulerConfiguration)
        {
            InitializeResources(schedulerConfiguration);
            Validate(schedulerConfiguration);
            ExecutionResult executionResult = NextDateResult(schedulerConfiguration, null);
            return executionResult;
        }

        public static ExecutionResult[] GetNextExecutionSeries(this SchedulerConfiguration schedulerConfiguration, int numSeries)
        {
            InitializeResources(schedulerConfiguration);
            Validate(schedulerConfiguration);
            DateTime? currentDate = null;
            ExecutionResult[] result = new ExecutionResult[numSeries];
            for (int i = 0; i < numSeries; i++)
            {
                currentDate = GetNewTime(schedulerConfiguration, currentDate);
                if (currentDate.HasValue &&
                    currentDate.Value >= schedulerConfiguration.EndDate.ChangeTime(schedulerConfiguration.EndTime))
                {
                    currentDate = schedulerConfiguration.EndDate;
                }
                result[i] = NextDateResult(schedulerConfiguration, currentDate.Value);
            }
            return result;
        }

        #region private methods
        private static void Validate(SchedulerConfiguration schedulerConfiguration)
        {
            ValidateEnabled(schedulerConfiguration);
            ValidateCommonDates(schedulerConfiguration);
            switch (schedulerConfiguration.ExecutionType)
            {
                case ExecutionType.Once:
                    ValidateOnceConfiguration(schedulerConfiguration);
                    break;
                case ExecutionType.Recurring:
                    ValidateRecurringConfiguration(schedulerConfiguration);
                    break;
            }
        }

        private static ExecutionResult NextDateResult(SchedulerConfiguration schedulerConfiguration, DateTime? currentDate)
        {
            ExecutionResult executionResult = new();
            switch (schedulerConfiguration.ExecutionType)
            {
                case ExecutionType.Once:
                    executionResult = CalculateNextDateOnce(schedulerConfiguration);
                    break;
                case ExecutionType.Recurring:
                    executionResult = CalculateNewResult(schedulerConfiguration, currentDate);
                    break;
            }
            return executionResult;
        }

        private static void InitializeResources(SchedulerConfiguration schedulerConfiguration)
        {
            SchedulerResourceManager.Initialize(schedulerConfiguration);
        }

        private static ExecutionResult CalculateNewResult(SchedulerConfiguration schedulerConfiguration, DateTime? currentDate)
        {
            DateTime newDate;
            if (currentDate == null)
            {
                newDate = CalculateStartDate(schedulerConfiguration);
            }
            else
            {
                newDate = currentDate.Value;
            }
            return new ExecutionResult
            {
                NextExecution = newDate,
                Description = DescriptionManager.GetRecurringDescription(schedulerConfiguration)
            };
        }

        private static DateTime CalculateNextDateRecurring(SchedulerConfiguration schedulerConfiguration, DateTime actualDate)
        {
            return schedulerConfiguration.FrecuencyType switch
            {
                FrecuencyType.Daily => GetDailyResult(schedulerConfiguration, actualDate),
                FrecuencyType.Weekly => CalculateNextDayWeek(schedulerConfiguration, actualDate),
                FrecuencyType.Monthly => OrdinalDate(schedulerConfiguration, actualDate, 1),
                _ => throw new NotImplementedException()
            };
        }

        private static DateTime OrdinalDate(SchedulerConfiguration schedulerConfiguration, DateTime currentDate, int month)
        {
            DateTime date = GetDateToStart(currentDate, month);
            int position = (int)schedulerConfiguration.OrdinalConfiguration;
            if ((int)schedulerConfiguration.DayOfWeek < 7)
            {
                if (schedulerConfiguration.OrdinalConfiguration == OrdinalConfiguration.Last)
                {
                    position = GetLastDay(schedulerConfiguration, currentDate);
                }
                return NewMonthNormalDay(date, schedulerConfiguration, currentDate, position).ChangeTime(schedulerConfiguration.StartTime);
            }
            else
            {
                return CalculateNewMonthDate(date, schedulerConfiguration, currentDate).ChangeTime(schedulerConfiguration.StartTime);
            }
        }

        private static DateTime CalculateNewMonthDate(DateTime date, SchedulerConfiguration schedulerConfiguration, DateTime currentDate)
        {
            return (int)schedulerConfiguration.DayOfWeek switch
            {
                7 => FoundNewDay(date, schedulerConfiguration),
                8 => FoundWeekDay(date, schedulerConfiguration, currentDate),
                9 => FoundWeekendDay(date, schedulerConfiguration, currentDate),
                _ => throw new TimeSchedulerException()
            };
        }

        private static DateTime FoundNewDay(DateTime date, SchedulerConfiguration schedulerConfiguration)
        {
            int ordinal = 0;
            int position = (int)schedulerConfiguration.OrdinalConfiguration;
            if (schedulerConfiguration.OrdinalConfiguration == OrdinalConfiguration.Last)
            {
                position = DateTime.DaysInMonth(date.Year, date.Month);
            }
            for (int i = 0; i < DateTime.DaysInMonth(date.Year, date.Month); i++)
            {
                ordinal++;
                if (position == ordinal)
                {
                    return date.ChangeTime(schedulerConfiguration.StartTime);
                }
                date = date.AddDays(1);
            }
            return date;
        }

        private static DateTime FoundWeekendDay(DateTime date, SchedulerConfiguration schedulerConfiguration, DateTime currentDate)
        {
            int ordinal = 0;
            int position = (int)schedulerConfiguration.OrdinalConfiguration;
            if (schedulerConfiguration.OrdinalConfiguration == OrdinalConfiguration.Last)
            {
                return GetLastWeekendDay(date, schedulerConfiguration);
            }
            for (int i = 0; i < DateTime.DaysInMonth(currentDate.Year, currentDate.Month); i++)
            {
                int addDays = 1;
                if ((int)date.DayOfWeek == 0 ||
                    (int)date.DayOfWeek == 6)
                {
                    ordinal++;
                    if ((int)date.DayOfWeek == 6)
                    {
                        addDays = 2;
                    }                    
                    if (position == ordinal)
                    {
                        return date.ChangeTime(schedulerConfiguration.StartTime);
                    }
                }
                date = date.AddDays(addDays);
            }
            return date;
        }

        private static DateTime GetLastWeekendDay(DateTime date, SchedulerConfiguration schedulerConfiguration)
        {
            DateTime newDate = new(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            for (int i = DateTime.DaysInMonth(date.Year, date.Month); i > 1; i--)
            {
                if ((int)newDate.DayOfWeek == 0 ||
                    (int)newDate.DayOfWeek == 6)
                {
                    if ((int)newDate.DayOfWeek == 0)
                    {
                        return newDate.ChangeTime(schedulerConfiguration.StartTime).AddDays(-1);
                    }
                    else
                    {
                        return newDate.ChangeTime(schedulerConfiguration.StartTime);
                    }
                }
                newDate = newDate.AddDays(-1);
            }
            return newDate;
        }

        private static DateTime FoundWeekDay(DateTime date, SchedulerConfiguration schedulerConfiguration, DateTime currentDate)
        {
            int ordinal = 0;
            int position = (int)schedulerConfiguration.OrdinalConfiguration;
            if (schedulerConfiguration.OrdinalConfiguration == OrdinalConfiguration.Last)
            {
                return GetLastWeekDay(date, schedulerConfiguration);
            }
            else
            {
                for (int i = 0; i < DateTime.DaysInMonth(currentDate.Year, currentDate.Month); i++)
                {
                    if ((int)date.DayOfWeek != 0 &&
                        (int)date.DayOfWeek != 6)
                    {
                        ordinal++;
                        if (position == ordinal)
                        {
                            return date.ChangeTime(schedulerConfiguration.StartTime);
                        }
                    }
                    date = date.AddDays(1);
                }
            }
            return date;
        }

        private static DateTime GetLastWeekDay(DateTime date, SchedulerConfiguration schedulerConfiguration)
        {
            DateTime newDate = new(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            for (int i = DateTime.DaysInMonth(date.Year, date.Month); i > 1; i--)
            {
                if ((int)newDate.DayOfWeek != 0 &&
                    (int)newDate.DayOfWeek != 6)
                {
                    return newDate.ChangeTime(schedulerConfiguration.StartTime);
                }
                newDate = newDate.AddDays(-1);
            }
            return newDate;
        }

        private static DateTime NewMonthNormalDay(DateTime date, SchedulerConfiguration schedulerConfiguration, DateTime currentDate, int position)
        {
            int ordinal = 0;
            for (int i = 0; i < DateTime.DaysInMonth(currentDate.Year, currentDate.Month); i++)
            {
                if ((int)date.DayOfWeek == (int)schedulerConfiguration.DayOfWeek)
                {
                    ordinal++;
                    if (position == ordinal)
                    {
                        return date.ChangeTime(schedulerConfiguration.StartTime);
                    }
                }
                date = date.AddDays(1);
            }
            return date;
        }

        private static DateTime GetDateToStart(DateTime currentDate, int month)
        {
            DateTime startDate;
            if (month == 0)
            {
                startDate = new(currentDate.Year, currentDate.Month, 1);
            }
            else
            {
                if (currentDate.Month + 1 > 12)
                {
                    startDate = new(currentDate.Year + 1, 1, 1);
                }
                else
                {
                    startDate = new(currentDate.Year, currentDate.Month + 1, 1);
                }
            }
            return startDate;
        }

        private static int GetLastDay(SchedulerConfiguration schedulerConfiguration, DateTime currentDate)
        {
            DateTime newDate = new(currentDate.Year, currentDate.Month, 1);
            int ordinal = 0;
            for (int h = 0; h < DateTime.DaysInMonth(currentDate.Year, currentDate.Month); h++)
            {
                if ((int)newDate.DayOfWeek == (int)schedulerConfiguration.DayOfWeek)
                {
                    ordinal++;
                }
                newDate = newDate.AddDays(1);
            }
            return ordinal;
        }

        private static DateTime GetNewTime(SchedulerConfiguration schedulerConfiguration, DateTime? currentDate)
        {
            return currentDate == null
            ? CalculateStartDate(schedulerConfiguration)
            : schedulerConfiguration.TimeUnit switch
            {
                TimeUnit.Seconds => NextDateSeconds(schedulerConfiguration, currentDate.Value),
                TimeUnit.Minutes => NextDateMinutes(schedulerConfiguration, currentDate.Value),
                TimeUnit.Hours => NextDateHours(schedulerConfiguration, currentDate.Value),
                _ => throw new NotImplementedException()
            };
        }

        private static DateTime CalculateStartDate(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.FrecuencyType == FrecuencyType.Weekly)
            {
                return CalculateNextDayWeek(schedulerConfiguration, schedulerConfiguration.StartDate);
            }
            if (schedulerConfiguration.FrecuencyType == FrecuencyType.Monthly)
            {
                return OrdinalDate(schedulerConfiguration, schedulerConfiguration.StartDate, 0);
            }
            else
            {
                return schedulerConfiguration.StartDate.ChangeTime(schedulerConfiguration.StartTime);
            }
        }

        private static DateTime NextDateMinutes(SchedulerConfiguration schedulerConfiguration, DateTime currentDate)
        {
            DateTime dateTime;
            if (currentDate.AddMinutes(schedulerConfiguration.TimeUnitFrequency) > currentDate.ChangeTime(schedulerConfiguration.EndTime))
            {
                dateTime = CalculateNextDateRecurring(schedulerConfiguration, currentDate).ChangeTime(schedulerConfiguration.StartTime);
            }
            else
            {
                dateTime = currentDate.AddMinutes(schedulerConfiguration.TimeUnitFrequency);
            }
            return dateTime;
        }

        private static DateTime NextDateSeconds(SchedulerConfiguration schedulerConfiguration, DateTime currentDate)
        {
            DateTime dateTime;
            if (currentDate.AddSeconds(schedulerConfiguration.TimeUnitFrequency) > currentDate.ChangeTime(schedulerConfiguration.EndTime))
            {
                dateTime = CalculateNextDateRecurring(schedulerConfiguration, currentDate).ChangeTime(schedulerConfiguration.StartTime);
            }
            else
            {
                dateTime = currentDate.AddSeconds(schedulerConfiguration.TimeUnitFrequency);
            }
            return dateTime;
        }

        private static DateTime NextDateHours(SchedulerConfiguration schedulerConfiguration, DateTime currentDate)
        {
            DateTime dateTime;
            if (currentDate.AddHours(schedulerConfiguration.TimeUnitFrequency) > currentDate.ChangeTime(schedulerConfiguration.EndTime))
            {
                dateTime = CalculateNextDateRecurring(schedulerConfiguration, currentDate).ChangeTime(schedulerConfiguration.StartTime);
            }
            else
            {
                dateTime = currentDate.AddHours(schedulerConfiguration.TimeUnitFrequency);
            }
            return dateTime;
        }

        private static DateTime GetDailyResult(SchedulerConfiguration schedulerConfiguration, DateTime actualDate)
        {
            return actualDate.AddDays(schedulerConfiguration.FrequencyDays);
        }

        private static ExecutionResult CalculateNextDateOnce(SchedulerConfiguration schedulerConfiguration)
        {
            return new ExecutionResult()
            {
                NextExecution = schedulerConfiguration.OnceDateTime,
                Description = DescriptionManager.GetOnceDescription(schedulerConfiguration)
            };
        }

        private static void ValidateCommonDates(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.EndDate < schedulerConfiguration.StartDate)
            {
                throw new TimeSchedulerException(SchedulerResourceManager.GetResource("EndDateIsLessThanStartDate"));
            }
            if (schedulerConfiguration.CurrentDate < schedulerConfiguration.StartDate ||
                schedulerConfiguration.CurrentDate > schedulerConfiguration.EndDate)
            {
                throw new TimeSchedulerException(SchedulerResourceManager.GetResource("CurrentDateOutOfRange"));
            }
        }

        private static void ValidateRecurringConfiguration(SchedulerConfiguration schedulerConfiguration)
        {
            ValidateDailyFrequency(schedulerConfiguration);
            if (schedulerConfiguration.FrecuencyType == FrecuencyType.Daily)
            {
                ValidateDaysFrequency(schedulerConfiguration);
                ValidateDailyMaxDate(schedulerConfiguration);
            }
            if (schedulerConfiguration.FrecuencyType == FrecuencyType.Weekly)
            {
                ValidateWeeklyFrequency(schedulerConfiguration);
            }
            if (schedulerConfiguration.FrecuencyType == FrecuencyType.Monthly)
            {
                ValidateMonthlyFrequency(schedulerConfiguration);
            }
        }

        private static void ValidateDailyMaxDate(SchedulerConfiguration schedulerConfiguration)
        {
            if (DateTime.MaxValue.Subtract(schedulerConfiguration.CurrentDate).Days < schedulerConfiguration.FrequencyDays)
            {
                throw new TimeSchedulerException(SchedulerResourceManager.GetResource("TheDateCannotBeRepresented"));
            }
        }

        private static void ValidateDaysFrequency(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.FrequencyDays == 0)
            {
                throw new TimeSchedulerException(SchedulerResourceManager.GetResource("FrequencyDaysIsZero"));
            }
            if (schedulerConfiguration.FrequencyDays < 0)
            {
                throw new TimeSchedulerException(SchedulerResourceManager.GetResource("FrequencyDaysIsNegative"));
            }
        }

        private static void ValidateMonthlyFrequency(SchedulerConfiguration schedulerConfiguration)
        {
            ValidateEveryMonth(schedulerConfiguration);
            if (schedulerConfiguration.MonthlyType == MonthlyType.Day)
            {
                ValidateDayOfMonth(schedulerConfiguration);
            }
        }

        private static void ValidateDayOfMonth(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.DayOfMonth == 0)
            {
                throw new TimeSchedulerException(SchedulerResourceManager.GetResource("MonthDayIsZero"));
            }
            if (schedulerConfiguration.DayOfMonth < 0)
            {
                throw new TimeSchedulerException(SchedulerResourceManager.GetResource("MonthDayIsNegative"));
            }
        }

        private static void ValidateEveryMonth(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.EveryMonth == 0)
            {
                throw new TimeSchedulerException(SchedulerResourceManager.GetResource("EveryMonthIsZero"));
            }
            if (schedulerConfiguration.EveryMonth < 0)
            {
                throw new TimeSchedulerException(SchedulerResourceManager.GetResource("EveryMonthIsNegative"));
            }
        }

        private static void ValidateWeeklyFrequency(SchedulerConfiguration schedulerConfiguration)
        {
            ValidateWeekFrequency(schedulerConfiguration);
            ValidateWeekDays(schedulerConfiguration);
        }

        private static void ValidateWeekFrequency(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.WeekFrequency == 0)
            {
                throw new TimeSchedulerException(SchedulerResourceManager.GetResource("TheWeekFrequencyIsZero"));
            }
            if (schedulerConfiguration.WeekFrequency < 0)
            {
                throw new TimeSchedulerException(SchedulerResourceManager.GetResource("TheWeekFrequencyIsNegative"));
            }
        }

        private static void ValidateDailyFrequency(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.StartTime > schedulerConfiguration.EndTime)
            {
                throw new TimeSchedulerException(SchedulerResourceManager.GetResource("EndTimeIsLessThanStartTime"));
            }
            if (schedulerConfiguration.OccursType == OccursType.Once)
            {
                if (schedulerConfiguration.OccursOnceTime < schedulerConfiguration.StartTime ||
                schedulerConfiguration.OccursOnceTime > schedulerConfiguration.EndTime)
                {
                    throw new TimeSchedulerException(SchedulerResourceManager.GetResource("OccursOnceTimeIsOutOfRange"));
                }
            }
            if (schedulerConfiguration.OccursType == OccursType.Every)
            {
                if (schedulerConfiguration.TimeUnitFrequency == 0)
                {
                    throw new TimeSchedulerException(SchedulerResourceManager.GetResource("TheNumberOfTimeUnitIsZero"));
                }
                if (schedulerConfiguration.TimeUnitFrequency < 0)
                {
                    throw new TimeSchedulerException(SchedulerResourceManager.GetResource("TheNumberOfTimeUnitIsNegative"));
                }
            }
        }

        private static void ValidateOnceConfiguration(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.OnceDateTime < schedulerConfiguration.CurrentDate)
            {
                throw new TimeSchedulerException(SchedulerResourceManager.GetResource("OnceDateTimeLessThanCurrentDate"));
            }
        }

        private static DateTime CalculateNextDayWeek(SchedulerConfiguration schedulerConfiguration, DateTime currentDate)
        {
            bool[] weekDays = AddWeekDays(schedulerConfiguration);
            return currentDate.DayOfWeek switch
            {
                DayOfWeek.Monday => NewDay(1, weekDays, currentDate),
                DayOfWeek.Tuesday => NewDay(2, weekDays, currentDate),
                DayOfWeek.Wednesday => NewDay(3, weekDays, currentDate),
                DayOfWeek.Thursday => NewDay(4, weekDays, currentDate),
                DayOfWeek.Friday => NewDay(5, weekDays, currentDate),
                DayOfWeek.Saturday => NewDay(6, weekDays, currentDate),
                DayOfWeek.Sunday => NewDay(0, weekDays, currentDate),
                _ => throw new NotImplementedException()
            };
        }

        private static DateTime NewDay(int numDay, bool[] weekDays, DateTime currentdate)
        {
            int newDayPosition = 0;
            DateTime NewDay = currentdate;
            for (int i = numDay; i < weekDays.Length; i++)
            {
                newDayPosition++;
                if (weekDays[i])
                {
                    return NewDay.AddDays(newDayPosition);
                }
            }
            for (int i = 0; i < numDay; i++)
            {
                newDayPosition++;
                if (weekDays[i])
                {
                    return NewDay.AddDays(newDayPosition);
                }
            }
            return NewDay;
        }

        private static bool[] AddWeekDays(SchedulerConfiguration schedulerConfiguration)
        {
            bool[] weekDays = new bool[7];
            weekDays[0] = schedulerConfiguration.MondayEnabled;
            weekDays[1] = schedulerConfiguration.TuesdayEnabled;
            weekDays[2] = schedulerConfiguration.WednesdayEnabled;
            weekDays[3] = schedulerConfiguration.ThursdayEnabled;
            weekDays[4] = schedulerConfiguration.FridayEnabled;
            weekDays[5] = schedulerConfiguration.SaturdayEnabled;
            weekDays[6] = schedulerConfiguration.SundayEnabled;
            return weekDays;
        }

        private static void ValidateWeekDays(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.MondayEnabled == false &&
                schedulerConfiguration.TuesdayEnabled == false &&
                schedulerConfiguration.WednesdayEnabled == false &&
                schedulerConfiguration.ThursdayEnabled == false &&
                schedulerConfiguration.FridayEnabled == false &&
                schedulerConfiguration.SaturdayEnabled == false &&
                schedulerConfiguration.SundayEnabled == false)
            {
                throw new TimeSchedulerException(SchedulerResourceManager.GetResource("NoWeekDaysSelected"));
            }
        }

        private static void ValidateEnabled(this SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.Enabled == false)
            {
                throw new TimeSchedulerException(SchedulerResourceManager.GetResource("EnabledIsFalse"));
            }
        }
        #endregion private methods
    }
}
