﻿using System;
using System.Collections.Generic;
using System.Text;
using TimeScheduler.Resources.Texts;

namespace TimeScheduler
{
    public static class SchedulerConfigurationExtensions
    {
        public struct ExecutionResult
        {
            public DateTime NextExecution;
            public string Description;
        }

        public static ExecutionResult GetNextExecution(this SchedulerConfiguration schedulerConfiguration)
        {
            ExecutionResult executionResult = new();
            ValidateEnabled(schedulerConfiguration);
            if (schedulerConfiguration.ExecutionType == ExecutionType.Once)
            {
                executionResult.NextExecution = schedulerConfiguration.ExecutionDate;
                executionResult.Description = SchedulerDescriptionOnce(schedulerConfiguration);
            }
            else
            {
                ValidateDailyConfiguration(schedulerConfiguration);
                ValidateMonthlyConfiguration(schedulerConfiguration);
                executionResult.NextExecution = CalculateNextExecutionDate(schedulerConfiguration);
                executionResult.Description = SchedulerDescriptionRecurring(schedulerConfiguration);
            }
            return executionResult;
        }

        private static void ValidateMonthlyConfiguration(SchedulerConfiguration schedulerConfiguration)
        {
            ValidateMonthlyType(schedulerConfiguration);
            if (schedulerConfiguration.MonthlyType == MonthlyType.Day)
            {
                ValidateEveryDay(schedulerConfiguration);
                ValidateEveryMonth(schedulerConfiguration);
            }
            else
            {
                ValidateEveryMonthWeek(schedulerConfiguration);
            }
        }

        private static void ValidateEveryMonthWeek(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.EveryMonthDay < 0)
            {
                throw new TimeSchedulerException("Every months is negative.");
            }
            if (schedulerConfiguration.EveryMonthDay == 0)
            {
                throw new TimeSchedulerException("Every months is zero.");
            }
        }

        private static void ValidateEveryMonth(SchedulerConfiguration schedulerConfiguration)
        {
            if(schedulerConfiguration.MonthsDay < 0)
            {
                throw new TimeSchedulerException("Every months is negative.");
            }
            if(schedulerConfiguration.MonthsDay == 0)
            {
                throw new TimeSchedulerException("Every months is zero.");
            }
        }

        private static void ValidateEveryDay(SchedulerConfiguration schedulerConfiguration)
        {
            if(schedulerConfiguration.EveryMonthDay < 0)
            {
                throw new TimeSchedulerException("Every month day can't be negative.");
            }
            if (schedulerConfiguration.EveryMonthDay == 0)
            {
                throw new TimeSchedulerException("Every month day can't be zero.");
            }
            if(schedulerConfiguration.EveryMonthDay > 31)
            {
                throw new TimeSchedulerException("Every month day out of range.");
            }
        }

