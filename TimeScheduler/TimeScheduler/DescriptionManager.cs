using System;
using System.Collections.Generic;
using System.Text;
using TimeScheduler.Resources;

namespace TimeScheduler
{
    public static class DescriptionManager
    {
        public static string GetOnceDescription(SchedulerConfiguration schedulerConfiguration)
        {
            return string.Format(
                Global.OnceDescription,
                schedulerConfiguration.OnceDateTime.ToShortDateString(),
                schedulerConfiguration.OnceDateTime.ToShortTimeString(),
                schedulerConfiguration.StartDate.ToShortDateString(),
                schedulerConfiguration.EndDate.ToShortDateString());
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
            return string.Format(Global.MonthlyDescription,
                    MonthlyConfiguration(schedulerConfiguration),
                    schedulerConfiguration.EveryMonth,
                    FrequencyStr(schedulerConfiguration),
                    schedulerConfiguration.StartTime.ToString(),
                    schedulerConfiguration.EndTime.ToString(),
                    schedulerConfiguration.StartDate.ToShortDateString(),
                    schedulerConfiguration.EndDate.ToShortDateString());
        }

        private static string MonthlyConfiguration(SchedulerConfiguration schedulerConfiguration)
        {
            return schedulerConfiguration.OrdinalConfiguration.ToString() + " " + schedulerConfiguration.DayOfWeek.ToString();
        }

        private static string WeeklyDescription(SchedulerConfiguration schedulerConfiguration)
        {
            return string.Format(Global.WeeklyDescription,
                schedulerConfiguration.WeekFrequency,
                WeekDaysMsg(schedulerConfiguration),
                FrequencyStr(schedulerConfiguration),
                schedulerConfiguration.StartTime.ToString(),
                schedulerConfiguration.EndTime.ToString(),
                schedulerConfiguration.StartDate.ToShortDateString(),
                schedulerConfiguration.EndDate.ToShortDateString());
        }

        private static string DailyDescription(SchedulerConfiguration schedulerConfiguration)
        {
            return string.Format(
                Global.DailyDescription,
                schedulerConfiguration.StartDate.ToShortDateString(),
                schedulerConfiguration.StartTime.ToString(),
                FrequencyStr(schedulerConfiguration),
                schedulerConfiguration.StartTime.ToString(),
                schedulerConfiguration.EndTime.ToString(),
                schedulerConfiguration.StartDate.ToShortDateString(),
                schedulerConfiguration.EndDate.ToShortDateString());
        }

        private static object FrequencyStr(SchedulerConfiguration schedulerConfiguration)
        {
            return schedulerConfiguration.TimeUnitFrequency + " " + schedulerConfiguration.TimeUnit.ToString();
        }

        public static string WeekDaysMsg(SchedulerConfiguration schedulerConfiguration)
        {
            List<string> weekDaysStr = new();
            if (schedulerConfiguration.MondayEnabled)
            {
                weekDaysStr.Add("monday");
            }
            if (schedulerConfiguration.TuesdayEnabled)
            {
                weekDaysStr.Add("tuesday");
            }
            if (schedulerConfiguration.WednesdayEnabled)
            {
                weekDaysStr.Add("wednesday");
            }
            if (schedulerConfiguration.ThursdayEnabled)
            {
                weekDaysStr.Add("thursday");
            }
            if (schedulerConfiguration.FridayEnabled)
            {
                weekDaysStr.Add("friday");
            }
            if (schedulerConfiguration.SaturdayEnabled)
            {
                weekDaysStr.Add("saturday");
            }
            if (schedulerConfiguration.SundayEnabled)
            {
                weekDaysStr.Add("sunday");
            }
            StringBuilder weekDaysMsg = new();
            for (int i = 0; i < weekDaysStr.Count; i++)
            {
                weekDaysMsg.Append(weekDaysStr[i]);
                if (i + 1 == weekDaysStr.Count - 1)
                {
                    weekDaysMsg.Append(" and ");
                }
                if (i + 1 <= weekDaysStr.Count - 2)
                {
                    weekDaysMsg.Append(", ");
                }
            }
            return weekDaysMsg.ToString();
        }
    }
}
