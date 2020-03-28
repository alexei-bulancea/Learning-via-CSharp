using System;

/// <summary>
/// 11. Container With Most Water
/// Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai).
/// n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, 
/// which together with x-axis forms a container, such that the container contains the most water.
/// </summary>

namespace Learning.LeetCode_Medium
{
    class ContainerWithMostWater
    {
        public ContainerWithMostWater()
        {
            var input = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

            var result = MaxArea(input);

            Console.WriteLine("The most are is " + result);
            Console.ReadKey();
        }

        public int MaxArea(int[] height)
        {
            var maxArea = 0;
            for (int i = 0; i < height.Length; i++)
            {
                for (int j = i; j < height.Length; j++)
                {
                    var lowestHeight = Math.Min(height[i], height[j]);

                    maxArea = Math.Max(lowestHeight * (j - i), maxArea);
                }
            }

            return maxArea;
        }
    }
}
