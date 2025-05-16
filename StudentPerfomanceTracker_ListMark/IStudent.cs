using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance_Tracker
{
    internal interface IStudent
    {
        //interface methods

        //add new student
        void AddStudentDetails(Student student);

        //display all student details
        void DisplayStudentDetails();

        //delete student details using id
        void delteStudentDetails(int deleteId);

        //search student detials usng id or name
        void StudentSearch(int searchId, string serachName);

        //display student details by all grade
        void DisplayByGrade();

        //check student details present or not
        bool StudentCheck(int checkId);

        //update student all details using id
        void updateStudentAll(int upId);

        //update student details specific one using id
        void updateStudentSpecific(int upId);

        //display student grade count
        void DisplayCount_Grade();
    }
}
