using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDb.FluentAPI.Model
{
    public class Reviewer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Rating> Ratings { get; set; }
    }
}
