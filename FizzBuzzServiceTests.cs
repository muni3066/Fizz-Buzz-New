using FizzBuzzApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzProgram
{
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        private IFizzBuzzService _fizzBuzzService;

        [SetUp]
        public void Setup()
        {
            _fizzBuzzService = FizzBuzzService.GetInstance();
        }

        [TestCase("1", ExpectedResult = "Divided 1 by 3 and divided 1 by 5")]
        [TestCase("3", ExpectedResult = "Fizz")]
        [TestCase("5", ExpectedResult = "Buzz")]
        [TestCase("15", ExpectedResult = "FizzBuzz")]
        [TestCase("A", ExpectedResult = "Invalid item")]
        [TestCase("23", ExpectedResult = "Divided 23 by 3 and divided 23 by 5")]
        public void FizzBuzzService_GetFizzBuzzResult_ReturnsExpectedResult(string input)
        {
            _fizzBuzzService.PrintFizzBuzz(input);
        }

    }
}
