using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.LeetCode_Medium
{
    class ZigZag_Conversion
    {
        char[,] str;

        public ZigZag_Conversion()
        {
            var str = "PAHNAPLSIIGYIR";
            var result = Convert(str, 3);

            Console.WriteLine("ZigZagged string : " + str);
            Console.WriteLine("Converted string : " + result);

            Console.ReadKey();
        }

        public string Convert(String s, int numRows)
        {
            var numCols = (s.Length + numRows - 1 ) / numRows; // Doesn't work properly in AB  1 case
            str = new char[4, numCols];

            var step = numRows - 1 == 0 ? 1 : numRows - 1;
            int count = 0;
            for (int i = 0; i < numCols; i++)
            {
                if (i % step == 0)
                {
                    for (int j = 0; j < numRows; j++)
                    {
                        if (count >= s.Length)
                            break;
                        str[j, i] = s[count++];
                    }
                }
                else
                {
                    if (count >= s.Length)
                        break;

                    var j = numRows - (i % step) - 1;
                    str[j, i] = s[count++];
                }
            }
           var result = ReadInZigZag();
            Show();
            return result;
        }

        private String ReadInZigZag()
        {
            var strBuilder = new StringBuilder();
            for (int i = 0; i < str.GetLength(0); i++)
            {
                for (int j = 0; j < str.GetLength(1); j++)
                {
                    if (!Equals(str[i, j], char.MinValue))
                        strBuilder.Append(str[i, j]);
                }
            }
            return strBuilder.ToString();
        }

        public void Show()
        {
            for (int i = 0; i < str.GetLength(0); i++)
            {
                for (int j = 0; j < str.GetLength(1); j++)
                {
                    Console.Write(str[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
