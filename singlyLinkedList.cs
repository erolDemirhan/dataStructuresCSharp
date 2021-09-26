using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace singlyLinkedList
{

    public class SinglyListNode
    {
        public int val;
        public SinglyListNode next;
        public SinglyListNode(int x)
        {
            val = x;
        }
    }

    class MyLinkedList
    {
        private SinglyListNode head;
        public MyLinkedList()
        {
            head = null;
        }

        /** Helper function to return the index-th node in the linked list. */
        private SinglyListNode getNode(int index)
        {
            SinglyListNode cur = head;
            for (int i=0; i<index && cur!=null; ++i)
            {
                cur = cur.next;
            }
            return cur;
        }

        /** Helper function to return the last node in the linked list. */
        private SinglyListNode getTail()
        {
            SinglyListNode cur = head;
            while(cur!=null && cur.next != null)
            {
                cur = cur.next;
            }
            return cur;
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int get(int index)
        {
            SinglyListNode cur = getNode(index);
            return cur == null ? -1 : cur.val;
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void addAtHead(int val)
        {
            SinglyListNode cur = new SinglyListNode(val);
            cur.next = head;
            head = cur;
            return;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void addAtTail(int val)
        {
            if(head == null)
            {
                addAtHead(val);
                return;
            }
            SinglyListNode prev = getTail();
            SinglyListNode cur = new SinglyListNode(val);
            prev.next = cur;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void addAtIndex(int index, int val)
        {
            if(index == 0)
            {
                addAtHead(val);
                return;
            }
            SinglyListNode prev = getNode(index - 1);
            if(prev == null)
            {
                return;
            }
            SinglyListNode cur = new SinglyListNode(val);
            SinglyListNode next = prev.next;
            cur.next = next;
            prev.next = cur;
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void deleteAtIndex(int index)
        {
            if(head == null)
            {
                return;
            }
            if (index == 0)
            {
                head = head.next;
                return;
            }
               
            SinglyListNode prev = getNode(index-1);
            prev.next = prev.next.next;
        }

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            MyLinkedList obj = new MyLinkedList();
            
            obj.addAtHead(3);
            obj.addAtTail(4);
            obj.addAtTail(5);
            obj.addAtIndex(3, 6);
            obj.deleteAtIndex(3);       
        }
    }
}
