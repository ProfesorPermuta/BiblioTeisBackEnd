using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class BookLendingController : ControllerBase
{
    private readonly LibraryDbContext _context;

    public BookLendingController(LibraryDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookLendingDTO>>> GetLendings()
    {
        return await _context.BookLendings
            .Include(bl => bl.Book)
            .Include(bl => bl.User)
            .Select(bl => BookLendingDTO.BookLending2DTO(bl))
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookLending>> GetLending(int id)
    {
        var lending = await _context.BookLendings.FindAsync(id);
        if (lending == null)
            return NotFound();
        return lending;
    }

    [HttpPost]
    public async Task<ActionResult<BookLending>> LendBook(int userId, int bookId)
    {
        var book = await _context.Books.FindAsync(bookId);
        if (book == null || !book.IsAvailable)
            return BadRequest("Book not available.");

        var user = await _context.Users.FindAsync(userId);
        if (user == null)
            return BadRequest("User not available.");

        book.IsAvailable = false;
        BookLending bl = new()
        {
            BookId = bookId,
            UserId = userId,

            LendDate = DateTime.Today
        };
        _context.BookLendings.Add(bl);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLending), new { id = bl.Id }, bl);
    }

    [HttpPut("{id}/return")]
    public async Task<IActionResult> ReturnBook(int id)
    {
        var lending = await _context.BookLendings.FindAsync(id);
        if (lending == null || lending.ReturnDate != null)
            return BadRequest("Invalid lending record.");

        lending.ReturnDate = DateTime.UtcNow;
        var book = await _context.Books.FindAsync(lending.BookId);
        if (book != null)
            book.IsAvailable = true;

        await _context.SaveChangesAsync();
        return NoContent();
    }
}
