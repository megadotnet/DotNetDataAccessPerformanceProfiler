using System;
using System.Collections.Generic;
using System.Text;

namespace DG.Common
{
    public static class ExtensionMethods
    {
        public static string JoinFormat(this string[] values, string separator, string format)
        {
            if (values == null)
                throw new ArgumentNullException("values");
            if (values.Length == 0 || values[0] == null)
                return string.Empty;
            if (separator == null)
                separator = string.Empty;
            var stringBuilder = new StringBuilder();
            string str1 = values[0];
            if (str1 != null)
                stringBuilder.AppendFormat(format, str1);
            for (int index = 1; index < values.Length; ++index)
            {
                stringBuilder.Append(separator);
                if (values[index] != null)
                {
                    string str2 = values[index];
                    if (str2 != null)
                        stringBuilder.AppendFormat(format, str2);
                }
            }
            return stringBuilder.ToString();
        }

        public static string JoinFormat<T>(this IEnumerable<T> values, string separator, string format)
        {
            if (values == null)
                throw new ArgumentNullException("values");
            var enumerator = values.GetEnumerator();
            var stringBuilder = new StringBuilder();

            if (enumerator.MoveNext() == false || enumerator.Current == null)
            {
                return string.Empty;

            }
            stringBuilder.AppendFormat(format, enumerator.Current);
            while (enumerator.MoveNext())
            {
                stringBuilder.Append(separator);
                if (enumerator.Current != null)
                {
                    stringBuilder.AppendFormat(format, enumerator.Current);
                }
            }

            return stringBuilder.ToString();
        }

        public static string JoinFormat<T>(this IEnumerable<T> values, string separator, Func<T, string> action) 
        {
            if (values == null)
                throw new ArgumentNullException("values");
            var enumerator = values.GetEnumerator();
            var stringBuilder = new StringBuilder();

            if (enumerator.MoveNext() == false || enumerator.Current == null)
            {
                return string.Empty;

            }
            stringBuilder.Append(action(enumerator.Current));
            while (enumerator.MoveNext())
            {
                stringBuilder.Append(separator);
                if (enumerator.Current != null)
                {
                    stringBuilder.Append(action(enumerator.Current));
                }
            }

            return stringBuilder.ToString(); 
        }
    }
}