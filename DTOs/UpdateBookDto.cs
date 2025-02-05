namespace BookLibraryApi.DTOs;

public class UpdateBookDto
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Isbn { get; set; }
    public DateTime? PublishedDate { get; set; }
}