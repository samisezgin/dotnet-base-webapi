using BookLibraryApi.DTOs;
using BookLibraryApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService bookService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<BookResultDto>> GetBooks()
    {
        return bookService.GetAllBooks();
    }

    [HttpGet("{id:long}")]
    public ActionResult<BookResultDto> GetBook(long id)
    {
        var book = bookService.GetBookById(id);
        return Ok(book);
    }

    [HttpPost]
    public ActionResult<BookResultDto> CreateBook(CreateBookDto requestDto)
    {
        var bookResult = bookService.CreateBook(requestDto);
        return CreatedAtAction(nameof(GetBook), new { id = bookResult.Id }, bookResult);
    }

    [HttpPut("{id:long}")]
    public IActionResult UpdateBook(long id, UpdateBookDto requestDto)
    {
        bookService.UpdateBook(id, requestDto);

        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public IActionResult DeleteBook(long id)
    {
        bookService.DeleteBook(id);
        return NoContent();
    }
}