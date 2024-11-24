using System.ComponentModel.DataAnnotations;

namespace movie_review.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Description { get; set; }

        [Required]
        public string Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Director { get; set; }

        public int Duration { get; set; } // Duration in minutes

        public ICollection<MovieReview> Reviews { get; set; } // Navigation property for reviews
        public ICollection<MovieListMovie> MovieListMovies { get; set; }
    }
}