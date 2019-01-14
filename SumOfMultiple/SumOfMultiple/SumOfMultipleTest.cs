using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumOfMultiple
{
    public class SumOfMultipleTest
    {
        public void SumofMultipleTest()
        {
            List<ulong> numberArr = new List<ulong>();
            numberArr.Add(3);
            numberArr.Add(5);
            //Idea is to Create Golden Data set and compare.
            ulong[] output = { 14, 14, 23, 33, 33, 45 };
            SumofMultiple sumMultiple = new SumofMultiple();
            for (ulong idx = 8; idx < 13; idx++)
            {
                ulong outvalue = sumMultiple.compute(idx, numberArr.ToArray());
                if (outvalue != output[idx - 8])
                {
                    Console.Write("FAILED, value is coming wrong: idx={0}", idx);
                    return;
                }
            }

            Console.Write("Test Numeric Passed");
        }


        public void SumofMultipleinThreadTest()
        {
            List<ulong> numberArr = new List<ulong>();
            numberArr.Add(3);
            numberArr.Add(5);
            numberArr.Add(7);
            numberArr.Add(12);
            numberArr.Add(16);
            numberArr.Add(21);
            numberArr.Add(31);
            //Idea is to Create Golden Data set and compare.
            ulong[] output = { 1090, 1139, 1189, 1240, 1240, 1240, 1294 };
            SumofMultiple sumMultiple = new SumofMultiple();
            int index = 0;
            for (ulong idx = 49; idx < 56; idx++)
            {
                ulong singlethreadval = sumMultiple.compute(idx, numberArr.ToArray());
                ulong multithreadval = sumMultiple.computeinThreads(idx, numberArr.ToArray(), 3);
                if(singlethreadval != multithreadval)
                {
                    Console.Write("Test Numeric Failed");
                }
                if (multithreadval != output[index++])
                {
                    Console.Write("FAILED, value is coming wrong: idx={0}", idx);
                    return;
                }
                Console.Write("Sum of Multiples:{0}, {1}\n", singlethreadval, multithreadval);
            }

            Console.Write("Test Numeric Passed");
        }

        private Random getrandom = new Random();

        int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        public void SumofMultipleTestStress()
        {
            SumofMultiple sumMultiple = new SumofMultiple();
            List<ulong> numberArr = new List<ulong>();
            //Random Stress Test.
            for (int counter = 0; counter < 1000; counter++)
            {
                ulong limit = (ulong)GetRandomNumber(0, int.MaxValue);
                Console.Write("Limit:{0}\n\n", limit);
                int length = (int)(limit % 115);
                for (int index = 1; index < length; index++)
                {
                    numberArr.Add((ulong)index);
                }

                ulong output1 = sumMultiple.compute(limit, numberArr.ToArray());
                Console.Write("\nOutput:{0}\n\n", output1);
            }
            Console.Write("Test Numeric Stress Passed");
        }
    }
}
