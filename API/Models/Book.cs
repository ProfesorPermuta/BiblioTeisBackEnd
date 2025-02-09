public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public bool IsAvailable { get; set; } = true;
    public string BookPicture { get; set; } = string.Empty;

    // Navigation Property
    public List<BookLending>? BookLendings { get; set; }
}
