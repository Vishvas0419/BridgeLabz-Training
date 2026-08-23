using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    internal class Node
    {
        private Node next;
        private int data;

        public Node Next
        {
            get { return next; }
            set { next = value; }
        }

        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        public Node(int data)
        {
            this.data = data;
        }

    }
}
