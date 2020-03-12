using System;
using System.Collections.Generic;
using System.Text;

namespace Student_DAL.Model
{
    public class Address
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string StreetAddress { get; set; }

        public string PostalCode { get; set; }

        public Student Student { get; set; }

        public override string ToString()
        {
            return $"{StreetAddress}\n{City}\n{Country}\n{PostalCode}";
        }
    }
}
