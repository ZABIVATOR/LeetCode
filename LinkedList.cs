using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LeetCode.IRecursion;

namespace LeetCode
{
    public class TwoPointer
    {
        
        public ListNode Task142_DetectCycle(ListNode head)
        {
            ListNode slow = head, fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    break;
                }
            }

            if (fast == null || fast.next == null)
            {
                return null;
            }

            while (head != fast)
            {
                head = head.next;
                fast = fast.next;
            }

            return head;
        }




        private bool MovePointers(ListNode fast, ListNode slow)
        {
            if (fast == null || fast.next == null || fast.next.next == null)
                return false;
            if (fast == slow)
            {
                return true;
            }

            else
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return MovePointers(fast, slow);
        }
        public bool Task141_HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return false;
            ListNode fast = head.next;
            ListNode slow = head;
            return MovePointers(fast, slow);
        }

    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
    public class MyLinkedList
    {
        private ListNode head;

        public MyLinkedList()
        {
            head = null;
        }

        public int Get(int index)
        {
            ListNode current = head;
            int i = 0;
            while (current != null && i < index)
            {
                current = current.next;
                i++;
            }
            if (current == null)
            {
                return -1;
            }
            return current.val;
        }

        public void AddAtHead(int val)
        {
            ListNode temp = new ListNode(val); ;
            temp.next = head;
            head = temp;
        }

        public void AddAtTail(int val)
        {
            ListNode current = head;
            ListNode previous = null;

            while (current != null)
            {
                previous = current;
                current = current.next;
            }

            if (previous == null)
            {
                head = new ListNode(val);
            }
            else
            {
                previous.next = new ListNode(val);
            }
        }

        public void AddAtIndex(int index, int val)
        {
            ListNode current = head;
            ListNode previous = null;

            if (index < 0)
            {
                return;
            }
            if (index == 0)
            {
                var next = head;
                head = new ListNode(val);
                head.next = next;
                return;
            }
            int i = 0;
            while (current != null && i < index)
            {
                previous = current;
                current = current.next;
                i++;
            }
            if (i == index)
            {
                var next = current;
                previous.next = new ListNode(val);
                previous.next.next = next;
            }
        }

        public void DeleteAtIndex(int index)
        {
            ListNode current = head;
            ListNode previous = null;

            if (index < 0)
            {
                return;
            }

            if (index == 0)
            {
                head = head.next;
                return;
            }

            int i = 0;
            while (current != null && i < index)
            {
                previous = current;
                current = current.next;
                i++;
            }

            if (i == index)
            {
                previous.next = current?.next;
            }
        }
    }
}
