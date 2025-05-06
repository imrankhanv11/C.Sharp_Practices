using System;
using System.Collections.Generic;
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

            return;
        }
        public void AddTeacher()
        {
            Console.Write("Enter the Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter the subject : ");
            string subject = Console.ReadLine();

            Person teach = new Teacher(id++, name, subject);
            details.Add(teach);

            return;

        }
        public void ShowList()
        {
            foreach(Person person in details)
            {
                Console.WriteLine(person.Id);
                Console.WriteLine(person.Name);
                if(person is Student st)
                {
                    Console.WriteLine(st.Grade);
                }
                if(person is Teacher teacher)
                {
                    Console.WriteLine(teacher.Subject);
                }
            }

        }
    }
}
