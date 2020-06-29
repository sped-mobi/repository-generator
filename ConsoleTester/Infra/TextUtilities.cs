// -----------------------------------------------------------------------
// <copyright file="TextUtilities.cs" company="Ollon, LLC">
//     Copyright (c) 2017 Ollon, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Globalization;

namespace System.Text
{
    public static class TextUtilities
    {
        public static string PascalCase(string value, bool pluralize = false)
        {
            if (value == null) return null;
            if (value.Length != 0)
            {
                char first = char.ToUpper(value[0]);
                if (pluralize)
                {
                    return first + value.Substring(1) + "s";
                }

                return first + value.Substring(1);
            }

            return string.Empty;
        }

        public static string CamelCase(string value, bool pluralize = false)
        {
            if (value == null) return null;
            if (value.Length != 0)
            {
                char first = char.ToLower(value[0]);
                if (pluralize)
                {
                    return first + value.Substring(1) + "s";
                }

                return first + value.Substring(1);
            }

            return string.Empty;
        }

        public static string TitleCase(string value, bool pluralize = false)
        {
            if (value == null) return null;
            if (value.Length != 0)
            {
                var culture = new CultureInfo("en-US");
                var textInfo = culture.TextInfo;
                if (pluralize)
                {
                    return textInfo.ToTitleCase(value) + "s";
                }

                return textInfo.ToTitleCase(value);
            }

            return string.Empty;
        }
    }
}
