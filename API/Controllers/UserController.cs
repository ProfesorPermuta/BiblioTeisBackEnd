using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly LibraryDbContext _context;

    public UsersController(LibraryDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetUser(int id)
    {
        var user = await _context.Users
            .Include(u => u.BookLendings!)
            .ThenInclude(bl => bl.Book)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            return NotFound();

        return UserDTO.User2DTO(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(UserForm userForm)
    {
        User user = UserForm.Map2User(userForm);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, UserForm userForm)
    {
        User user = UserForm.Map2User(userForm);

        if (id != user.Id)
            return BadRequest();
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return NotFound();
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> Login(LoginForm login)
    {
        var user = await _context.Users.FirstOrDefaultAsync(
            u => u.Email == login.Email & u.PasswordHash == login.Password
        );

        if (user == null)
            return NotFound();
        return Ok(UserDTO.User2DTO(user));
    }
}
