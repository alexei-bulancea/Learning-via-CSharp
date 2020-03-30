using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.LeetCode_Medium
{
    class _3Sum
    {
        public _3Sum()
        {
            var input = new int[] { -1, 0, 1, 2, -1, -4 };

            var result = ThreeSum(input);


            Console.ReadKey();
        }


        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length-2; j++)
                {
                    for (int k = j+1; k < nums.Length -1; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            var newList = new List<int>() { nums[i], nums[j], nums[k] };
                            var newList1 = new List<int>() {  nums[j], nums[i], nums[k] };
                            var newList2 = new List<int>() { nums[i], nums[k], nums[j] };
                            var newList3 = new List<int>() {  nums[k], nums[i], nums[j] };
                            var newList4 = new List<int>() {  nums[k],  nums[j], nums[i]};
                            var newList5 = new List<int>() {   nums[j], nums[k], nums[i]};


                            result.Add(newList);

                        }
                    }
                }
            }

            return result;
        }
    }


}
