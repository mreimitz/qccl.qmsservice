using System;
using System.Collections.Generic;
using System.Text;

namespace qccl.toolbox
{
    /// <summary>
    /// 
    /// </summary>
    public class Tools
    {
        /// <summary>
        /// Arry2s the string.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="seperator">The seperator.</param>
        /// <returns></returns>
        public static string Arry2String(string[] array, string seperator)
        {
            // Concatenate all the elements into a StringBuilder.
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
                builder.Append(seperator);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Strings the left.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <returns></returns>
        public static string StringLeft(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength
                   ? value
                   : value.Substring(0, maxLength)
                   );
        }

        /// <summary>
        /// Exeception2s the string array.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        public static string[] Exeception2StringArray(Exception ex)
        {
            List<string> result = new List<string>();
            result.Add("Exception");
            if (!string.IsNullOrEmpty(ex.Message))
                result.Add("Message@" + ex.Message);
            if (!string.IsNullOrEmpty(ex.Source))
                result.Add("Source@" + ex.Source);
            if (ex.InnerException != null)
                result.Add("InnerException@" + ex.InnerException.Message);

            return result.ToArray();
        }

        /// <summary>
        /// String2s the string array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string[] String2StringArray(string value)
        {
            List<string> result = new List<string>();
            if (string.IsNullOrEmpty(value))
            {
                result.Add("");
                result.Add("");
            }
            else
            {
                result.Add(value);
                result.Add("");
                result.Add("");
            }
            return result.ToArray();
        }

        /// <summary>
        /// List2s the string array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public static string[] List2StringArray(List<string> values)
        {
            List<string> result = new List<string>();
            if (values == null || values.Count == 0)
            {
                result.Add("");
                result.Add("");
            }
            else
            {
                result = values;
                result.Add("");
                result.Add("");
            }
            return result.ToArray();
        }


        /// <summary>
        /// Base64s the URL encode.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        internal static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }
    }
}