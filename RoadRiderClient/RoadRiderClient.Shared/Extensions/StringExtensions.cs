using System.Text.RegularExpressions;

namespace RoadRiderClient.Shared.Extensions
{
    public static class StringExtensions
    {
        const string COORD_REGEX = "^[-+]?([1-8]?\\d(\\.\\d+)?|90(\\.0+)?),\\s*[-+]?(180(\\.0+)?|((1[0-7]\\d)|([1-9]?\\d))(\\.\\d+)?)$";

        public static bool HasCooridnates(this string str)
        {
            var reg = new Regex(COORD_REGEX);
            return reg.IsMatch(str);
        }

        public static (double, double) GetCoord(this string str)
        {
            var reg = new Regex(COORD_REGEX);
            var matchCollection = reg.Matches(str);

            var coords = matchCollection[0].Value.Split(',');

            double.TryParse(coords[0], out var lat);
            double.TryParse(coords[1], out var @long);

            return (lat, @long);
        }
    }
}
