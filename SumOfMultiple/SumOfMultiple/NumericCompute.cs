using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumOfMultiple
{
    class NumericCompute
    {
        // Algorithm is having a Big of notation of O(n), where is number of multiples to consider.
        // Say there is 3 and 5 then 0(2) is hte time complexity.
        public ulong computeMultiples( ulong limit, ulong[] number)
        {
            ulong sum = 0;
            for (int numberidx = 0; numberidx < number.Length; numberidx++)
            {
                if (number[numberidx] != 0)
                {
                    ulong multipleCount = (limit - 1) / number[numberidx];
                    sum += number[numberidx] * (multipleCount * (multipleCount + 1) / 2);
                }
                else
                {
                    System.Console.Write("Invalid Input, one of hte input is zero.\n");
                    return 0;
                }
            }
            return sum;
        }

        public ulong computeMultiples(int start, int end, ulong limit, ulong[] number)
        {
            ulong sum = 0;
            for (int numberidx = start; numberidx < end; numberidx++)
            {
                if (number[numberidx] != 0)
                {
                    ulong multipleCount = (limit - 1) / number[numberidx];
                    sum += number[numberidx] * (multipleCount * (multipleCount + 1) / 2);
                }
                else
                {
                    System.Console.Write("Invalid Input, one of hte input is zero.\n");
                    return 0;
                }
            }
            return sum;
        }
    }
}
