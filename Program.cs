
using Microsoft.EntityFrameworkCore;

await using var db = new AppDbContext();

// Create the database and tables if they don't exist.
await db.Database.EnsureCreatedAsync();

// Insert sample data only when the database is empty.
if (!await db.Users.AnyAsync())
{
    db.Users.AddRange(
        new User
        {
            Name = "Nimal",
            Email = "nimal@gmail.com",
            Orders =
            {
                new Order { Total = 5000m },
                new Order { Total = 2500m }
            }
        },
        new User
        {
            Name = "Amara",
            Email = "amara@yahoo.com",
            Orders =
            {
                new Order { Total = 3000m }
            }
        },
        new User
        {
            Name = "Kamal",
            Email = "kamal@gmail.com"
        }
    );

    await db.SaveChangesAsync();
}

RunAsNoTracking.Run();

// Retrieve users.
var users = await db.Users.ToListAsync();

foreach (var user in users)
{
    Console.WriteLine($"{user.Id}: {user.Name} - {user.Email}");
}


