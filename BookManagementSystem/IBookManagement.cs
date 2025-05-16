using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem
{
    interface IBookManagement
    {
        void SearchBook(int searchId);
        void DisplayBook();
        void DisplayByCetegery();

    }
}
