using System;
using System.Text;

/// <summary>
/// 8. String to Integer (atoi)
/// 
/// Implement atoi which converts a string to an integer.
///The function first discards as many whitespace characters as necessary until the first non-whitespace character is found.Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, and interprets them as a numerical value.
///The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.
///If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.
///If no valid conversion could be performed, a zero value is returned.
/// </summary>
/// 
namespace Learning.LeetCode_Medium
{
   public class StringToInteger
    {

        public StringToInteger()
        {
            var str = "-5-";
            var result = MyAtoi(str);

            Console.WriteLine("Starting string is : "+ str);
            Console.WriteLine("Result integer is : " + result);

            Console.ReadKey();
        }

        //This is trash, need to rewrite this using smth like regex approach
        public int MyAtoi(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            var res = new StringBuilder();
            bool negative = false;
            bool numberStarted = false;
            var strInBytes = Encoding.ASCII.GetBytes(str);


            for (int i = 0; i < strInBytes.Length; i++)
            {
                if (numberStarted)
                {
                    if (strInBytes[i] >= 48 && strInBytes[i] <= 57)
                    {
                        res.Append(strInBytes[i] % 48);
                    }
                    else
                    {
                        if (strInBytes[i-1] == 45 || strInBytes[i-1] == 43)
                            return 0;

                        break;
                    }
                }
                else
                {
                    if (strInBytes[i] == 32) //WhiteSpace
                    {
                        continue;
                    }
                    else if (strInBytes[i] == 45 || strInBytes[i] == 43) // minus/ plus sign 
                    {
                        negative = strInBytes[i] % 45 != 0 ? false : true;
                        numberStarted = true;
                    }
                    else if (strInBytes[i] >= 48 && strInBytes[i] <= 57)
                    {
                        numberStarted = true;
                        res.Append(strInBytes[i] % 48);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (res.Length == 0)
                return 0;
            double intResult;

            intResult = Double.Parse(res.ToString());
            if (negative)
                intResult *= -1;

            if (intResult > int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (intResult < int.MinValue)
            {
                return int.MinValue;
            }

            return (int)intResult;

        }
    }
}