        private static void ValidateMonthlyType(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.DaySelector &&
                schedulerConfiguration.WeekDaySelector)
            {
                throw new TimeSchedulerException("Monthly type is true two times.");
            }
            if (schedulerConfiguration.DaySelector == false &&
               schedulerConfiguration.WeekDaySelector == false)
            {
                throw new TimeSchedulerException("Monthly type is false two times.");
            }
            if (schedulerConfiguration.WeekDaySelector)
            {
                schedulerConfiguration.MonthlyType = MonthlyType.WeeksDay;
            }
            else
            {
                schedulerConfiguration.MonthlyType = MonthlyType.Day;
            }
        }

        public static ExecutionResult[] CalculateSerie(this SchedulerConfiguration schedulerConfiguration, int numSeries)
        {
            ValidateDailyConfiguration(schedulerConfiguration);
            ValidateMonthlyType(schedulerConfiguration);
            if (schedulerConfiguration.MonthlyType == MonthlyType.Day)
            {
                ValidateEveryDay(schedulerConfiguration);
                ValidateEveryMonth(schedulerConfiguration);
            }
            else
            {
                ValidateEveryMonthWeek(schedulerConfiguration);
            }
            ExecutionResult[] result = new ExecutionResult[numSeries];
            DateTime currentTime = schedulerConfiguration.StartingAt;
            for (int i = 0; i < numSeries; i++)
            {
                result[i].NextExecution = currentTime;
                result[i].Description = SchedulerDescriptionRecurring(schedulerConfiguration);
                currentTime = CalculateNextDate(schedulerConfiguration, currentTime);
            }
            return result;
        }


        #region private methods
        private static void ValidateDailyConfiguration(SchedulerConfiguration schedulerConfiguration)
        {
            schedulerConfiguration.OccursType = ValidateOccursType(schedulerConfiguration);
            ValidateOccurs(schedulerConfiguration);
        }

        private static DateTime CalculateNextDate(SchedulerConfiguration schedulerConfiguration, DateTime currentTime)
        {
            if (schedulerConfiguration.TimeUnit == TimeUnit.Seconds)
            {
                return NextDateSeconds(schedulerConfiguration, currentTime);
            }
            if (schedulerConfiguration.TimeUnit == TimeUnit.Minutes)
            {
                return NextDateMinutes(schedulerConfiguration, currentTime);
            }
            if (schedulerConfiguration.TimeUnit == TimeUnit.Hours)
            {
                return NextDateHours(schedulerConfiguration, currentTime);
            }
            return currentTime;
        }

        //private static DateTime NextDateHours(SchedulerConfiguration schedulerConfiguration, DateTime currentTime)
        //{
        //    if (currentTime.AddHours(schedulerConfiguration.EveryTimes).TimeOfDay > schedulerConfiguration.EndAt.TimeOfDay)
        //    {
        //        int daysDiff = CalculateNextDayWeek(schedulerConfiguration, currentTime) + (currentTime.Day - schedulerConfiguration.StartingAt.Day);
        //        double secondsDiff = currentTime.AddHours(schedulerConfiguration.EveryTimes).TimeOfDay.Subtract(schedulerConfiguration.EndAt.TimeOfDay).Seconds;
        //        return schedulerConfiguration.StartingAt.AddSeconds(secondsDiff).AddDays(daysDiff);
        //    }
        //    else
        //    {
        //        return currentTime.AddHours(schedulerConfiguration.EveryTimes);
        //    }
        //}

        //private static DateTime NextDateMinutes(SchedulerConfiguration schedulerConfiguration, DateTime currentTime)
        //{
        //    if (currentTime.AddMinutes(schedulerConfiguration.EveryTimes).TimeOfDay > schedulerConfiguration.EndAt.TimeOfDay)
        //    {
        //        int daysDiff = CalculateNextDayWeek(schedulerConfiguration, currentTime) + (currentTime.Day - schedulerConfiguration.StartingAt.Day);
        //        int secondsDiff = currentTime.AddMinutes(schedulerConfiguration.EveryTimes).TimeOfDay.Subtract(schedulerConfiguration.EndAt.TimeOfDay).Seconds;
        //        return schedulerConfiguration.StartingAt.AddSeconds(secondsDiff).AddDays(daysDiff);
        //    }
        //    else
        //    {
        //        return currentTime.AddMinutes(schedulerConfiguration.EveryTimes);
        //    }
        //}

        //private static DateTime NextDateSeconds(SchedulerConfiguration schedulerConfiguration, DateTime currentTime)
        //{
        //    if (currentTime.AddSeconds(schedulerConfiguration.EveryTimes).TimeOfDay > schedulerConfiguration.EndAt.TimeOfDay)
        //    {
        //        int daysDiff = CalculateNextDayWeek(schedulerConfiguration, currentTime) + (currentTime.Day - schedulerConfiguration.StartingAt.Day);
        //        int secondsDiff = currentTime.AddSeconds(schedulerConfiguration.EveryTimes).TimeOfDay.Subtract(schedulerConfiguration.EndAt.TimeOfDay).Seconds;
        //        return schedulerConfiguration.StartingAt.AddSeconds(secondsDiff).AddDays(daysDiff);
        //    }
        //    else
        //    {
        //        return currentTime.AddSeconds(schedulerConfiguration.EveryTimes);
        //    }
        //}

        //private static int CalculateNextDayWeek(SchedulerConfiguration schedulerConfiguration, DateTime currentTime)
        //{
        //    bool[] weekDays = AddWeekDays(schedulerConfiguration);
        //    return currentTime.DayOfWeek switch
        //    {
        //        DayOfWeek.Monday => NewDay(0, weekDays),
        //        DayOfWeek.Tuesday => NewDay(1, weekDays),
        //        DayOfWeek.Wednesday => NewDay(2, weekDays),
        //        DayOfWeek.Thursday => NewDay(3, weekDays),
        //        DayOfWeek.Friday => NewDay(4, weekDays),
        //        DayOfWeek.Saturday => NewDay(5, weekDays),
        //        DayOfWeek.Sunday => NewDay(6, weekDays),
        //        _ => throw new NotImplementedException()
        //    };
        //}

        private static int NewDay(int numDay, bool[] weekDays)
        {
            int newDay = 0;
            for (int i = numDay + 1; i < weekDays.Length; i++)
            {
                newDay++;
                if (weekDays[i])
                {
                    return newDay;
                }
            }
            for (int i = 0; i < numDay; i++)
            {
                newDay++;
                if (weekDays[i])
                {
                    return newDay;
                }
            }
            return newDay;
        }

        //private static bool[] AddWeekDays(SchedulerConfiguration schedulerConfiguration)
        //{
        //    bool[] weekDays = new bool[7];
        //    weekDays[0] = schedulerConfiguration.MondayEnabled;
        //    weekDays[1] = schedulerConfiguration.TuesdayEnabled;
        //    weekDays[2] = schedulerConfiguration.WednesdayEnabled;
        //    weekDays[3] = schedulerConfiguration.ThursdayEnabled;
        //    weekDays[4] = schedulerConfiguration.FridayEnabled;
        //    weekDays[5] = schedulerConfiguration.SaturdayEnabled;
        //    weekDays[6] = schedulerConfiguration.SundayEnabled;
        //    return weekDays;
        //}

        private static OccursType ValidateOccursType(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.OccursOnce &&
                schedulerConfiguration.OccursEvery)
            {
                throw new TimeSchedulerException("Occurs is true two times.");
            }
            if (schedulerConfiguration.OccursOnce == false &&
               schedulerConfiguration.OccursEvery == false)
            {
                throw new TimeSchedulerException("Occurs is false two times.");
            }
            return schedulerConfiguration.OccursOnce == false &&
                schedulerConfiguration.OccursEvery
                ? OccursType.Every
                : OccursType.Once;
        }
        private static void ValidateOccurs(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.OccursType == OccursType.Every)
            {
                ValidateOccursEveryTimes(schedulerConfiguration.EveryTimes);
            }
        }
        //private static void ValidateWeeklyConfiguration(SchedulerConfiguration schedulerConfiguration)
        //{
        //    ValidateEveryWeekly(schedulerConfiguration.EveryTimesWeek);
        //    ValidateDays(schedulerConfiguration);
        //}

        private static void ValidateEveryWeekly(int? everyTimesweek)
        {
            if (everyTimesweek == 0)
            {
                throw new TimeSchedulerException("Every times week is zero.");
            }
            if (everyTimesweek.Value < 0)
            {
                throw new TimeSchedulerException("Every times week is negative.");
            }
        }

        //private static void ValidateDays(SchedulerConfiguration schedulerConfiguration)
        //{
        //    if (schedulerConfiguration.MondayEnabled == false &&
        //        schedulerConfiguration.TuesdayEnabled == false &&
        //        schedulerConfiguration.WednesdayEnabled == false &&
        //        schedulerConfiguration.ThursdayEnabled == false &&
        //        schedulerConfiguration.FridayEnabled == false &&
        //        schedulerConfiguration.SaturdayEnabled == false &&
        //        schedulerConfiguration.SundayEnabled == false)
        //    {
        //        throw new TimeSchedulerException("No week days selected.");
        //    }
        //}

        private static string GetDescriptionType(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.OccursType == OccursType.Every)
            {
                return "every " + schedulerConfiguration.EveryTimes.ToString() + " " + schedulerConfiguration.TimeUnit.ToString().ToLower();
            }
            else
            {
                return "once at " + schedulerConfiguration.OccursOnceTime.ToShortTimeString();
            }
        }

        //private static string WeekDaysMsg(SchedulerConfiguration schedulerConfiguration)
        //{
        //    List<string> weekDaysStr = new();
        //    if (schedulerConfiguration.MondayEnabled)
        //    {
        //        weekDaysStr.Add("monday");
        //    }
        //    if (schedulerConfiguration.TuesdayEnabled)
        //    {
        //        weekDaysStr.Add("tuesday");
        //    }
        //    if (schedulerConfiguration.WednesdayEnabled)
        //    {
        //        weekDaysStr.Add("wednesday");
        //    }
        //    if (schedulerConfiguration.ThursdayEnabled)
        //    {
        //        weekDaysStr.Add("thursday");
        //    }
        //    if (schedulerConfiguration.FridayEnabled)
        //    {
        //        weekDaysStr.Add("friday");
        //    }
        //    if (schedulerConfiguration.SaturdayEnabled)
        //    {
        //        weekDaysStr.Add("saturday");
        //    }
        //    if (schedulerConfiguration.SundayEnabled)
        //    {
        //        weekDaysStr.Add("sunday");
        //    }
        //    StringBuilder weekDaysMsg = new();
        //    for (int i = 0; i < weekDaysStr.Count; i++)
        //    {
        //        weekDaysMsg.Append(weekDaysStr[i]);
        //        if (i + 1 == weekDaysStr.Count - 1)
        //        {
        //            weekDaysMsg.Append(" and ");
        //        }
        //        if (i + 1 <= weekDaysStr.Count - 2)
        //        {
        //            weekDaysMsg.Append(", ");
        //        }
        //    }
        //    return weekDaysMsg.ToString();
        //}

        private static void ValidateOccursEveryTimes(int? everyTimes)
        {
            if (everyTimes == 0)
            {
                throw new TimeSchedulerException("Occurs every times is zero.");
            }
            if (everyTimes.Value < 0)
            {
                throw new TimeSchedulerException("Occurs every times is negative.");
            }
        }

        private static void ValidateEnabled(this SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.Enabled == false)
            {
                throw new TimeSchedulerException("Enabled is false.");
            }
        }

        private static string SchedulerDescriptionOnce(SchedulerConfiguration schedulerConfiguration)
        {
            return string.Format(
                Global.ExecutionDescription,
                "Once",
                schedulerConfiguration.ExecutionDate.ToShortDateString(),
                schedulerConfiguration.ExecutionDate.ToShortTimeString(),
                schedulerConfiguration.StartDate,
                schedulerConfiguration.EndDate);
        }

        private static string SchedulerDescriptionRecurring(SchedulerConfiguration schedulerConfiguration)
        {
            return string.Format("Occurs the {0} {1} of every {3} months.",
                schedulerConfiguration.ExecutionType.ToString(),
                schedulerConfiguration.FrecuencyType.ToString(),
                schedulerConfiguration.EveryMonthDay);
        }

        private static DateTime CalculateNextExecutionDate(SchedulerConfiguration schedulerConfiguration)
        {
            return schedulerConfiguration.CurrentDate;
        }

        #endregion private methods
    }
}
