using DateAdditionApp.Models;


namespace DateAdditionApp.Services
{
    public class DateCalculatorService
    {
        public CustomDate Calculate(CustomDate date, int days)
        {
            if (days > 0)
            {
                AddDays(date, days);
            }
            return date;
        }

        private void AddDays(CustomDate date, int days)
        {
            while (days > 0)
            {
                date.Day++;

                if (date.Day > DaysInMonth(date.Month, date.Year))
                {
                    date.Day = 1;
                    date.Month++;
                    if (date.Month > 12)
                    {
                        date.Month = 1;
                        date.Year++;
                    }
                }
                days--;
            }
        }

        private int DaysInMonth(int month, int year)
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
            }

            return 0;
        }

        private bool IsLeapYear(int year)
        {
            return
                year % 400 == 0 ||
                (year % 4 == 0 &&
                 year % 100 != 0);
        }
    }
}