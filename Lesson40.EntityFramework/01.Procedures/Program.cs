using _05.StoredProcedures;
using _05.StoredProcedures.Models;
using Microsoft.EntityFrameworkCore;

using AppDbContext db = new AppDbContext();
IEnumerable<Student> foundStudents = FindStudentsFromSql(db, "Farid");

foreach (Student student in foundStudents)
{
    Console.WriteLine($"{student.Name} {student.Mark}");
}

static List<Student> FindStudentsFromSql(AppDbContext context, string searchFor)
{
    return context.Students.FromSql($"FindStudents {searchFor}").ToList();
}

Console.WriteLine("\nDone!");