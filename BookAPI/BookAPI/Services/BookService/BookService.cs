namespace BookAPI.Services.BookService
{
    public class BookService : IBook
    {
        private static List<Book> books = new List<Book> {
                new Book { Id = 1, Title = "12 Rules for Life", Author="Jordan Peterson", Description="12 principles to bring order in your life"},
                new Book { Id = 2, Title = "The Book of 5 Rings", Author="Mimato Musashi", Description="Samauri wisdon for life"}
        };

        public List<Book> CreateBook(Book newBook)
        {
            books.Add(newBook);
            return books;
        }

        public List<Book>? DeleteBook(int id)
        {
            var book = books.Find(x => x.Id == id);
            if (book is null)
                return null;
            books.Remove(book);

            return books;
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book? GetSingleBook(int id)
        {
            var book = books.Find(x => x.Id == id);
            if (book is null)
                return null;
            return book;
        }

        public List<Book>? UpdateBook(int id, Book updateBook)
        {
            var book = books.Find(x => x.Id == id);
            if (book is null)
                return null;

            book.Title = updateBook.Title;
            book.Author = updateBook.Author;
            book.Description = updateBook.Description;

            return books;
        }
    }
}
