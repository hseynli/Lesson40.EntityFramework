using _09.ExecuteUpdate;
using Microsoft.EntityFrameworkCore;

using (ApplicationContext db = new ApplicationContext())
{
    db.Users.ExecuteUpdate(s => s.SetProperty(u => u.Age, u => u.Age + 1));
}

/*
 UPDATE [u]
    SET [u].[Age] = [b].[Age] + 1
 FROM [Users] AS [u]
 */

using (ApplicationContext db = new ApplicationContext())
{
    // Ancaq adları Tom olan istifadəçilərin yaşını 1 artırırıq
    db.Users.Where(u => u.Name == "Tom")
        .ExecuteUpdate(s => s.SetProperty(u => u.Age, u => u.Age + 1));
}

/*
  UPDATE [u]
     SET [u].[Age] = [u].[Age] + 1
  WHERE [u].[Name] = N'Tom'
 */

using (ApplicationContext db = new ApplicationContext())
{
    // Ancaq adları Tom olan istifadəçiləri silirik
    db.Users.Where(u => u.Name == "Tom").ExecuteDelete();
}

Console.WriteLine("\nDone!");