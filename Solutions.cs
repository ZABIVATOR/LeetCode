using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Solutions
    {
        static public int Task2870_MinOperations(int[] nums)//2870. Minimum Number of Operations to Make Array Empty 
        /*
        You are given a 0-indexed array nums consisting of positive integers.
        There are two types of operations that you can apply on the array any number of times:

            *Choose two elements with equal values and delete them from the array.
            *Choose three elements with equal values and delete them from the array.
        Return the minimum number of operations required to make the array empty, or -1 if it is not possible
        */

        {
            int res = 0;
            Dictionary<int, int> heap = new();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!heap.ContainsKey(nums[i])) heap.Add(nums[i], 0);
                heap[nums[i]]++;
            }
            foreach (var item in heap)
            {
                if (item.Value == 1) return -1;
                if (item.Value % 3 == 0)
                {
                    res += item.Value / 3;
                }
                else
                {
                    res += item.Value / 3 + 1;
                }
            }

            return res;
        }
    }
}
