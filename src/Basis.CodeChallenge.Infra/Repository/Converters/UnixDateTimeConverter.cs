using Basis.CodeChallenge.Domain.Extensions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Basis.CodeChallenge.Infra.Repository.Converters
{
    internal class UnixDateTimeConverter : ValueConverter<DateTime, long>
    {
        /// <summary>
        /// Converts the DateTime to/from DateTime/long
        /// </summary>
        /// <param name="mappingHints"><see cref="ConverterMappingHints"/></param>
        public UnixDateTimeConverter(ConverterMappingHints mappingHints = null)
            : base(
                dateTime => dateTime != DateTime.MinValue
                    ? dateTime.ToUnixTimestamp()
                    : 0,
                dateTime => dateTime == 0
                    ? DateTime.MinValue
                    : DateTimeOffset.FromUnixTimeSeconds(dateTime).UtcDateTime,
                mappingHints)
        {
        }
    }
}
