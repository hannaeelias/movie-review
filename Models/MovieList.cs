using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace movie_review.Models
{
    public class MovieList
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ListName { get; set; }

        // Foreign key for the User table
        public string UserId { get; set; }

        // Reference to IdentityUser
        public IdentityUser User { get; set; }

        public ICollection<MovieListMovie> MovieListMovies { get; set; } // Navigation property for junction table

        public DateTime DateCreated { get; set; }
    }
}
