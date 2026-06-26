using System.Text.RegularExpressions;
using DateAdditionApp.Models;

namespace DateAdditionApp.Helpers
{
    public static class DateParser
    {
        public static bool TryParse(string? input, out CustomDate? date)
        {
            date = null;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            input = input.Trim();

            // Exact format dd/mm/yyyy
            if (!Regex.IsMatch(
                input,
                @"^\d{2}/\d{2}/\d{4}$"))
            {
                return false;
            }

            string[] parts = input.Split('/');

            if (!int.TryParse(parts[0], out int day))
                return false;


            if (!int.TryParse(parts[1], out int month))
                return false;


            if (!int.TryParse(parts[2], out int year))
                return false;

            date = new CustomDate
            {
                Day = day,
                Month = month,
                Year = year
            };
            return true;
        }
    }
}