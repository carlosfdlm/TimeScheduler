using System;
using System.Collections.Generic;
using System.Text;

namespace TimeScheduler
{
    public class RecurringStrategy : SchedulerStrategy
    {
        private string[] nextDate;
        private string type;
        private const string DESCRIPTION = "Occurs every {0} weeks on {1} {2} between {3} and {4} starting on {5} and ending on {6}.";

        public RecurringStrategy()
        {
            this.nextDate = new string[2];
            this.type = string.Empty;
        }

        public string[] CalculateNextDate(SchedulerConfiguration schedulerConfiguration)
        {            
            this.ValidateGeneralConfiguration(schedulerConfiguration);
            this.ValidateLimitsDates(schedulerConfiguration.StartDate, schedulerConfiguration.EndDate);
            this.ValidateDailyConfiguration(schedulerConfiguration);
            this.ValidateWeeklyConfiguration(schedulerConfiguration);
            
            this.nextDate[0] = this.CalculateNextExecutionDate(schedulerConfiguration);
            this.nextDate[1] = this.SchedulerDescription(schedulerConfiguration);
            return this.nextDate;
        }

        private string SchedulerDescription(SchedulerConfiguration schedulerConfiguration)
        {
            return string.Format(DESCRIPTION,
                schedulerConfiguration.EveryTimesWeekly,
                this.WeekDaysMsg(schedulerConfiguration),
                this.GetTypeStr(schedulerConfiguration),
                schedulerConfiguration.StartTime,
                schedulerConfiguration.EndTime,
                schedulerConfiguration.StartDate,
                schedulerConfiguration.EndDate);
        }
       

        private void ValidateWeeklyConfiguration(SchedulerConfiguration schedulerConfiguration)
        {
            this.ValidateEveryWeekly(schedulerConfiguration);
            this.ValidateDays(schedulerConfiguration);
        }

        private void ValidateDailyConfiguration(SchedulerConfiguration schedulerConfiguration)
        {
            this.type = this.ValidateOccursType(schedulerConfiguration);
            this.ValidateOccurs(schedulerConfiguration);
            this.ValidatingStartEndHours(schedulerConfiguration);
        }

        private void ValidateGeneralConfiguration(SchedulerConfiguration schedulerConfiguration)
        {
            this.ValidateCurrentDate(schedulerConfiguration.CurrentDate);
            this.ValidateNumDays(schedulerConfiguration.NumDays);
            this.ValidateSum(schedulerConfiguration.CurrentDate, schedulerConfiguration.NumDays);
        }
              
        private void ValidateNumDays(string numDays)
        {
            if (numDays == null)
            {
                throw new TimeSchedulerException("Num days is null.");
            }
            if (string.IsNullOrWhiteSpace(numDays))
            {
                throw new TimeSchedulerException("Num days is empty.");
            }
            if (Double.TryParse(numDays, out _) == false)
            {
                throw new TimeSchedulerException("Num days bad format.");
            }
            if (Double.Parse(numDays) < 0)
            {
                throw new TimeSchedulerException("Num days is negative.");
            }
        }

        private void ValidateSum(string currentDate, string numDays)
        {
            try
            {
                DateTime currentTime = DateTime.Parse(currentDate);
                currentTime.AddDays(Double.Parse(numDays));
            }
            catch (Exception)
            {
                throw new TimeSchedulerException("Next execution date is max date.");
            }
        }

        private void ValidateCurrentDate(string currentDate)
        {
            currentDate.ValidateDates();
        }

        private void ValidateLimitsDates(string startDate, string endDate)
        {
            try
            {
                startDate.ValidateDates();
            }
            catch (TimeSchedulerException exc)
            {
                throw new TimeSchedulerException("Start date " + exc.Message);
            }
            try
            {
                endDate.ValidateDates();
            }
            catch (TimeSchedulerException exc)
            {
                throw new TimeSchedulerException("End date " + exc.Message);
            }
        }

