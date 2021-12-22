namespace TimeScheduler
{
    public enum ExecutionType
    {
        Once,
        Recurring
    }

    public enum TimeUnit
    {
        Seconds,
        Minutes,
        Hours
    }

    public enum OccursType
    {
        Once,
        Every
    }

    public enum FrecuencyType
    {
        Daily,
        Weekly,
        Monthly
    }

    public enum DaysConfiguration
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 0,
        Day = 7,
        Weekday = 8,
        WeekendDay = 9
    }

    public enum OrdinalConfiguration
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Last = 31
    }

    public enum MonthlyType
    {
        Day,
        WeeksDay
    }
}
