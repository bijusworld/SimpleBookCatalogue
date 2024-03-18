using Microsoft.EntityFrameworkCore;
using SimpleBookCatalogue.Domain.Entities;

namespace SimpleBookCatalogue.Infrastructure.Context;
public class SimpleBookCatalogueDBContext : DbContext
{
    public SimpleBookCatalogueDBContext(DbContextOptions<SimpleBookCatalogueDBContext> options) : base(options)
    {
        
    }

    public DbSet<Book> Books { get; set; }

    ////Incase of using fluentAPI
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Book>().Property(e => e.Title).IsRequired().HasMaxLength(100);
    //    modelBuilder.Entity<Book>().Property(e => e.Author).IsRequired().HasMaxLength(100);
    //}
}
