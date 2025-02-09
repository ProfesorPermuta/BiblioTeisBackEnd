public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime DateJoined { get; set; } = DateTime.UtcNow;

    public string ProfilePicture { get; set; } = string.Empty;

    // Navigation Property
    public List<BookLending>? BookLendings { get; set; }
}
