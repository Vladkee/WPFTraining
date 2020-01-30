using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019._01._25CustomerMVVM.Model
{
    public class Customer
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {City}";
        }
    }

}
