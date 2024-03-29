﻿using SimpleBookCatalogue.Application.DTOs;
using SimpleBookCatalogue.Domain.Entities;

namespace SimpleBookCatalogue.Application.Interfaces;
public interface IBookRepository
{
    Task<ServiceResponse> AddAsync(Book book);

    Task<ServiceResponse> UpdateAsync(Book book);

    Task<ServiceResponse> DeleteByIdAsync(int id);

    Task<List<Book>> GetAllAsync();

    Task<Book?> GetByIdAsync(int id);
}
