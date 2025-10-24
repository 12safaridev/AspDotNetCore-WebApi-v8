using Learn_DotNetCore_WebApi_v8.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Learn_DotNetCore_WebApi_v8.Data
{
    public class InitializeSeeder 
    {
        private readonly AppDbContext dbContext;
        public InitializeSeeder(AppDbContext appDbContext)
        {
                dbContext = appDbContext;
        }

        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (dbContext.Books.Any())
                {
                }
                else
                {
                    var books = GetBooks();
                    dbContext.AddRange(books);

                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Book> GetBooks()
        {
            var books = new List<Book>()
            {
                new Book()
                {
                     Title = "ist Book Title",
                     Description = "ist Book Description",
                     // Author = "ist Book Author",
                       IsRead= false,
                       Genre = "Comedy",
                      CoverUrl = "Converted Url",
                      DateAdded = DateTime.UtcNow
                },
                 new Book()
                {
                     Title = "2nd Book Title",
                     Description = "2nd Book Description",
                     // Author = "2nd Book Author",
                       IsRead= false,
                       Genre = "Horrow",
                      CoverUrl = "2nd book Converted Url1",
                      DateAdded = DateTime.UtcNow.AddDays(1)
                },

            };

            return books;
        }
    }
}
