using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MyListNode
    {
        public int val;
        public MyListNode next;

        public MyListNode(int val)
        {
            this.val = val;
            this.next = null;
        }
    }


    public class MyLinkedList
    {
        private MyListNode head;

        public MyLinkedList()
        {
            head = null;
        }

        public int Get(int index)
        {
            MyListNode current = head;
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
            MyListNode temp = new MyListNode(val); ;
            temp.next = head;
            head = temp;
        }

        public void AddAtTail(int val)
        {
            MyListNode current = head;
            MyListNode previous = null;

            while (current != null)
            {
                previous = current;
                current = current.next;
            }

            if (previous == null)
            {
                head = new MyListNode(val);
            }
            else
            {
                previous.next = new MyListNode(val);
            }
        }

        public void AddAtIndex(int index, int val)
        {
            MyListNode current = head;
            MyListNode previous = null;

            if (index < 0)
            {
                return;
            }
            if (index == 0)
            {
                var next = head;
                head = new MyListNode(val);
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
                previous.next = new MyListNode(val);
                previous.next.next = next;
            }
        }

        public void DeleteAtIndex(int index)
        {
            MyListNode current = head;
            MyListNode previous = null;

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
