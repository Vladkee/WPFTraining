using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDb.FluentAPI.Model
{
    public class Rating
    {
        public int MovieId { get; set; }

        public int ReviewId { get; set; }

        public int ReviewStars { get; set; }

        public int NumberOfRatings { get; set; }

        public Movie Movie { get; set; }

        public Reviewer Reviewer { get; set; }
    }
}
