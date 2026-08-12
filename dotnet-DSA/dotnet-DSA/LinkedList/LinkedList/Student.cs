using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    internal class Student
    {
        public class Student
        {
            private int rollNumber;
            private string name;
            private int age;
            private string grade;

            public int RollNumber
            {
                get { return rollNumber; }
                set { rollNumber = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Age
            {
                get { return age; }
                set { age = value; }
            }

            public string Grade
            {
                get { return grade; }
                set { grade = value; }
            }

            public Student(int rollNumber, string name, int age, string grade)
            {
                RollNumber = rollNumber;
                Name = name;
                Age = age;
                Grade = grade;
            }
        }

        public class StudentNode
        {
            private Student data;
            private StudentNode next;

            public Student Data
            {
                get { return data; }
                set { data = value; }
            }

            public StudentNode Next
            {
                get { return next; }
                set { next = value; }
            }

            public StudentNode(Student data)
            {
                Data = data;
                Next = null;
            }
        }

        public class StudentLinkedList
        {
            private StudentNode head;
            private int count;

            public int Count
            {
                get { return count; }
            }

            public void AddAtBeginning(Student student)
            {
                StudentNode newNode = new StudentNode(student);
                newNode.Next = head;
                head = newNode;
                count++;
            }

            public void AddAtEnd(Student student)
            {
                StudentNode newNode = new StudentNode(student);
                if (head == null)
                {
                    head = newNode;
                    count++;
                    return;
                }

                StudentNode current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
                count++;
            }

            public void AddAtPosition(Student student, int position)
            {
                if (position <= 0 || position > count + 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(position), "Invalid position");
                }

                if (position == 1)
                {
                    AddAtBeginning(student);
                    return;
                }

                StudentNode newNode = new StudentNode(student);
                StudentNode current = head;
                int index = 1;
                while (index < position - 1)
                {
                    current = current.Next;
                    index++;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
                count++;
            }

            public bool DeleteByRollNumber(int rollNumber)
            {
                if (head == null)
                {
                    return false;
                }

                if (head.Data.RollNumber == rollNumber)
                {
                    head = head.Next;
                    count--;
                    return true;
                }

                StudentNode current = head;
                while (current.Next != null && current.Next.Data.RollNumber != rollNumber)
                {
                    current = current.Next;
                }

                if (current.Next == null)
                {
                    return false;
                }

                current.Next = current.Next.Next;
                count--;
                return true;
            }

            public Student SearchByRollNumber(int rollNumber)
            {
                StudentNode current = head;
                while (current != null)
                {
                    if (current.Data.RollNumber == rollNumber)
                    {
                        return current.Data;
                    }
                    current = current.Next;
                }
                return null;
            }

            public bool UpdateGrade(int rollNumber, string newGrade)
            {
                Student student = SearchByRollNumber(rollNumber);
                if (student == null)
                {
                    return false;
                }
                student.Grade = newGrade;
                return true;
            }

            public void DisplayAll()
            {
                StudentNode current = head;
                if (current == null)
                {
                    Console.WriteLine("No student records found");
                    return;
                }

                while (current != null)
                {
                    Student s = current.Data;
                    Console.WriteLine($"Roll: {s.RollNumber}, Name: {s.Name}, Age: {s.Age}, Grade: {s.Grade}");
                    current = current.Next;
                }
            }
        }
    }
}
