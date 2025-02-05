using BookLibraryApi.DTOs;

namespace BookLibraryApi.Services.Interfaces;

public interface IBookService
{
    public List<BookResultDto> GetAllBooks();
    public BookResultDto GetBookById(long id);
    public BookResultDto CreateBook(CreateBookDto book);
    public void UpdateBook(long id, UpdateBookDto book);
    public void DeleteBook(long id);
}