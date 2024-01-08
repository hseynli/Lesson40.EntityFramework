using _05.StoredProcedures;
using Microsoft.EntityFrameworkCore;

using AppDbContext db = new AppDbContext();
int result = UpdateStudentMarkSql(db, 1, 2);
Console.WriteLine($"{result} rows affected");

static int UpdateStudentMarkSql(AppDbContext context, int id, int mark)
{
    return context.Database.ExecuteSql($"UpdateStudentMark @Id={id}, @Mark={mark}");
}

Console.WriteLine("\nDone!");