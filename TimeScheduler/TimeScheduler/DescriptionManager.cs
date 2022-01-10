using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TimeScheduler.Resources;

namespace TimeScheduler
{
    public static class DescriptionManager
    {
        public static string GetOnceDescription(SchedulerConfiguration schedulerConfiguration)
        {
            return string.Format(
                SchedulerResourceManager.GetResource("OnceDescription"),
                schedulerConfiguration.OnceDateTime.ToString(FormatDate(schedulerConfiguration)),
                schedulerConfiguration.OnceDateTime.ToString(FormatTime(schedulerConfiguration)),
                schedulerConfiguration.StartDate.ToString(FormatDate(schedulerConfiguration)),
                schedulerConfiguration.EndDate.ToString(FormatDate(schedulerConfiguration)));
        }

        public static string GetRecurringDescription(SchedulerConfiguration schedulerConfiguration)
        {
            return schedulerConfiguration.FrecuencyType switch
            {
                FrecuencyType.Daily => DailyDescription(schedulerConfiguration),
                FrecuencyType.Weekly => WeeklyDescription(schedulerConfiguration),
                FrecuencyType.Monthly => MonthlyDescription(schedulerConfiguration),
                _ => throw new NotImplementedException()
            };
        }

        private static string MonthlyDescription(SchedulerConfiguration schedulerConfiguration)
        {
            return string.Format(
                    SchedulerResourceManager.GetResource("MonthlyDescription"),
                    MonthlyConfiguration(schedulerConfiguration),
                    schedulerConfiguration.EveryMonth,
                    FrequencyStr(schedulerConfiguration),
                    DateTime.Now.ChangeTime(schedulerConfiguration.StartTime).ToString(FormatTime(schedulerConfiguration)),
                    DateTime.Now.ChangeTime(schedulerConfiguration.EndTime).ToString(FormatTime(schedulerConfiguration)),
                    schedulerConfiguration.StartDate.ToString(FormatDate(schedulerConfiguration)),
                    schedulerConfiguration.EndDate.ToString(FormatDate(schedulerConfiguration)));
        }

        private static string MonthlyConfiguration(SchedulerConfiguration schedulerConfiguration)
        {
            return SchedulerResourceManager.GetResource(schedulerConfiguration.OrdinalConfiguration.ToString()) 
                + " " + SchedulerResourceManager.GetResource(schedulerConfiguration.DayOfWeek.ToString());
        }

        private static string WeeklyDescription(SchedulerConfiguration schedulerConfiguration)
        {
            return string.Format(
                SchedulerResourceManager.GetResource("WeeklyDescription"),
                schedulerConfiguration.WeekFrequency,
                WeekDaysMsg(schedulerConfiguration),
                FrequencyStr(schedulerConfiguration),
                DateTime.Now.ChangeTime(schedulerConfiguration.StartTime).ToString(FormatTime(schedulerConfiguration)),
                DateTime.Now.ChangeTime(schedulerConfiguration.EndTime).ToString(FormatTime(schedulerConfiguration)),
                schedulerConfiguration.StartDate.ToString(FormatDate(schedulerConfiguration)),
                schedulerConfiguration.EndDate.ToString(FormatDate(schedulerConfiguration)));
        }

        private static string DailyDescription(SchedulerConfiguration schedulerConfiguration)
        {
            return string.Format(
                SchedulerResourceManager.GetResource("DailyDescription"),
                schedulerConfiguration.StartDate.ToString(FormatDate(schedulerConfiguration)),
                DateTime.Now.ChangeTime(schedulerConfiguration.StartTime).ToString(FormatTime(schedulerConfiguration)),
                FrequencyStr(schedulerConfiguration),
                DateTime.Now.ChangeTime(schedulerConfiguration.StartTime).ToString(FormatTime(schedulerConfiguration)),
                DateTime.Now.ChangeTime(schedulerConfiguration.EndTime).ToString(FormatTime(schedulerConfiguration)),
                schedulerConfiguration.StartDate.ToString(FormatDate(schedulerConfiguration)),
                schedulerConfiguration.EndDate.ToString(FormatDate(schedulerConfiguration)));
        }

        private static object FrequencyStr(SchedulerConfiguration schedulerConfiguration)
        {
            return schedulerConfiguration.TimeUnitFrequency + " " +
                SchedulerResourceManager.GetResource(schedulerConfiguration.TimeUnit.ToString());
        }

        public static string WeekDaysMsg(SchedulerConfiguration schedulerConfiguration)
        {
            List<string> weekDaysStr = new();
            if (schedulerConfiguration.MondayEnabled)
            {
                weekDaysStr.Add(SchedulerResourceManager.GetResource("Monday"));
            }
            if (schedulerConfiguration.TuesdayEnabled)
            {
                weekDaysStr.Add(SchedulerResourceManager.GetResource("Tuesday"));
            }
            if (schedulerConfiguration.WednesdayEnabled)
            {
                weekDaysStr.Add(SchedulerResourceManager.GetResource("Wednesday"));
            }
            if (schedulerConfiguration.ThursdayEnabled)
            {
                weekDaysStr.Add(SchedulerResourceManager.GetResource("Thursday"));
            }
            if (schedulerConfiguration.FridayEnabled)
            {
                weekDaysStr.Add(SchedulerResourceManager.GetResource("Friday"));
            }
            if (schedulerConfiguration.SaturdayEnabled)
            {
                weekDaysStr.Add(SchedulerResourceManager.GetResource("Saturday"));
            }
            if (schedulerConfiguration.SundayEnabled)
            {
                weekDaysStr.Add(SchedulerResourceManager.GetResource("Sunday"));
            }
            StringBuilder weekDaysMsg = new();
            for (int i = 0; i < weekDaysStr.Count; i++)
            {
                weekDaysMsg.Append(weekDaysStr[i]);
                if (i + 1 == weekDaysStr.Count - 1)
                {
                    weekDaysMsg.Append(SchedulerResourceManager.GetResource("And"));
                }
                if (i + 1 <= weekDaysStr.Count - 2)
                {
                    weekDaysMsg.Append(", ");
                }
            }
            return weekDaysMsg.ToString();
        }

        private static string FormatDate(SchedulerConfiguration schedulerConfiguration)
        {
            return schedulerConfiguration.CultureInfo.DateTimeFormat.ShortDatePattern;
        }

        private static string FormatTime(SchedulerConfiguration schedulerConfiguration)
        {
            return schedulerConfiguration.CultureInfo.DateTimeFormat.ShortTimePattern;
        }
    }
}
