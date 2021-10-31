using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciRec
{
    class Program
    {
         public static void countFibonacci(int x, int y, int count, int length, FibTestCase fibTest)
        {
            count++;
            int fibPrev = y;
            int fibLast = x + y;
            Console.WriteLine($"next={fibLast}, Seq Number={count}");
            if (count < length)
            {
                countFibonacci(fibPrev, fibLast, count, length, fibTest);
            }  
            else
            {
                fibTest.FibTargetActualValue = fibLast;
            }
        }
        public class FibTestCase
        {
            public int FibFirst = 0;
            public int FibSecond = 1;
            public int Count = 2;
            public int FibTargetSeqNumber { set; get; }
            public int FibTargetExpectedValue { get; set; }

            public int FibTargetActualValue { get; set; }
            public Exception ExpectedEx { get; set; }
        }

        static void validateCountFibonacci(FibTestCase fibTestCase)
        {
            try
            {
                countFibonacci(fibTestCase.FibFirst, fibTestCase.FibSecond, fibTestCase.Count, fibTestCase.FibTargetSeqNumber, fibTestCase);
                Console.WriteLine(fibTestCase.FibTargetActualValue == fibTestCase.FibTargetExpectedValue ? "Test PASSED" : $"Test FAILED. \n Expected: {fibTestCase.FibTargetExpectedValue} \n Actual: {fibTestCase.FibTargetActualValue}");
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
                FibTargetExpectedValue = 4181,
                ExpectedEx = null
            };

            var Case2 = new FibTestCase()
            {
                FibTargetSeqNumber = 40,
                FibTargetExpectedValue = 63245986,
                ExpectedEx = null
            };

            var Case3 = new FibTestCase()
            {
                FibTargetSeqNumber = 30,
                FibTargetExpectedValue = 514229,
                ExpectedEx = null
            };

            validateCountFibonacci(Case1);
            validateCountFibonacci(Case2);
            validateCountFibonacci(Case3);
            Console.ReadKey();
        }
    }
}
