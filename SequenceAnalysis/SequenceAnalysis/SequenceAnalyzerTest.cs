using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequenceAnalysis
{

    public class SequenceAnalyzerTest
    {

        public int TestFindUpperCharInAscendingOrder()
        {
            SequenceAnalyzer sequence = new SequenceAnalyzer();
            String output = "";
            String[] inputseq = { "Input is A BeaST", "Easy Job Is My NaME", "easy to manage", "SEA MAN" };
            String[] outputSeq = { "ABIST", "EEIJMMN", "", "AAEMNS" };
            int index = 0;
            foreach (String input in inputseq)
            {
                Console.Write("\nInput:{0}", input);
                sequence.FindUpperCharInAscendingOrder(input, ref output);
                Console.Write("Output:{0}", output);
                if (0 != output.CompareTo(outputSeq[index++]))
                {
                    Console.Write("Test Failed\n");
                }
                else
                {
                    Console.Write("Test Passed\n");
                }
            }
            return 0;
        }


        private Random random = new Random();
        string generateString(int length)
        {
            const string chars = "ABabCDcdEFefGHghIJijKLklMNmnOPopQRqrSTstUVuvWXwxYZyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private Random getrandom = new Random();

        int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }


        public int TestFindUpperCharInAscendingOrderStress()
        {
            SequenceAnalyzer sequence = new SequenceAnalyzer();
            Console.Write("\n\nTest Sequence for Sequence Problem\n\n");
            for (int i = 0; i < 1000; i++)
            {
                int length = GetRandomNumber(0, 1024);
                String strInput = generateString(length);

                String outputStr = "";
                Console.Write("\n\nInput:{0}", strInput);
                sequence.FindUpperCharInAscendingOrder(strInput, ref outputStr);
                Console.Write("\n\nOutput:{0}", outputStr);
            }
            return 0;
        }
    }
}
