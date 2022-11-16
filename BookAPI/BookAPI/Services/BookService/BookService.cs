namespace BookAPI.Services.BookService
{
    public class BookService : IBook
    {
        private static List<Book> books = new List<Book> {
                new Book { Id = 1, Title = "12 Rules for Life", Author="Jordan Peterson", Description="12 principles to bring order in your life"},
                new Book { Id = 2, Title = "The Book of 5 Rings", Author="Mimato Musashi", Description="Samauri wisdon for life"}
        };

        private readonly DataContext _context;

        public BookService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> CreateBook(Book newBook)
        {

            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();
            return await _context.Books.ToListAsync();

        }

        public async Task<List<Book>> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book is null)
                return null;


            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return await _context.Books.ToListAsync();
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<Book>? GetSingleBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book is null)
                return null;
            return book;
        }

        public async Task<List<Book>>? UpdateBook(int id, Book updateBook)
        {
            var book = await _context.Books.FindAsync(id);
            if (book is null)
                return null;

            book.Title = updateBook.Title;
            book.Author = updateBook.Author;
            book.Description = updateBook.Description;

            await _context.SaveChangesAsync();

            return await _context.Books.ToListAsync();
        }
    }
}
