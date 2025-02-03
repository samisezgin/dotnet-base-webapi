using BookLibraryApi.Models;
using BookLibraryApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService bookService) : ControllerBase
{
    [HttpGet]
    public IEnumerable<Book> GetBooks()
    {
        return bookService.GetAllBooks();
    }

    [HttpGet("{id:long}")]
    public ActionResult<Book> GetBook(long id)
    {
        var book = bookService.GetBookById(id);
        return Ok(book);
    }

    [HttpPost]
    public ActionResult<Book> CreateBook(Book book)
    {
        var bookEntity = bookService.CreateBook(book);
        return CreatedAtAction(nameof(GetBook), new { id = bookEntity.Id }, bookEntity);
    }

    [HttpPut("{id:long}")]
    public IActionResult UpdateBook(long id, Book book)
    {
        bookService.UpdateBook(id, book);

        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public IActionResult DeleteBook(long id)
    {
        bookService.DeleteBook(id);
        return NoContent();
    }
}