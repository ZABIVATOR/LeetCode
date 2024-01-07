using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal interface IRecursion
    {
        public int KthGrammar(int N, int K)
        {
            N = N - 1;
            K = K - 1;
            return F(N, K);
        }
        public int F(int n, int k)
        {
            if (n == 0) return 0;
            if (k % 2 == 0)
            {
                return F(n - 1, k / 2);
            }
            return F(n - 1, k / 2) == 1 ? 0 : 1;
        }
        public int Task779_KthGrammar(int n, int k)
        {
            string prev = "0";
            string cur ="";
            for (int i = 0; i < n; i++)
            {
                foreach (char elem in prev)
                {
                    switch  (elem)
                    {
                       case '0':
                            cur+="01";
                            break;
                        case '1':
                            cur += "10";
                            break;
                    }
                }
                prev = cur;
                cur= "";
            }
            return int.Parse(Convert.ToString( prev[k-1]));
        }

        public ListNode Task21_MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val <= l2.val)
            {
                l1.next = Task21_MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = Task21_MergeTwoLists(l1, l2.next);
                return l2;
            }
        }

        public int Task70_ClimbStairs(int n)
        {
            if (n <= 3)
            {
                return n;
            }
            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        public int Task509_Fib(int n)
        {
            int temp1 = 1;
            int temp2 = 2;
            if (n < 2)
            {
                return n;
            }
            else
            {
                for (int i = 3; i < n + 1; i++)
                {
                    int temp = 0;
                    temp = temp1 + temp2;
                    temp1 = temp2;
                    temp2 = temp;

                }
            }
            return temp2 + temp1;
        }

        public int Task104_MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            int left = Task104_MaxDepth(root.left);
            int right = Task104_MaxDepth(root.right);

            return Math.Max(left, right) + 1;
        }

        public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            public int val = val;
            public TreeNode left = left;
            public TreeNode right = right;
        }
        //the parent node is stored at index i, the left child will be stored at index 2i + 1
        //and the right child at index 2i + 2 (assuming the indexing starts at 0).
        public TreeNode Task700_SearchBST(TreeNode root, int val)//it is SORTED!!!
        {
            while (root != null)
            {
                if (val < root.val) root = root.left;
                else if (val > root.val) root = root.right;
                else return root;
            }
            return root;
        }

        //Definition for singly-linked list.
        public class ListNode(int val = 0, ListNode? next = null)
        {
            public int val = val;
            public ListNode next = next;
        }

        public ListNode ReverseList(ListNode head)
        {
            ListNode cur = head;
            ListNode prev = null;
            ListNode nxt = null;
            while (cur != null)
            {
                nxt = cur.next;
                cur.next = prev;
                prev = cur;
                cur = nxt;
            }

            return prev;
        }
        public ListNode Task206_ReverseList(ListNode head)
        {
            ListNode resultNode = null;
            while (head != null)
            {
                resultNode = new ListNode(head.val, resultNode);
                head = head.next;
            }
            return resultNode;
        }

        public ListNode Task24_SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            if (head.next != null)
            {
                (head.val, head.next.val) = (head.next.val, head.val);

                if (head.next.next != null)
                    head.next.next = Task24_SwapPairs(head.next.next);
            }
            return head;
        }
    }
}
