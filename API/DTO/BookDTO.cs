public class BookDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public bool IsAvailable { get; set; } = true;
    public string BookPicture { get; set; } = string.Empty;

    // Navigation Property
    public List<BookLendingDTO>? BookLendings { get; set; }

    public static BookDTO Book2DTO(Book u)
    {
        BookDTO bd =
            new()
            {
                Id = u.Id,
                Title = u.Title,
                Author = u.Author,
                ISBN = u.ISBN,
                PublishedDate = u.PublishedDate,
                IsAvailable = u.IsAvailable,
                BookPicture = u.BookPicture,
                BookLendings = new List<BookLendingDTO>()
            };

        if (u.BookLendings != null)
        {
            foreach (BookLending bl in u.BookLendings)
            {
                bd.BookLendings.Add(BookLendingDTO.BookLending2DTONoChild(bl));
            }
        }

        return bd;
    }

    public static BookDTO Book2DTONoChild(Book u)
    {
        BookDTO bd =
            new()
            {
                Id = u.Id,
                Title = u.Title,
                Author = u.Author,
                ISBN = u.ISBN,
                PublishedDate = u.PublishedDate,
                IsAvailable = u.IsAvailable,
                BookPicture = u.BookPicture,
                BookLendings = null
            };

        return bd;
    }
}
