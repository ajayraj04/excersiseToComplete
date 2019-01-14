using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SumOfMultiple;
using SequenceAnalysis;

namespace Runner
{
    class Program
    {
        static void InputForNumberProblem()
        {
            String number;
            Console.Write("Enter input Numbers : ");
            number = Console.ReadLine();
            List<ulong> numberArr = new List<ulong>();
            ulong value = 0 ;
            while( true )
            {
                if (ulong.TryParse(number, out value))
                {
                    numberArr.Add(value);
                }
                else
                {
                    Console.Write("Last Input is not a ulong");
                }
                Console.Write("Press Q to Stop Getting Input \n Else Enter Number:");
                number = Console.ReadLine();
                if( 0 == number.CompareTo("Q"))
                {
                    break;
                }
            }
            Console.Write("Input the Limit:");
            String limitstr= Console.ReadLine();
            ulong limit = 0;
            if (!ulong.TryParse(limitstr, out limit))
            {
                Console.Write("Last Input is not a ulong for Limit");
            }
           
            SumofMultiple sumMultiple = new SumofMultiple();
            ulong output = 0;
            output = sumMultiple.compute(limit, numberArr.ToArray());
           
            Console.Write("Output For the Problem:{0}\n\n", output);
        }


        static void InputForSequenceProblem()
        {
            String inputStr;
            Console.Write("Input String: ");
            inputStr = Console.ReadLine();
            Console.Write("UPPER case Press Key U Else Small Letter  case Press S:");
            String input = Console.ReadLine();
            bool isUpper = false;
            if( 0 == input.CompareTo("U"))
            {
                isUpper = true;
            }
            Console.Write("Ascending Order Press A and Else Descending Order Press D:");
            input = Console.ReadLine();
            bool isAscending = false;
            if( 0 == input.CompareTo("A"))
            {
                isAscending = true;
            }
            SequenceAnalyzer sequence = new SequenceAnalyzer();
            String outputStr = "";
            if (isAscending && isUpper)
            {
                sequence.FindUpperCharInAscendingOrder(inputStr, ref outputStr);
            }
            else if( !isAscending && isUpper)
            {
                sequence.FindUpperCharInDescendingOrder(inputStr, ref outputStr);
            }
            Console.Write("Output:{0}", outputStr);
        }


        static void Main(string[] args)
        {
            while (true)
            {
                String testString;
                Console.Write(" \n\nEnter 1 or 2 or 3 or 4:\n1 - Numeric Number Problem \n" +
                               "2 - Sequence String Program \n" +
                               "3 - TestRunner With PreData set NumericProblem \n" +
                               "4 - TestRunner with PreData set SequenceProblem \n" +
                               "5 - TestRunner with RandomData set for Stress NumericProblem \n" +
                               "6 - TestRunner with RandomData set for Sequence Problem \n"+
                               "7 - TestRunner with PreData set for NumericProblem on Multiple Threads \n" +
                               " \n Enter Choice: ");
                testString = Console.ReadLine();
                SequenceAnalyzerTest sequenceAnalyzerTest = new SequenceAnalyzerTest();
                SumOfMultipleTest sumOfMultipleTest = new SumOfMultipleTest();
                if (0 == testString.CompareTo("1"))
                {
                    InputForNumberProblem();
                }
                else if (0 == testString.CompareTo("2"))
                {
                    InputForSequenceProblem();
                }
                else if( 0 == testString.CompareTo("3"))
                {
                    sumOfMultipleTest.SumofMultipleTest();
                }
                else if (0 == testString.CompareTo("4"))
                {
                    sequenceAnalyzerTest.TestFindUpperCharInAscendingOrder();
                }
                else if (0 == testString.CompareTo("5"))
                {
                    sumOfMultipleTest.SumofMultipleTestStress();
                }
                else if (0 == testString.CompareTo("6"))
                {
                    sequenceAnalyzerTest.TestFindUpperCharInAscendingOrderStress();
                }
                else if (0 == testString.CompareTo("7"))
                {
                    sumOfMultipleTest.SumofMultipleinThreadTest();
                }
                else
                {
                    Console.Write("Invalid Input, so Quiting");
                    return;
                }
                testString = "";
            }
        }
    }
}
