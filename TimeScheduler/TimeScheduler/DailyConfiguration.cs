namespace TimeScheduler
{
    public class DailyConfiguration
    {
        public DailyConfiguration() { }

        public string OccursEvery { get; set; }
        public string OccursOnce { get; set; }
        public string OccursOnceTime { get; set; }
        public string EveryType { get; set; }
        public string EveryTimes { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public string TypeStr
        {
            get
            {
                if (this.ValidateOccursType().ContainsString("every"))
                {
                    return "every " + this.EveryTimes.ToString() + " " + this.EveryType;
                }
                else
                {
                    return "once at " + this.OccursOnceTime;
                }
            }
        }

        public void Validate()
        {
            this.ValidateOccurs(this.ValidateOccursType());
            this.ValidatingStartEndHours();
        }

        public void ValidateOccursEvery()
        {
            if (this.EveryType == null)
            {
                throw new TimeSchedulerException();
            }
            if (string.IsNullOrEmpty(this.EveryType))
            {
                throw new TimeSchedulerException();
            }
            if (this.EveryType.ContainsString("hours") == false &&
                this.EveryType.ContainsString("minutes") == false &&
                this.EveryType.ContainsString("seconds") == false)
            {
                throw new TimeSchedulerException();
            }
        }

        private void ValidatingStartEndHours()
        {
            this.StartTime.ValidateHour();
            this.EndTime.ValidateHour();
        }

        private void ValidateOccurs(string Occurs)
        {
            if (Occurs == "once")
            {
                this.ValidateOccursOnceAt();
            }
            else
            {
                this.ValidateOccursEvery();
            }
        }        

        private void ValidateOccursOnceAt()
        {
            this.OccursOnceTime.ValidateHour();
        }

        private string ValidateOccursType()
        {
            if (this.OccursOnce == null &&
                this.OccursEvery == null)
            {
                throw new TimeSchedulerException();
            }
            if (string.IsNullOrEmpty(this.OccursOnce) &&
                string.IsNullOrEmpty(this.OccursEvery))
            {
                throw new TimeSchedulerException();
            }
            if (this.OccursOnce == null &&
                this.OccursEvery.ContainsString("true"))
            {
                return "every";
            }
            if (this.OccursOnce.ContainsString("true") &&
                this.OccursEvery == null)
            {
                return "once";
            }
            if (this.OccursOnce.ContainsString("false") &&
                this.OccursEvery.ContainsString("false"))
            {
                throw new TimeSchedulerException();
            }
            if (this.OccursOnce.ContainsString("true") &&
                this.OccursEvery.ContainsString("true"))
            {
                throw new TimeSchedulerException();
            }
            return string.Empty;
        }
    }
}
