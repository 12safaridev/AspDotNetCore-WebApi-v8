using Learn_DotNetCore_WebApi_v8.Data.Models;
using Learn_DotNetCore_WebApi_v8.Data.ViewModels;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Learn_DotNetCore_WebApi_v8.Data.Services
{
    public class BooksService
    {
        private readonly AppDbContext appDbContext;
        public BooksService(AppDbContext dbContext) 
        {
            appDbContext = dbContext;
        }

        public int AddBookWithAuthors(BookVM book)
        {
            var newBook = new Book
            {
                Title = book.Title,
                Description = book.Description,
               // Author = book.Author,  This is not required as we have authorId's against BOOK
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                IsRead = book.IsRead ,
                DateRead = book.IsRead? book.DateRead.Value : null,               
                Rate = book.IsRead? book.Rate.Value:null,
                DateAdded = DateTime.UtcNow,
                PublisherId  = book.PublisherId
            };

            appDbContext.Books.Add(newBook);
            appDbContext.SaveChanges();

            var newBookId = newBook.Id;

            foreach (var id in book.AuthorIds)
            {
                var book_author = new Book_Author
                {
                    BookId = newBookId,
                    AuthorId = id 
                };

                appDbContext.Books_Authors.Add(book_author);
                appDbContext.SaveChanges();
            }

            return newBookId;
        }

        public List<Book> GetAllBooks() => appDbContext.Books.ToList();

        public Book GetBookById(int bookId) => appDbContext.Books.FirstOrDefault(n => n.Id == bookId);

        public Book UpdateBookById(int bookId , BookVM book) 
        {
            var _book = appDbContext.Books.FirstOrDefault(b => b.Id == bookId);
            if (_book !=null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
               // _book.Author = book.Author;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;

                appDbContext.SaveChanges();
            }

            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var book =  appDbContext.Books.FirstOrDefault(n => n.Id == bookId);
            if (book !=null)
            {
                appDbContext.Books.Remove(book);
                appDbContext.SaveChanges();
            }
        }

    }
}
