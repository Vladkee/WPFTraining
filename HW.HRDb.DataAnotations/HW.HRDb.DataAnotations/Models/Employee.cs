using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW.HRDb.DataAnotations.Models
{
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        [MaxLength(25)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        public decimal Commission { get; set; }

        public int ManagerId { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int JobId { get; set; }

        public Job Job { get; set; }

        public JobHistory JobHistory { get; set; }
    }
}
