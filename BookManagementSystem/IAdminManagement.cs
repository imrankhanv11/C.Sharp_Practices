namespace BookManagementSystem
{
    public interface IAdminManagement
    {
        void AddBook(Book new_book);
        void DeleteBook(int deleteId);
        void UpdateBook(int updateId);
        void ShowUsersList();
        bool ValidateAdminMain(string username, string password);
    }
}