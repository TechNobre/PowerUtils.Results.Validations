using System;

namespace PowerUtils.Results
{
    internal static class Temporary
    { // TODO: to remove
        private const string PATTERN_ERROR_CODE_WITH_LIMIT = "{0}:{1}"; // {0} => ERROR CODE, {1} => LIMIT


        public const string MIN = "MIN";
        public const string MAX = "MAX";


#if NET6_0_OR_GREATER
        public static string CreateMin(DateOnly min, string format = "yyyy-MM-dd")
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MIN, min.ToString(format));

        public static string CreateMin(TimeOnly min, string format = "HH:mm:ss")
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MIN, min.ToString(format));

        public static string CreateMax(DateOnly max, string format = "yyyy-MM-dd")
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MAX, max.ToString(format));

        public static string CreateMax(TimeOnly max, string format = "HH:mm:ss")
            => string.Format(PATTERN_ERROR_CODE_WITH_LIMIT, MAX, max.ToString(format));
#endif
    }
}
