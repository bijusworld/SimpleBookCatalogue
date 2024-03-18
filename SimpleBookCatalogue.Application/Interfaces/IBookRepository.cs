using SimpleBookCatalogue.Domain.Entities;

namespace SimpleBookCatalogue.Application.Interfaces;
public interface IBookRepository
{
    Task AddAsync(Book book);

    Task <List<Book>> GetAllAsync();

    Task<Book?> GetByIdAsync(int id);
    
    Task UpdateAsync(Book book);

    Task DeleteByIdAsync(int id);
}
