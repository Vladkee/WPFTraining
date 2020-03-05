using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDb.FluentAPI.Model
{
    public class Actor
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [MaxLength(1)]
        public string Gender { get; set; }

        public List<MovieCast> MovieCasts { get; set; }
    }
}
