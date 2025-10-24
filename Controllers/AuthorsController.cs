using Learn_DotNetCore_WebApi_v8.Data.Models;
using Learn_DotNetCore_WebApi_v8.Data.Services;
using Learn_DotNetCore_WebApi_v8.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn_DotNetCore_WebApi_v8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsService authorService;
        public AuthorsController(AuthorsService service)
        {
                authorService = service;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            authorService.AddAuthor(author);
            return Ok();
        }
    }
}
