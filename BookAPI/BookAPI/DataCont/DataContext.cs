global using Microsoft.EntityFrameworkCore;

namespace BookAPI.DataCont
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {
       
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-4AROGVD\\TEW_SQLEXPRESS;Database=CRUD-Book-DB;User Id=MBUNCE;Password=bunk;");
        }

        public DbSet<Book> Books { get; set; }

    }
}
