using Microsoft.EntityFrameworkCore;

namespace LibraryApp
{
   public partial class LibraryContext : DbContext
    {

        public static LibraryContext Instance { get; } = new LibraryContext();

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<LoanDetail> LoanDetails { get; set; }
        public DbSet<AuthorBook> AuthorsBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Library;");
            }
        }

    }
}
