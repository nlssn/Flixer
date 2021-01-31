using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flixer.Models
{
    public class Movie
    {
        // Properties
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Year { get; set; }

        public bool Watched { get; set; } = false;

        [Range(0, 10)]
        public int Score { get; set; } = 0;

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
