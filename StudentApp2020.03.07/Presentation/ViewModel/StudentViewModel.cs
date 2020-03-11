using Presentation.Extensions;
using Student_DAL.Model;
using Student_DAL.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Presentation.ViewModel
{
    public class StudentViewModel : ViewModelBase.ViewModelBase
    {
        private ObservableCollection<Student> students;

        private Student selectedStudent;

        private Book selectedBook;

        private readonly IStudentService studentService;

        public StudentViewModel(IStudentService studentService)
        {
            if (studentService == null) throw new ArgumentNullException(nameof(studentService));

            this.studentService = studentService;
            this.Students = new ObservableCollection<Student>();

            this.GetStudentsCommmand = new DelegateCommand.DelegateCommand(this.ExecuteGetStudents, this.CanGetStudentsExecute);
            this.SaveCommand = new DelegateCommand.DelegateCommand(this.ExecuteSave);
            this.RemoveStudentCommmand = new DelegateCommand.DelegateCommand(this.ExecuteDeleteStudent, this.CanDeleteStudentExecute);
        }

        public ObservableCollection<Student> Students
        {
            get { return this.students; }
            set
            {
                this.students = value;
                OnPropertyChanged();
            }
        }

        public Student SelectedStudent
        {
            get { return this.selectedStudent; }
            set
            {
                this.selectedStudent = value;
                OnPropertyChanged();
            }
        }

        public Book SelectedBook
        {
            get { return this.selectedBook; }
            set
            {
                this.selectedBook = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand.DelegateCommand GetStudentsCommmand { get; }

        public DelegateCommand.DelegateCommand SaveCommand { get; }

        public DelegateCommand.DelegateCommand RemoveStudentCommmand { get; }

        private void ExecuteSave()
        {
            this.studentService.SaveStudents();
            MessageBox.Show("Saved!");
        }

        private void ExecuteGetStudents()
        {
            this.Students = this.studentService.GetStudents().ToObservableCollection();
        }

        private bool CanGetStudentsExecute()
        {
            if (this.Students.Count == 0)
            {
                return true;
            }
            return false;
        }

        private void ExecuteDeleteStudent()
        {
            this.studentService.RemoveStudent(this.SelectedStudent);
            this.ExecuteSave();
            this.ExecuteGetStudents();
        }

        private bool CanDeleteStudentExecute()
        {
            if (this.SelectedStudent != null)
            {
                return true;
            }
            return false;
        }
    }
}