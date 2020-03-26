using System;
using System.Collections.Generic;
using University.DAL;
using University.DAL.Models;
using University.DAL.Repositories;

namespace University.ConsoleUI
{
    class Program
    {
        static private UnitOfWork unitOfWork;

        static void Main(string[] args)
        {
            HandleMenuDesicion(DisplayMenu());
        }

        //
        // Student Methods.
        //

        private static void AddStudent()
        {
            unitOfWork = new UnitOfWork();

            Console.WriteLine("You chose (1) Add.");
            Console.WriteLine("Please, enter First Name:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Please, enter Last Name:");
            var lastName = Console.ReadLine();

            Console.WriteLine("Please, enter CourseID:");
            var course = Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Would you like to add?");
            Console.WriteLine($"{firstName} {lastName}, Course - {course}");

            Console.WriteLine("\nPress Y or N:");
            var decision = Console.ReadLine();
            switch (decision)
            {
                case "y":
                    {
                        var newStudent = new Student()
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Course = unitOfWork.CourseRepository.GetByID(course)
                        };

                        unitOfWork.StudentRepository.Insert(newStudent);
                        unitOfWork.Save();
                        unitOfWork.Dispose();

                        Console.Clear();
                        Console.WriteLine("\nStudent is added.");

                        Console.WriteLine("\nPress M to back");
                        var result = Console.ReadLine();
                        if (result == "m")
                        {
                            DisplayStudentsMenu();
                        }
                        break;
                    }
                case "n":
                    DisplayStudentsMenu();
                    break;
            }
        }

        private static void DeleteStudent()
        {
            unitOfWork = new UnitOfWork();

            Console.WriteLine("You chose (2) Delete.");
            Console.WriteLine("Please, enter StudentID:");
            var studentId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Would you like to delete?");
            var studentToDelete = unitOfWork.StudentRepository.GetByID(studentId);
            Console.WriteLine(studentToDelete);

            Console.WriteLine("\nPress Y or N:");
            var decision = Console.ReadLine();
            switch (decision)
            {
                case "y":
                    {
                        unitOfWork.StudentRepository.Delete(studentId);
                        unitOfWork.Save();
                        unitOfWork.Dispose();

                        Console.Clear();
                        Console.WriteLine("\nStudent is deleted.");

                        Console.WriteLine("\nPress M to back");
                        var result = Console.ReadLine();
                        if (result == "m")
                        {
                            DisplayStudentsMenu();
                        }
                        break;
                    }
                case "n":
                    DisplayStudentsMenu();
                    break;
            }
        }

        private static void UpdateStudent()
        {
            unitOfWork = new UnitOfWork();

            Console.WriteLine("You chose (3) Update.");
            Console.WriteLine("Please, enter StudentID:");
            var studentID = Int32.Parse(Console.ReadLine());
            var selectedStudent = unitOfWork.StudentRepository.GetByID(studentID);

            Console.Clear();

            Console.WriteLine("You chose student:");
            Console.WriteLine(selectedStudent);

            Console.WriteLine("\nPlease, choose attribute which you want to update:");

            Console.WriteLine("1 - First name");
            Console.WriteLine("2 - Last name");
            Console.WriteLine("3 - Course ID");
            Console.WriteLine("m - Back to menu");

            var attributeResult = Console.ReadLine();

            Console.Clear();

            UpdateStudentAttributeMenu(selectedStudent, attributeResult);
        }

