using System;

namespace TimeScheduler
{
    public static class ExtensionMethods
    {
        public static bool ContainsString(this string cadena, string cadenaBusqueda)
        {
            return cadena.ToLower().Contains(cadenaBusqueda.ToLower());
        }
    }
}
