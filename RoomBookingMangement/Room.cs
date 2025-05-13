using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingMangement
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public string RoomType { get; set; } // e.g., Single, Double, Suite
        public bool IsAvailable { get; set; }

        public Room(int roomNumber, string roomType)
        {
            RoomNumber = roomNumber;
            RoomType = roomType;
            IsAvailable = true; 
        }

        public void BookRoom()
        {
            IsAvailable = false;
        }

        public void CancelBooking()
        {
            IsAvailable = true;
        }
    }

}
