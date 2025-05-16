using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_MultiUserExpeseTraker_Oops
{
    //expenses details stroing using class and objects
    class Expense
    {
        public string ExpenseName { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }

        public Expense(string expenseName, int amount, string description)
        {
            ExpenseName = expenseName;
            Amount = amount;
            Description = description;
        }
    }
}
