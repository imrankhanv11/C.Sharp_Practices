using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem
{
    //Base class for book
    public class Book
    {
        public int BookId { get; set; }
        public String Title { get; set; }

        public string Author { get; set; }
        public String Cetegery { get; set; }

        public Book(int bookId, String title, string author, string cetegery)
        {
           this.BookId = bookId;
           this.Title = title;
            this.Author = author;
           this.Cetegery = cetegery;
        }
    }

    //Child class for Ebook
    public class EBook : Book
    {
        public double FileSize { get; set; }
        public EBook(int bookId, string title, string author, string cetegery, double fileSize)
            : base (bookId, title, author, cetegery)
        {
            this.FileSize = fileSize;
        }
    }

    //child class for Printed Book
    public class PrintedBook : Book
    {
        public int Pagecount { get; set; }
        public PrintedBook(int bookId, string title, string author, string cetegery, int pagecount)
            : base (bookId, title, author, cetegery)
        {
            this.Pagecount = pagecount;
        }
    }
}
