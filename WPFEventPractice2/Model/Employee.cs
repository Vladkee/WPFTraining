using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFEventPractice2
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public string HiredDate { get; set; }

        public bool IsManager { get; set; }

        public static int Counter { get; set; }

        public Employee(int id, string name, string department, string hiredDate, bool isManager)
        {
            this.Id = id;
            this.Name = name;
            this.Department = department;
            this.HiredDate = hiredDate;
            this.IsManager = isManager;
        }

        public Employee()
        {

        }

        public static ObservableCollection<Employee> GetEmployeeList()
        {
            ObservableCollection<Employee> listOfEmployees = new ObservableCollection<Employee>();

            listOfEmployees.Add(new Employee(1, "Petro Kasini", "Dev", "28/02/1990", true));
            listOfEmployees.Add(new Employee(2, "Maksim Fransua", "GIS", "12/04/2000", false));
            listOfEmployees.Add(new Employee(3, "Dima Bulgov", "Dev", "01/10/2012", false));
            listOfEmployees.Add(new Employee(4, "Olga Laptina", "Marketing", "13/08/2005", false));

            return listOfEmployees;
        }
    }
}
