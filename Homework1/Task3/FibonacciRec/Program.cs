using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciRec
{
    class Program
    {
         static int countFibonacci(int x, int y, int count, int length)
        {
            count++;
            int fibPrev2 = y;
            int fibTargetValue = x + y;
            Console.WriteLine($"next={fibTargetValue}, count={count}");
            if (count < length)
            {
                countFibonacci(fibPrev2, fibTargetValue, count, length);
            }
            int result = fibTargetValue;
            return result;
        }
        public class FibTestCase
        {
            public int FibFirst = 0;
            public int FibSecond = 1;
            public int Count = 0;
            public int FibTargetSeqNumber { set; get; }
            public int FibTargetExpectedValue { get; set; }
            public Exception ExpectedEx { get; set; }
        }

        static void validateCountFibonacci(FibTestCase fibTestCase)
        {
            try
            {
                int fibTargetActualValue = countFibonacci(fibTestCase.FibFirst, fibTestCase.FibSecond, fibTestCase.Count, fibTestCase.FibTargetSeqNumber);
                Console.WriteLine(fibTargetActualValue == fibTestCase.FibTargetExpectedValue ? "Test PASSED" : $"Test FAILED. \n Expected: {fibTestCase.FibTargetExpectedValue} \n Actual: {fibTargetActualValue}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(fibTestCase.ExpectedEx == ex ? "PASSED: valid exception" : $"FAILED: Invalid exception. \n Expected: {fibTestCase.ExpectedEx.Message} \n Actual: {ex.Message}");
            }

        }
        static void Main(string[] args)
        {
            var Case1 = new FibTestCase()
            {
                FibTargetSeqNumber = 20,
                FibTargetExpectedValue = 6765,
                ExpectedEx = null
            };

            validateCountFibonacci(Case1);
            Console.ReadKey();
        }
    }
}
