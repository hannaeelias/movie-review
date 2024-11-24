using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
    
namespace movie_review.Models
{
    public class MovieReview
    {
        public int Id { get; set; }

        [Range(1, 10)] // Rating scale 1-10
        public int Rating { get; set; }

        public string ReviewText { get; set; } = string.Empty;

        public string UserId { get; set; } // Foreign key to the User table
        public IdentityUser User { get; set; } // Navigation property for the user who wrote the review

        public int MovieId { get; set; } // Foreign key to the Movie table
        public Movie Movie { get; set; } // Navigation property for the movie being reviewed
        
        public DateTime DateCreated { get; set; }
    }
}