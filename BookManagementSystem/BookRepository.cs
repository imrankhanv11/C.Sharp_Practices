using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem
{
    public class BookRepository : IBookManagement
    {
        //storing users detials
        protected static Dictionary<String, String> UserDetails = new Dictionary<string, string>
        {
            {"imran","1234"},{"Ram","2345"},{"Gokul","0987"}
        };
        protected static Dictionary<int, Book> BookDetails = new Dictionary<int, Book>
        {
              { 1, new EBook(1, "Digital Values", "Felix", "Thriller", 1.5) },
              { 2, new PrintedBook(2, "Angels and Fire", "Santhosh", "Thriller", 550) },
              { 3, new EBook(3, "C#", "San", "Programming", 2.0) },
              { 4, new PrintedBook(4, "Clean Java", "Java Ram", "Programming", 450) },
              { 5, new EBook(5, "The Cricket", "Adhi", "Sports", 3.1) },
              { 6, new PrintedBook(6, "The Hobbit", "Praveen", "Fantasy", 310) }
        };//storing book details-- protected for inherit and access in admin panel

        //search
        public void SearchBook(int searchId)
        {
            if (!BookDetails.ContainsKey(searchId))
            {
                Console.WriteLine("Book not found");
                Console.WriteLine();
                return;
            }

            var book = BookDetails[searchId];

            Console.WriteLine("+----------------------------------+");
            Console.WriteLine($"| Book Id: {book.BookId,-24}|");
            Console.WriteLine($"| Title: {book.Title,-26}|");
            Console.WriteLine($"| Author: {book.Author,-25}|");
            Console.WriteLine($"| Category: {book.Cetegery,-23}|");

            if (book is EBook e)
            {
                Console.WriteLine($"| Type: EBook                      |");
                Console.WriteLine($"| File Size: {e.FileSize,-22}|");
            }
            else if (book is PrintedBook p)
            {
                Console.WriteLine($"| Type: Printed Book               |");
                Console.WriteLine($"| Page Count: {p.Pagecount,-20}|");
            }

            Console.WriteLine("+----------------------------------+\n");
            Console.WriteLine();
        }

        //display
        public void DisplayBook()
        {
            if (BookDetails.Count == 0)
            {
                Console.WriteLine("No books found");
                Console.WriteLine();
                return;
            }
            int counter = 1;
            foreach (var book in BookDetails.Values)
            {
                Console.WriteLine($"S. No. : {counter++}");
                Console.WriteLine("+----------------------------------+");
                Console.WriteLine($"| Book Id      : {book.BookId,-18}|");
                Console.WriteLine($"| Title        : {book.Title,-18}|");
                Console.WriteLine($"| Author       : {book.Author,-18}|");
                Console.WriteLine($"| Category     : {book.Cetegery,-18}|");

                if (book is EBook e)
                {
                    Console.WriteLine($"| Type         : EBook             |");
                    Console.WriteLine($"| File Size    : {e.FileSize,-18}|");
                }
                else if (book is PrintedBook p)
                {
                    Console.WriteLine($"| Type         : Printed Book      |");
                    Console.WriteLine($"| Page Count   : {p.Pagecount,-18}|");
                }

                Console.WriteLine("+----------------------------------+\n");
            }
        }

        //display by cetegery
        public void DisplayByCetegery()
        {
            var group = BookDetails.Values
                .GroupBy(e => e.Cetegery);

            foreach (var item in group)
            {
                Console.WriteLine($"+----------------------------------+");
                Console.WriteLine($"| Category: {item.Key,-23}|");
                Console.WriteLine($"+----------------------------------+");

                foreach (var book in item)
                {
                    Console.WriteLine($"| Book Id      : {book.BookId,-18}|");
                    Console.WriteLine($"| Title        : {book.Title,-18}|");

                    if (book is EBook e)
                    {
                        Console.WriteLine($"| Type         : EBook             |");
                        Console.WriteLine($"| File Size    : {e.FileSize,-18}|");
                    }
                    else if (book is PrintedBook p)
                    {
                        Console.WriteLine($"| Type         : Printed Book      |");
                        Console.WriteLine($"| Page Count   : {p.Pagecount,-18}|");
                    }

                    Console.WriteLine("+----------------------------------+\n");
                }
            }
        }

    }
}
