using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Movies_WebApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        [Required, MaxLength(2500)]
        public string Storyline { get; set; }

        public int Year { get; set; }

        [Required, Range(0,10)]
        public double Rate { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(100)]
        public string Language { get; set; }
        public byte[] Poster { get; set; }

        [MaxLength(255)]
        public string Url { get; set; }

        [DisplayName("Genre")]
        public byte GenreId { get; set; }
        public Genre Genres { get; set; }


    }
}
