using System;
using System.Collections.Generic;
using System.Text;

namespace TimeScheduler
{
    public class RecurringStrategy : ISchedulerStrategy
    {
        private readonly string[] nextDate;
        private string type;
        private const string DESCRIPTION = "Occurs every {0} weeks on {1} {2} between {3} and {4} starting on {5} and ending on {6}.";

        public RecurringStrategy()
        {
            this.nextDate = new string[2];
            this.type = string.Empty;
        }

        public string[] CalculateNextDate(SchedulerConfiguration schedulerConfiguration)
        {
            ValidateGeneralConfiguration(schedulerConfiguration);
            this.ValidateDailyConfiguration(schedulerConfiguration);
            ValidateWeeklyConfiguration(schedulerConfiguration);

            this.nextDate[0] = CalculateNextExecutionDate(schedulerConfiguration);
            this.nextDate[1] = this.SchedulerDescription(schedulerConfiguration);
            return this.nextDate;
        }

        private string SchedulerDescription(SchedulerConfiguration schedulerConfiguration)
        {
            return string.Format(DESCRIPTION,
                schedulerConfiguration.EveryTimesWeek,
                WeekDaysMsg(schedulerConfiguration),
                this.GetDescriptionType(schedulerConfiguration),
                schedulerConfiguration.StartingAt.ToShortTimeString(),
                schedulerConfiguration.EndAt.ToShortTimeString(),
                schedulerConfiguration.StartDate,
                schedulerConfiguration.EndDate);
        }

        private static string CalculateNextExecutionDate(SchedulerConfiguration schedulerConfiguration)
        {

            return schedulerConfiguration.CurrentDate.AddDays(schedulerConfiguration.NumDays).ToShortDateString();
        }

        private static void ValidateGeneralConfiguration(SchedulerConfiguration schedulerConfiguration)
        {
            ValidateNumDays(schedulerConfiguration.NumDays);
            ValidateSum(schedulerConfiguration.CurrentDate, schedulerConfiguration.NumDays);
        }

        private void ValidateDailyConfiguration(SchedulerConfiguration schedulerConfiguration)
        {
            this.type = ValidateOccursType(schedulerConfiguration);
            this.ValidateOccurs(schedulerConfiguration);
        }

        private static void ValidateWeeklyConfiguration(SchedulerConfiguration schedulerConfiguration)
        {
            ValidateEveryWeekly(schedulerConfiguration.EveryTimesWeek);
            ValidateDays(schedulerConfiguration);
        }

        private static void ValidateNumDays(int? numDays)
        {
            if (numDays == 0)
            {
                throw new TimeSchedulerException("Num days is zero.");
            }
            if (numDays.Value < 0)
            {
                throw new TimeSchedulerException("Num days is negative.");
            }
        }

        private static void ValidateSum(DateTime currentDate, int numDays)
        {
            try
            {
                currentDate.AddDays(numDays);
            }
            catch (Exception)
            {
                throw new TimeSchedulerException("Next execution date is max date.");
            }
        }

        private static string ValidateOccursType(SchedulerConfiguration schedulerConfiguration)
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
            if (schedulerConfiguration.OccursOnce == false &&
                schedulerConfiguration.OccursEvery)
            {
                return "every";
            }
            if (schedulerConfiguration.OccursOnce &&
                schedulerConfiguration.OccursEvery == false)
            {
                return "once";
            }
            return string.Empty;
        }

        private void ValidateOccurs(SchedulerConfiguration schedulerConfiguration)
        {
            if (this.type.ContainsString("every"))
            {
                ValidateOccursEveryTimes(schedulerConfiguration.EveryTimes);
            }
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

        private string GetDescriptionType(SchedulerConfiguration schedulerConfiguration)
        {
            if (this.type.ContainsString("every"))
            {
                return "every " + schedulerConfiguration.EveryTimes.ToString() + " " + schedulerConfiguration.TimeUnit.ToString().ToLower();
            }
            else
            {
                return "once at " + schedulerConfiguration.OccursOnceTime.ToShortTimeString();
            }
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
