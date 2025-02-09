public class UserForm
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime DateJoined { get; set; } = DateTime.UtcNow;

    public string ProfilePicture { get; set; } = string.Empty;

    public static User Map2User(UserForm uf)
    {
        User u =
            new()
            {
                Id = uf.Id,
                Name = uf.Name,
                Email = uf.Email,
                PasswordHash = uf.PasswordHash,
                DateJoined = uf.DateJoined,
                ProfilePicture = uf.ProfilePicture
            };

        return u;
    }
}
