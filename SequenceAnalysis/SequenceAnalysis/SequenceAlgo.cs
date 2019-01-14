using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequenceAnalysis
{
    struct CharacterInfo
    {
        public String m_characterName;
        public int m_count;
    }


    class SequenceAlgo
    {
        // Time complexity is Big O(n+52)== O(n) in this case where n the number of character in string
        // THis function can perform same mechanism on Upper case and lower case
        // as well as Ascending and descending order.
        public String FindCharacterInOrder(String inputStr, bool isAcending, bool considerupperCase)
        {
            CharacterInfo[] arrayChar = new CharacterInfo[26];
            for (int index = 0; index < arrayChar.Length; index++)
            {
                arrayChar[index].m_characterName = "0";
                arrayChar[index].m_count = 0;
            }
            int start = 0;
            int end = 0;
            if (considerupperCase)
            {
                start = 'A';
                end = 'Z';
            }
            else
            {
                start = 'a';
                end = 'z';
            }
            // Read each character to a Alphabet Array of 26 characters and 
            // adding those.
            foreach (char value in inputStr)
            {
                if (value >= start && value <= end)
                {
                    arrayChar[value - start].m_characterName = value.ToString();
                    arrayChar[value - start].m_count++;
                }
            }

            String outputString = "";
            // Constructing the Character output
            if (isAcending)
            {
                foreach (CharacterInfo info in arrayChar)
                {
                    for (int idx = 0; idx < info.m_count; idx++)
                    {
                        outputString += info.m_characterName;
                    }
                }
            }
            else
            {
                for (int index = arrayChar.Length-1; index > 0; index--)
                {
                    for (int idx = 0; idx < arrayChar[index].m_count; idx++)
                    {
                        outputString += arrayChar[index].m_characterName;
                    }
                }
            }
            return outputString;
        }
    }
}
