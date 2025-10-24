using Learn_DotNetCore_WebApi_v8.Data.Models;
using Learn_DotNetCore_WebApi_v8.Data.Services;
using Learn_DotNetCore_WebApi_v8.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn_DotNetCore_WebApi_v8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublishersService publishersService;
        public PublishersController(PublishersService service)
        {
            publishersService = service;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            publishersService.AddPublisher(publisher);
            return Ok();
        }
    }
}
