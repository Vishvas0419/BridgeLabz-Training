using dotnet_DSA.LinkedList.LinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    internal class EmployeeLL
    {
        private EmployeeNode head;
        public void InsertAtBegin(Employee emp)
        {
            EmployeeNode newNode = new EmployeeNode(emp);
            newNode.Next = head;
            head = newNode;
        }

        public void InsertAtEnd(Employee emp)
        {
            EmployeeNode newNode = new EmployeeNode(emp);
            if (head == null)
            {
                head = newNode;
                return;
            }
            EmployeeNode temp = head;
            while(temp.Next!=null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
        }

        public void InsertAtPosition(Employee emp,int pos)
        {
            EmployeeNode newNode = new EmployeeNode(emp);
            if (head == null)
            {
                head = newNode;
                return;
            }

            if (pos == 1)
            {
                InsertAtBegin(emp);
                return;
            }
            EmployeeNode temp = head;
            int cnt = 0;
            while(temp.Next!=null)
            {
                if(cnt==pos-1)
                {
                    newNode.Next = temp.Next;
                    temp.Next = newNode;
                }
                cnt++;
                temp = temp.Next;
            }
        }
        public void DeleteById(int id)
        {
            if (head == null) return;

            if(head.Data.Id == id)
            {
                head = head.Next;
                return;
            }

            EmployeeNode temp = head;
            while(temp.Next!=null)
            {
                if(temp.Next.Data.Id == id)
                {
                    temp.Next = temp.Next.Next;
                    return;
                }
                temp = temp.Next;
            }

            Console.WriteLine("Employee not found !");
        }

        public Employee SearchById(int id)
        {
            EmployeeNode temp = head;
            while(temp!=null)
            {
                if (temp.Data.Id == id) return temp.Data;
                temp = temp.Next;
            }
            return null;

        }

        public Employee SearchByName(string name)
        {
            EmployeeNode temp = head;
            while(temp!=null)
            {
                if (temp.Data.Name == name) return temp.Data;
                temp = temp.Next;
            }
            return null;
        }

        public void Display()
        {
            EmployeeNode temp = head;
            while(temp!=null)
            {
                Console.WriteLine($"ID : {temp.Data.Id} , Name : {temp.Data.Name}, Department : {temp.Data.Department}, Salary : {temp.Data.Salary}");
                temp = temp.Next;
            }
        }










    }
}
