public class BookLendingDTO
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
    public DateTime LendDate { get; set; } = DateTime.UtcNow;
    public DateTime? ReturnDate { get; set; }

    // Navigation Properties
    public BookDTO? Book { get; set; }
    public UserDTO? User { get; set; }

    internal static BookLendingDTO BookLending2DTO(BookLending bl)
    {
        BookLendingDTO bld =
            new()
            {
                Id = bl.Id,
                BookId = bl.BookId,
                UserId = bl.UserId,
                LendDate = bl.LendDate,
                ReturnDate = bl.ReturnDate
            };

        if (bl.User != null)
            bld.User = UserDTO.User2DTONoChild(bl.User);
        if (bl.Book != null)
            bld.Book = BookDTO.Book2DTONoChild(bl.Book);

        return bld;
    }

    internal static BookLendingDTO BookLending2DTONoChild(BookLending bl)
    {
        BookLendingDTO bld =
            new()
            {
                Id = bl.Id,
                BookId = bl.BookId,
                UserId = bl.UserId,
                LendDate = bl.LendDate,
                ReturnDate = bl.ReturnDate,
                User = null,
                Book = null
            };

        return bld;
    }
}
