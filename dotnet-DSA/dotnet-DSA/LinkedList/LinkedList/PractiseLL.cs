using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    internal static class PractiseLL
    {

        public static Node InsertAtBegin(Node head,int val)
        {
            Node newNode = new Node(val);
            if (head == null) return newNode;
            newNode.Next = head;
            return newNode;
        }
        public static Node InsertAtEnd(Node head,int val)
        {
            Node newNode = new Node(val);
            if (head == null) return newNode;
            while (head.Next != null)
            {
                head = head.Next;
            }
            head.Next = newNode;
            return head;
        }
        public static Node InsertAtPosition(Node head,int val,int pos)
        {
            Node newNode = new Node(val);
            if(pos==1)
            {
                newNode.Next = head;
                return newNode;
            }
            Node temp = head;
            int cnt = 0;
            while(temp!=null)
            {
                if(cnt==pos-1)
                {
                    newNode.Next = temp.Next;
                    temp.Next = newNode;
                    break;
                }
                temp = temp.Next;
                cnt++;
            }
            return head;
        }

        public static void Display(Node head)
        {
            Node temp = head;
            while(temp!=null)
            {
                Console.Write(temp.Data+" -> ");
                temp = temp.Next;
            }
            Console.WriteLine("null");
        }
    }
}
