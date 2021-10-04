using System;

namespace TimeScheduler
{
    public static class ExtensionMethods
    {
        public static bool IsNull(this DateTime dateTime)
        {
            return dateTime.ToString() == null;
        }
    }
}
