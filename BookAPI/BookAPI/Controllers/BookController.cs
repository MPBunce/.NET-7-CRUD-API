using BookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private static List<Book> books = new List<Book> {
                new Book { Id = 1, Title = "12 Rules for Life", Author="Jordan Peterson", Description="12 principles to bring order in your life"},
                new Book { Id = 2, Title = "The Book of 5 Rings", Author="Mimato Musashi", Description="Samauri wisdon for life"}
        };


        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            return Ok(books);
        }

        //[HttpGet]
        //[Route("{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Book>>> GetSingleBook(int id)
        {
            var book = books.Find(x => x.Id == id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> CreateBook(Book newBook)
        {
            books.Add(newBook);
            return Ok(books);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Book>>> UpdateBook(Book updateBook)
        {
            var book = books.Find(x => x.Id == updateBook.Id);
            if (book is null)
                return NotFound("Cant find it");

            book.Title = updateBook.Title;
            book.Author = updateBook.Author;
            book.Description = updateBook.Description;

            return Ok(books);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> DeleteBook(int id)
        {
            var book = books.Find(x => x.Id == id);
            if (book is null)
                   return NotFound("Not Found");
            books.Remove(book);
            
            return Ok(book);
        }
    }
}
