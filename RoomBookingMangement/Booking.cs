using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingMangement
{
    using System;

    public class Booking
    {
        public string CustomerName { get; set; }
        public Room Room { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public Booking(string customerName, Room room, DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate)
        {
            CustomerName = customerName;
            Room = room;
            BookingDate = bookingDate;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }
    }

}
