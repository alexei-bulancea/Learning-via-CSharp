using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// 3. Longest Substring Without Repeating Characters
/// 
/// Given a string, find the length of the longest substring without repeating characters.
/// </summary>
namespace Learning.LeetCode_Medium
{

    class LongestSubstringWithoutRepeatingCharacters
    {
        public LongestSubstringWithoutRepeatingCharacters()
        {
            var testString = "asljlj";

            var result = LengthOfLongestSubstring(testString);

            Console.WriteLine("The length of the longest non repeating substring in string : "+ testString + " is " + result);
            Console.ReadKey();
        }

        public int LengthOfLongestSubstring(string s)
        {
            List<char> nonRepeatingSequence = new List<char>();
            int overallMax = 0;
            int maxLength = 0;
            for (int j = 0; j < s.Length; j++)
            {
                nonRepeatingSequence.Clear();

                for (int i = j; i < s.Length; i++)
                {
                    if( !nonRepeatingSequence.Contains(s[i]))
                    {
                        nonRepeatingSequence.Add(s[i]);

                        maxLength = nonRepeatingSequence.Count > maxLength ? nonRepeatingSequence.Count : maxLength;

                    }
                    else
                    {
                        maxLength = nonRepeatingSequence.Count > maxLength ? nonRepeatingSequence.Count : maxLength;
                        break;
                    }
                }

                overallMax = overallMax > maxLength ? overallMax : maxLength;

            }

            return overallMax; 
        }
    }
}
