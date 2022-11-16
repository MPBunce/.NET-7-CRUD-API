using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Services.BookService
{
    public interface IBook
    {

        Task<List<Book>> GetAllBooks();
        Task<Book?> GetSingleBook(int id);
        Task<List<Book>> CreateBook(Book newBook);
        Task<List<Book>?> UpdateBook(int id, Book updateBook);
        Task<List<Book>?> DeleteBook(int id);
    }
}
