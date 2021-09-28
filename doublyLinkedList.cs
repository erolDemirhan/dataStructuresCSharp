    public class DoublyListNode
    {
        public int val;
        public DoublyListNode next, prev;
        public DoublyListNode(int x) { val = x; }
    }

    public class MyLinkedList
    {
        private DoublyListNode head;
        public MyLinkedList()
        {
            head = null;
        }

        private DoublyListNode getNode(int index)
        {
            DoublyListNode curr = head;
            for(int i = 0;i < index && curr != null; ++i)
            {
                curr = curr.next;
            }
            return curr;
        }

        private DoublyListNode getTail()
        {
            DoublyListNode curr = head;
            while (curr != null && curr.next != null)
            {
                curr = curr.next;
            }
            return curr;
        }

        public int get(int index)
        {
            DoublyListNode curr = getNode(index);
            return curr == null ? -1 : curr.val;
        }

        public void addAtHead(int val)
        {
            DoublyListNode curr = new DoublyListNode(val);
            curr.next = head;
            if(head != null)
            {
                head.prev = curr;
            }
            head = curr;
            return;
        }

        public void addAtTail(int val)
        {
            if(head == null)
            {
                addAtHead(val);
                return;
            }
            DoublyListNode prev = getTail();
            DoublyListNode curr = new DoublyListNode(val);
            prev.next = curr;
            curr.prev = prev;
            return;
        }

        public void addAtIndex(int index, int val)
        {
            if(index == 0)
            {
                addAtHead(val);
                return;
            }
            DoublyListNode prev = getNode(index-1);
            if(prev == null)
            {
                return;
            }
            DoublyListNode curr = new DoublyListNode(val);
            DoublyListNode next = prev.next;
            curr.prev = prev;
            curr.next = next;
            prev.next = curr;
            if (next != null)
            {
                next.prev = curr;
            }
            return;
        }

        public void deleteAtIndex(int index)
        {
            DoublyListNode curr = getNode(index);
            if(curr == null)
            {
                return;
            }
            DoublyListNode prev = curr.prev;
            DoublyListNode next = curr.next;
            if (prev != null)
            {
                prev.next = next;
            }else
            {
                head = next;
            }
            if(next != null)
            {
                next.prev = prev;
            }

        }
    }