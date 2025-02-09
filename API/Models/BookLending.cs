public class BookLending
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
    public DateTime LendDate { get; set; } = DateTime.UtcNow;
    public DateTime? ReturnDate { get; set; }

    // Navigation Properties
    public Book? Book { get; set; }
    public User? User { get; set; }
}
