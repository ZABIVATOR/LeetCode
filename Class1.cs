using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Solution
    {
        static public int MinOperations(int[] nums)//2870. Minimum Number of Operations to Make Array Empty
        {
            int res = 0;
            Dictionary<int, int> heap = new Dictionary<int, int>();

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
