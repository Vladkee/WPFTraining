using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieDb.FluentAPI.Model
{
    public class Director
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        public List<MovieDirection> MovieDirections { get; set; }
    }
}
