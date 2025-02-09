public class BookForm
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public bool IsAvailable { get; set; } = true;
    public string BookPicture { get; set; } = string.Empty;

    public static Book Map2Book(BookForm bf)
    {
        Book b =
            new()
            {
                Id = bf.Id,
                Title = bf.Title,
                Author = bf.Author,
                ISBN = bf.ISBN,
                PublishedDate = bf.PublishedDate,
                IsAvailable = bf.IsAvailable,
                BookPicture = bf.BookPicture
            };
        return b;
    }
}
