using System;

namespace TimeScheduler
{
    [Serializable]
    public class TimeSchedulerException : Exception
    {
        public TimeSchedulerException() { }

        public TimeSchedulerException(string message)
            : base(message) { }
    }
}
