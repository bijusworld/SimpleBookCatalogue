using System.Net.Http.Json;
using SimpleBookCatalogue.Application.DTOs;
using SimpleBookCatalogue.Domain.Entities;

namespace SimpleBookCatalogue.Application.Services;
public class BookService : IBookService
{
    private readonly HttpClient httpClient;

    public BookService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ServiceResponse> AddAsync(Book book)
    {
        var data = await httpClient.PostAsJsonAsync("api/book", book);
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response!;
    }

    public async Task<ServiceResponse> DeleteByIdAsync(int id)
    {
        var data = await httpClient.DeleteAsync($"api/book/{id}");
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response!;
    }

    public async Task<List<Book>?> GetAllAsync() => 
        await httpClient.GetFromJsonAsync<List<Book>>("api/book")!;

    public async Task<Book?> GetByIdAsync(int id) => 
        await httpClient.GetFromJsonAsync<Book>($"api/book/{id}")!;

    public async Task<ServiceResponse> UpdateAsync(Book book)
    {
        var data = await httpClient.PutAsJsonAsync("api/book", book);
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response!;
    }
}
