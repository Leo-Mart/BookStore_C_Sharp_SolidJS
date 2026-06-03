using Microsoft.EntityFrameworkCore;
using someboeoeks.Models.Authors;
using someboeoeks.Models.Books;
using someboeoeks.Models.Genres;
using someboeoeks.Models.Reviews;
using someboeoeks.Models.Users;

namespace someboeoeks.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = 1,
                    Isbn = "9713196ajdhadhjakhd",
                    Title = "Gardens of the Moon",
                    Publisher = "A publisher",
                    PublishedDate = new DateTime(2026, 1, 1),
                    Description = "The malazan something something",
                    Price = 102,
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new Book()
                {
                    Id = 2,
                    Isbn = "9713196ajdhadhjakhd",
                    Title = "Pride and Prejudice",
                    Publisher = "T. Egerton, Whitehall",
                    PublishedDate = new DateTime(1813, 1, 28),
                    Description = "MR DARCY!",
                    Price = 1337,
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new Book()
                {
                    Id = 3,
                    Isbn = "9713196ajdhadhjakhd",
                    Title = "House of Leaves",
                    Publisher = "A publisher",
                    PublishedDate = new DateTime(2020, 5, 11),
                    Description = "a house of leaves",
                    Price = 150,
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review()
                {
                    Id = 1,
                    BookId = 1,
                    UserId = 2,
                    Title = "Such a good series",
                    Text = "Wow. So good.",
                    Score = 5,
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new Review()
                {
                    Id = 2,
                    BookId = 1,
                    UserId = 1,
                    Title = "Such a bad series",
                    Text = "Wow. So bad.",
                    Score = 1,
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new Review()
                {
                    Id = 3,
                    BookId = 2,
                    UserId = 2,
                    Title = "He is so dreamy",
                    Text = "Wow. So dreamy.",
                    Score = 5,
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new Review()
                {
                    Id = 4,
                    BookId = 2,
                    UserId = 1,
                    Title = "She is so dreamy",
                    Text = "Wow. So dreamy.",
                    Score = 5,
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new Review()
                {
                    Id = 5,
                    BookId = 3,
                    UserId = 2,
                    Title = "It's bigger on the inside!",
                    Text = "Wow, so dark.",
                    Score = 5,
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new Review()
                {
                    Id = 6,
                    BookId = 3,
                    UserId = 2,
                    Title = "3Spooky5Me",
                    Text = "So spooky and weird",
                    Score = 1,
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new Review()
                {
                    Id = 7,
                    BookId = 3,
                    UserId = 1,
                    Title = "Test review",
                    Text = "So spooky and weird",
                    Score = 1,
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                }

            );
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Mr.",
                    LastName = "Test",
                    Email = "mrtest@test.com",
                    Phone = "0123456789",
                    Password = "uhohplaintext",
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Mrs.",
                    LastName = "Test",
                    Email = "mrstest@test.com",
                    Phone = "987654321",
                    Password = "encryptmeplease",
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = 1,
                    FirstName = "Steven",
                    LastName = "Eriksson",
                    Bio = "Canadian?",
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new Author()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Austen",
                    Bio = "English?",
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new Author()
                {
                    Id = 3,
                    FirstName = "Mark",
                    LastName = "Z. Danielewski",
                    Bio = "no clue where this dude is from, could google it, but...",
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre()
                {
                    Id = 1,
                    Name = "Fantasy",
                    Description = "Here be dragons",
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new Genre()
                {
                    Id = 2,
                    Name = "Romance",
                    Description = "Smooches",
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new Genre()
                {
                    Id = 3,
                    Name = "Horror",
                    Description = "Spooky-scary skeletons",
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new Genre()
                {
                    Id = 4,
                    Name = "Satire",
                    Description = "Fools are my theme, let satire be my song.",
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}