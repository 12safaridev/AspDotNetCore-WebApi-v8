using Learn_DotNetCore_WebApi_v8.Data.Models;
using Learn_DotNetCore_WebApi_v8.Data.Services;
using Learn_DotNetCore_WebApi_v8.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace Learn_DotNetCore_WebApi_v8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;
        public BooksController(BooksService bookService) 
        {
            _booksService = bookService;
        }

        [HttpPost("add-book-with-authors")]
        public IActionResult CreateBook([FromBody] BookVM book)
        {
           var bookId = _booksService.AddBookWithAuthors(book);
            return Ok("Book Created");
            
            //https://localhost:7071/api/Books?bookId=13
            //return CreatedAtAction(nameof(GetBookById), new { t = "get-all-books/" +  bookId.ToString() }, null);
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var books = _booksService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("get-all-books/{id}")]
        // [HttpGet]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updatedBook = _booksService.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }


    }
}
