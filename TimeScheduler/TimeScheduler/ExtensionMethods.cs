using System;

namespace TimeScheduler
{
    public static class ExtensionMethods
    {
        public static void ValidateDates(this string DateToValidate)
        {
            if (DateToValidate == null)
            {
                throw new TimeSchedulerException();
            }
            if (string.IsNullOrWhiteSpace(DateToValidate))
            {
                throw new TimeSchedulerException();
            }
            if (DateTime.TryParse(DateToValidate, out _) == false)
            {
                throw new TimeSchedulerException();
            }
        }

        public static void ValidateHour(this string HourToValidate)
        {
            if (HourToValidate == null)
            {
                throw new TimeSchedulerException();
            }
            if (string.IsNullOrEmpty(HourToValidate))
            {
                throw new TimeSchedulerException();
            }
            if (DateTime.TryParse(HourToValidate, out _) == false)
            {
                throw new TimeSchedulerException();
            }
        }

        public static bool ContainsString(this string cadena, string cadenaBusqueda)
        {
            if(cadena == null)
            {
                throw new TimeSchedulerException();
            }
            return cadena.ToLower().Contains(cadenaBusqueda.ToLower());
        }
    }
}
