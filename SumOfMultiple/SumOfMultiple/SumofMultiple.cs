using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumOfMultiple
{
    
    public class SumofMultiple
    {
        public ulong compute(ulong limit, ulong[] numbers)
        {
            NumericCompute algo = new NumericCompute();
            foreach (ulong number in numbers)
            {
                if (number >= limit)
                {
                    System.Console.Write("Numbers in range bigger than end {0}\n", numbers);
                    return 0;
                }
            }
            if( (ulong)numbers.Length >= limit )
            {
                System.Console.Write("More numbers than limit. {0}\n", numbers);
                return 0;
            }
            return algo.computeMultiples( limit, numbers);
        }


        public ulong computeinThreads(ulong limit, ulong[] numbers, int threads)
        {
            NumericCompute algo = new NumericCompute();
            foreach (ulong number in numbers)
            {
                if (number >= limit)
                {
                    System.Console.Write("Numbers in range bigger than end {0}\n", numbers);
                    return 0;
                }
            }
            if ((ulong)numbers.Length >= limit)
            {
                System.Console.Write("More numbers than limit. {0}\n", numbers);
                return 0;
            }
            return algo.computeMultiples(limit, numbers);
        }


    }
}
