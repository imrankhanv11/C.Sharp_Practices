using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_Learning
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
    public class Student : Person
    {
        public string Grade { get; set; }
        public Student(int id, string name, string grade)
            : base (id, name)
        {
            Grade = grade;
        }
    }
    class Teacher : Person
    {
        public string Subject {  get; set; }
        public Teacher(int id, string name, string subject)
            : base(id, name)
        {
            Subject = subject;
        }
    }
}
