using System;
using System.Collections.Generic;
using System.Text;

namespace Student_DAL.Model
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public Student Student { get; set; }
    }
}