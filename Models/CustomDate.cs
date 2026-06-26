namespace DateAdditionApp.Models
{
    public class CustomDate
    {
        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Day:D2}/{Month:D2}/{Year}";
        }
    }
}