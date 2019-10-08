using Fluent.Architecture.EntityFramework.SqLite;

namespace Migrations
{
    //For Migrations
    public class MyEfContextSqLite : EfContextSqLite
    {
        public MyEfContextSqLite() : base("Data Source=Migrations.db;") { }
    }
}
