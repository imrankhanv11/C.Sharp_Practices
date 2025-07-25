﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingMangement
{
    public class RoomBookingSystem : IUser, IAdmin
    {

        InputHandle input = new InputHandle();
        private List<Room> rooms = new List<Room>();
        private List<Booking> bookings = new List<Booking>();
        private List<User> users = new List<User>();

        public RoomBookingSystem()
        {
            // Add initial rooms
            rooms.Add(new Room(101, "Single"));
            rooms.Add(new Room(102, "Double"));
            rooms.Add(new Room(103, "Suite"));

            // Add a few users (one admin and one customer)
            users.Add(new User("admin", "admin123", true));
            users.Add(new User("imran", "password123", false));
        }

        public void RegisterUser(string username, string password, bool isAdmin = false)
        {
            users.Add(new User(username, password, isAdmin));
            Console.WriteLine("Register sucessfully");
            Console.WriteLine();
        }

        public User Login(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.UserName == username && user.Password == password)
                    return user;
            }
            return null;
        }

        public void ViewAvailableRooms()
        {
            Console.WriteLine("Available Rooms (Today):");
            Console.WriteLine("=============================================");
            Console.WriteLine("| Room Number | Room Type                   |");
            Console.WriteLine("=============================================");

            foreach (var room in rooms)
            {
                bool isBookedToday = bookings.Any(b =>
                    b.Room.RoomNumber == room.RoomNumber &&
                    DateTime.Today >= b.CheckInDate &&
                    DateTime.Today < b.CheckOutDate);

                if (!isBookedToday)
                {
                    Console.WriteLine($"| {room.RoomNumber,-12} | {room.RoomType,-26} |");
                    Console.WriteLine("---------------------------------------------");
                }
            }

            Console.WriteLine();
        }

        public void MakeBooking(User user)
        {
            Console.WriteLine("Enter room number to book:");
            string inputroom = Console.ReadLine();
            int roomNumber = input.IntCheck(inputroom);

            Room selectedRoom = rooms.Find(r => r.RoomNumber == roomNumber);

            if (selectedRoom == null)
            {
                Console.WriteLine("Room does not exist.");
                return;
            }

            Console.WriteLine("Enter check-in date (yyyy-mm-dd):");
            string inputcheckin = Console.ReadLine();
            DateTime checkInDate = input.DateTimeCheck(inputcheckin);

            DateTime checkOutDate;
            while (true)
            {
                Console.WriteLine("Enter check-out date (yyyy-mm-dd):");
                string inputcheckout = Console.ReadLine();
                checkOutDate = input.DateTimeCheck(inputcheckout);

                if (checkOutDate > checkInDate)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Check-out date must be after the check-in date. Please enter a valid check-out date.");
                }
            }

            bool isRoomAvailable = !bookings.Any(b =>
                b.Room.RoomNumber == roomNumber &&
                ((checkInDate < b.CheckOutDate) && (checkOutDate > b.CheckInDate))
            );

            if (isRoomAvailable)
            {
                Booking newBooking = new Booking(user.UserName, selectedRoom, DateTime.Now, checkInDate, checkOutDate);
                bookings.Add(newBooking);
                Console.WriteLine($"Booking confirmed for {selectedRoom.RoomType} room {selectedRoom.RoomNumber}.");
                Console.WriteLine($"Check-in: {checkInDate:yyyy-MM-dd}, Check-out: {checkOutDate:yyyy-MM-dd}");
            }
            else
            {
                Console.WriteLine("Sorry, the room is already booked during the selected dates.");
            }
        }

        public void CancelBooking(User user)
        {
            Console.WriteLine("Enter the room number of the booking you want to cancel:");
            int roomNumber = int.Parse(Console.ReadLine());

            var booking = bookings.Find(b => b.Room.RoomNumber == roomNumber && b.CustomerName == user.UserName);

            if (booking != null)
            {
                bookings.Remove(booking);
                Console.WriteLine("Booking canceled successfully.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Booking not found.");
                Console.WriteLine();
            }
        }

        public void AdminViewBookings()
        {
            Console.WriteLine("All Bookings:");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("| Customer Name    | Room Number | Check-In Date | Check-Out Date     |");
            Console.WriteLine("==========================================================================");

            foreach (var booking in bookings)
            {
                Console.WriteLine($"| {booking.CustomerName,-17} | {booking.Room.RoomNumber,-12} | {booking.CheckInDate.ToShortDateString(),-14} | {booking.CheckOutDate.ToShortDateString(),-17} |");
            }

            Console.WriteLine("==========================================================================");
            Console.WriteLine();

        }

        public void AdminManageRooms()
        {
            Console.WriteLine("Manage Rooms (Add/Delete Rooms):");
            Console.WriteLine("1. Add Room");
            Console.WriteLine("2. Remove Room");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                int roomNumber;
                while (true)
                {
                    Console.WriteLine("Enter Room Number:");
                    string inputroomnum = Console.ReadLine();
                    roomNumber = input.IntCheck(inputroomnum);

                    bool roomExists = rooms.Any(r => r.RoomNumber == roomNumber);
                    if (roomExists)
                    {
                        Console.WriteLine("Error: Room number already exists. Please enter a different room number.");
                        Console.WriteLine();
                    }
                    else
                    {
                        break; 
                    }
                }

                string roomType;
                while (true)
                {
                    Console.WriteLine("Enter Room Type (Single/Double/Suite):");
                    string inputroom = Console.ReadLine().ToLower().Trim();
                    roomType = input.StringCheck(inputroom);

                    if(roomType == "single" || roomType == "double" || roomType == "suite")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("invalid room type");
                        Console.WriteLine();
                    }
                }
                

                rooms.Add(new Room(roomNumber, roomType));
                Console.WriteLine("Room added successfully.");
                Console.WriteLine();
            }

            else if (choice == "2")
            {
                Console.WriteLine("Enter Room Number to Remove:");
                string inputroomremove = Console.ReadLine();
                int roomNumber = input.IntCheck(inputroomremove);
                Room roomToRemove = rooms.Find(r => r.RoomNumber == roomNumber);
                if (roomToRemove != null)
                {
                    rooms.Remove(roomToRemove);
                    Console.WriteLine("Room removed successfully.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Room not found.");
                    Console.WriteLine();
                }
            }
        }
    }

}
