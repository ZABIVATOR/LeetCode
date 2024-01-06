using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal interface IDailySolutions: ISorting,ArrayandString
    {
        static int FindLastCompletedJob(ref int[] startTime,ref int[] endTime, int currentIndex)
        {
            int low = 0;
            int high = currentIndex - 1;

            while (low <= high)
            {
                int mid = (high + low) / 2;
                if (endTime[mid] <= startTime[currentIndex])
                {
                    if (endTime[mid + 1] <= startTime[currentIndex])
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        return mid;
                    }
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }
        public static int Task1235_JobScheduling(int[] startTime, int[] endTime, int[] profit)//Maximum Profit in Job Scheduling same as task 300 + dihotomiya(binary search)
        {
            int n = profit.Length;
            int[] maxProfit = new int[n];//used for temp arr in sorting and for memorizing eachprofit max

            Sort3Arr_byFirst(ref endTime, ref startTime, ref profit);

            maxProfit[0] = profit[0];
            for (int cur = 1; cur < n; cur++)
            {
                maxProfit[cur] = Math.Max(maxProfit[cur - 1], profit[cur]);
                int lastjob = FindLastCompletedJob(ref startTime, ref endTime, cur);
                if(lastjob >= 0)
                {
                    maxProfit[cur] = Math.Max(maxProfit[cur], profit[cur] + maxProfit[lastjob]);
                }
            }

            return maxProfit.Max();
        }
        public static  int Task1235_JobScheduling_brootforce_notwork_bigruntime(int[] startTime, int[] endTime, int[] profit)//1235. Maximum Profit in Job Scheduling same as task 300
        {
            int n = profit.Length;
            int[] maxProfit = new int[n];//used for temp arr in sorting and for memorizing eachprofit max

            Sort3Arr_byFirst(ref startTime, ref endTime, ref profit);

            EquateFirstArrToSecond(ref maxProfit, profit);
            for (int cur = 0; cur < n; cur++)
            {
                int eachprofit = maxProfit[cur];
                for (int prev = 0; prev < cur; prev++)
                {
                    if (endTime[prev] <= startTime[cur])
                    {
                        if (maxProfit[prev] >eachprofit - profit[cur])
                        {
                            eachprofit = maxProfit[prev] + profit[cur];
                        }
                    }
                }
                maxProfit[cur] = eachprofit;

            }

            return maxProfit.Max();
        }

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

        static public int[] Task300_LengthOfLIS_dynamic(int[] nums)//300. Longest Increasing Subsequence, nado eshe ebanut' nlogn
        {
            int[] Subseq = new int[nums.Length];
            
            for (int i = 0; i < nums.Length; i++)
            {
                int count = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i] && count-1< Subseq[j])
                    {
                        count = Subseq[j]+1;
                    }
                }
                Subseq[i] = count;
                
            }
            return Subseq;
        }


    }
}
