using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 16. 3Sum Closest
/// Given an array nums of n integers and an integer target, find three integers in nums such that the sum is closest to target. Return the sum of the three integers. 
/// You may assume that each input would have exactly one solution.
/// </summary>

namespace Learning.LeetCode_Medium
{
    class _3SumClosest
    {
        public _3SumClosest()
        {
            var input = new int[] {-1,2 ,1,-4};
            var target = 1;
            var result = ThreeSum(input, target);

            Console.WriteLine(result);
            Console.ReadKey();
        }


        public int ThreeSum(int[] nums, int target)
        {
            int closestValue = nums[0] + nums[1] + nums[2];
            bool sign = target >= 0;
            for (int i = 0; i < nums.Length-2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        var currentResult = nums[i] + nums[j] + nums[k];

                        if (currentResult - target == 0)
                        {
                            return currentResult;
                        }

                            if (Math.Abs(currentResult -target ) < Math.Abs(closestValue - target))
                            {
                                closestValue = currentResult;
                            }

                    }
                }
            }

            return closestValue;
        }
    }
}
