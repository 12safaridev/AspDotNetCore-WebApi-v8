using Learn_DotNetCore_WebApi_v8.Data.Models;
using Learn_DotNetCore_WebApi_v8.Data.ViewModels;

namespace Learn_DotNetCore_WebApi_v8.Data.Services
{
    public class AuthorsService
    {
        private readonly AppDbContext appDbContext;
        public AuthorsService(AppDbContext dbContext)
        {
            appDbContext = dbContext;
        }

        public void AddAuthor(AuthorVM author)
        {
            var newAuthor = new Author
            {
                FullName = author.FullName
            };

            appDbContext.Authors.Add(newAuthor);
            appDbContext.SaveChanges();
        }

    }
}
