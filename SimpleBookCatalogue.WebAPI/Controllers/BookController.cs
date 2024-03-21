using Microsoft.AspNetCore.Mvc;
using SimpleBookCatalogue.Application.Interfaces;
using SimpleBookCatalogue.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleBookCatalogue.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookRepository bookRepository;

    public BookController(IBookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    // GET: api/<BookController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var data = await bookRepository.GetAllAsync();
        return Ok(data);
    }

    // GET api/<BookController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await bookRepository.GetByIdAsync(id);
        return Ok(data);
    }

    // POST api/<BookController>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Book bookDto)
    {
        var result = await bookRepository.AddAsync(bookDto);
        return Ok(result);
    }

    // PUT api/<BookController>/5
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Book bookDto)
    {
        var result = await bookRepository.UpdateAsync(bookDto);
        return Ok(result);
    }

    // DELETE api/<BookController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await bookRepository.DeleteByIdAsync(id);
        return Ok(result);
    }
}
