using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TimeScheduler.Resources
{
    public static class SchedulerResourceManager
    {
        private static List<SchedulerResource> resources;
        private static CultureInfo culture;

        internal static void Initialize(SchedulerConfiguration schedulerConfiguration)
        {
            culture = schedulerConfiguration.CultureInfo;
            InitializeList();
        }

        public static string GetResource(string Code)
        {
            return resources.Where(r => r.Code == Code).Select(r => r.Description).FirstOrDefault();
        }

        private static void InitializeList()
        {
            if (culture == CultureInfo.GetCultureInfo("es-ES"))
            {
                InitializeSpanishList();
            }
            else
            {
                InitializeEnglishList();
            }
        }

        private static void InitializeSpanishList()
        {
            resources = new List<SchedulerResource>()
            {
                new()
                {
                    Code = "WeeklyDescription",
                    Description = "Ocurre cada {0} semanas en {1} cada {2} entre {3} y {4} empezando el {5} y acabando el {6}.",
                    Culture = culture
                },
                new()
                {
                    Code = "TheWeekFrequencyIsZero",
                    Description = "La frecuencia semanal es cero.",
                    Culture = culture
                },
                new()
                {
                    Code = "TheWeekFrequencyIsNegative",
                    Description = "La frecuencia semanal es negativa.",
                    Culture = culture
                },
                new()
                {
                    Code = "TheNumberOfTimeUnitIsZero",
                    Description = "El número de unidades de tiempo es cero.",
                    Culture = culture
                },
                new()
                {
                    Code = "TheNumberOfTimeUnitIsNegative",
                    Description = "El número de unidades de tiempo es negativo.",
                    Culture = culture
                },
                new()
                {
                    Code = "TheDateCannotBeRepresented",
                    Description = "La fecha no puede ser representada.",
                    Culture = culture
                },
                new()
                {
                    Code = "OnceDescription",
                    Description = "Ocurre una vez. El Planificador será utilizado el {0} a las {1} empezando el {2} y acabando el {3}.",
                    Culture = culture
                },
                new()
                {
                    Code = "OnceDateTimeLessThanCurrentDate",
                    Description = "La fecha no puede ser menor que la fecha actual.",
                    Culture = culture
                },
                new()
                {
                    Code = "OccursOnceTimeIsOutOfRange",
                    Description = "La fecha está fuera de rango.",
                    Culture = culture
                },
                new()
                {
                    Code = "NoWeekDaysSelected",
                    Description = "No hay días de la semana seleccionados.",
                    Culture = culture
                },
                new()
                {
                    Code = "MonthlyDescription",
                    Description = "Ocurre el {0} de cada {1} meses cada {2} entre {3} y {4} empezando el {5} y acabando el {6}.",
                    Culture = culture
                },
                new()
                {
                    Code = "MonthDayIsZero",
                    Description = "El día del mes es cero.",
                    Culture = culture
                },
                new()
                {
                    Code = "MonthDayIsNegative",
                    Description = "El día del mes es negativo.",
                    Culture = culture
                },
                new()
                {
                    Code = "FrequencyDaysIsZero",
                    Description = "La frecuencia diaria es cero.",
                    Culture = culture
                },
                new()
                {
                    Code = "FrequencyDaysIsNegative",
                    Description = "La frecuencia diaria es negativa.",
                    Culture = culture
                },
                new()
                {
                    Code = "EveryMonthIsZero",
                    Description = "El número de meses es 0.",
                    Culture = culture
                },
                new()
                {
                    Code = "EveryMonthIsNegative",
                    Description = "El número de meses es negativa.",
                    Culture = culture
                },
               new()
                {
                    Code = "EndTimeIsLessThanStartTime",
                    Description = "La hora final es anterior a la hora inicial.",
                    Culture = culture
                },
                new()
                {
                    Code = "EndDateIsLessThanStartDate",
                    Description = "La fecha final es anterior a la fecha inicial.",
                    Culture = culture
                },
                new()
                {
                    Code = "EnabledIsFalse",
                    Description = "Está desactivado.",
                    Culture = culture
                },
                new()
                {
                    Code = "DailyDescription",
                    Description = "Ocurre cada día. El planificador será usado el {0} a las {1} cada {2} entre {3} y {4} empezando el {5} y acabando el {6}.",
                    Culture = culture
                },
                new()
                {
                    Code = "CurrentDateOutOfRange",
                    Description = "La fecha actual está fuera de rango.",
                    Culture = culture
                },
                new()
                {
                    Code = "Monday",
                    Description = "lunes",
                    Culture = culture
                },
                new()
                {
                    Code = "Tuesday",
                    Description = "martes",
                    Culture = culture
                },
                new()
                {
                    Code = "Wednesday",
                    Description = "miércoles",
                    Culture = culture
                },
                new()
                {
                    Code = "Thursday",
                    Description = "jueves",
                    Culture = culture
                },
                new()
                {
                    Code = "Friday",
                    Description = "viernes",
                    Culture = culture
                },
                new()
                {
                    Code = "Saturday",
                    Description = "sábado",
                    Culture = culture
                },
                new()
                {
                    Code = "Sunday",
                    Description = "domingo",
                    Culture = culture
                },
                new()
                {
                    Code = "And",
                    Description = " y ",
                    Culture= culture
                },
                new()
                {
                    Code = "Minutes",
                    Description = "minutos",
                    Culture = culture
                },
                new()
                {
                    Code = "Hours",
                    Description = "horas",
                    Culture = culture
                },
                new()
                {
                    Code = "Seconds",
                    Description = "segundos",
                    Culture = culture
                },
                new()
                {
                    Code = "Day",
                    Description = "día",
                    Culture = culture
                },
                new()
                {
                    Code = "Weekday",
                    Description = "día de la semana",
                    Culture = culture
                },
                new()
                {
                    Code = "WeekendDay",
                    Description = "día de fin de semana",
                    Culture = culture
                },
                new()
                {
                    Code = "First",
                    Description = "primer",
                    Culture = culture
                },
                new()
                {
                    Code = "Second",
                    Description = "segundo",
                    Culture = culture
                },
                new()
                {
                    Code = "Third",
                    Description = "tercer",
                    Culture = culture
                },
                new()
                {
                    Code = "Fourth",
                    Description = "cuarto",
                    Culture = culture
                },
                new()
                {
                    Code = "Last",
                    Description = "último",
                    Culture = culture
                }
        };
        }

        private static void InitializeEnglishList()
        {
            resources = new List<SchedulerResource>()
            {
                new()
                {
                    Code = "WeeklyDescription",
                    Description = "Occurs every {0} weeks on {1} every {2} between {3} and {4} starting on {5} and ending on {6}.",
                    Culture = culture
                },
                new()
                {
                    Code = "TheWeekFrequencyIsZero",
                    Description = "The week frequency is zero.",
                    Culture = culture
                },
                new()
                {
                    Code = "TheWeekFrequencyIsNegative",
                    Description = "The week frequency is negative.",
                    Culture = culture
                },
                new()
                {
                    Code = "TheNumberOfTimeUnitIsZero",
                    Description = "The times of time unit is zero.",
                    Culture = culture
                },
                new()
                {
                    Code = "TheNumberOfTimeUnitIsNegative",
                    Description = "The times of time unit is negative.",
                    Culture = culture
                },
                new()
                {
                    Code = "TheDateCannotBeRepresented",
                    Description = "The date can't be represented.",
                    Culture = culture
                },
                new()
                {
                    Code = "OnceDescription",
                    Description = "Occurs once. Schedule will be used on {0} at {1} starting on {2} and ending {3}.",
                    Culture = culture
                },
                new()
                {
                    Code = "OnceDateTimeLessThanCurrentDate",
                    Description = "Once date time is less than current date.",
                    Culture = culture
                },
                new()
                {
                    Code = "OccursOnceTimeIsOutOfRange",
                    Description = "Occurs once time is out of range.",
                    Culture = culture
                },
                new()
                {
                    Code = "NoWeekDaysSelected",
                    Description = "No week days selected.",
                    Culture = culture
                },
                new()
                {
                    Code = "MonthlyDescription",
                    Description = "Occurs the {0} of every {1} months every {2} between {3} and {4} starting on {5} and ending on {6}.",
                    Culture = culture
                },
                new()
                {
                    Code = "MonthDayIsZero",
                    Description = "Day of month is zero.",
                    Culture = culture
                },
                new()
                {
                    Code = "MonthDayIsNegative",
                    Description = "Day of month is negative.",
                    Culture = culture
                },
                new()
                {
                    Code = "FrequencyDaysIsZero",
                    Description = "The frequency days is zero.",
                    Culture = culture
                },
                new()
                {
                    Code = "FrequencyDaysIsNegative",
                    Description = "The frequency days is negative.",
                    Culture = culture
                },
                new()
                {
                    Code = "EveryMonthIsZero",
                    Description = "Every month is zero.",
                    Culture = culture
                },
                new()
                {
                    Code = "EveryMonthIsNegative",
                    Description = "Every month is negative.",
                    Culture = culture
                },
               new()
                {
                    Code = "EndTimeIsLessThanStartTime",
                    Description = "The end time is less than the start time.",
                    Culture = culture
                },
                new()
                {
                    Code = "EndDateIsLessThanStartDate",
                    Description = "End date is less than start date.",
                    Culture = culture
                },
                new()
                {
                    Code = "EnabledIsFalse",
                    Description = "Enabled is false.",
                    Culture = culture
                },
                new()
                {
                    Code = "DailyDescription",
                    Description = "Occurs every day. Schedule will be used on {0} at {1} every {2} between {3} and {4} starting on {5} and ending on {6}.",
                    Culture = culture
                },
                new()
                {
                    Code = "CurrentDateOutOfRange",
                    Description = "Current date is out of range.",
                    Culture = culture
                },
                new()
                {
                    Code = "Monday",
                    Description = "monday",
                    Culture = culture
                },
                new()
                {
                    Code = "Tuesday",
                    Description = "tuesday",
                    Culture = culture
                },
                new()
                {
                    Code = "Wednesday",
                    Description = "wednesday",
                    Culture = culture
                },
                new()
                {
                    Code = "Thursday",
                    Description = "thursday",
                    Culture = culture
                },
                new()
                {
                    Code = "Friday",
                    Description = "friday",
                    Culture = culture
                },
                new()
                {
                    Code = "Saturday",
                    Description = "saturday",
                    Culture = culture
                },
                new()
                {
                    Code = "Sunday",
                    Description = "sunday",
                    Culture = culture
                },
                new()
                {
                    Code = "And",
                    Description = " and ",
                    Culture= culture
                },
                new()
                {
                    Code = "Minutes",
                    Description = "minutes",
                    Culture = culture
                },
                new()
                {
                    Code = "Hours",
                    Description = "hours",
                    Culture = culture
                },
                new()
                {
                    Code = "Seconds",
                    Description = "seconds",
                    Culture = culture
                },
                new()
                {
                    Code = "Day",
                    Description = "day",
                    Culture = culture
                },
                new()
                {
                    Code = "Weekday",
                    Description = "week day",
                    Culture = culture
                },
                new()
                {
                    Code = "WeekendDay",
                    Description = "weekend day",
                    Culture = culture
                },
                new()
                {
                    Code = "First",
                    Description = "first",
                    Culture = culture
                },
                new()
                {
                    Code = "Second",
                    Description = "second",
                    Culture = culture
                },
                new()
                {
                    Code = "Third",
                    Description = "third",
                    Culture = culture
                },
                new()
                {
                    Code = "Fourth",
                    Description = "fourth",
                    Culture = culture
                },
                new()
                {
                    Code = "Last",
                    Description = "last",
                    Culture = culture
                }
        };
        }
    }
}
