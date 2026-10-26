
using Microsoft.EntityFrameworkCore;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";

    public List<Order> Orders { get; set; } = new();
}

public class Order
{
    public int Id { get; set; }
    public decimal Total { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;
}

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnConfiguring(
        DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=practice.db");
    }
}
