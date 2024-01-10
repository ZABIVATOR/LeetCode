using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LeetCode.IRecursion;

namespace LeetCode
{
    internal interface IDailySolutions: ISorting,IArrayandString
    {
        public class Solution2385
        {
            private int result;
            public int Task2385_AmountOfTime(TreeNode root, int start)
            {
                DFS(root, start);
                return result;
            }

            private int DFS(TreeNode node, int start)
            {
                if (node == null) return 0;

                int leftDepth = DFS(node.left, start);
                int rightDepth = DFS(node.right, start);

                if (node.val == start)
                {
                    result = Math.Max(leftDepth, rightDepth);
                    return -1;
                }
                else if (leftDepth >= 0 && rightDepth >= 0)
                    return Math.Max(leftDepth, rightDepth) + 1;

                result = Math.Max(result, Math.Abs(leftDepth - rightDepth));
                return Math.Min(leftDepth, rightDepth) - 1;
            }
        }

        public List<int> FindLeafs(ref List<int> res, TreeNode root)
        {
            if (root.left == null && root.right == null)
            {
                res.Add(root.val);
            }
            else
            {
                if (root.left != null)
                    FindLeafs(ref res, root.left);
                if (root.right != null)
                    FindLeafs(ref res, root.right);
            }
            return res;
        }
        public bool Task872_LeafSimilar(TreeNode root1, TreeNode root2)
        {
            List<int> leaf1 = new();
            List<int> leaf2 = new();
            leaf1 = FindLeafs(ref leaf1, root1);
            leaf2 = FindLeafs(ref leaf2, root2);

            return (leaf1.SequenceEqual(leaf2));
        }

        public int Task938_RangeSumBST(TreeNode root, int low, int high)
        {
            int summ = 0;
            if (low <= root.val && root.val <= high)
            {
                summ += root.val;
            }
            if (root.left != null)
                {
                    summ += Task938_RangeSumBST(root.left, low, high);
                }
            if (root.right != null)
                {
                    summ += Task938_RangeSumBST(root.right, low, high);
                }
            return summ;
            
        }

        static public int[] Task300_LengthOfLIS_dynamic(int[] nums)//300. Longest Increasing Subsequence, nado eshe ebanut' nlogn
        {
            int[] Subseq = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                int count = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i] && count - 1 < Subseq[j])
                    {
                        count = Subseq[j] + 1;
                    }
                }
                Subseq[i] = count;

            }
            return Subseq;
        }

        public int Task446_NumberOfArithmeticSlices(int[] nums)
        {
            int n = nums.Length;
            int total_count = 0;

            Dictionary<int, int>[] dp = new Dictionary<int, int>[n];

            for (int i = 0; i < n; ++i)
            {
                dp[i] = new Dictionary<int, int>();
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    long diff = (long)nums[i] - nums[j];
                    if (diff > int.MaxValue || diff < int.MinValue)
                    {
                        continue;
                    }

                    int diffInt = (int)diff;

                    dp[i][diffInt] = dp[i].GetValueOrDefault(diffInt) + 1;

                    if (dp[j].ContainsKey(diffInt))
                    {
                        dp[i][diffInt] += dp[j][diffInt];
                        total_count += dp[j][diffInt];
                    }
                }
            }

            return total_count;
        }

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
    }
}
