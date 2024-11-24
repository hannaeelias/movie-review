using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using movie_review.Models;

namespace movie_review.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Add DbSets for your custom models
        public DbSet<MovieList> MovieLists { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieListMovie> MovieListMovies { get; set; }

        // You can also configure relationships here if needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define composite primary key for MovieListMovie
            modelBuilder.Entity<MovieListMovie>()
                .HasKey(mlm => new { mlm.MovieListId, mlm.MovieId });

            // Define relationships
            modelBuilder.Entity<MovieListMovie>()
                .HasOne(mlm => mlm.MovieList)
                .WithMany(ml => ml.MovieListMovies)
                .HasForeignKey(mlm => mlm.MovieListId);

            modelBuilder.Entity<MovieListMovie>()
                .HasOne(mlm => mlm.Movie)
                .WithMany()
                .HasForeignKey(mlm => mlm.MovieId);

            // Seeding Data (Adjust seed data as needed)
            var user = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@example.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            modelBuilder.Entity<IdentityUser>().HasData(user);

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Inception", Director = "Christopher Nolan", Genre = "Sci-Fi", Description = "A mind-bending thriller about dreams within dreams.", Duration = 148, ReleaseDate = new DateTime(2010, 7, 16), IsDeleted = false },
                new Movie { Id = 2, Title = "The Dark Knight", Director = "Christopher Nolan", Genre = "Action", Description = "Batman battles the Joker in a fight for Gotham's soul.", Duration = 152, ReleaseDate = new DateTime(2008, 7, 18), IsDeleted = false }
            );

            modelBuilder.Entity<MovieList>().HasData(
                new MovieList { Id = 1, ListName = "Favorites", UserId = user.Id, DateCreated = DateTime.Now }
            );

            modelBuilder.Entity<MovieListMovie>().HasData(
                new MovieListMovie { MovieListId = 1, MovieId = 1 },
                new MovieListMovie { MovieListId = 1, MovieId = 2 }
            );

            modelBuilder.Entity<MovieReview>().HasData(
                new MovieReview { Id = 1, MovieId = 1, UserId = user.Id, Rating = 5, ReviewText = "Incredible movie! A must-see for anyone interested in complex narratives.", DateCreated = DateTime.Now },
                new MovieReview { Id = 2, MovieId = 2, UserId = user.Id, Rating = 5, ReviewText = "A masterpiece of superhero cinema. Heath Ledger's Joker is iconic.", DateCreated = DateTime.Now }
            );
        }
    }
}
