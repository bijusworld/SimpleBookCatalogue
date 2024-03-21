using SimpleBookCatalogue.Application.DTOs;
using SimpleBookCatalogue.Domain.Entities;

namespace SimpleBookCatalogue.Application.Services;
public interface IBookService
{
    Task<ServiceResponse> AddAsync(Book book);

    Task<ServiceResponse> UpdateAsync(Book book);

    Task<ServiceResponse> DeleteByIdAsync(int id);

    Task<List<Book>?> GetAllAsync();

    Task<Book?> GetByIdAsync(int id);
}
