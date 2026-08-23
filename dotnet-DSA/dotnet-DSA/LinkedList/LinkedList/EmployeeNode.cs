using LinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    //this EmployeeNode class is same as Node class but here instead of int data we have Employee data next ptr and  return type of data is now changed i.e Employee object
    internal class EmployeeNode
    {
        public Employee Data { get; set; } //composition EmployeeNode has a Employee 
        public EmployeeNode Next {  get; set; }

        public EmployeeNode(Employee empData) //just like data
        {
            Data = empData;
            Next = null;
        }
    }
}
