using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciCycle
{
    class Program
    {
        static int countFibonacci(int x, int y, int length) //вычисляем число Фибоначчи
        {
            List<int> fibList = new List<int> { x, y };

            while (fibList.Count < length)
            {
                int fibPrev1 = fibList[fibList.Count - 1];
                int fibPrev2 = fibList[fibList.Count - 2];
                fibList.Add(fibPrev1 + fibPrev2);
            }
            foreach (int item in fibList)
            {
                Console.WriteLine($" Seq number: {fibList.IndexOf(item) + 1}, value: {item}");
            }
            int result = fibList[fibList.Count - 1];
            return result;
        }
        public class FibTestCase // конструктор тест-кейсов для проверки countFibonacci
        {
            public int FibFirst = 0;
            public int FibSecond = 1;
            public int Count = 0;
            public int FibTargetSeqNumber { set; get; }
            public int FibTargetExpectedValue { get; set; }
            public Exception ExpectedEx { get; set; }
        }

        static void validateCountFibonacci(FibTestCase fibTestCase) //запускаем тест-кейс для проверки countFibonnaci
        {
            try
            {
                int fibTargetActualValue = countFibonacci(fibTestCase.FibFirst, fibTestCase.FibSecond, fibTestCase.FibTargetSeqNumber);
                Console.WriteLine(fibTargetActualValue == fibTestCase.FibTargetExpectedValue ? "Test PASSED" : $"Test FAILED. \n Expected: {fibTestCase.FibTargetExpectedValue} \n Actual: {fibTargetActualValue}");
            }
            catch (Exception ex)
            {
                //               Console.WriteLine(fibTestCase.ExpectedEx == ex ? "PASSED: valid exception" : $"FAILED: Invalid exception. \n Expected: {fibTestCase.ExpectedEx.Message} \n Actual: {ex.Message}");
                Console.WriteLine(ex.GetType());
                Console.WriteLine(ex.Message);
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