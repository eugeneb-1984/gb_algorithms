using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp
{
    class Program
    {
        public class TestCase
        {
            public int N { get; set; }
            public string ExpectedResult { get; set; }
            public Exception ExpectedEx { get; set; }
        }
        static string CheckIfNumberIsSimple (int n)
        {
            int d = 0;
            int i = 2;
            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                }
                i++;
            }
            string result = (d == 0 ? "Простое" : "Не простое");
            return result;
        }

        static void RunTest (TestCase test)
        {
            try
            {
                var ActualResult = CheckIfNumberIsSimple(test.N);
                Console.WriteLine((ActualResult == test.ExpectedResult) ? "PASSED" : "FAILED");
            }
            catch (Exception ex)
            {
                Console.WriteLine(test.ExpectedEx == ex ? "PASSED: valid exception" : $"FAILED: Invalid exception:{ex.Message}");
            }
        }
        static void Main(string[] args)
        {
            var testCase1 = new TestCase() // POSITIVE
            {
                N = 123,
                ExpectedResult = "Не простое",
                ExpectedEx = null,
            };

            var testCase2 = new TestCase() // POSITIVE
            {
                N = 17,
                ExpectedResult = "Простое",
                ExpectedEx = null,
            };

            var testCase3 = new TestCase() //NEGATIVE
            {
                N = 19,
                ExpectedResult = "Не простое",
                ExpectedEx = null,
            };

            RunTest(testCase1);
            RunTest(testCase2);
            RunTest(testCase3);
            Console.ReadKey();
        }

    }
}
