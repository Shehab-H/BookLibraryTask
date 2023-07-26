using BookStoreTask.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStoreTask.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopies> BookCopies { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>(books =>
            {
                books.ToTable("Books");
                books.HasKey(b => b.ISBN);
                books.HasOne(b => b.BookCopies)
                .WithOne().HasForeignKey<BookCopies>(bc => bc.BookISBN);

                books.HasData(
                    new { ISBN = "9780060915544", Title = "Meditations", ImageName = "meditations.jpg" },
                    new { ISBN = "9780061120084", Title = "Daughter Of Fortune", ImageName = "daughter-of-fortune.jpg" },
                    new { ISBN = "9780062561029", Title = "The Brothers karamazov", ImageName = "the-brothers-karmazov.jpg" },
                    new { ISBN = "9780062315007", Title = "The Book Of The Five Rings", ImageName = "the-book-of-the-five-rings.jpg" },
                    new { ISBN = "9780062220509", Title = "Jane Eyre", ImageName = "jane-eyre.jpg" },
                    new { ISBN = "9780060935467", Title = "One Hundred Years of Solitude", ImageName = "one-hunderd-years.jpg" },
                    new { ISBN = "9780061120060", Title = "The Adventures of Tom Sawyer", ImageName = "tom-sawyer.jpg" },
                    new { ISBN = "9780141187761", Title = "The Odyssey", ImageName = "the-odyssey.jpg" },
                    new { ISBN = "9780316066525", Title = "The Divine Comedy", ImageName = "the-divine-comedy.jpg" }
                );
            });

            builder.Entity<BookCopies>(bookCopies =>
            {
                bookCopies.HasData(
                        new BookCopies("9780060915544", 5),
                        new BookCopies("9780061120084", 4),
                        new BookCopies("9780062561029", 4),
                        new BookCopies("9780062315007", 4),
                        new BookCopies("9780062220509", 4),
                        new BookCopies("9780060935467", 4),
                        new BookCopies("9780061120060", 4),
                        new BookCopies("9780141187761", 4),
                        new BookCopies("9780316066525", 4));
                bookCopies.ToTable("Books");
                bookCopies.HasKey(bc => bc.BookISBN);
            });
        }

    }
}