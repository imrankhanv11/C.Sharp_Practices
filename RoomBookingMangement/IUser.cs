namespace RoomBookingMangement
{
    public interface IUser
    {
        //user need
        void CancelBooking(User user);
        User Login(string username, string password);
        void MakeBooking(User user);
        void RegisterUser(string username, string password, bool isAdmin = false);
        void ViewAvailableRooms();
    }
}