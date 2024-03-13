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
        int factorial(int n) {
            int res = 0;
            for (int i = 1; i < n + 1; i++)
                res += i;
            return res;
        }   
        public int Task2485_PivotInteger(int n)
        {
            int leftsum = 0;
            int rightsum = factorial(n);

            for (int i = 0; i < n+1; i++)
            {
                leftsum += i;
                if (leftsum == rightsum)
                    return i;

                rightsum -= i;
            }

            return -1;
        }

        public int[] Task349_Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> res1 = new HashSet<int>();
            foreach (int i in nums1)
            {
                res1.Add(i);
            }

            HashSet<int> res2 = new HashSet<int>();
            foreach (int i in nums2)
            {
                res2.Add(i);
            }
            res1.IntersectWith(res2);

            return res1.ToArray();
        }

        int FirstEncounter(ref int[] nums1, ref int[] nums2)
        {
            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j=0; j< nums2.Length/2+1; j++) { 
                    if (nums1[i] == nums2[j]) 
                        return nums1[i];
                    if (nums1[i] == nums2[nums2.Length-j-1])
                        return nums1[i];
                }
            }
            return -1;
        }

        public int Task2540_GetCommon(int[] nums1, int[] nums2)//time limit exceeded
        {
            Array.Sort(nums1);
            Array.Sort(nums2);

            if (nums1[0] > nums2[0])
            {
                return FirstEncounter(ref nums1, ref nums2);
            }
            else
            {
                return FirstEncounter(ref nums2, ref nums1);
            }
        }
        static public int MinimumLength(string s)
        {
            int aswer = s.Length;
            for (int i = 0; i < s.Length/2;)
            {
                if (s[i] == s[s.Length-1-i])
                {
                    i++;
                    aswer -= 2;
                }
                else
                {
                    return aswer;
                }

            }
            return aswer;
        }


        public int Task948_BagOfTokensScore(int[] tokens, int power)
        {
            Array.Sort(tokens);
            int maxScore = 0, currentScore = 0;
            int left = 0, right = tokens.Length - 1;

            while (left <= right)
            {
                if (power >= tokens[left])
                {
                    power -= tokens[left++];
                    currentScore++;
                    maxScore = Math.Max(maxScore, currentScore);
                }
                else if (currentScore > 0)
                {
                    power += tokens[right--];
                    currentScore--;
                }
                else
                {
                    break;
                }
            }

            return maxScore;
        }

        public ListNode Task19_RemoveNthFromEnd(ListNode head, int n)
        {
            int length = findLength(head);
            int i = 0, traverseTill = length - n - 1;
            if (traverseTill == -1) return head.next;
            ListNode curr = head;
            while (i < traverseTill)
            {
                curr = curr.next;
                i++;
            }
            curr.next = curr.next.next;
            return head;
        }
        public int findLength(ListNode head)
        {
            int count = 0;
            if (head == null) return count;
            ListNode curr = head;
            while (curr != null)
            {
                count++;
                curr = curr.next;
            }
            return count;
        }


        public int[] Task977_SortedSquares(int[] nums)
        {
            int countpos = 1;
            int countneg = 0;
            int countBeginning = 0;
            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= 0)
                {
                    if (nums.Length == 2)
                        result[countBeginning] = nums[i] * nums[i];
                    if ((countBeginning + countneg + countpos) >= nums.Length + 1)
                    {
                        Console.WriteLine("END ");
                        break;
                    }
                    result[countBeginning] = nums[i] * nums[i];
                    countBeginning++;
                    continue;
                }
                while (-nums[i] <= nums[nums.Length - countpos])
                {
                    result[nums.Length - countpos - countneg] = nums[nums.Length - countpos] * nums[nums.Length - countpos];
                    countpos++;
                }
                result[nums.Length - countpos - countneg] = nums[i] * nums[i];
                countneg++;
            }
            return result;
        }

        public string Task2864_MaximumOddBinaryNumber(string s)
        {
            int zeros = 0;
            int ones = 0;
            foreach (char letter in s) {
                switch (letter)
                {
                    case '0':
                        zeros++;
                        break;
                    case '1':
                        ones++;
                        break;
                }
            }
            string result = "";

            for (int i = 0; i < ones-1; i++)
            {
                result += 1;
            }

            for (int i = ones; i < ones + zeros; i++)
            {
                result += '0';
            }
            result += '1';

            return result;
        }

        public int Task1143_LongestCommonSubsequence(string text1, string text2)
        {
            var matrix = new int[text1.Length + 1, text2.Length + 1];

            for (var i1 = 0; i1 < text1.Length; i1++)
                for (var i2 = 0; i2 < text2.Length; i2++)
                    if (text1[i1] == text2[i2])
                        matrix[i1 + 1, i2 + 1] = matrix[i1, i2] + 1;
                    else
                        matrix[i1 + 1, i2 + 1] = Math.Max(matrix[i1 + 1, i2], matrix[i1, i2 + 1]);

            return matrix[text1.Length, text2.Length];
        }
        public int Task1457_PseudoPalindromicPaths(TreeNode root, int c = 0)
        {
            if (root == null) return 0;
            c ^= 1 << root.val; // toggle bit for each number
            if (root.left == null && root.right == null) return (c & (c - 1)) > 0 ? 0 : 1; // return 1 when there's at most one bit set
            return Task1457_PseudoPalindromicPaths(root.left, c) + Task1457_PseudoPalindromicPaths(root.right, c);
        }

        public int Task1239_MaxLength(IList<string> arr, int i = 0, string s = "")
        {
            if (s.Distinct().Count() < s.Length) return 0;

            if (arr.Count == i) return s.Length;

            return Math.Max(
                Task1239_MaxLength(arr, i + 1, s),
                Task1239_MaxLength(arr, i + 1, s + arr[i])
            );
        }

        public int[] Task645_FindErrorNums(int[] nums)
        {
            int first = 0;
            int second = 0;

            int[] count = new int[nums.Length + 1];
            count[nums[0]] += 1;
            for (int i = 1; i < nums.Length; i++)
            {
                count[nums[i]] += 1;
            }

            for (int j = 1; j < count.Length; j++)
            {
                if (count[j] > 1)
                {
                    first = j;
                }
                if (count[j] == 0)
                {
                    second = j;
                }
            }

            return new int[] { first, second };
        }

        public int Task198_Rob(int[] nums)
        {
            if (nums.Length < 3) return nums.Max();
            int prevMax = 0;
            int currMax = 0;

            foreach (int num in nums)
            {
                int temp = currMax;
                currMax = Math.Max(prevMax + num, currMax);
                prevMax = temp;
            }

            return currMax;
        }

        public int SumSubarrayMins(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return 0;

            Stack<int> stack = new Stack<int>();
            int n = arr.Length, MOD = (int)1e9 + 7;
            long res = 0;

            for (int i = 0; i <= n; i++)
            {
                while (stack.Count > 0 && arr[stack.Peek()] >= (i == n ? 0 : arr[i]))
                {
                    int mid = stack.Pop();
                    int left = stack.Count == 0 ? -1 : stack.Peek();
                    int right = i;
                    res = (res + (long)arr[mid] * (right - mid) * (mid - left)) % MOD;
                }
                stack.Push(i);
            }
            return (int)res;
        }

        private void AddMin(ref int elem, int a = 1000000, int b = 1000000, int c = 100000000)
        {
            elem = elem + Math.Min(a, Math.Min(b, c));
        }
        public int Task931_MinFallingPathSum(int[][] matrix)
        {
            int n = matrix[0].Length;
            for (int i = 1; i < matrix.Length; i++)
            {
                AddMin(ref matrix[i][0], matrix[i - 1][0], matrix[i - 1][1]);
                AddMin(ref matrix[i][n - 1], matrix[i - 1][n - 2], matrix[i - 1][n - 1]);
                for (int j = 1; j < n - 1; j++)
                {
                    AddMin(ref matrix[i][j], matrix[i - 1][j - 1], matrix[i - 1][j], matrix[i - 1][j + 1]);
                }
            }
            return matrix[n - 1].Min();
        }

        public bool Task1207_UniqueOccurrences(int[] arr)
        {
            Dictionary<int, int> occur = new Dictionary<int, int>();
            foreach (var a in arr)
            {
                if (occur.ContainsKey(a))
                    occur[a]++;
                else
                    occur.Add(a, 1);
            }
            Dictionary<int, int> temp = new Dictionary<int, int>();
            foreach (var elem in occur)
            {
                int val = occur[elem.Key];
                try
                {
                    temp.Add(val, 1);
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public IList<IList<int>> Task2225_FindWinners(int[][] matches)
        {
            Dictionary<int, int> players = new Dictionary<int, int>();

            foreach (int[] game in matches)
            {
                var winner = game[0];
                var loser = game[1];

                if (players.ContainsKey(winner))
                {

                }
                else
                {
                    players.Add(winner, 0);
                }

                if (players.ContainsKey(loser))
                {
                    players[loser]++;
                }
                else
                {
                    players.Add(loser, 1);
                }
            }

            var zeroloses = players.Where(x => x.Value == 0).ToList();
            var onelose = players.Where(x => x.Value == 1).ToArray();
            IList<int> first = new List<int>();
            IList<int> second = new List<int>();

            foreach (var player in zeroloses)
            {
                first.Add(player.Key);
            }

            foreach (var player in onelose)
            {
                second.Add(player.Key);
            }

            return new List<IList<int>>
        {
            first.OrderBy(x => x).ToList(),
            second.OrderBy(x => x).ToList()
        };
        }

        public bool Task1657_CloseStrings(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;

            int[] w1c = new int[26];
            int[] w2c = new int[26];

            foreach (char c in word1) w1c[c - 'a']++;
            foreach (char c in word2) w2c[c - 'a']++;

            for (int i = 0; i < 26; i++)
            {
                if ((w1c[i] != 0) != (w2c[i] != 0)) return false;
            }

            Array.Sort(w1c);
            Array.Sort(w2c);

            return w1c.SequenceEqual(w2c);
        }

        public int Task1347_MinSteps(string s, string t)
        {
            int[] charSet = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                charSet[s[i] - 'a']++;    
                --charSet[t[i] - 'a'];     
            }
            int count = 0;
            for (int i = 0; i < charSet.Length; i++)
                if (charSet[i] > 0) 
                    count += charSet[i];
            return count;
        }

        public bool Task1704_HalvesAreAlike(string s)
        {
            int right = 0;
            int left = 0;
            int len = s.Length;

            for (int i = 0; i < len / 2; i++)
            {
                switch (s[i])
                {
                    case 'a':
                        left++;
                        break;
                    case 'e':
                        left++;
                        break;
                    case 'i':
                        left++;
                        break;
                    case 'o':
                        left++;
                        break;
                    case 'u':
                        left++;
                        break;
                    case 'A':
                        left++;
                        break;
                    case 'E':
                        left++;
                        break;
                    case 'I':
                        left++;
                        break;
                    case 'O':
                        left++;
                        break;
                    case 'U':
                        left++;
                        break;
                }
            }


            for (int i = len/2; i < len; i++)
            {
                switch (s[i])
                {
                    case 'a':
                        right++;
                        break;
                    case 'e':
                        right++;
                        break;
                    case 'i':
                        right++;
                        break;
                    case 'o':
                        right++;
                        break;
                    case 'u':
                        right++;
                        break;
                    case 'A':
                        right++;
                        break;
                    case 'E':
                        right++;
                        break;
                    case 'I':
                        right++;
                        break;
                    case 'O':
                        right++;
                        break;
                    case 'U':
                        right++;
                        break;
                }
            }

            return left == right;
        }


        public class Solution1026
        {
            int diff = 0;
            public int Task1026_MaxAncestorDiff(TreeNode root)
            {
                DFS(root, root.val, 0);
                return diff;
            }

            public void DFS(TreeNode root, int min, int max)
            {
                if (root == null) return;
                min = Math.Min(min, root.val);
                max = Math.Max(max, root.val);
                diff = Math.Max(diff, max - min);
                DFS(root.left, min, max);
                DFS(root.right, min, max);
            }
        }


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
