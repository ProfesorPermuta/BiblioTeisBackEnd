using Microsoft.EntityFrameworkCore;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BookLending> BookLendings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookLending>()
            .HasOne(bl => bl.Book)
            .WithMany(b => b.BookLendings)
            .HasForeignKey(bl => bl.BookId);

        modelBuilder.Entity<BookLending>()
            .HasOne(bl => bl.User)
            .WithMany(u => u.BookLendings)
            .HasForeignKey(bl => bl.UserId);
    }
}
