using BookAPI.Services.BookService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BookAPI.Controllers
{
    [DisableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBook _bookService;

        public BookController(IBook bookService)
        {   
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            return await _bookService.GetAllBooks();
        }

        //[HttpGet]
        //[Route("{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Book>>>? GetSingleBook(int id)
        {
            var result = await _bookService.GetSingleBook(id);
            if (result == null)
                return NotFound("We didnt find this sorry");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> CreateBook(Book newBook)
        {
            var result = await _bookService.CreateBook(newBook);
            if (result == null)
                return NotFound("We didnt find this sorry");
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Book>>> UpdateBook(int id, Book updateBook)
        {
            var result = await _bookService.UpdateBook(id, updateBook);
            if (result is null)
                return NotFound("Could not find hero with corresponding ID");
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBook(id);
            if (result is null)
                return NotFound("Could not find hero with corresponding ID");
            return Ok(result);
        }
    }
}
