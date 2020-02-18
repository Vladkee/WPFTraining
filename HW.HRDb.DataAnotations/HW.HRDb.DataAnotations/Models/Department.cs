using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW.HRDb.DataAnotations.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(30)]
        public string DepartmentName { get; set; }

        public int ManagerId { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public List<JobHistory> JobHistories { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
