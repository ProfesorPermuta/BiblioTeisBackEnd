public static class DbInitializer
{
    public static void Seed(LibraryDbContext context)
    {
        if (!context.Books.Any() && !context.Users.Any()) // Prevent duplicate seeding
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "Alice Johnson",
                    Email = "alice@example.com",
                    PasswordHash = "hashedpassword1"
                },
                new User
                {
                    Id = 2,
                    Name = "Bob Smith",
                    Email = "bob@example.com",
                    PasswordHash = "hashedpassword2"
                },
                new User
                {
                    Id = 3,
                    Name = "Charlie Brown",
                    Email = "charlie@example.com",
                    PasswordHash = "hashedpassword3"
                },
                new User
                {
                    Id = 4,
                    Name = "Diana Prince",
                    Email = "diana@example.com",
                    PasswordHash = "hashedpassword4"
                }
            };

            var books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "C# in Depth",
                    Author = "Jon Skeet",
                    ISBN = "1234567890",
                    PublishedDate = new DateTime(2019, 1, 1),
                    IsAvailable = true
                },
                new Book
                {
                    Id = 2,
                    Title = "ASP.NET Core in Action",
                    Author = "Andrew Lock",
                    ISBN = "0987654321",
                    PublishedDate = new DateTime(2021, 6, 15),
                    IsAvailable = true
                },
                new Book
                {
                    Id = 3,
                    Title = "The Pragmatic Programmer",
                    Author = "Andrew Hunt",
                    ISBN = "9780201616224",
                    PublishedDate = new DateTime(1999, 10, 30),
                    IsAvailable = true
                },
                new Book
                {
                    Id = 4,
                    Title = "Design Patterns",
                    Author = "Erich Gamma",
                    ISBN = "9780201633610",
                    PublishedDate = new DateTime(1994, 11, 1),
                    IsAvailable = true
                },
                new Book
                {
                    Id = 5,
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    ISBN = "9780132350884",
                    PublishedDate = new DateTime(2008, 8, 1),
                    IsAvailable = true
                },
                new Book
                {
                    Id = 6,
                    Title = "Refactoring",
                    Author = "Martin Fowler",
                    ISBN = "9780201485677",
                    PublishedDate = new DateTime(1999, 7, 8),
                    IsAvailable = true
                },
                new Book
                {
                    Id = 7,
                    Title = "Domain-Driven Design",
                    Author = "Eric Evans",
                    ISBN = "9780321125217",
                    PublishedDate = new DateTime(2003, 8, 30),
                    IsAvailable = true
                },
                new Book
                {
                    Id = 8,
                    Title = "You Don't Know JS",
                    Author = "Kyle Simpson",
                    ISBN = "9781491904244",
                    PublishedDate = new DateTime(2015, 1, 1),
                    IsAvailable = true
                },
                new Book
                {
                    Id = 9,
                    Title = "Eloquent JavaScript",
                    Author = "Marijn Haverbeke",
                    ISBN = "9781593279509",
                    PublishedDate = new DateTime(2018, 12, 4),
                    IsAvailable = true
                },
                new Book
                {
                    Id = 10,
                    Title = "JavaScript: The Good Parts",
                    Author = "Douglas Crockford",
                    ISBN = "9780596517748",
                    PublishedDate = new DateTime(2008, 5, 15),
                    IsAvailable = true
                },
                new Book
                {
                    Id = 11,
                    Title = "The Clean Coder",
                    Author = "Robert C. Martin",
                    ISBN = "9780137081073",
                    PublishedDate = new DateTime(2011, 5, 23),
                    IsAvailable = true
                },
                new Book
                {
                    Id = 12,
                    Title = "Working Effectively with Legacy Code",
                    Author = "Michael Feathers",
                    ISBN = "9780131177055",
                    PublishedDate = new DateTime(2004, 9, 30),
                    IsAvailable = true
                }
            };

            context.Users.AddRange(users);
            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}
