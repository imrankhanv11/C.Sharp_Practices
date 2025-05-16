using System;
using System.Collections.Generic;

namespace Student_Performance_Tracker
{
    //Main base class
    class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        
        public List<int> StudentMarks { get; set; }

        public Student(int id, string name, List<int>StudentMarks)
        {
            StudentId = id;
            StudentName = name;
            this.StudentMarks = StudentMarks;
        }
    }

    //RegularStudent class inherit from Student

    class RegularStudent : Student
    {
        public string Grade { get; set; }

        public RegularStudent(int id, string name, List<int>StudentMarks, string grade)
            : base(id, name, StudentMarks)
        {
            Grade = grade;
        }
    }

    //ExchangeStudent class inherit from Student

    class ExchangeStudent : Student
    {
        public string Grade { get; set; }

        public ExchangeStudent(int id, string name, List<int>StudentMarks ,string grade)
            : base(id, name, StudentMarks)
        {
            Grade = grade;
        }
    }
}
