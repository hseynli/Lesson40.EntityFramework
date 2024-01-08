using _05.StoredProcedures;
using _06.StoredProcedureNet8.Models;
using Microsoft.EntityFrameworkCore;

using AppDbContext db = new AppDbContext();
GetSelectedColumnsWithJoin(db);

static void GetSelectedColumnsWithJoin(AppDbContext db)
{
    var query = db.Database.SqlQuery<StudentWithJoin>($"select s.Id, Title, Name, Mark, CourseId from Courses c join Students s on c.Id = s.CourseId");

    foreach (var student in query)
    {
        Console.WriteLine(student.Name + " " + student.Mark);
    }
}

Console.WriteLine("\nDone!");