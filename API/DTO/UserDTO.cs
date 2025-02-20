public class UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime DateJoined { get; set; } = DateTime.UtcNow;

    public string ProfilePicture { get; set; } = string.Empty;

    // Navigation Property
    public List<BookLendingDTO>? BookLendings { get; set; }

    public static UserDTO User2DTO(User u)
    {
        UserDTO ud =
            new()
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                DateJoined = u.DateJoined,
                ProfilePicture = u.ProfilePicture,
                BookLendings = new List<BookLendingDTO>()
            };

        if (u.BookLendings != null)
        {
            foreach (BookLending bl in u.BookLendings)
            {
                ud.BookLendings.Add(BookLendingDTO.BookLending2DTO(bl));
            }
        }

        return ud;
    }

    public static UserDTO User2DTONoChild(User u)
    {
        UserDTO ud =
            new()
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                DateJoined = u.DateJoined,
                ProfilePicture = u.ProfilePicture,
                BookLendings = null
            };

        return ud;
    }
}
