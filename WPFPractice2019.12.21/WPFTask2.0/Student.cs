using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTask2._0
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool MasterDegree { get; set; }

        public Student(string firstName, string lastName, bool masterDegree)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MasterDegree = masterDegree;
        }
    }
}
