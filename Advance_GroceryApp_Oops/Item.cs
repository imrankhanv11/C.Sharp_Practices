using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_GroceryApp_Oops
{
    //details storing of items
    class Item
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Item(int code, string name, double price)
        {
            Code = code;
            Name = name;
            Price = price;
        }
    }


}
