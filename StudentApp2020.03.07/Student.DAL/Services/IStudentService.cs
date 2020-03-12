using System.Collections.Generic;
using Student_DAL.Model;

namespace Student_DAL.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        void SaveStudents();

        void RemoveStudent(Student student);
    }
}