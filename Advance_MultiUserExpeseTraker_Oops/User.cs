using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_MultiUserExpeseTraker_Oops
{

    //user detials storing using class and objects
    class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        //to store the expenses details of each person
        public List<Expense> Expenses { get; set; } = new List<Expense>();

        public User(int id, string name, string password)
        {
            UserId = id;
            UserName = name;
            Password = password;
        }
    }

}
