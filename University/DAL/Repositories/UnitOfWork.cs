using System;
using System.Collections.Generic;
using System.Text;
using University.DAL.Models;

namespace University.DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private UniversityDbContext context = new UniversityDbContext();
        private GenericRepository<Department> departmentRepository;
        private GenericRepository<Course> coursetRepository;
        private GenericRepository<Student> studentRepository;
        private bool disposed = false;

        public GenericRepository<Department> DepartmentRepository 
        {
            get
            {
                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Department>(context);
                }
                return departmentRepository;
            }
        }

        public GenericRepository<Course> CourseRepository
        {
            get
            {
                if (this.coursetRepository == null)
                {
                    this.coursetRepository = new GenericRepository<Course>(context);
                }
                return coursetRepository;
            }
        }

        public GenericRepository<Student> StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(context);
                }
                return studentRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
