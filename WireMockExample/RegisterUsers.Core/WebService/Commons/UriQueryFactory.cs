using System;
using System.Linq;
using System.Reflection;

namespace RegisterUsers.Core.WebService.Commons
{
    public class UriQueryFactory : IUriQueryFactory
    {

        public string BuildQueryString(object queryObject)
        {
            string Format(PropertyInfo property, object value)
            {
                var attribute = property.GetCustomAttributes()
                    .FirstOrDefault(a => a is IFormatPropertyQuery);

                if (attribute != null)
                    return ((IFormatPropertyQuery) attribute).Format(value);
                return value?.ToString();
            }

            var qsList = queryObject.GetType().GetProperties()
                .Select(p => (p.Name, Format(p, p.GetValue(queryObject))))
                .Where(t => !string.IsNullOrWhiteSpace(t.Item2))
                .Select(t => $"{t.Name}={t.Item2}");

            var result = $"?{string.Join('&', qsList)}";

            return result;
        }
    }

    public interface IFormatPropertyQuery
    {
        string Format(object value);
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class FormatDateTimeIsoAttribute : Attribute, IFormatPropertyQuery
    {
        public string Format(object value)
        {
            var dateTime = value as DateTime?;
            return dateTime?.ToString("yyy-MM-ddTHH:mm:ssZ");
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class FormatIntAttribute : Attribute, IFormatPropertyQuery
    {
        private readonly int _minCharacters;

        public FormatIntAttribute(int minCharacters = 0)
        {
            _minCharacters = minCharacters;
        }

        public string Format(object value)
        {
            return value?.ToString().PadLeft(_minCharacters, '0');
        }
    }
}