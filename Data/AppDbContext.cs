using Learn_DotNetCore_WebApi_v8.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Learn_DotNetCore_WebApi_v8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.AuthorId);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Books_Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Configure the database provider and connection string.
        //    // UseSqlServer method configures the DbContext to use SQL Server as the database provider.
        //    // The provided connection string specifies the server, database name, and credentials.
        //    // Replace "Server=YourServerName;Database=YourDatabaseName;User Id=YourUsername;Password=YourPassword;"
        //    // with your actual SQL Server details.
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-DEV\\SQLEXPRESS;Database=RestaurantsDb;User Id=sa;Password=dbserver; TrustServerCertificate=True");
        //}
    }    
}
