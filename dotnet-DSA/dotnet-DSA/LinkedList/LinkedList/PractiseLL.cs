using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    class Node
    {
        private Node next;
        private int data;

        public Node Next
        {
            get {  return next; }
            set { next = value; }
        }

        public int Data
        {
            get { return data;}
            set { data = value; }
        }
        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
        
    }

    internal class PractiseLL
    {
        Node InsertAtBegin(Node head)
        {
            Node newNode = new Node(head.Data);
            if (head == null) return newNode;
            newNode.Next = head;
            return newNode;
        }
        Node InsertAtEnd(Node head)
        {

        }
    }
}
