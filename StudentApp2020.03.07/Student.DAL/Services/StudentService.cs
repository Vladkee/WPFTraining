using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Student_DAL.Model;

namespace Student_DAL.Services
{
    public class StudentService : IStudentService
    {
        private StudentContext context;
        public StudentService()
        {
            this.context = new StudentContext();
        }

        public IEnumerable<Student> GetStudents()
        {
            return this.context.Students.Include(b => b.Books).Include(a =>a.StudentAddress);
        }

        public void RemoveStudent(Student student)
        {
            this.context.Students.Remove(student);
        }

        public void SaveStudents()
        {
            this.context.SaveChanges();
        }
    }
}