using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumCount
{
    class Program
    {
        static void Main(string[] args)
        {
            public static int StrangeSum(int[] inputArray)  
            {
                int sum = 0; //O(1)
                for (int i = 0; i < inputArray.Length; i++) //O(N+1)
                {
                    for (int j = 0; j < inputArray.Length; j++) //O(N^2+1)
                    {
                        for (int k = 0; k < inputArray.Length; k++) //O(N^3+1)
                        {
                            int y = 0; //O(2N^3+1)

                            if (j != 0) //O(3N^3+1)
                            {
                                y = k / j;
                            }

                            sum += inputArray[i] + i + k + j + y; //O(3N^3+2)
                        }
                    }
                }

                return sum; //O(3N^3+3)
            }

            //Итого: O(N^3).
        }
    }
}
