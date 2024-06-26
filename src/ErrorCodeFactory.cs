﻿using System;

namespace PowerUtils.Results
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public static class ErrorCodeFactory
    {
        private const string PATTERN_ERROR_CODE_WITH_LIMIT = "{0}:{1}"; // {0} => ERROR CODE, {1} => LIMIT

        private const string MIN = "MIN";
        private const string MAX = "MAX";


        public const string MIN_DATETIME_UTCNOW = MIN + ":DATETIME_UTCNOW";
        public const string MAX_DATETIME_UTCNOW = MAX + ":DATETIME_UTCNOW";

        public const string MIN_LATITUDE = MIN + ":-90";
        public const string MAX_LATITUDE = MAX + ":90";

        public const string MIN_LONGITUDE = MIN + ":-180";
        public const string MAX_LONGITUDE = MAX + ":180";


        public static string CreateMin(int min)
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MIN, min);

        public static string CreateMin<TValue>(TValue min)
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MIN, min.ToString().Replace(",", "."));

        public static string CreateMin(DateTime min, string format = "yyyy-MM-dd HH:mm:ss")
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MIN, min.ToString(format));

        public static string CreateDateTimeMin(DateTime min)
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MIN, min.ToString("yyyy-MM-dd HH:mm:ss"));

        public static string CreateDateMin(DateTime min)
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MIN, min.ToString("yyyy-MM-dd"));

#if NET6_0_OR_GREATER
        public static string CreateDateMin(DateOnly min, string format = "yyyy-MM-dd")
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MIN, min.ToString(format));

        public static string CreateTimeMin(TimeOnly min, string format = "HH:mm:ss")
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MIN, min.ToString(format));
#endif



        public static string CreateMax(int max)
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MAX, max);

        public static string CreateMax<TValue>(TValue max)
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MAX, max.ToString().Replace(",", "."));

        public static string CreateMax(DateTime max, string format = "yyyy-MM-dd HH:mm:ss")
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MAX, max.ToString(format));

        public static string CreateDateTimeMax(DateTime max)
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MAX, max.ToString("yyyy-MM-dd HH:mm:ss"));

        public static string CreateDateMax(DateTime max)
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MAX, max.ToString("yyyy-MM-dd"));

#if NET6_0_OR_GREATER
        public static string CreateDateMax(DateOnly max, string format = "yyyy-MM-dd")
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MAX, max.ToString(format));

        public static string CreateTimeMax(TimeOnly max, string format = "HH:mm:ss")
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MAX, max.ToString(format));
#endif
    }
}
