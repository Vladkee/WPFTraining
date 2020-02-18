using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW.HRDb.DataAnotations.Models
{
    public class Job
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        [MaxLength(35)]
        public string JobTitle { get; set; }

        public decimal MinSalary { get; set; }

        public decimal MaxSalary { get; set; }

        public List<Employee> Employees { get; set; }

        public List<JobHistory> JobHistories { get; set; }
    }
}
