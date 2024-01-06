using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal interface IDailySolutions: ISorting
    {
        static private int FindLastCompletedJob(ref int[] startTime,ref int[] endTime,ref int[] profit, int currentIndex)
        {
            int low = 0;
            int high = currentIndex - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
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
                int lastjob = FindLastCompletedJob(ref startTime, ref endTime, ref profit, cur);
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

        static public int Task215_FindKthLargest(int[] nums, int k) //lol idk sort bc i can
        {
            Array.Sort(nums);
            return (nums[^k]);
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


        static public int[] Task75_SortColors(int[] nums)
        {
            int red = 0;
            int green = 0;
            int blue = 0;
            foreach (int i in nums)
            {
                switch (i)
                {
                    case 0:
                        red++;
                        break;
                    case 1:
                        green++;
                        break;
                    case 2:
                        blue++;
                        break;
                }
            }
            for (int i = 0; i < red; i++)
            {
                nums[i] = 0;
            }
            for (int i = red; i < red + green; i++)
            {
                nums[i] = 1;
            }
            for (int i = red + green; i < red + green + blue; i++)
            {
                nums[i] = 2;
            }
            return nums;
        }

        static public IList<IList<int>> Task1200_MinimumAbsoluteDifference_brootforce(int[] arr)//straight
        {
            Array.Sort(arr);
            IList<IList<int>> res = new List<IList<int>>();
            int n = arr.Length;
            int minimalminimaldifference = int.MaxValue;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (Math.Abs(arr[i] - arr[j]) < minimalminimaldifference)
                    {
                        minimalminimaldifference = Math.Abs(arr[i] - arr[j]);
                    }
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (Math.Abs(arr[i] - arr[j]) == minimalminimaldifference)
                    {
                        res.Add(new int[] { arr[i], arr[j] });
                    }
                }
            }

            return res;
        }

        static public IList<IList<int>> Task1200_MinimumAbsoluteDifference(int[] arr)//sort optimized
        {
            Array.Sort(arr);
            IList<IList<int>> result = new List<IList<int>>();
            int minDiff = int.MaxValue;
            for (int i = 1; i < arr.Length; i++)
            {
                int currentDiff = arr[i] - arr[i - 1];
                if (currentDiff < minDiff)
                {
                    minDiff = currentDiff;
                    result.Clear();
                    result.Add(new List<int> { arr[i - 1], arr[i] });
                }
                else if (currentDiff == minDiff)
                {
                    result.Add(new List<int> { arr[i - 1], arr[i] });
                }
            }
            return result;
        }

        static public int[] Task2343SmallestTrimmedNumbers(string[] nums, int[][] queries)//2343. Query Kth Smallest Trimmed Number
        {
            List<int> res = new();
            foreach (int[] q in queries)
            {
                int min = Task2343Countonequerry(nums, q[0], q[1]);
                // res.Add(int.Parse(nums[min]));
                res.Add(min);
            }
            return res.ToArray();
        }

        static int Task2343Countonequerry(string[] nums, int k, int trim)
        {
            int eachNumlenght = nums[0].Length;
            List<(string, int)> values = new();
            for (int i = 0; i < nums.Length; i++)
            {
                values.Add((nums[i].Substring(eachNumlenght - trim), i));
            }
            values.Sort((a, b) => a.Item1 != b.Item1 ? a.Item1.CompareTo(b.Item1) : a.Item2.CompareTo(b.Item2));
            return values.Skip(k - 1).ToList()[0].Item2;
        }


        public int[] Task347_TopKFrequent(int[] nums, int k)//347. Top K Frequent Elements
        {
            int[] res = new int[k];
            Dictionary<int, int> keyValuePairs = new();
            foreach (int elem in nums)
            {
                if (keyValuePairs.ContainsKey(elem))
                    keyValuePairs[elem]++;
                else
                    keyValuePairs.Add(elem, 1);
            }
            keyValuePairs = keyValuePairs.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            for (int i = 0; i < k; i++)
            {
                res[i] = keyValuePairs.ElementAt(keyValuePairs.Count - i - 1).Key;
            }
            return res;
        }
        
        public int Task164_MaximumGap(int[] nums)
        {
            Array.Sort(nums);
            int max = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (Math.Abs(nums[i] - nums[i - 1]) > max)
                {
                    max = nums[i] - nums[i - 1];
                }
            }
            return max;
        }


    }
}
