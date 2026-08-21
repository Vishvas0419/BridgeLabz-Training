using System;
using System.Collections.Generic;
using System.Text;

namespace _01Generics
{
    internal class Practise
    {
    }
    internal class Box<T> //generic class means sarkari class ,it can be used by all datatypes
    {
        private T item;

        public T GetItem()
        {
            return item;
        }

        public void SetItem(T item)
        {
            this.item = item;
        }

        public void DisplayItem<T>(T data)
        {
            Console.WriteLine("Details : " + data);
        }


        public T Value;
        public void Print<T>(T value)
        {
            Console.WriteLine("value : "+Value);
        }
    }
}   
