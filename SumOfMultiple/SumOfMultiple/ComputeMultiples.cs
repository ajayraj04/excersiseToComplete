using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SumOfMultiple
{

    class ThreadExecutor
    {
        // State information used in the task.
        private int m_start;
        private int m_end;
        private ulong m_limit;
        private ulong[] m_numbers;
        private ulong m_result;
        // The constructor obtains the state information.
        public ThreadExecutor(int start, int end, ulong limit, ulong[] numbers)
        {
            m_start = start;
            m_end = end;
            m_limit = limit;
            m_numbers = numbers;
            m_result = 0;

        }

        // The thread procedure performs the task, such as formatting
        // and printing a document.
        public void execute()
        {
            NumericCompute algo = new NumericCompute();
            System.Console.Write("\nStart and End:{0}, {1}\n", m_start, m_end);
            m_result = algo.computeMultiples(m_start, m_end, m_limit, m_numbers);
        }

        public ulong getResult()
        {
            System.Console.Write("\nResult:{0}\n", m_result);
            return m_result;
        }
    }


    public class ComputeMultiples
    {

        public ComputeMultiples()
        {
            m_threadcount = 1;
        }

        // Performance increases till logical core of threads.
        // Using more than logical thread will decreased the performance.
        public void setMaxThread(int threadCount)
        {
            m_threadcount = threadCount;
            System.Console.Write("Thread Count Set:{0}\n", m_threadcount);
        }

      
        public ulong computeNumeric(ulong limit, ulong[] numbers)
        {
            if (m_threadcount == 1)
            {
                // Single Threaded.
                NumericCompute algo = new NumericCompute();
                foreach (ulong number in numbers)
                {
                    if (number >= limit)
                    {
                        System.Console.Write("Numbers in range bigger than end {0}\n", numbers);
                        return 0;
                    }
                }
                return algo.computeMultiples( limit, numbers);
            }
            else
            {
                // Multi threaded
                threadSplitter(limit, numbers);
                ulong output = 0;
                foreach (ThreadExecutor executor in algothreads)
                {
                    output += executor.getResult();
                }
                return output;
            }
        }

        // Split the task based on the t
        private void threadSplitter(ulong max, ulong[] number)
        {

            int cIndex = 0;
            if (number.Length > m_threadcount * 2)
            {
              cIndex =  number.Length / m_threadcount;
            }
            List<Thread> threads = new List<Thread>();
            for (int index = 0; index < number.Length; index += cIndex)
            {
                int endIndex = index + cIndex;
                if (number.Length < endIndex)
                {
                    endIndex = number.Length;
                }
                ThreadExecutor algoThread = new ThreadExecutor(index, endIndex, max, number);
                Thread thread = new Thread(new ThreadStart(algoThread.execute));
                threads.Add(thread);
                algothreads.Add(algoThread);
                thread.Start();

            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
        }

        private int m_threadcount;
        private List<ThreadExecutor> algothreads = new List<ThreadExecutor>();
    }
}