        private static void DisplayAllStudents()
        {
            unitOfWork = new UnitOfWork();

            var students = unitOfWork.StudentRepository.Get();

            Console.WriteLine("Here is all students:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("\nPress M to back");
            var decision = Console.ReadLine();
            if (decision == "m")
            {
                DisplayStudentsMenu();
            }
        }

        //
        // Course Methods.
        //

        private static void AddCourse()
        {
            unitOfWork = new UnitOfWork();

            Console.WriteLine("You chose (1) Add.");
            Console.WriteLine("Please, enter course Name:");
            var courseName = Console.ReadLine();

            Console.WriteLine("Please, enter DepartmnetID:");
            var department = Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Would you like to add?");
            Console.WriteLine($"Name - {courseName}, Department - {department}");

            Console.WriteLine("\nPress Y or N:");
            var decision = Console.ReadLine();
            switch (decision)
            {
                case "y":
                    {
                        var newCourse = new Course()
                        {
                            Name = courseName,
                            Department = unitOfWork.DepartmentRepository.GetByID(department),
                        };

                        unitOfWork.CourseRepository.Insert(newCourse);
                        unitOfWork.Save();
                        unitOfWork.Dispose();

                        Console.Clear();
                        Console.WriteLine("\nCourse is added.");

                        Console.WriteLine("\nPress M to back");
                        var result = Console.ReadLine();
                        if (result == "m")
                        {
                            DisplayCoursesMenu();
                        }
                        break;
                    }
                case "n":
                    DisplayCoursesMenu();
                    break;
            }

        }

        private static void DeleteCourse()
        {
            unitOfWork = new UnitOfWork();

            Console.WriteLine("You chose (2) Delete.");
            Console.WriteLine("Please, enter CourseID:");
            var courseId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Would you like to delete?");
            var courseToDelete = unitOfWork.CourseRepository.GetByID(courseId);
            Console.WriteLine(courseToDelete);

            Console.WriteLine("\nPress Y or N:");
            var decision = Console.ReadLine();
            switch (decision)
            {
                case "y":
                    {
                        unitOfWork.CourseRepository.Delete(courseId);
                        unitOfWork.Save();
                        unitOfWork.Dispose();

                        Console.Clear();
                        Console.WriteLine("\nCourse is deleted.");

                        Console.WriteLine("\nPress M to back");
                        var result = Console.ReadLine();
                        if (result == "m")
                        {
                            DisplayCoursesMenu();
                        }
                        break;
                    }
                case "n":
                    DisplayCoursesMenu();
                    break;
            }
        }

        private static void UpdateCourse()
        {
            unitOfWork = new UnitOfWork();

            Console.WriteLine("You chose (3) Update.");
            Console.WriteLine("Please, enter CourseID:");
            var courseId = Int32.Parse(Console.ReadLine());
            var selectedCourse = unitOfWork.CourseRepository.GetByID(courseId);

            Console.Clear();

            Console.WriteLine("You chose course:");
            Console.WriteLine(selectedCourse);

            Console.WriteLine("\nPlease, choose attribute which you want to update:");

            Console.WriteLine("1 - Name");
            Console.WriteLine("2 - Department ID");
            Console.WriteLine("m - Back to menu");

            var attributeResult = Console.ReadLine();

            Console.Clear();

            UpdateCourseAttributeMenu(selectedCourse, attributeResult);
        }

        private static void DisplayAllCourses()
        {
            unitOfWork = new UnitOfWork();

            var courses = unitOfWork.CourseRepository.Get();

            Console.WriteLine("Here is all courses:");
            foreach (var course in courses)
            {
                Console.WriteLine(course);
            }

            Console.WriteLine("\nPress M to back");
            var decision = Console.ReadLine();
            if (decision == "m")
            {
                DisplayCoursesMenu();
            }
        }

        //
        // Department Methods.
        //

        private static void AddDepartment()
        {
            unitOfWork = new UnitOfWork();

            Console.WriteLine("You chose (1) Add.");
            Console.WriteLine("Please, enter department Name:");
            var departmentName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Would you like to add?");
            Console.WriteLine($"Name - {departmentName}");

            Console.WriteLine("\nPress Y or N:");
            var decision = Console.ReadLine();
            switch (decision)
            {
                case "y":
                    {
                        var newDepartment = new Department()
                        {
                            Name = departmentName,
                        };

                        unitOfWork.DepartmentRepository.Insert(newDepartment);
                        unitOfWork.Save();
                        unitOfWork.Dispose();

                        Console.Clear();
                        Console.WriteLine("\nDepartment is added.");

                        Console.WriteLine("\nPress M to back");
                        var result = Console.ReadLine();
                        if (result == "m")
                        {
                            DisplayDepartmentsMenu();
                        }
                        break;
                    }
                case "n":
                    DisplayDepartmentsMenu();
                    break;
            }

        }

        private static void DeleteDepatment()
        {
            unitOfWork = new UnitOfWork();

            Console.WriteLine("You chose (2) Delete.");
            Console.WriteLine("Please, enter DepartmentID:");
            var departmentId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Would you like to delete?");
            var departmentToDelete = unitOfWork.DepartmentRepository.GetByID(departmentId);
            Console.WriteLine(departmentToDelete);

            Console.WriteLine("\nPress Y or N:");
            var decision = Console.ReadLine();
            switch (decision)
            {
                case "y":
                    {
                        unitOfWork.DepartmentRepository.Delete(departmentId);
                        unitOfWork.Save();
                        unitOfWork.Dispose();

                        Console.Clear();
                        Console.WriteLine("\nDepartment is deleted.");

                        Console.WriteLine("\nPress M to back");
                        var result = Console.ReadLine();
                        if (result == "m")
                        {
                            DisplayDepartmentsMenu();
                        }
                        break;
                    }
                case "n":
                    DisplayDepartmentsMenu();
                    break;
            }
        }

        private static void UpdateDepartment()
        {
            unitOfWork = new UnitOfWork();

            Console.WriteLine("You chose (3) Update.");
            Console.WriteLine("Please, enter DepartmentID:");
            var departmentId = Int32.Parse(Console.ReadLine());
            var selectedDepartment = unitOfWork.DepartmentRepository.GetByID(departmentId);

            Console.Clear();

            Console.WriteLine("You chose department:");
            Console.WriteLine(selectedDepartment);

            Console.WriteLine("\nPlease, choose attribute which you want to update:");

            Console.WriteLine("1 - Name");
            Console.WriteLine("m - Back to menu");

            var attributeResult = Console.ReadLine();

            Console.Clear();

            UpdateDepartmentAttributeMenu(selectedDepartment, attributeResult);
        }

        private static void DisplayAllDepartments()
        {
            unitOfWork = new UnitOfWork();

            var departments = unitOfWork.DepartmentRepository.Get();

            Console.WriteLine("Here is all courses:");
            foreach (var department in departments)
            {
                Console.WriteLine(department);
            }

            Console.WriteLine("\nPress M to back");
            var decision = Console.ReadLine();
            if (decision == "m")
            {
                DisplayDepartmentsMenu();
            }
        }

        //
        // Menu Methods.
        //

        private static string DisplayMenu()
        {
            Console.WriteLine("Please, choose the entity to display");
            Console.WriteLine("1 - Students");
            Console.WriteLine("2 - Courses");
            Console.WriteLine("3 - Departments");
            var entityResult = Console.ReadLine();
            Console.Clear();

            return entityResult;
        }

        private static void HandleMenuDesicion(string entityResult)
        {
            switch (entityResult)
            {
                case "1":
                    {
                        DisplayStudentsMenu();
                        break;
                    }
                case "2":
                    {
                        DisplayCoursesMenu();
                        break;
                    }
                case "3":
                    {
                        DisplayDepartmentsMenu();
                        break;
                    }
                default:
                    throw new Exception("Wrong Option! Try again!");
            }
        }

        private static void DisplayStudentsMenu()
        {
            Console.Clear();

            Console.WriteLine("You chose (1) Students.");
            Console.WriteLine("Choose option:");
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Delete");
            Console.WriteLine("3 - Update");
            Console.WriteLine("4 - Display all students");
            Console.WriteLine("m - Back to menu");

            string studentResult = Console.ReadLine();
            Console.Clear();

            switch (studentResult)
            {
                case "1":
                    {
                        AddStudent();
                    }
                    break;
                case "2":
                    {
                        DeleteStudent();
                    }
                    break;
                case "3":
                    {
                        UpdateStudent();
                    }
                    break;
                case "4":
                    {
                        DisplayAllStudents();
                    }
                    break;

                case "m":
                    {
                        HandleMenuDesicion(DisplayMenu());
                    }
                    break;
            }
        }

        private static void DisplayCoursesMenu()
        {
            Console.Clear();

            Console.WriteLine("You chose (2) Courses");
            Console.WriteLine("Choose option:");
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Delete");
            Console.WriteLine("3 - Update");
            Console.WriteLine("4 - Display all courses");
            Console.WriteLine("m - Back to menu");

            var courseResult = Console.ReadLine();
            Console.Clear();

            switch (courseResult)
            {
                case "1":
                    {
                        AddCourse();
                    }
                    break;
                case "2":
                    {
                        DeleteCourse();
                    }
                    break;
                case "3":
                    {
                        UpdateCourse();
                    }
                    break;
                case "4":
                    {
                        DisplayAllCourses();
                    }
                    break;

                case "m":
                    {
                        HandleMenuDesicion(DisplayMenu());
                    }
                    break;
            }
        }

        private static void DisplayDepartmentsMenu()
        {
            Console.Clear();

            Console.WriteLine("You chose (3) Departments");
            Console.WriteLine("Choose option:");
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Delete");
            Console.WriteLine("3 - Update");
            Console.WriteLine("4 - Display all courses");
            Console.WriteLine("m - Back to menu");

            var departmentResult = Console.ReadLine();
            Console.Clear();

            switch (departmentResult)
            {
                case "1":
                    {
                        AddDepartment();
                    }
                    break;
                case "2":
                    {
                        DeleteDepatment();
                    }
                    break;
                case "3":
                    {
                        UpdateDepartment();
                    }
                    break;
                case "4":
                    {
                        DisplayAllDepartments();
                    }
                    break;

                case "m":
                    {
                        HandleMenuDesicion(DisplayMenu());
                    }
                    break;
            }
        }

        private static void UpdateStudentAttributeMenu(Student student, string attributeResult)
        {
            switch (attributeResult)
            {
                case "1":
                    {
                        Console.WriteLine($"You want to change First name - {student.FirstName}");
                        Console.WriteLine("Please, enter a new one:");
                        var firstName = Console.ReadLine();

                        Console.WriteLine("Press Y or N to save:");
                        var decision = Console.ReadLine();
                        switch (decision)
                        {
                            case "y":
                                {
                                    student.FirstName = firstName;
                                    unitOfWork.StudentRepository.Update(student);
                                    unitOfWork.Save();
                                    unitOfWork.Dispose();

                                    Console.Clear();
                                    Console.WriteLine("Student's first name is updated.");

                                    Console.WriteLine("\nPress M to back");
                                    var result = Console.ReadLine();
                                    if (result == "m")
                                    {
                                        DisplayStudentsMenu();
                                    }
                                    break;
                                }
                            case "n":
                                UpdateStudent();
                                break;
                        }
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine($"You want to change Last name - {student.LastName}");
                        Console.WriteLine("Please, enter a new one:");
                        var lastName = Console.ReadLine();

                        Console.WriteLine("Press Y or N to save:");
                        var decision = Console.ReadLine();
                        switch (decision)
                        {
                            case "y":
                                {
                                    student.LastName = lastName;
                                    unitOfWork.StudentRepository.Update(student);
                                    unitOfWork.Save();
                                    unitOfWork.Dispose();

                                    Console.Clear();
                                    Console.WriteLine("\nStudent's last name is updated.");

                                    Console.WriteLine("\nPress M to back");
                                    var result = Console.ReadLine();
                                    if (result == "m")
                                    {
                                        DisplayStudentsMenu();
                                    }
                                    break;
                                }
                            case "n":
                                UpdateStudent();
                                break;
                        }
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("You want to change Course");
                        Console.WriteLine("Please, enter a new one:");
                        var course = Int32.Parse(Console.ReadLine());

                        student.Course = unitOfWork.CourseRepository.GetByID(course);
                        unitOfWork.StudentRepository.Update(student);
                        unitOfWork.Save();
                        unitOfWork.Dispose();

                        Console.Clear();
                        Console.WriteLine("\nStudent's course is updated.");

                        Console.WriteLine("\nPress M to back");
                        var result = Console.ReadLine();
                        if (result == "m")
                        {
                            DisplayStudentsMenu();
                        }
                        break;
                    }
                case "m":
                    {
                        DisplayMenu();
                        break;
                    }
            }
        }

        private static void UpdateCourseAttributeMenu(Course course, string attributeResult)
        {
            switch (attributeResult)
            {
                case "1":
                    {
                        Console.WriteLine($"You want to change Name - {course.Name}");
                        Console.WriteLine("Please, enter a new one:");
                        var courseName = Console.ReadLine();

                        Console.WriteLine("Press Y or N to save:");
                        var decision = Console.ReadLine();
                        switch (decision)
                        {
                            case "y":
                                {
                                    course.Name = courseName;
                                    unitOfWork.CourseRepository.Update(course);
                                    unitOfWork.Save();
                                    unitOfWork.Dispose();

                                    Console.Clear();
                                    Console.WriteLine("Course's name is updated.");

                                    Console.WriteLine("\nPress M to back");
                                    var result = Console.ReadLine();
                                    if (result == "m")
                                    {
                                        DisplayCoursesMenu();
                                    }
                                    break;
                                }
                            case "n":
                                UpdateCourse();
                                break;
                        }
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("You want to change Department");
                        Console.WriteLine("Please, enter a new one:");
                        var department = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("\nPress Y or N to save:");
                        var decision = Console.ReadLine();
                        switch (decision)
                        {
                            case "y":
                                {
                                    course.Department = unitOfWork.DepartmentRepository.GetByID(department);
                                    unitOfWork.CourseRepository.Update(course);
                                    unitOfWork.Save();
                                    unitOfWork.Dispose();

                                    Console.Clear();
                                    Console.WriteLine("\nCourse's department is updated.");

                                    Console.WriteLine("\nPress M to back");
                                    var result = Console.ReadLine();
                                    if (result == "m")
                                    {
                                        DisplayCoursesMenu();
                                    }
                                    break;
                                }
                            case "n":
                                UpdateCourse();
                                break;
                        }
                        break;
                    }
                case "m":
                    {
                        DisplayMenu();
                        break;
                    }
            }
        }

        private static void UpdateDepartmentAttributeMenu(Department department, string attributeResult)
        {
            switch (attributeResult)
            {
                case "1":
                    {
                        Console.WriteLine($"You want to change Name - {department.Name}");
                        Console.WriteLine("Please, enter a new one:");
                        var departmentName = Console.ReadLine();

                        Console.WriteLine("Press Y or N to save:");
                        var decision = Console.ReadLine();
                        switch (decision)
                        {
                            case "y":
                                {
                                    department.Name = departmentName;
                                    unitOfWork.DepartmentRepository.Update(department);
                                    unitOfWork.Save();
                                    unitOfWork.Dispose();

                                    Console.Clear();
                                    Console.WriteLine("Department's name is updated.");

                                    Console.WriteLine("\nPress M to back");
                                    var result = Console.ReadLine();
                                    if (result == "m")
                                    {
                                        DisplayDepartmentsMenu();
                                    }
                                    break;
                                }
                            case "n":
                                UpdateDepartment();
                                break;
                        }
                        break;
                    }
                case "m":
                    {
                        DisplayMenu();
                        break;
                    }
            }
        }
    }
}
