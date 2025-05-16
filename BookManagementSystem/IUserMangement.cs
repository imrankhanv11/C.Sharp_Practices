namespace BookManagementSystem
{
    public interface IUserMangement
    {
        bool UserLogin(string username, string password);
        void UserRegistr(string username, string password);
        void UserDeleteAccount(string username, string password);
        void AddFavorites(int bookId);
        void ViewFavorites();
        void RemoveFavorites(int bookId);
    }
}