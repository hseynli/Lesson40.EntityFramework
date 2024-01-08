using _05.StoredProcedures.Models;
using _05.StoredProcedures;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using AppDbContext db = new AppDbContext();
IEnumerable<Student> students = FindStudentsFromSql(db, "Farid");

foreach (Student student in students)
{
    Console.WriteLine($"{student.Name} {student.Mark}");
}

static List<Student> FindStudentsFromSql(AppDbContext context, string searchFor)
{
    //Doesn't have parameter
    //return context.Students.FromSql($"FindStudents {searchFor}").ToList();
    //Have parameter
    SqlParameter parameter = new SqlParameter("@searchFor", searchFor);
    //return context.Students.FromSqlRaw("FindStudents @searchFor", parameter).ToList();
    //FromSqlInterpolated 
    //Automatically parameterizes the query, preventing SQL injection, and uses the values of the interpolated expressions as parameters.
    return context.Students.FromSqlInterpolated($"FindStudents {searchFor}").ToList();
}

Console.WriteLine("\nDone!");