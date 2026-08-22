using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace dotnet_Reflections_Annotations
{
    // Question 1
    class Employee
    {
        private string name;
        public int age;

        public Employee()
        {
        }

        public Employee(int age)
        {
            this.age = age;
        }

        public void Display()
        {
            Console.WriteLine("Employee Display");
        }
    }


    // Question 2
    class Person
    {
        private int age = 20;
    }


    // Question 3
    class Calculator
    {
        private int Multiply(int a, int b)
        {
            return a * b;
        }
    }


    // Question 4
    class Student
    {
        private string name;

        public Student(string name)
        {
            this.name = name;
        }

        public void Display()
        {
            Console.WriteLine("Student Name: " + name);
        }
    }
    internal class Reflection_Assignment
    {
        // Question 1
        public static void GetClassInformation()
        {
            Console.Write("Enter class name: ");
            string className = Console.ReadLine();

            Type type = null;

            Type[] types = typeof(Reflection_Assignment).Assembly.GetTypes();

            foreach (Type t in types)
            {
                if (t.Name == className)
                {
                    type = t;
                    break;
                }
            }

            if (type == null)
            {
                Console.WriteLine("Class not found.");
                return;
            }

            Console.WriteLine("\nClass Name: " + type.Name);

            Console.WriteLine("\nMethods:");

            MethodInfo[] methods = type.GetMethods();

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }

            Console.WriteLine("\nFields:");

            FieldInfo[] fields = type.GetFields(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance
            );

            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field.Name);
            }

            Console.WriteLine("\nConstructors:");

            ConstructorInfo[] constructors = type.GetConstructors(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance
            );

            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor);
            }
        }


        // Question 2
        public static void AccessPrivateField()
        {
            Person person = new Person();

            Type type = person.GetType();

            FieldInfo field = type.GetField(
                "age",
                BindingFlags.NonPublic | BindingFlags.Instance
            );

            Console.WriteLine("Old Age: " + field.GetValue(person));

            field.SetValue(person, 25);

            Console.WriteLine("New Age: " + field.GetValue(person));
        }


        // Question 3
        public static void InvokePrivateMethod()
        {
            Calculator calculator = new Calculator();

            Type type = calculator.GetType();

            MethodInfo method = type.GetMethod(
                "Multiply",
                BindingFlags.NonPublic | BindingFlags.Instance
            );

            int result = (int)method.Invoke(
                calculator,
                new object[] { 5, 10 }
            );

            Console.WriteLine("Multiplication Result: " + result);
        }


        // Question 4
        public static void DynamicallyCreateObjects()
        {
            Type type = typeof(Student);

            ConstructorInfo constructor = type.GetConstructor(
                new Type[] { typeof(string) }
            );

            Student student = (Student)constructor.Invoke(
                new object[] { "Vishvas" }
            );

            student.Display();
        }
    }
}
