using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem
{
    internal class AdminRepository : BookRepository, IAdminManagement
    {
        static int BookId = 7;//auto increment Id
        static string Admin = "admin";//adminuser name
        static string Password = "1234";//passwor

        InputChecker check = new InputChecker();//input validate

        //addbook
        public void AddBook(Book new_book)
        {
            new_book.BookId = BookId;
            BookDetails.Add(new_book.BookId, new_book);
            BookId++;
            Console.WriteLine($"New Book Added Succesfully with Id : {new_book.BookId}");
            Console.WriteLine();
        }

        //delete book
        public void DeleteBook(int deleteId)
        {
            if (BookDetails.ContainsKey(deleteId))
            {
                while (true)
                {

                    Console.WriteLine($"Do you want to Delete the book (yes/no) : ");
                    string confirmation = Console.ReadLine().ToLower().Trim();
                    if (confirmation.Equals("yes"))
                    {
                        BookDetails.Remove(deleteId);
                        Console.WriteLine($"Book removed succesfully with id {deleteId}");
                        Console.WriteLine();
                        break;
                    }
                    else if (confirmation.Equals("no"))
                    {
                        Console.WriteLine("Removing cancenled");
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid");
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Book Details not found");
                Console.WriteLine();
            }
        }

        //update
        public void UpdateBook(int updateId)
        {
            if (!BookDetails.ContainsKey(updateId))
            {
                Console.WriteLine("Book not found");
                Console.WriteLine();
                return;
            }

            Book value = BookDetails[updateId];

            Console.WriteLine("Which field do you want to update?");
            Console.WriteLine("1. Title");
            Console.WriteLine("2. Author");
            Console.WriteLine("3. Category");

            if (value is EBook)
            {
                Console.WriteLine("4. File Size");
            }
            else if (value is PrintedBook)
            {
                Console.WriteLine("5. Page Count");
            }

            Console.WriteLine("6. Exit");

            Console.Write("Enter code for update: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter new Title: ");
                    value.Title = check.StringCheck(Console.ReadLine());
                    break;
                case "2":
                    Console.Write("Enter new Author: ");
                    value.Author = check.StringCheck(Console.ReadLine());
                    break;
                case "3":
                    Console.Write("Enter new Category: ");
                    value.Cetegery = check.StringCheck(Console.ReadLine());
                    break;
                case "4":
                    if (value is EBook e)
                    {
                        Console.Write("Enter new File Size: ");
                        e.FileSize = check.DoubleCheck(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("Invalid option for this book type.");
                        Console.WriteLine();
                    }
                    break;
                case "5":
                    if (value is PrintedBook p)
                    {
                        Console.Write("Enter new Page Count: ");
                        p.Pagecount = check.IntergerCheck(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("Invalid option for this book type.");
                        Console.WriteLine();
                    }
                    break;
                case "6":
                    Console.WriteLine("Update process finished.");
                    Console.WriteLine();
                    return;
                default:
                    Console.WriteLine("Invalid input, try again.");
                    Console.WriteLine();
                    break;
            }
        }

        //show user List
        public void ShowUsersList()
        {
            int count = 1;
            foreach(var entry in UserDetails)
            {
                Console.WriteLine($"User {count}");
                Console.WriteLine($"User Name      : {entry.Key}");
                count++;
            }
            Console.WriteLine();
        }
        //admin check
        public bool ValidateAdminMain(string username, string password)
        {
            if (username == Admin || password == Password)
            {
                return true;
            }
            return false;
        }

    }
}
