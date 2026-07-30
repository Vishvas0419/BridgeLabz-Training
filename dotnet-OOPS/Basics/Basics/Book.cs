using System;
using System.Collections.Generic;
using System.Text;

//Problem Statement: Write a program to create a Book class with attributes title, author, and price. Add a method to display the book details.

namespace Basics
{
    public class Book
    {
        public string Title {  get; set; }
        public string Author {  get; set; }
        public double Price {  get; set; }

        //public Book() { }

        //public Book(string title, string author, double price)
        //{
        //    this.Title = title;
        //    //this.author = author;
        //    //this.price = price;
        //}

        public void displayBookDetails()
        {
            Console.WriteLine("========Book Details========");
            Console.WriteLine($"Book Title : {Title}");
            Console.WriteLine($" Book Author : {Author}");
            Console.WriteLine($" Book Price: {Price}");

        }





    }
}
