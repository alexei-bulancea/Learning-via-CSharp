using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 17. Letter Combinations of a Phone Number
/// Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.
///A mapping of digit to letters(just like on the telephone buttons) is given below.Note that 1 does not map to any letters.
/// </summary>
namespace Learning.LeetCode_Medium
{

    class PhoneNumberLetterCombination
    {
        public PhoneNumberLetterCombination()
        {
            var input = "234";

            var result = LetterCombinations(input);

            Console.WriteLine();
        }

        Dictionary<char, string> vss = new Dictionary<char, string>() {
            {'2', "a,b,c" },
            {'3', "d,e,f" },
            {'4', "g,h,i" },
            {'5', "j,k,l" },
            {'6', "m,n,o" },
            {'7', "p,q,r,s" },
            {'8', "t,u,v" },
            {'9', "w,x,y,z" },
        };

        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0)
                return new List<string>();

            var result = new List<string>();
            var temp = new List<List<string>>();
            for (int i = 0; i < digits.Length; i++)
            {
                var digList = vss[digits[i]].Split(',').ToList();
                temp.Add(digList);
            }
            AddChar(temp, 0, new StringBuilder());

            return res;
        }
        List<String> res = new List<String>();
        public void AddChar(List<List<string>> ss, int pos , StringBuilder currString)
        {
            if(pos > ss.Count - 1 )
            {
                res.Add(currString.ToString());
                return;
            }
            for (int i = 0; i < ss[pos].Count; i++)
            {
                currString.Append(ss[pos][i]);
                AddChar(ss, pos + 1, currString);
                currString.Remove(currString.Length - 1, 1);
            }

        }
    }
}
