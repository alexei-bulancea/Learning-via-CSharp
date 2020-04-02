using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// <summary>
/// 18. 4Sum
/// Given an array nums of n integers and an integer target, are there elements a, b, c, and d in nums such that a + b + c + d = target?
/// Find all unique quadruplets in the array which gives the sum of target.
/// </summary>
/// <Credits>
/// Solution was found over here - https://www.programcreek.com/2013/02/leetcode-4sum-java/
/// </Credits>
namespace Learning.LeetCode_Medium
{
    class _4Sum
    {

        public _4Sum()
        {
            var input = new int[] { 1, 0, -1, 0, -2, 2 };
            var target = 0;

            var result = FourSum(input, target);

            foreach (var list in result)
            {
                foreach (var num in list)
                {
                    Console.Write(num + ", ");

                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var res = new List<IList<int>>();

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i != 0 && nums[i] == nums[i - 1])
                    continue;
                for (int j = i + 1; j < nums.Length-2; j++)
                {
                    if (j != i+1 && nums[j] == nums[j - 1])
                        continue;
                    var k = j + 1;
                    var l = nums.Length - 1;

                    while(k < l)
                    {
                        var summ = nums[i] + nums[j] + nums[k] + nums[l];
                        if (summ == target)
                        {
                            var tempRes = new List<int>
                            {
                                nums[i],
                                nums[j],
                                nums[k],
                                nums[l]
                            };
                            res.Add(tempRes);
                            k++;
                            l--;
                            while (l > k && nums[l + 1] == nums[l])
                            {
                                l--;
                            }
                            while (k < l && nums[k] == nums[k - 1])
                            {
                                k++;
                            }
                        }
                        if(summ < target)
                        {
                            k++;
                        }
                        else if (summ > target)
                        {
                            l--;
                        }

                    }
                }
            }



            return  res;
        }

    }
}
