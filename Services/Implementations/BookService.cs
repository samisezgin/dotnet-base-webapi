using AutoMapper;
using BookLibraryApi.Data;
using BookLibraryApi.DTOs;
using BookLibraryApi.Models;
using BookLibraryApi.Services.Interfaces;

namespace BookLibraryApi.Services.Implementations;

public class BookService(BookDbContext context, IMapper mapper) : IBookService
{
    public List<BookResultDto> GetAllBooks()
    {
        var resultList = context.Books.ToList();
        return mapper.Map<List<BookResultDto>>(resultList);
    }

    public BookResultDto GetBookById(long id)
    {
        var book = context.Books.Find(id);
        if (book == null) throw new NullReferenceException("Book could not be found");
        return mapper.Map<BookResultDto>(book);
    }

    public BookResultDto CreateBook(CreateBookDto requestDto)
    {
        if (requestDto == null) throw new NullReferenceException("Book could not be found");

        if (context.Books.Any(b => b.Title == requestDto.Title)) throw new Exception("Book already exists");
        var book = mapper.Map<Book>(requestDto);
        context.Books.Add(book);
        context.SaveChanges();
        return mapper.Map<BookResultDto>(book);
    }

    public void DeleteBook(long id)
    {
        var book = context.Books.Find(id);
        if (book == null) throw new NullReferenceException("Book could not be found");
        context.Books.Remove(book);
        context.SaveChanges();
    }

    public void UpdateBook(long id, UpdateBookDto requestDto)
    {
        if (requestDto == null) throw new NullReferenceException("Book could not be found");
        var existingBook = context.Books.FirstOrDefault(elem => elem.Id == id);
        if (existingBook == null) throw new NullReferenceException("Book could not be found");
        existingBook = mapper.Map(requestDto, existingBook);
        context.Books.Update(existingBook);
        context.SaveChanges();
    }
}