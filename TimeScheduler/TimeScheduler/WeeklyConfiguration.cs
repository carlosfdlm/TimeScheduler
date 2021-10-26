using System;
using System.Collections.Generic;
using System.Text;

namespace TimeScheduler
{
    public class WeeklyConfiguration
    {
        private string[] weekDays;

        public WeeklyConfiguration()
        {
            this.weekDays = new string[7] { "", "", "", "", "", "", "" };
        }

        public string EveryTimes { get; set; }

        public string[] WeekDays
        {
            get
            {
                return this.weekDays;
            }
            set
            {
                this.weekDays = value;
            }
        }

        public string WeekDaysMsg()
        {
            List<string> weekDaysStr = new List<string>();           
            for (int i = 0; i < this.weekDays.Length; i++)
            {
                if (i == 0 &&
                    this.weekDays[i].ContainsString("true"))
                {
                    weekDaysStr.Add("monday");
                }
                if (i == 1 &&
                    this.weekDays[i].ContainsString("true"))
                {
                    weekDaysStr.Add("tuesday");
                }
                if (i == 2 &&
                    this.weekDays[i].ContainsString("true"))
                {
                    weekDaysStr.Add("wednesday");
                }
                if (i == 3 &&
                    this.weekDays[i].ContainsString("true"))
                {
                    weekDaysStr.Add("thursday");
                }
                if (i == 4 &&
                    this.weekDays[i].ContainsString("true"))
                {
                    weekDaysStr.Add("friday");
                }
                if (i == 5 &&
                    this.weekDays[i].ContainsString("true"))
                {
                    weekDaysStr.Add("saturday");
                }
                if (i == 6 &&
                    this.weekDays[i].ContainsString("true"))
                {
                    weekDaysStr.Add("sunday");
                }
            }
            StringBuilder weekDaysMsg = new StringBuilder();
            for (int i = 0; i < weekDaysStr.Count; i++)
            {
                weekDaysMsg.Append(weekDaysStr[i]);
                if(i + 1 == weekDaysStr.Count - 1)
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

        public void Validate()
        {
            this.ValidateEvery();
            this.ValidateDays();
        }

        private void ValidateDays()
        {
            bool found = false;
            for (int i = 0; i < this.WeekDays.Length - 1; i++)
            {
                if (this.WeekDays[i].Contains("true"))
                {
                    found = true;
                }
            }
            if (found == false)
            {
                throw new TimeSchedulerException();
            }
        }

        private void ValidateEvery()
        {
            if (this.EveryTimes == null)
            {
                throw new TimeSchedulerException();
            }
            if (string.IsNullOrEmpty(this.EveryTimes))
            {
                throw new TimeSchedulerException();
            }
            if (Int32.TryParse(this.EveryTimes, out _) == false)
            {
                throw new TimeSchedulerException();
            }
            if (Int32.TryParse(this.EveryTimes, out _) &&
                Int32.Parse(this.EveryTimes) <= 0)
            {
                throw new TimeSchedulerException();
            }
        }
    }
}
