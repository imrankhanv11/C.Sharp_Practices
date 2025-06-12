using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_Learning
{
    class Process : Services
    {
        static int id = 100;
        List<Person> details = new List<Person>();

        public void AddStudent()
        {
            Console.Write("Enter the Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter the Grade : ");
            string grade = Console.ReadLine();

            Person stud = new Student(id++, name, grade);

            details.Add(stud);
        }
        public void AddTeacher()
        {
            Console.Write("Enter the Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter the Grade : ");
            string subject = Console.ReadLine();

            Teacher teach = new Teacher(id++, name, subject);

            details.Add(teach);

        }
        public void ShowList()
        {
            foreach (Person person in details)
            {
                Console.WriteLine(person.Id);
                Console.WriteLine(person.Name);
                if (person is Student st)
                {
                    Console.WriteLine(st.Grade);
                }
                if (person is Teacher teacher)
                {
                    Console.WriteLine(teacher.Subject);
                }
            }

        }
    }
}
