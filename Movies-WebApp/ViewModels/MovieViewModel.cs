using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Movies_WebApp.ViewModels
{
    public class MovieViewModel
    {
        [Required, StringLength(255)]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required, StringLength(2500)]
        [DataType(DataType.MultilineText)]
        public string Storyline { get; set; }

        [DataType(DataType.Date)]
        public int Year { get; set; }

        [Required, Range(1, 10)]
        public double Rate { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(100)]
        public string Language { get; set; }

        [DataType(DataType.Upload)]
        public byte[] Poster { get; set; }

        [StringLength(255)]
        [DataType(DataType.ImageUrl)]
        public string Url { get; set; }

        [DisplayName("Genre")]
        public byte GenreId { get; set; }

    }
}
