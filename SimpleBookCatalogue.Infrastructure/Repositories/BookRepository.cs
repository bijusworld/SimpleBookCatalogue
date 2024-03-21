using Microsoft.EntityFrameworkCore;
using SimpleBookCatalogue.Application.DTOs;
using SimpleBookCatalogue.Application.Interfaces;
using SimpleBookCatalogue.Domain.Entities;
using SimpleBookCatalogue.Infrastructure.Context;

namespace SimpleBookCatalogue.Infrastructure.Repositories;
public class BookRepository : IBookRepository
{
    private readonly SimpleBookCatalogueDBContext context;
    private async Task SaveChangesAsync() => await context.SaveChangesAsync();

    public BookRepository(IDbContextFactory<SimpleBookCatalogueDBContext> factory)
    {
        context = factory.CreateDbContext();
    }

    public async Task<ServiceResponse> AddAsync(Book book)
    {
        context.Books.Add(book);
        await SaveChangesAsync();
        return new ServiceResponse(true, "Book added.");
    }
    
    public async Task<ServiceResponse> UpdateAsync(Book book)
    {
        context.Entry(book).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return new ServiceResponse(true, "Book edited.");
    }

    public async Task<ServiceResponse> DeleteByIdAsync(int id)
    {
        var book = await GetByIdAsync(id);
        if (book is null)
        {
            return new ServiceResponse(false, "Book not found.");
        }

        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return new ServiceResponse(true, "Book deleted.");
    }

    public async Task<List<Book>> GetAllAsync()
    {
        var books = await context.Books.ToListAsync();
        return books;
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        var book = await context.Books.FirstOrDefaultAsync(e => e.Id == id);
        return book;
    }


}
