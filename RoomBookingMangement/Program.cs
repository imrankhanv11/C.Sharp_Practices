using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingMangement
{
    class Program
    {
        public static  void Main(string[] args)
        {
            RoomBookingSystem roomBookingSystem = new RoomBookingSystem();
            User loggedInUser = null;

            InputHandle input = new InputHandle();

            while (true)
            {
                Console.WriteLine("Welcome to the Room Booking System");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Enter the operation code : ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Enter username:");
                    string inputusername = Console.ReadLine();
                    string username = input.StringCheck(inputusername);

                    Console.WriteLine("Enter password:");
                    string password = Console.ReadLine();

                    loggedInUser = roomBookingSystem.Login(username, password);

                    if (loggedInUser != null)
                    {
                        Console.WriteLine($"Welcome, {loggedInUser.UserName}!");
                        while (true)
                        {
                            Console.WriteLine("1. View Available Rooms");
                            Console.WriteLine("2. Make a Booking");
                            Console.WriteLine("3. Cancel a Booking");
                            if (loggedInUser.IsAdmin)
                            {
                                Console.WriteLine("4. Admin View Bookings");
                                Console.WriteLine("5. Admin Manage Rooms");
                            }
                            Console.WriteLine("6. Logout");
                            Console.Write("Enter the operation code : ");
                            string userChoice = Console.ReadLine();

                            if (userChoice == "1")
                            {
                                roomBookingSystem.ViewAvailableRooms();
                            }
                            else if (userChoice == "2")
                            {
                                roomBookingSystem.MakeBooking(loggedInUser);
                            }
                            else if (userChoice == "3")
                            {
                                roomBookingSystem.CancelBooking(loggedInUser);
                            }
                            else if (userChoice == "4" && loggedInUser.IsAdmin)
                            {
                                roomBookingSystem.AdminViewBookings();
                            }
                            else if (userChoice == "5" && loggedInUser.IsAdmin)
                            {
                                roomBookingSystem.AdminManageRooms();
                            }
                            else if (userChoice == "6")
                            {
                                loggedInUser = null;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid code");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid credentials.");
                    }
                }
                else if(choice == "2")
                {
                    Console.WriteLine("Enter username:");
                    string inputusername = Console.ReadLine();
                    string username = input.StringCheck(inputusername);

                    Console.WriteLine("Enter password:");
                    string password = Console.ReadLine();

                    roomBookingSystem.RegisterUser(username, password);

                }
                else if (choice == "3")
                {
                    Console.WriteLine("Thank you");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid try again");
                }
            }
        }
    }

}