        public void ValidateOccursEvery(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.EveryType == null)
            {
                throw new TimeSchedulerException("Occurs every type is null.");
            }
            if (string.IsNullOrEmpty(schedulerConfiguration.EveryType))
            {
                throw new TimeSchedulerException("Occurs every type is empty.");
            }
            if (schedulerConfiguration.EveryType.ContainsString("hours") == false &&
                schedulerConfiguration.EveryType.ContainsString("minutes") == false &&
                schedulerConfiguration.EveryType.ContainsString("seconds") == false)
            {
                throw new TimeSchedulerException("Occurs every type bad format.");
            }
        }

        private void ValidatingStartEndHours(SchedulerConfiguration schedulerConfiguration)
        {
            try
            {
                schedulerConfiguration.StartTime.ValidateHour();
            }
            catch (TimeSchedulerException exc)
            {
                throw new TimeSchedulerException("Start time " + exc.Message);
            }
            try
            {
                schedulerConfiguration.EndTime.ValidateHour();
            }
            catch (TimeSchedulerException exc)
            {
                throw new TimeSchedulerException("End time " + exc.Message);
            }
        }

        private void ValidateOccurs(SchedulerConfiguration schedulerConfiguration)
        {
            if (this.type.ContainsString("once"))
            {
                try
                {
                    schedulerConfiguration.OccursOnceTime.ValidateHour();
                }
                catch (TimeSchedulerException exc)
                {
                    throw new TimeSchedulerException("Occurs once time " + exc.Message);
                }
            }
            else if (this.type.ContainsString("every"))
            {
                this.ValidateOccursEveryTimes(schedulerConfiguration);
                this.ValidateOccursEvery(schedulerConfiguration);                
            }
        }

        private void ValidateDays(SchedulerConfiguration schedulerConfiguration)
        {
            bool found = false;
            for (int i = 0; i < schedulerConfiguration.WeekDays.Length; i++)
            {
                if (schedulerConfiguration.WeekDays[i].Contains("true"))
                {
                    found = true;
                }
            }
            if (found == false)
            {
                throw new TimeSchedulerException("Week days is empty.");
            }
        }

