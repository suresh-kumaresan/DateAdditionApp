using DateAdditionApp.Models;


namespace DateAdditionApp.Services
{
    public class DateValidatorService
    {
        public bool IsValidDate(CustomDate date)
        {
            if (date.Year < 1 || date.Year > 9999)  return false;

            if (date.Month < 1 ||  date.Month > 12) return false;

            int maxDays = GetDaysInMonth(date.Month, date.Year);

            return date.Day >= 1 && date.Day <= maxDays;
        }

        public bool IsValidDayRange(int days)
        {
            if (Math.Abs(days) > 100000)
                return false;

            return true;
        }

        private int GetDaysInMonth(int month, int year)
        {
            switch (month)
            {

                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;

                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;

                case 2:
                    return IsLeapYear(year) ? 29 : 28;

                default:
                    return 0;
            }
        }

        private bool IsLeapYear(int year)
        {
            return year % 400 == 0 ||  (year % 4 == 0 && year % 100 != 0);
        }
    }
}