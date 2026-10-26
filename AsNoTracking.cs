using Microsoft.EntityFrameworkCore;



public static class RunAsNoTracking
{
    public static void Run()
    {
        using var db = new AppDbContext();

        var users = db.Users.AsNoTracking().ToList();

        users[0].Name = "changed";
        db.SaveChanges();
    }

}


