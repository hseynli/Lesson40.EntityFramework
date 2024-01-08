using _05.StoredProcedures;
using _05.StoredProcedures.Models;
using Microsoft.EntityFrameworkCore;

using AppDbContext db = new AppDbContext();
GetSelectedColumns(db);

static void GetSelectedColumns(AppDbContext db)
{
    var query = db.Database.SqlQuery<StudentWithOnlyName>($"select Name, Mark from Students");

    foreach (var student in query)
    {
        Console.WriteLine(student.Name + " " + student.Mark);
    }
}


Console.WriteLine("\nDone!");