        private void ValidateEveryWeekly(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.EveryTimesWeekly == null)
            {
                throw new TimeSchedulerException("Weekly times is null.");
            }
            if (string.IsNullOrEmpty(schedulerConfiguration.EveryTimesWeekly))
            {
                throw new TimeSchedulerException("Weekly times is empty.");
            }
            if (Int32.TryParse(schedulerConfiguration.EveryTimesWeekly, out _) == false)
            {
                throw new TimeSchedulerException("Weekly times bad format.");
            }
            if (Int32.TryParse(schedulerConfiguration.EveryTimesWeekly, out _) &&
                Int32.Parse(schedulerConfiguration.EveryTimesWeekly) <= 0)
            {
                throw new TimeSchedulerException("Weekly times negative.");
            }
        }

        private void ValidateOccursEveryTimes(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.EveryTimes == null)
            {
                throw new TimeSchedulerException("Occurs every times is null.");
            }
            if (string.IsNullOrEmpty(schedulerConfiguration.EveryTimes))
            {
                throw new TimeSchedulerException("Occurs every times is empty.");
            }
            if (Int32.TryParse(schedulerConfiguration.EveryTimes, out _) == false)
            {
                throw new TimeSchedulerException("Occurs every times bad format.");
            }
            if (Int32.TryParse(schedulerConfiguration.EveryTimes, out _) &&
                Int32.Parse(schedulerConfiguration.EveryTimes) <= 0)
            {
                throw new TimeSchedulerException("Occurs every times is negative.");
            }
        }

        private string ValidateOccursType(SchedulerConfiguration schedulerConfiguration)
        {
            if (schedulerConfiguration.OccursOnce == null &&
                schedulerConfiguration.OccursEvery == null)
            {
                throw new TimeSchedulerException("Occurs is null.");
            }
            if (string.IsNullOrEmpty(schedulerConfiguration.OccursOnce) &&
                string.IsNullOrEmpty(schedulerConfiguration.OccursEvery))
            {
                throw new TimeSchedulerException("Occurs is empty.");
            }
            if (schedulerConfiguration.OccursOnce != null &&
                schedulerConfiguration.OccursOnce.ContainsString("true") &&
                schedulerConfiguration.OccursEvery == null)
            {
                return "once";
            }
            if (schedulerConfiguration.OccursOnce == null &&
                schedulerConfiguration.OccursEvery.ContainsString("true"))
            {
                return "every";
            }
            if (schedulerConfiguration.OccursOnce.ContainsString("true") == false &&
                schedulerConfiguration.OccursEvery.ContainsString("true"))
            {
                return "every";
            }
            if (schedulerConfiguration.OccursOnce.ContainsString("true") &&
                schedulerConfiguration.OccursEvery.ContainsString("true") == false)
            {
                return "once";
            }
            if (schedulerConfiguration.OccursOnce.ContainsString("true") &&
               schedulerConfiguration.OccursEvery.ContainsString("true"))
            {
                throw new TimeSchedulerException("Occurs is two times true.");
            }
            if (schedulerConfiguration.OccursOnce.ContainsString("true") == false &&
                schedulerConfiguration.OccursEvery.ContainsString("false") == false)
            {
                throw new TimeSchedulerException("Occurs bad format.");
            }
            if (schedulerConfiguration.OccursOnce.ContainsString("false") &&
             schedulerConfiguration.OccursEvery.ContainsString("false"))
            {
                throw new TimeSchedulerException("Occurs is two times false.");
            }
            return string.Empty;
        }

        private string GetTypeStr(SchedulerConfiguration schedulerConfiguration)
        {
            if (this.type.ContainsString("every"))
            {
                return "every " + schedulerConfiguration.EveryTimes.ToString() + " " + schedulerConfiguration.EveryType;
            }
            else
            {
                return "once at " + schedulerConfiguration.OccursOnceTime;
            }
        }

        public string WeekDaysMsg(SchedulerConfiguration schedulerConfiguration)
        {
            List<string> weekDaysStr = new List<string>();
            for (int i = 0; i < schedulerConfiguration.WeekDays.Length; i++)
            {
                if (i == 0 &&
                    schedulerConfiguration.WeekDays[i].ContainsString("true"))
                {
                    weekDaysStr.Add("monday");
                }
                if (i == 1 &&
                    schedulerConfiguration.WeekDays[i].ContainsString("true"))
                {
                    weekDaysStr.Add("tuesday");
                }
                if (i == 2 &&
                    schedulerConfiguration.WeekDays[i].ContainsString("true"))
                {
                    weekDaysStr.Add("wednesday");
                }
                if (i == 3 &&
                    schedulerConfiguration.WeekDays[i].ContainsString("true"))
                {
                    weekDaysStr.Add("thursday");
                }
                if (i == 4 &&
                    schedulerConfiguration.WeekDays[i].ContainsString("true"))
                {
                    weekDaysStr.Add("friday");
                }
                if (i == 5 &&
                    schedulerConfiguration.WeekDays[i].ContainsString("true"))
                {
                    weekDaysStr.Add("saturday");
                }
                if (i == 6 &&
                    schedulerConfiguration.WeekDays[i].ContainsString("true"))
                {
                    weekDaysStr.Add("sunday");
                }
            }
            StringBuilder weekDaysMsg = new StringBuilder();
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

        private string CalculateNextExecutionDate(SchedulerConfiguration schedulerConfiguration)
        {

            return DateTime.Parse(schedulerConfiguration.CurrentDate).AddDays(Double.Parse(schedulerConfiguration.NumDays)).ToString();
        }       
    }
}
