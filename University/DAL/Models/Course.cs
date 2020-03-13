using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace University.DAL.Models
{
    public class Course
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual Department Department { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
