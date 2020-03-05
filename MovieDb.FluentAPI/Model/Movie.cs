using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDb.FluentAPI.Model
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public int Time { get; set; }

        public string Language { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string ReleaseCountry { get; set; }

        public List<MovieCast> MovieCasts { get; set; }

        public List<MovieDirection> MovieDirections { get; set; }

        public List<Rating> Ratings { get; set; }

        public List<MovieGenre> MovieGenres { get; set; }
    }
}
