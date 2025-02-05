namespace BookLibraryApi.DTOs;

public class CreateBookDto
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Isbn { get; set; }
    public DateTime PublishedDate { get; set; }
}