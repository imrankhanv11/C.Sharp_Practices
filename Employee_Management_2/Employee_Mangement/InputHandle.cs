using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Mangement
{
    internal class InputHandle
    {
        public double DoubleCheck(string input)
        {
            double value;

            while (true)
            {
                try
                {
                    value = Convert.ToDouble(input);
                    break; 
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid numeric salary:");
                    input = Console.ReadLine();
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number entered is too large or too small. Try again:");
                    input = Console.ReadLine();
                }
            }

            return value;
        }

        public int IntCheck(string input)
        {
            int value;
            while (true)
            {
                try
                {
                    value = Convert.ToInt32(input);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid numeric salary:");
                    input = Console.ReadLine();
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number entered is too large or too small. Try again:");
                    input = Console.ReadLine();
                }
            }
            return value;

        }
        public bool BoolCheck(string input)
        {
            bool value;
            while (true)
            {
                try
                {
                    value = Convert.ToBoolean(input);
                    break;
                }
                catch(FormatException)
                {
                    Console.Write("Invalid input. Please enter 'true' or 'false': ");
                    input = Console.ReadLine();
                }
            }
            return value;
        }
        public DateTime DateTimeCheck(string input)
        {
            DateTime value;
            while (true)
            {
                try
                {
                    value = Convert.ToDateTime(input);
                    break;
                }
                catch(FormatException)
                {
                    Console.Write("Invalid date. Please enter again (yyyy-mm-dd): ");
                    input = Console.ReadLine();
                }
            }
            return value;
        }
    }
}