using System;

namespace Dasigno.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static bool HasValue(this object @object)
        {
            return @object != null;
        }

        public static string ToNullValueString(this object value, object data)
        {
            string result;
            if (value.HasValue())
            {
                result = value.ToString();
            }
            else
            {
                result = data?.ToString();
            }
            return result;
        }

        public static DateTime ToNullValueDateTime(this object value, object data)
        {
            DateTime result;
            if (value.HasValue())
            {
                result = DateTime.Parse(value.ToString());
            }
            else
            {
                result = DateTime.Parse(data.ToString());
            }
            return result;
        }
    }
}
