using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// 12. Integer to Roman
/// For example, two is written as II in Roman numeral, just two one's added together.
/// Twelve is written as, XII, which is simply X + II. 
/// The number twenty seven is written as XXVII, which is XX + V + II.
/// </summary>
namespace Learning.LeetCode_Medium
{
    class IntegerToRoman
    {
        public IntegerToRoman()
        {
            var input = 3999;

           var result = IntToRoman(input);
            Console.WriteLine("The Input is : " + input);
            Console.WriteLine("The result Roman number is : " + result.ToString()) ;
            Console.ReadKey();
        }

        Dictionary<int, string> map = new Dictionary<int, string>()
        {
            {1000, "M" },
            {900, "CM" },
            {500, "D" },
            {400, "CD" },
            {100, "C" },
            {90, "XC" },
            {50, "L" },
            {40, "XL" },
            {10, "X" },
            {9, "IX" },
            {5, "V" },
            {4, "IV" },
            {1, "I" },
        };

        public string IntToRoman(int num)
        {
            StringBuilder number = new StringBuilder();

            int[] aa = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40,10,9, 5, 4, 1 };
            int counter = 0;
            while (num != 0)
            {
                if (num < aa[counter]) counter++;

                else if (num - aa[counter] >= 0 )
                {
                    num -= aa[counter];
                    number.Append(map[aa[counter]]);

                }
            }
            return number.ToString();
            //if(num - 1000 >= 0)
            //{
            //    number.Append(Letters.M);
            //    IntToRoman(num - 1000);
            //}
            //else if(num - 500 >=0)
            //{
            //    number.Append(Letters.D);
            //    IntToRoman(num - 500);
            //}
            //else if (num - 100 >= 0)
            //{
            //    number.Append(Letters.C);
            //    IntToRoman(num - 100);
            //}
            //else if (num - 50 >= 0)
            //{
            //    number.Append(Letters.L);
            //    IntToRoman(num - 50);
            //}

            //else if (num - 10 >= 0)
            //{
            //    number.Append(Letters.X);
            //    IntToRoman(num - 10);
            //}
            //else if (num - 5 >= 0)
            //{
            //    number.Append(Letters.V);
            //    IntToRoman(num - 5);
            //}
            //else if (num - 1 >= 0)
            //{
            //    number.Append(Letters.I);
            //    IntToRoman(num - 1);
            //}
        }

        
    }
}
