using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW.HRDb.DataAnotations.Models
{
    public class JobHistory
    {
        public int EmployeeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int JobId { get; set; }

        public Job Job { get; set; }

        public List<Employee> Employees { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
