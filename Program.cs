using DateAdditionApp.Helpers;
using DateAdditionApp.Models;
using DateAdditionApp.Services;
using System.Security.AccessControl;



class Program
{

    static void Main()
    {
        ////Note: Uncommand the below lines if you want test the default unit test cases
        //DateAdditionApp.Tests.DateCalculatorTests tests = new DateAdditionApp.Tests.DateCalculatorTests();
        //tests.RunAllTests();

        Console.Write("Enter date (dd/mm/yyyy): ");
        string? input = Console.ReadLine();

        if (!DateParser.TryParse(input, out CustomDate? date))
        {
            Console.WriteLine("Invalid date format. Use dd/mm/yyyy");
            return;
        }

        DateValidatorService validator = new DateValidatorService();

        if (!validator.IsValidDate(date))
        {
            Console.WriteLine("Invalid date entered.");
            return;
        }

        Console.Write("Enter number of days to addition: ");

        if (!int.TryParse(Console.ReadLine(), out int days))
        {
            Console.WriteLine( "Invalid day value");
            return;
        }

        if (days < 0)
        {
            Console.WriteLine("Invalid value. Days to add cannot be negative.");
            return;
        }

        if (!validator.IsValidDayRange(days))
        {
            Console.WriteLine( "Day range is too large.");
            return;
        }

        DateCalculatorService service = new DateCalculatorService();

        CustomDate result = service.Calculate(date, days);

        Console.WriteLine();
        Console.WriteLine($"Original Date : {input}");
        Console.WriteLine( $"Days Added   : {days}");
        Console.WriteLine($"New Date      : {result}");

        
    }

}