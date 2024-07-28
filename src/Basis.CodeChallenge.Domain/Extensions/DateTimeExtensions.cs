using System;

namespace Basis.CodeChallenge.Domain.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts the DateTime to Timestamp
        /// </summary>
        /// <param name="dateTime">DateTime specified to be converted</param>
        /// <returns>Unix time seconds</returns>
        public static long ToUnixTimestamp(this DateTime dateTime)
            => new DateTimeOffset(dateTime).ToUnixTimeSeconds();
    }
}
