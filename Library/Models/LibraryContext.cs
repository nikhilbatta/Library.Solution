using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Library.Models
{
    public class LibraryContext : IdentityDbContext<LibraryManager>
    {
        public DbSet<Patron> Patrons {get;set;}
        public DbSet<Copies> Copies {get;set;}
        public DbSet<Checkout> Checkouts {get;set;}
        public DbSet<Book> Books {get;set;}
        public DbSet<Author> Authors {get;set;}
        public DbSet<AuthorBooks> AuthorBooks {get;set;}
        public LibraryContext(DbContextOptions options) : base(options) { }
    }
}