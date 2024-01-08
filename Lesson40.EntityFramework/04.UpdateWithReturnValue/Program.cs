using _05.StoredProcedures;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using AppDbContext db = new AppDbContext();
int result = UpdateStudentMarkWithReturnValueSqlRaw(db, 1, 10);
Console.WriteLine($"Average mark is {result}");

// With output parameter
static int UpdateStudentMarkWithReturnValueSqlRaw(AppDbContext context, int id, int mark)
{
    var avgMarkParameter = new SqlParameter()
    {
        ParameterName = "AvgMark",
        SqlDbType = System.Data.SqlDbType.Int,
        Direction = System.Data.ParameterDirection.Output
    };
    context.Database.ExecuteSqlRaw("dbo.UpdateStudentMarkWithReturnValue @Id, @Mark, @AvgMark OUTPUT",
        new SqlParameter("@Id", id),
        new SqlParameter("@Mark", mark),
        avgMarkParameter);
    return (int)avgMarkParameter.Value;
}

Console.WriteLine("\nDone!");