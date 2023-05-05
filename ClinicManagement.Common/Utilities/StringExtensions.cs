using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
namespace ClinicManagement.Common.Utilities
{
    public static class StringExtensions
    {
        public static bool HasValue(this string value, bool ignoreWhiteSpace = true)
        {
            return ignoreWhiteSpace ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrEmpty(value);
        }

        public static string TrimEnd(this string source, string value)
        {
            while (source.EndsWith(value, StringComparison.OrdinalIgnoreCase))
                source = source.Substring(0, source.Length - value.Length);
            return source;
        }

        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }

        public static decimal ToDecimal(this string value)
        {
            return Convert.ToDecimal(value);
        }

        public static string ToNumeric(this int value)
        {
            return value.ToString("N0"); //"123,456"
        }

        public static string ToNumeric(this long value)
        {
            return value.ToString("N0"); //"123,456"
        }

        public static string ToNumeric(this decimal value)
        {
            return value.ToString("N0"); //"123,456"
        }

        public static string ToCurrency(this int value)
        {
            //fa-IR => current culture currency symbol => ریال
            //123456 => "123,123ریال"
            return value.ToString("C0");
        }

        public static string ToCurrency(this decimal value)
        {
            return value.ToString("C0");
        }

        public static string En2Fa(this string str)
        {
            return str.Replace("0", "۰")
                .Replace("1", "۱")
                .Replace("2", "۲")
                .Replace("3", "۳")
                .Replace("4", "۴")
                .Replace("5", "۵")
                .Replace("6", "۶")
                .Replace("7", "۷")
                .Replace("8", "۸")
                .Replace("9", "۹");
        }

        public static string Fa2En(this string str)
        {
            return str.Replace("۰", "0")
                .Replace("۱", "1")
                .Replace("۲", "2")
                .Replace("۳", "3")
                .Replace("۴", "4")
                .Replace("۵", "5")
                .Replace("۶", "6")
                .Replace("۷", "7")
                .Replace("۸", "8")
                .Replace("۹", "9")
                //iphone numeric
                .Replace("٠", "0")
                .Replace("١", "1")
                .Replace("٢", "2")
                .Replace("٣", "3")
                .Replace("٤", "4")
                .Replace("٥", "5")
                .Replace("٦", "6")
                .Replace("٧", "7")
                .Replace("٨", "8")
                .Replace("٩", "9");
        }

        public static string FixPersianChars(this string str)
        {
            return str.Replace("ﮎ", "ک")
                .Replace("ﮏ", "ک")
                .Replace("ﮐ", "ک")
                .Replace("ﮑ", "ک")
                .Replace("ك", "ک")
                .Replace("ي", "ی")
                .Replace(" ", " ")
                .Replace("‌", " ")
                .Replace("ھ", "ه");//.Replace("ئ", "ی");
        }

        public static string CleanString(this string str)
        {
            return str.Trim().FixPersianChars().Fa2En().NullIfEmpty();
        }

        public static string NullIfEmpty(this string str)
        {
            return str?.Length == 0 ? null : str;
        }


        public static List<string>? SplitCsv(this string csvList, bool nullOrWhitespaceInputReturnsNull = false)
        {
            if (string.IsNullOrWhiteSpace(csvList))
                return nullOrWhitespaceInputReturnsNull ? null : new List<string>();

            return csvList
                .TrimEnd(',')
                .Split(',')
                .AsEnumerable()
                .Select(s => s.Trim())
                .ToList();
        }
        public static bool IsNullOrWhitespace(this string s)
            => string.IsNullOrWhiteSpace(s);

        public static bool HasValidUri(this string address)
        {
            var result = Uri.IsWellFormedUriString(address, UriKind.Absolute);
            var resul2 = address.HasValue();
            return resul2 && result;
        }

        public static string AddParametersToStringUri(this string value, Dictionary<string, string> parameters)
        {
            var boolDefault = default(bool).ToString().ToLower();
            var dateTimeDefault = default(DateTime).ToString().ToLower();
            var intDefault = default(int).ToString().ToLower();

            var result = new StringBuilder();
            result.Append(value);
            result.Append('?');
            foreach (var param in parameters)
            {
                if (param.Value != null && param.Value != boolDefault && param.Value != dateTimeDefault &&
                    param.Value != intDefault)
                {
                    result.Append(param.Key);
                    result.Append('=');
                    result.Append(param.Value);
                    result.Append('&');
                }
            }

            var stringResult = result.ToString();
            stringResult = stringResult.Remove(stringResult.Length - 1);

            return stringResult.ToString();
        }
    }
}
