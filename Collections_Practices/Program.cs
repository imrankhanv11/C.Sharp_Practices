using System.Collections.Generic;
using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Collections_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the operation list =1 /  stack = 2 / queue =3 / Hashset = 4 / Dictionary = 5 : ");
            int Value = Convert.ToInt32(Console.ReadLine());
            if (Value == 1)
            {
                Listvalue();
            }
            else if (Value == 2)
            {
                Stackvalue();
            }
            else if (Value == 3)
            {
                Queuevalue();
            }
            else if (Value == 4)
            {
                Hashsetvalue();
            }
            else if (Value == 5)
            {
                Dictionaryvalue();
            }
            else
            {
                Console.WriteLine("Invalid :");
            }

        }
        public static void Listvalue()
        {
            Console.WriteLine("List :");
            List<int> Values = new List<int>();
            Values.Add(1);
            Values.Add(2);
            Values.Add(3);


            for (int i = 0; i < Values.Count; i++)
            {
                Console.Write(Values[i] + " ");
            }
            Console.WriteLine();
            List<int> ints = new List<int>();
            ints.Add(1);
            ints.Add(2);
            ints.Add(3);
            ints.Add(4);
            Values.AddRange(ints);
            Console.WriteLine("After add Range :");
            for (int i = 0; i < Values.Count; i++)
            {
                Console.Write(Values[i] + " ");
            }
            Console.WriteLine();
            Values.Sort();
            Console.WriteLine("After Sorting :");
            for (int i = 0; i < Values.Count; i++)
            {
                Console.Write(Values[i] + " ");
            }
            Console.WriteLine();
            Values.Clear();
            Console.WriteLine("After Clear :");
            for (int i = 0; i < Values.Count; i++)
            {
                Console.Write(Values[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Printing Ints: ");
            for (int i = 0; i < ints.Count; i++)
            {
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine();
            //insert at specfic positon
            ints.Insert(2, 24);
            Console.WriteLine("After insert at specfic position");
            for (int i = 0; i < ints.Count; i++)
            {
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine();

            Console.Write("Checking if spcific value is in list: ");
            Console.WriteLine(ints.Contains(24));
            Console.WriteLine("Reverce the List :");
            ints.Reverse();
            for (int i = 0; i < ints.Count; i++)
            {
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine();

            int[] arr1;
            Console.WriteLine("Convert list to Array : ");
            arr1 = ints.ToArray();
            Console.WriteLine(arr1 + " ");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(arr1[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("After converstion check the List: ");
            for (int i = 0; i < ints.Count; i++)
            {
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Using the lamda function at RemoveAll : ");
            ints.RemoveAll(x => x == 24);
            for (int i = 0; i < ints.Count; i++)
            {
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine();

        }
        public static void Stackvalue()
        {
            Stack<int> stack = new Stack<int>();
            Console.WriteLine("Enter the adding size of stack : ");
            int size = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < size; i++)
            {
                stack.Push(Convert.ToInt32(Console.ReadLine()));
            }

            Console.Write(stack.Peek() + " ");
            Console.WriteLine("Using the pop operation and after that : ");

            Console.WriteLine("Checking the values of stack : ");
            foreach (int i in stack)
            {
                Console.WriteLine(i + " ");
            }
            stack.Pop();
            Console.WriteLine(stack.Peek());
            Console.WriteLine("Checking the size of stack : ");
            Console.WriteLine("Check if the value present in stack : ");
            Console.WriteLine(stack.Contains(32));


        }

        public static void Queuevalue()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            foreach (int am in queue)
            {
                Console.Write(am + " ");

            }
            Console.WriteLine();
            Console.WriteLine("Removing item and print : ");
            queue.Dequeue();
            foreach (int am in queue)
            {
                Console.Write(am + " ");

            }
            Console.WriteLine();

        }
        public static void Hashsetvalue()
        {
            HashSet<String> Days = new HashSet<String>();
            Days.Add("Mon");
            Days.Add("Tues");
            Days.Add("Wed");
            Console.WriteLine("Printing the Days hashset : ");
            foreach (String day in Days)
            {
                Console.Write(day + " ");

            }
            Console.WriteLine();
            HashSet<String> Days2 = new HashSet<String>();
            Days2.Add("Mon");
            Days2.Add("Thur");
            Days2.Add("Thur");
            Days2.Add("Sat");
            Days2.Add("Sun");

            Console.WriteLine("Printing the Days2 Hashset :");
            foreach (String day in Days2)
            {
                Console.Write(day + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Adding 2 hashsets :");
            Days.UnionWith(Days2);
            foreach (String day in Days)
            {
                Console.Write(day + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Taking maching Elements from 2 sets:");
            Days.IntersectWith(Days2);
            foreach (String day in Days2)
            {
                Console.Write(day + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Get the non maching elments of 1st from 2nd -- Days.ExceptWith(Days2) : ");
            Console.WriteLine("Get the non matching elemnts from 1 to 2 and 2 to 1 -- Days.SymmetricExceptWith(Days2) : ");
        }
        public static void Dictionaryvalue()
        {
            Dictionary<int, String> order = new Dictionary<int, String>();
            order.Add(1, "abc");
            order.Add(2, "def");
            order.Add(3, "ghi");
            order.Add(4, "jkl");

            Console.WriteLine("for each loop printing Dictionary :");
            foreach (KeyValuePair<int, String> i in order)
            {
                Console.Write(i + " ");
            }
        }
    }
}