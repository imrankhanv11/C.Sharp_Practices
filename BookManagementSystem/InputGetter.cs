using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem
{
    class InputGetter
    {
        IBookManagement book = new BookRepository();//access bookrepository
        IAdminManagement admin = new AdminRepository();//access admin reposository
        IUserMangement user = new UserRepository();//access user repository

        InputChecker check = new InputChecker();//input checking


        //<------------- Admin/User Functions -------------->
        //search book - admin/user
        public void SearchBook()
        {
            Console.Write("Enter the Id to search : ");
            string idcheck = Console.ReadLine();
            int SearchId = check.IntergerCheck(idcheck);

            book.SearchBook(SearchId);
        }

        //display book - admin/user
        public void Display()
        {
            book.DisplayBook();
        }

        //display by cetergery - admin/user
        public void DisplayCetegery()
        {
            book.DisplayByCetegery();
        }


        //<-------------- User Functions -------------------->
        //user registration - user
        public void UserRegister()
        {
            Console.Write("Enter the User Name : ");
            string checkname = Console.ReadLine();
            string username = check.StringCheck(checkname);

            Console.Write("Enter the password (password must in 4 Character ) : ");
            string checkpassword = Console.ReadLine();
            string password = check.PasswordCheck(checkpassword);

            user.UserRegistr(username, password);
        }

        //user login - user
        public bool UserLoginpage()
        {
            Console.Write("Enter the User Name : ");
            string checkname = Console.ReadLine();
            string username = check.StringCheck(checkname);

            Console.Write("Enter the password (password must in 4 Character ) : ");
            string checkpassword = Console.ReadLine();
            string password = check.PasswordCheck(checkpassword);

            return user.UserLogin(username, password);

        }

        //user account delete - user
        public void UserDeleteAccount()
        {
            Console.Write("Enter the User Name : ");
            string checkname = Console.ReadLine();
            string username = check.StringCheck(checkname);

            Console.Write("Enter the password (password must in 4 Character ) : ");
            string checkpassword = Console.ReadLine();
            string password = check.PasswordCheck(checkpassword);

            user.UserDeleteAccount(username, password); 


        }

        // Add Book to Favorites 
        public void AddFavorites()
        {
            Console.Write("Enter the Book Id : ");
            string checkid = Console.ReadLine();
            int id  = check.IntergerCheck(checkid);

            user.AddFavorites(id);
        }

        //View Favorites
        public void ViewFavorites()
        {
            user.ViewFavorites();
        }

        //remove from favorites
        public void RemoveFavorites()
        {
            Console.Write("Enter the Book Id : ");
            string checkid = Console.ReadLine();
            int id = check.IntergerCheck(checkid);

            user.RemoveFavorites(id);
        }

        //<---------------- Admin Functions ------------------->
        //Admin login
        public bool Adminlogin()
        {

            Console.Write("Enter Admin Username: ");
            string checkusername = Console.ReadLine();
            string username = check.StringCheck(checkusername);

            Console.Write("Enter Admin Password: ");
            string checkpassword = Console.ReadLine();
            string password = check.PasswordCheck(checkpassword);

            return admin.ValidateAdminMain(username, password);

        }

        //addbook - admin
        public void AddBook()
        {
            Console.Write("Entr the Book Title : ");
            string titlecheck = Console.ReadLine();
            string Title = check.StringCheck(titlecheck);

            Console.Write("Enter the Auther Name : ");
            string authercheck = Console.ReadLine();
            string AutherName = check.StringCheck(authercheck);

            Console.Write("Enter the Cetegery : ");
            string cetegerycheck = Console.ReadLine();
            string Cetegery = check.StringCheck(cetegerycheck);
        BookType:
            Console.Write("Enter the Book Type  EBook - E / PrintedBook - P : ");
            String BookType = Console.ReadLine().ToUpper();

            //for ebook
            if (BookType.Equals("E"))
            {
                Console.Write("Enter the File size : ");
                string filesize = Console.ReadLine();
                double FileSize = check.DoubleCheck(filesize);

                Book newbook = new EBook(0, Title, AutherName, Cetegery, FileSize);

                admin.AddBook(newbook);

            }
            //for printed book
            else if (BookType.Equals("P"))
            {
                Console.Write("Enter the Page Count : ");
                string pagecountcheck = Console.ReadLine();
                int Pagecount = check.IntergerCheck(pagecountcheck);

                Book newbook = new PrintedBook(0, Title, AutherName, Cetegery, Pagecount);

                admin.AddBook(newbook);

            }
            else
            {
                Console.WriteLine("Invalid Type");
                goto BookType;
            }
        }

        //remove book - admin
        public void RemoveBook()
        {
            Console.Write("Enter the Book Id : ");
            string idcheck = Console.ReadLine();
            int RemoveId = check.IntergerCheck(idcheck);

            admin.DeleteBook(RemoveId);
        }

        //update book - admin
        public void UpdateBook()
        {
            Console.Write("Enter the Id for update : ");
            string checkid = Console.ReadLine();
            int updateId = check.IntergerCheck(checkid);

            admin.UpdateBook(updateId);
        }

        public void ShowUserList()
        {
            admin.ShowUsersList();
        }

    }
}
