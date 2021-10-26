using System;

namespace TimeScheduler
{
    public class LimitsConfiguration
    {
        public LimitsConfiguration() { }

        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public void Validate()
        {
            this.StartDate.ValidateDates();
            this.EndDate.ValidateDates();
        }
    }
}
