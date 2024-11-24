namespace movie_review.Models
{
    public class MovieListMovie
    {
        public int MovieListId { get; set; } // Foreign key to MovieList
        public MovieList MovieList { get; set; } // Navigation property for MovieList

        public int MovieId { get; set; } // Foreign key to Movie
        public Movie Movie { get; set; } // Navigation property for Movie
    }
}
