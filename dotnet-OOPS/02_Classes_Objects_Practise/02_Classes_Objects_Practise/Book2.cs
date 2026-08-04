using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Classes_Objects_Practise
{
    internal class Book2
    {
        public int ISBN;
        protected string title;
        public string author;


        public Book2(int ISBN, string title, string author)
        {
            this.ISBN = ISBN;
            this.title = title;
            this.author = author;
        }

        public string getAuthor()
        {
            return author;
        }

        public void setAuthor(string author) 
        {
            this.author = author;
        }



    }

    class EBook : Book2
    {
        
    }
}
