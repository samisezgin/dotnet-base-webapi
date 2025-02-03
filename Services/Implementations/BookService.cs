using AutoMapper;
using BookLibraryApi.Data;
using BookLibraryApi.Models;
using BookLibraryApi.Services.Interfaces;

namespace BookLibraryApi.Services.Implementations;

public class BookService(BookDbContext context, IMapper mapper) : IBookService
{
    public List<Book> GetAllBooks()
    {
        return context.Books.ToList();
    }

    public Book GetBookById(long id)
    {
        var book = context.Books.Find(id);
        if (book == null) throw new NullReferenceException("Book could not be found");

        return book;
    }

    public Book CreateBook(Book book)
    {
        if (book == null) throw new NullReferenceException("Book could not be found");

        if (context.Books.Any(b => b.Title == book.Title)) throw new Exception("Book already exists");
        context.Books.Add(book);
        context.SaveChanges();
        return book;
    }

    public Book UpdateBook(long id, Book book)
    {
        if (book == null) throw new NullReferenceException("Book could not be found");
        var existingBook = context.Books.FirstOrDefault(elem => elem.Id == id);
        if (existingBook == null) throw new NullReferenceException("Book could not be found");
        existingBook = mapper.Map(book, existingBook);
        context.Books.Update(existingBook);
        context.SaveChanges();
        return existingBook;
    }

    public void DeleteBook(long id)
    {
        var book = context.Books.Find(id);
        if (book == null) throw new NullReferenceException("Book could not be found");
        context.Books.Remove(book);
        context.SaveChanges();
    }
}