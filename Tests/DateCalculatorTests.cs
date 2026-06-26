using DateAdditionApp.Models;
using DateAdditionApp.Services;


namespace DateAdditionApp.Tests
{
    public class DateCalculatorTests
    {
        private readonly DateCalculatorService calculator;

        public DateCalculatorTests()
        {
            calculator = new DateCalculatorService();
        }

        public void RunAllTests()
        {
            Test_Add_One_Day();

            Test_End_Of_Month();

            Test_Leap_Year();

            Test_Non_Leap_Year();

            Test_Year_Change();

            Console.WriteLine("All tests completed.");
        }

        private void Test_Add_One_Day()
        {
            var date = new CustomDate
            {
                Day = 31,
                Month = 1,
                Year = 2016
            };

            var result = calculator.Calculate(date, 1);

            AssertEqual("01/02/2016", result.ToString(),"Add one day");
        }

        private void Test_End_Of_Month()
        {
            var date = new CustomDate
            {
                Day = 30,
                Month = 4,
                Year = 2025
            };

            var result = calculator.Calculate( date, 1);

            AssertEqual("01/05/2025", result.ToString(), "Month change");
        }

        private void Test_Leap_Year()
        {
            var date = new CustomDate
            {
                Day = 28,
                Month = 2,
                Year = 2024
            }; 

            var result = calculator.Calculate(date, 1);

            AssertEqual( "29/02/2024", result.ToString(), "Leap year");
        }

        private void Test_Non_Leap_Year()
        {

            var date = new CustomDate
            {
                Day = 28,
                Month = 2,
                Year = 2025
            };

            var result = calculator.Calculate(date, 1);

            AssertEqual("01/03/2025", result.ToString(), "Non leap year");
        }
                

        private void Test_Year_Change()
        {

            var date = new CustomDate
            {
                Day = 31,
                Month = 12,
                Year = 2025
            };

            var result = calculator.Calculate(date, 1);

            AssertEqual("01/01/2026", result.ToString(), "Year change");
        } 
        
        private void AssertEqual(
            string expected,
            string actual,
            string testName)
        {
            if (expected != actual)
            {
                Console.WriteLine(
                    $"FAILED : {testName} " +
                    $"Expected={expected}, Actual={actual}");
            }
            else
            {
                Console.WriteLine(
                    $"PASSED : {testName}" +
                    $"Expected={expected}, Actual={actual}");
            }
        }
    }
}