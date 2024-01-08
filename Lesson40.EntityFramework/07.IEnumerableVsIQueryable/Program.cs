using _07.IEnumerableVsIQueryable;

using (ApplicationContext db = new ApplicationContext())
{
    IEnumerable<User> userIEnum = db.Users;
    var users = userIEnum.Where(p => p.Id < 10).ToList();

    foreach (var user in users) Console.WriteLine(user.Name);
}

/*
 SELECT "u"."Id", "u"."Name"
 FROM "Users" AS "u"
 */

using (ApplicationContext db = new ApplicationContext())
{
    IQueryable<User> userIQuer = db.Users;
    var users = userIQuer.Where(p => p.Id < 10).ToList();

    foreach (var user in users) Console.WriteLine(user.Name);
}

/*
 SELECT "u"."Id", "u"."Name"
 FROM "Users" AS "u"
 WHERE "u"."Id" < 10
 */

using ApplicationContext database = new ApplicationContext();
IQueryable<User> userIQue = database.Users;
userIQue = userIQue.Where(p => p.Id < 10);
userIQue = userIQue.Where(p => p.Name == "Tom");
var users_ = userIQue.ToList();

/*
 SELECT "u"."Id", "u"."Name"
 FROM "Users" AS "u"
 WHERE ("u"."Id" < 10) AND ("u"."Name" = 'Tom')
 */

Console.WriteLine("\nDone!");