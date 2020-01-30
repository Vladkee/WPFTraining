using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTask2._0
{
    public class Handler
    {
        public Student myStudent { get; set; }

        public Handler()
        {
            this.myStudent = new Student("Vadik", "Oladik", true);
        }
    }
}
