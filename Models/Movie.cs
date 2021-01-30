using System;

namespace Flixer.Models
{
    public class Movie
    {
        // Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }
        public bool Watched { get; set; }
        public int Score { get; set; }

        // Parameterless constructor
        public Movie()
        {
            
        }

        // Constructor
        public Movie(int id, string title, string genre, string year, bool watched, int score)
        {
            this.Id = id;
            this.Title = title;
            this.Genre = genre;
            this.Year = year;
            this.Watched = watched;
            this.Score = score;
        }
    }
}
