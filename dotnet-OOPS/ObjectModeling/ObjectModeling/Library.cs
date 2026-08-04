using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectModeling
{
    internal class Library
    {
        public string Libarry;
        public List<Book> books;
            
    }
    class Book
    {
        private string title;
        private string author;
        public Book(string title, string author )
        {
            this.title = title;
            this.author = author;
        }

        public void display()
        {
            Console.WriteLine("Title : "+title);
            Console.WriteLine("Author : " + author);

        }
    }
}
