using BookStore.BL.Interfaces;
using BookStore.Models.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("GetAll")]
        public List<Author> GetAll()
        {
            return _authorService.GetAll();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id..");
            }

            var response = _authorService.GetById(id);

            if (response == null)
            {
                return NotFound(id);
            }

            return Ok(_authorService.GetById(id));
        }
    }
}
