using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDb.FluentAPI.Model
{
    public class Genre
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<MovieGenre> MovieGenres { get; set; }
    }
}
