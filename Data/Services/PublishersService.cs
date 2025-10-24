using Learn_DotNetCore_WebApi_v8.Data.Models;
using Learn_DotNetCore_WebApi_v8.Data.ViewModels;

namespace Learn_DotNetCore_WebApi_v8.Data.Services
{
    public class PublishersService
    {
        private readonly AppDbContext appDbContext;
        public PublishersService(AppDbContext dbContext)
        {
            appDbContext = dbContext;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var newPublisher= new Publisher
            {
                Name = publisher.Name
            };

            appDbContext.Publishers.Add(newPublisher);
            appDbContext.SaveChanges();
        }

    }
}
