using System;
using System.IO;
using NUnit.Framework;

namespace FizzBuzzApp
{
    public interface IFizzBuzzService
    {
        void PrintFizzBuzz(string n);
        //string GetFizzBuzzResult(string input);
    }
    public class FizzBuzzService : IFizzBuzzService
    {
        private static FizzBuzzService _instance;

        private FizzBuzzService() { }

        //Singelton
        public static FizzBuzzService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FizzBuzzService();
            }
            return _instance;
        }
        public void PrintFizzBuzz(string input)
        {
            var inputs = input.Split(',');
            foreach (var item in inputs)
            {
                if (int.TryParse(item, out int number))
                {
                    if (number % 3 == 0 && number % 5 == 0)
                    {
                        //return "FizzBuzz";
                        Console.WriteLine("FizzBuzz");
                    }
                    else if (number % 3 == 0)
                    {
                        //return "Fizz";
                        Console.WriteLine("Fizz");
                    }
                    else if (number % 5 == 0)
                    {
                        //return "Buzz";
                        Console.WriteLine("Buzz");
                    }
                    else
                    {
                        //return $"Divided {number} by 3 and divided {number} by 5";
                        Console.WriteLine($"Divided {number} by 3 and divided {number} by 5");
                    }
                }
                else
                {
                    //return "Invalid item";
                    Console.WriteLine("Invalid item");
                }
            }

        }

    }
    //this class separation of responsibilities ensure that each class has a single reason to change.
    public class FizzBuzzConsole
    {
        private readonly IFizzBuzzService _fizzBuzzService;

        public FizzBuzzConsole(IFizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        public void Run()
        {
            Console.WriteLine("Enter comma-separated values:");
            string input = Console.ReadLine();
            _fizzBuzzService.PrintFizzBuzz(input);
        }
    }
    class program
    {
        static void Main(string[] args)
        {
            var fizzBuzzService = FizzBuzzService.GetInstance();
            var fizzBuzzConsoleUI = new FizzBuzzConsole(fizzBuzzService);
            fizzBuzzConsoleUI.Run();
        }
    }
}