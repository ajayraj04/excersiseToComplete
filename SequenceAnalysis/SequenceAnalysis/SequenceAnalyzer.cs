using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequenceAnalysis
{
    public class SequenceAnalyzer
    {

        public int FindUpperCharInAscendingOrder(String inputStr, ref String outputStr)
        {
            // 100 MB value should be from config, which needs to be changed based on the config
            if (inputStr.Length > 100 * 1024 * 1024)
            {
                // Log error.
                return -1;
            }
            if( inputStr.Length == 0)
            {
                // Log error
                return -1;
            }
            SequenceAlgo algo = new SequenceAlgo();
            outputStr = algo.FindCharacterInOrder(inputStr, true, true);
            return 0;
        }



        public int FindUpperCharInDescendingOrder(String inputStr, ref String outputStr)
        {
            // 100 MB value should be from config, which needs to be changed based on the config
            if (inputStr.Length > 100 * 1024 * 1024)
            {
                // Log error.
                return -1;
            }
            if (inputStr.Length == 0)
            {
                // Log error
                return -1;
            }
            SequenceAlgo algo = new SequenceAlgo();
            outputStr = algo.FindCharacterInOrder(inputStr, false, true);
            return 0;
        }
    }
}
