using BookLibraryApi.Models;

namespace BookLibraryApi.Services.Interfaces;

public interface IBookService
{
    public List<Book> GetAllBooks();
    public Book GetBookById(long id);
    public Book CreateBook(Book book);
    public Book UpdateBook(long id, Book book);
    public void DeleteBook(long id);
}