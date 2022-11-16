using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Services.BookService
{
    public interface IBook
    {

        List<Book> GetAllBooks();
        Book? GetSingleBook(int id);
        List<Book>? CreateBook(Book newBook);
        List<Book>? UpdateBook(int id, Book updateBook);
        List<Book>? DeleteBook(int id);
    }
}
