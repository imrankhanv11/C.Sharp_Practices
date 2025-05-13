using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingMangement
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public User(string userName, string password, bool isAdmin = false)
        {
            UserName = userName;
            Password = password;
            IsAdmin = isAdmin;
        }
    }

}
