using System;
using System.Collections.Generic;
using System.Text;
using TimeScheduler.Resources.Texts;

namespace TimeScheduler
{
    public static class SchedulerConfigurationExtensions
    {
        public static string[] GetNextExecution(this SchedulerConfiguration schedulerConfiguration)
        {
            string[] result = new string[2];
            ValidateEnabled(schedulerConfiguration);
            if (schedulerConfiguration.ExecutionType == ExecutionType.Once)
            {
                result[0] = schedulerConfiguration.ExecutionDate.ToShortDateString();
                result[1] = SchedulerDescriptionOnce(schedulerConfiguration);
            }
            else
            {
                ValidateDailyConfiguration(schedulerConfiguration);
                ValidateWeeklyConfiguration(schedulerConfiguration);
                result[0] = CalculateNextExecutionDate(schedulerConfiguration);
                result[1] = SchedulerDescriptionRecurring(schedulerConfiguration);
            }
            return result;
        }

        public static string[] CalculateSerie(this SchedulerConfiguration schedulerConfiguration, int numSeries)
        {
            ValidateDailyConfiguration(schedulerConfiguration);
            ValidateWeeklyConfiguration(schedulerConfiguration);
            string[] result = new string[numSeries];
            DateTime currentTime = schedulerConfiguration.StartingAt;
            for (int i = 0; i < numSeries; i++)
            {
                result[i] = currentTime.ToString();
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

        private static DateTime NextDateHours(SchedulerConfiguration schedulerConfiguration, DateTime currentTime)
        {
            if (currentTime.AddHours(schedulerConfiguration.EveryTimes).TimeOfDay > schedulerConfiguration.EndAt.TimeOfDay)
            {
                int daysDiff = CalculateNextDayWeek(schedulerConfiguration, currentTime) + (currentTime.Day - schedulerConfiguration.StartingAt.Day);
                double secondsDiff = currentTime.AddHours(schedulerConfiguration.EveryTimes).TimeOfDay.Subtract(schedulerConfiguration.EndAt.TimeOfDay).Seconds;
                return schedulerConfiguration.StartingAt.AddSeconds(secondsDiff).AddDays(daysDiff);
            }
            else
            {
                return currentTime.AddHours(schedulerConfiguration.EveryTimes);
            }
        }

        private static DateTime NextDateMinutes(SchedulerConfiguration schedulerConfiguration, DateTime currentTime)
        {
            if (currentTime.AddMinutes(schedulerConfiguration.EveryTimes).TimeOfDay > schedulerConfiguration.EndAt.TimeOfDay)
            {
                int daysDiff = CalculateNextDayWeek(schedulerConfiguration, currentTime) + (currentTime.Day - schedulerConfiguration.StartingAt.Day);
                int secondsDiff = currentTime.AddMinutes(schedulerConfiguration.EveryTimes).TimeOfDay.Subtract(schedulerConfiguration.EndAt.TimeOfDay).Seconds;
                return schedulerConfiguration.StartingAt.AddSeconds(secondsDiff).AddDays(daysDiff);
            }
            else
            {
                return currentTime.AddMinutes(schedulerConfiguration.EveryTimes);
            }
        }

        private static DateTime NextDateSeconds(SchedulerConfiguration schedulerConfiguration, DateTime currentTime)
        {
            if (currentTime.AddSeconds(schedulerConfiguration.EveryTimes).TimeOfDay > schedulerConfiguration.EndAt.TimeOfDay)
            {
                int daysDiff = CalculateNextDayWeek(schedulerConfiguration, currentTime) + (currentTime.Day - schedulerConfiguration.StartingAt.Day);
                int secondsDiff = currentTime.AddSeconds(schedulerConfiguration.EveryTimes).TimeOfDay.Subtract(schedulerConfiguration.EndAt.TimeOfDay).Seconds;
                return schedulerConfiguration.StartingAt.AddSeconds(secondsDiff).AddDays(daysDiff);
            }
            else
            {
                return currentTime.AddSeconds(schedulerConfiguration.EveryTimes);
            }
        }

        private static int CalculateNextDayWeek(SchedulerConfiguration schedulerConfiguration, DateTime currentTime)
        {
            bool[] weekDays = AddWeekDays(schedulerConfiguration);
            return currentTime.DayOfWeek switch
            {
                DayOfWeek.Monday => NewDay(0, weekDays),
                DayOfWeek.Tuesday => NewDay(1, weekDays),
                DayOfWeek.Wednesday => NewDay(2, weekDays),
                DayOfWeek.Thursday => NewDay(3, weekDays),
                DayOfWeek.Friday => NewDay(4, weekDays),
                DayOfWeek.Saturday => NewDay(5, weekDays),
                DayOfWeek.Sunday => NewDay(6, weekDays)
            };           
        }

        private static int NewDay(int numDay, bool[] weekDays)
        {
            int newDay = 0;            
            for(int i = numDay + 1; i < weekDays.Length; i++)
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
        private static void ValidateWeeklyConfiguration(SchedulerConfiguration schedulerConfiguration)
        {
            ValidateEveryWeekly(schedulerConfiguration.EveryTimesWeek);
            ValidateDays(schedulerConfiguration);
        }

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

        private static void ValidateDays(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.MondayEnabled == false &&
                schedulerConfiguration.TuesdayEnabled == false &&
                schedulerConfiguration.WednesdayEnabled == false &&
                schedulerConfiguration.ThursdayEnabled == false &&
                schedulerConfiguration.FridayEnabled == false &&
                schedulerConfiguration.SaturdayEnabled == false &&
                schedulerConfiguration.SundayEnabled == false)
            {
                throw new TimeSchedulerException("No week days selected.");
            }
        }

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

        private static string WeekDaysMsg(SchedulerConfiguration schedulerConfiguration)
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
            return string.Format("Occurs every {0} weeks on {1} {2} between {3} and {4} starting on {5} and ending on {6}.",
                schedulerConfiguration.EveryTimesWeek,
                WeekDaysMsg(schedulerConfiguration),
                GetDescriptionType(schedulerConfiguration),
                schedulerConfiguration.StartingAt.ToShortTimeString(),
                schedulerConfiguration.EndAt.ToShortTimeString(),
                schedulerConfiguration.StartDate,
                schedulerConfiguration.EndDate);
        }

        private static string CalculateNextExecutionDate(SchedulerConfiguration schedulerConfiguration)
        {
            return schedulerConfiguration.CurrentDate.ToShortDateString() + " " + schedulerConfiguration.StartingAt.ToShortTimeString();
        }

        #endregion private methods
    }
}
