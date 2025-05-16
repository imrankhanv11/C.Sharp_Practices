using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem
{
    internal class UserRepository : BookRepository, IUserMangement
    {
        private static Dictionary<String, List<int>> userFavorites = new Dictionary<string, List<int>>();

        //register for user
        public void UserRegistr(string username, string password)
        {
            if (UserDetails.ContainsKey(username))
            {
                Console.WriteLine("Username already exists. Please try another username.");
                return;
            }

            UserDetails.Add(username, password);
            Console.WriteLine("Username and password created successfully.");
        }

        private static string currentUser = null;
        //login gor user
        public bool UserLogin(string username, string password)
        {
            if (UserDetails.ContainsKey(username) && UserDetails[username] == password)
            {
                currentUser = username;
                return true;
            }
            return false;
        }

        //delete user
        public void UserDeleteAccount(string username, string password)
        {
            if (UserDetails.ContainsKey(username) && UserDetails[username] == password)
            {
                Console.Write($"Do you want delete your account (yes/no) : ");
                string confirmation = Console.ReadLine().ToLower().Trim();

                if (confirmation.Equals("yes"))
                {
                    UserDetails.Remove(username);
                    Console.WriteLine("Account Deleted Succesfully");
                }
                else if (confirmation.Equals("no"))
                {
                    Console.WriteLine("Account Deletion Cancelled");
                }
                else
                {
                    Console.WriteLine("Invalid option");
                }
            }
            else
            {
                Console.WriteLine("user name or password is incorrect");
            }
        }

        //add favorites
        public void AddFavorites(int bookId)
        {
            if (!BookDetails.ContainsKey(bookId))
            {
                Console.WriteLine("Book not found.");
                Console.WriteLine();
                return;
            }

            if (!userFavorites.ContainsKey(currentUser))
            {
                userFavorites[currentUser] = new List<int>();
            }

            if (!userFavorites[currentUser].Contains(bookId))
            {
                userFavorites[currentUser].Add(bookId);
                Console.WriteLine("Book added to favorites.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Book is already in favorites.");
                Console.WriteLine();
            }
        }

        //view favorites
        public void ViewFavorites()
        {
            if (!userFavorites.ContainsKey(currentUser) || userFavorites[currentUser].Count == 0)
            {
                Console.WriteLine("No favorites found.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine($"Favorite Books for {currentUser}:");
            Console.WriteLine();

            foreach (int bookId in userFavorites[currentUser])
            {
                if (BookDetails.TryGetValue(bookId, out Book book))
                {
                    Console.WriteLine($"- {book.Title} by {book.Author}");
                }
            }
        }

        //remove favorites
        public void RemoveFavorites(int bookId)
        {
            if (userFavorites.ContainsKey(currentUser) && userFavorites[currentUser].Contains(bookId))
            {
                userFavorites[currentUser].Remove(bookId);
                Console.WriteLine("Book removed from favorites.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Book not found in favorites.");
                Console.WriteLine();
            }
        }
    }
}
