using LibraryDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentBookCopy> studentBookCopies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<BookCopy>().ToTable("BookCopies");
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<StudentBookCopy>().ToTable("BorrowRecords");

            modelBuilder.Entity<BookCopy>()
                .HasOne(bc => bc.book)
                .WithMany(b => b.BookCopies)
                .HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<StudentBookCopy>()
                .HasOne(br => br.bookCopy)
                .WithMany(bc => bc.studentBookCopies)
                .HasForeignKey(br => br.CopyId);

            modelBuilder.Entity<StudentBookCopy>()
                .HasOne(br => br.student)
                .WithMany(s => s.BookCopies)
                .HasForeignKey(br => br.StudentId);

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Clean Code" },
                new Book { Id = 2, Title = "Algorithms" }
            );

            // Seed BookCopies
            modelBuilder.Entity<BookCopy>().HasData(
                new BookCopy { Id = 1, status = "Good", BookId = 1 },
                new BookCopy { Id = 2, status = "Good", BookId = 2 },
                new BookCopy { Id = 3, status = "Good", BookId = 1 }
            );

            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Ali", phoneNumber = 0122224400, Email = "ali@enozom.com" },
                new Student { Id = 2, Name = "Mohammed", phoneNumber = 0111155000, Email = "mohammed@enozom.com" },
                new Student { Id = 3, Name = "Ahmed", phoneNumber = 155553311, Email = "ahmed@enozom.com" }
            );

            // Seed StudentBookCopies
              modelBuilder.Entity<StudentBookCopy>().HasData(
                new StudentBookCopy
                {
                    Id = 1,
                    CopyId = 3,
                    StudentId = 1,
                    borrowedDate = DateTime.Now.AddDays(-5),
                    expectedReturnDate = DateTime.Now.AddDays(10)
                }
            );
        }
    }
}

