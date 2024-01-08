using _08.ModelLevelQueryFilters;
using _08.ModelLevelQueryFilters.Models;
using Microsoft.EntityFrameworkCore;

using (ApplicationContext db = new ApplicationContext())
{
    // Recreate database
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    Role adminRole = new Role { Name = "admin" };
    Role userRole = new Role { Name = "user" };
    User user1 = new User { Name = "Tom", Age = 17, Role = userRole };
    User user2 = new User { Name = "Bob", Age = 18, Role = userRole };
    User user3 = new User { Name = "Alice", Age = 19, Role = adminRole };
    User user4 = new User { Name = "Sam", Age = 20, Role = adminRole };

    db.Roles.AddRange(userRole, adminRole);
    db.Users.AddRange(user1, user2, user3, user4);
    db.SaveChanges();
}

using (ApplicationContext db = new ApplicationContext() { RoleId = 2 })
{
    var users = db.Users.Include(u => u.Role).ToList();
    foreach (User user in users)
        Console.WriteLine($"Name: {user.Name}  Age: {user.Age}  Role: {user.Role?.Name}");
}

using (ApplicationContext db = new ApplicationContext() { RoleId = 2 })
{
    int minAge = db.Users.Min(x => x.Age);
    Console.WriteLine(minAge);  // 19 -> beacuse of the filter
}

// IgnoreQueryFilters
using (ApplicationContext db = new ApplicationContext() { RoleId = 2 })
{
    int minAge = db.Users.IgnoreQueryFilters().Min(x => x.Age);
    Console.WriteLine(minAge);  // 17
}

Console.WriteLine("\nDone!");